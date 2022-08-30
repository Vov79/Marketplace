using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
       
        private DataContext _context;

        public PhoneController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Phone>>> Get()
        {
            return Ok(await _context.Phones.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Phone>> Get(int id)
        {
            var phone = await _context.Phones.FindAsync(id);
            if (phone == null)
                return BadRequest("Phone not found.");
            return Ok(phone);
        }

        [HttpPost]
        public async Task<ActionResult<List<Phone>>> AddPhone(Phone phone)
        {
            _context.Phones.Add(phone);
            await _context.SaveChangesAsync();
            return Ok(await _context.Phones.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Phone>>> UpdatePhone(Phone request)
        {
            var phone = await _context.Phones.FindAsync(request.Id);
            if (phone == null)
                return BadRequest("Phone not found.");
            phone.Title = request.Title;
            phone.Price = request.Price;

            await _context.SaveChangesAsync();

            return Ok(await _context.Phones.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Phone>>> DeletePhone(int id)
        {
            var phone = await _context.Phones.FindAsync(id);
            if (phone == null)
                return BadRequest("Phone not found.");
            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();
            return Ok(await _context.Phones.ToListAsync());
        }


    }
}
