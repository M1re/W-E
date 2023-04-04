using ECommerce.Data.Base;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Services
{
    public class LotService : EntityBaseRepository<Lot>, ILotsService
    {
        public LotService(AppDbContext context) : base(context) { }
    }
}
