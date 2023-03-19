using ECommerce.Models;

namespace ECommerce.Data.Services
{
    public interface ILotsService
    {
        Task<IEnumerable<Lot>> GetAll();
        Task<Lot> GetById(int id);
        void Add(Lot lot);
        Task<Lot> Update(Lot lot, int id);
        void Delete(int id);

    }
}
