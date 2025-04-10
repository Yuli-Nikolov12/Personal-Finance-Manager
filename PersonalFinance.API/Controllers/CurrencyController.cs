using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.API.Repository;
using PersonalFinance.Business.DTOs;
using PersonalFinance.Business.Entities;
using PersonalFinance.DataAccess.Contexts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalFinance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private Repository<Currency> _currency;

        public CurrencyController(PersonalFinanceContext context, IMapper mapper)
        {
            _currency = new Repository<Currency>(context);
            _mapper = mapper;
        }
        // GET: api/<CurrencyController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyDTO>>> GetAllCurrencies()
        {
            var currency = await _currency.GetAllAsync();

            var currencyDTOs = _mapper.Map<List<CurrencyDTO>>(currency);

            return Ok(currencyDTOs);
        }

        // GET api/<CurrencyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrencyDTO>> GetOneCurrency(int id)
        {
            var currency = await _currency.GetByIdAsync(id);

            if (currency == null)
            {
                return NotFound();
            }

            var currencyDTO = _mapper.Map<CurrencyDTO>(currency);

            return Ok(currencyDTO);
        }

        // POST api/<CurrencyController>
        [HttpPost]
        public async Task<IActionResult> CreateCurrency(CurrencyDTO currencyDTO)
        {
            var currency = _mapper.Map<Currency>(currencyDTO);
            if (ModelState.IsValid)
            {
                await _currency.AddAsync(currency);
                return CreatedAtAction("Transaction Created", currencyDTO);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<CurrencyController>/5
        [HttpPut("{id}")]
        public async Task UpdateCurrency(int id, CurrencyDTO currencyDTO)
        {
            var currency = _mapper.Map<Currency>(currencyDTO);

            if (ModelState.IsValid)
            {
                await _currency.UpdateAsync(currency);
                Ok(currencyDTO);
            }
        }

        // DELETE api/<CurrencyController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _currency.DeleteAsync(id);
        }
    }
}
