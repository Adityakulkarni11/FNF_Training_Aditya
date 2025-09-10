using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class contactsController : ControllerBase
    {
        public readonly Data.AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public contactsController(Data.AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var data = await _context.Contacts.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var data = await _context.Contacts.FindAsync(id);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(Models.Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return Ok(contact);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, Models.Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
            return Ok(contact);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return Ok("Contact Deleted Successfully");
        }
    }
}
