using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.API.Repository;
using PersonalFinance.Business.DTOs;
using PersonalFinance.Business.Entities;
using PersonalFinance.DataAccess.Contexts;


namespace PersonalFinance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private Repository<Transaction> _transaction;

        public TransactionsController(PersonalFinanceContext context, IMapper mapper)
        {
            _transaction = new Repository<Transaction>(context);
            _mapper = mapper;
        }

        // GET: api/<TransactionsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetAllTransactions()
        {
            var transactions = await _transaction.GetAllAsync(new QueryOptions<Transaction>() { Includes = "Category,Currency"  });

            var transactionDTOs = _mapper.Map<List<TransactionDTO>>(transactions);

            return Ok(transactionDTOs);
        }

        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDTO>> GetOneTransaction(int id)
        {
            var transaction = await _transaction.GetByIdAsync(id, new QueryOptions<Transaction>() { Includes = "Category,Currency" });

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
                await _transaction.AddAsync(transaction);
                return CreatedAtAction("Transaction Created",transactionDTO);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<TransactionsController>/5
        [HttpPut("{id}")]
        public async Task Update(int id, TransactionDTO transactionDTO)
        {
            var transaction = _mapper.Map<Transaction>(transactionDTO);
            transaction.TransactionId = id;
            if (ModelState.IsValid)
            {
                await _transaction.UpdateAsync(transaction);
                Ok(transactionDTO);
            }
        }

        // DELETE api/<TransactionsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _transaction.DeleteAsync(id);
        }
    }
}
