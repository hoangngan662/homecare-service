using BE.Dtos;
using BE.Models;

namespace BE.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<Contact> GetContactByIdAsync(int id);
        Task<PaginatedResult<Contact>> GetAllContactsAsync(int pageNumber, int pageSize);
        Task CreateContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
    }
}
