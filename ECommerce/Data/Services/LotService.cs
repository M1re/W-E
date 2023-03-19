using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Services
{
    public class LotService : ILotsService
    {
        private readonly AppDbContext _context;
        public LotService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Lot lot)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Lot>> GetAll()
        {
            return await _context.Lots.ToListAsync();
        }

        public Task<Lot> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Lot> Update(Lot lot, int id)
        {
            throw new NotImplementedException();
        }
    }
}
