using BE.Dtos;
using BE.Models;
using BE.Repositories.Interfaces;

namespace BE.Services
{
    public class ContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _contactRepository.GetContactByIdAsync(id);
        }

        public async Task<PaginatedResult<Contact>> GetAllContactsAsync(int pageNumber, int pageSize)
        {
            return await _contactRepository.GetAllContactsAsync(pageNumber, pageSize);
        }

        public async Task CreateContactAsync(Contact contact)
        {
            await _contactRepository.CreateContactAsync(contact);
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            await _contactRepository.UpdateContactAsync(contact);
        }
    }
}
