using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Business.DTOs;
using PersonalFinance.Business.Entities;
using PersonalFinance.DataAccess.Contexts;
using System.Threading.Tasks;


namespace PersonalFinance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly PersonalFinanceContext _context;
        private readonly IMapper _mapper;
        public TransactionsController(PersonalFinanceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<TransactionsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetAllTransactions()
        {
            var transactions = await _context.Transactions
                .Include(t => t.Category)
                .Include(t => t.Currency)
                .ToListAsync();

            var transactionDTOs = _mapper.Map<List<TransactionDTO>>(transactions);

            return Ok(transactionDTOs);
        }

        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDTO>> GetOneTransaction(int id)
        {
            var transaction = await _context.Transactions
                .Include(t => t.Category)
                .Include(t => t.Currency)
                .FirstOrDefaultAsync(t => t.TransactionId == id);

            if (transaction == null) 
            {
                return NotFound();
            }

            var transactionDTO = _mapper.Map<TransactionDTO>(transaction);
            
            return Ok(transactionDTO);
        }

        // POST api/<TransactionsController>
        [HttpPost]
        public async Task<IActionResult> CreateTransaction(TransactionDTO transactionDTO)
        {
            var transaction = _mapper.Map<Transaction>(transactionDTO);
            if (ModelState.IsValid) 
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Transaction Created",transactionDTO);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<TransactionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<TransactionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
