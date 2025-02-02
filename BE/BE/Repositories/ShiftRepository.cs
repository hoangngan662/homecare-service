using AutoMapper;
using BE.Data;
using BE.Dtos;
using BE.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BE.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ShiftRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShiftDto>> GetAllShiftAsync()
        {
            var shift = await _context.Shifts.ToListAsync();
            var shiftDtos = _mapper.Map<IEnumerable<ShiftDto>>(shift);
            return shiftDtos;
        }
    }
}
