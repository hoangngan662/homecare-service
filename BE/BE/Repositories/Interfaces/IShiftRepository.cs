using BE.Dtos;
using BE.Models;

namespace BE.Repositories.Interfaces
{
    public interface IShiftRepository
    {
        Task<IEnumerable<ShiftDto>> GetAllShiftAsync();
    }
}
