using BE.Data;
using BE.Dtos;
using BE.Models;
using BE.Repositories.Interfaces;
using Google;
using Microsoft.EntityFrameworkCore;

namespace BE.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;
        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<PaginatedResult<Contact>> GetAllContactsAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.Contacts.CountAsync();
            var res = await _context.Contacts
                .OrderByDescending(c => c.InquiryDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PaginatedResult<Contact>
            {
                Items = res,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task CreateContactAsync(Contact contact)
        {
            var total = await _context.Contacts.CountAsync();
            contact.Id = total + 1;
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }
    }
}
