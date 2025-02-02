using BE.Dtos;
using BE.Repositories.Interfaces;

namespace BE.Services
{
    public class ShiftService
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftService(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        public async Task<IEnumerable<ShiftDto>> GetAllShiftAsync()
        {
            return await _shiftRepository.GetAllShiftAsync();
        }
    }
}
