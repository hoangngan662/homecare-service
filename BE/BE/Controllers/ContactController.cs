using BE.Dtos;
using BE.Models;
using BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }

        // API để tạo mới Contact
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            try
            {
                if (contact == null)
                {
                    return BadRequest(new { code = 1, message = "Liên hệ rỗng." });
                }
                Contact con = new Contact
                {
                    PatientName = contact.PatientName,
                    PhoneNumber = contact.PhoneNumber,
                    Service = contact.Service,
                    Message = contact.Message,
                    InquiryDate = DateTime.Now,
                    Status = ContactStatus.Pending
                };

                await _contactService.CreateContactAsync(con);
                return Ok(con);
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
            
        }

        // API để cập nhật Contact
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] Contact updatedContact)
        {
            try
            {
                if (updatedContact == null || id != updatedContact.Id)
                {
                    return BadRequest("Contact data is invalid.");
                }

                var contact = await _contactService.GetContactByIdAsync(id);
                if (contact == null)
                {
                    return NotFound();
                }

                // Cập nhật các thuộc tính
                contact.PatientName = updatedContact.PatientName;
                contact.PhoneNumber = updatedContact.PhoneNumber;
                contact.Service = updatedContact.Service;
                contact.Message = updatedContact.Message;
                contact.Status = updatedContact.Status;
                contact.Note = updatedContact.Note;

                await _contactService.UpdateContactAsync(contact);
                return NoContent(); // Trả về 204 No Content
            }
            catch (Exception ex)
            {
                return BadRequest(new { code = 1, message = "Đã xảy ra lỗi, hãy thử lại." });
            }
        }

        // API để lấy Contact theo Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact); // Trả về 200 OK và thông tin contact
        }

        // API để lấy tất cả các Contact (nếu cần)
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<Contact>>> GetAllContacts(int pageNumber, int pageSize)
        {
            return Ok(await _contactService.GetAllContactsAsync(pageNumber, pageSize));
        }
    }
}
