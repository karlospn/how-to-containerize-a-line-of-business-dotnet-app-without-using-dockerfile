using System.Collections.Generic;
using System.Linq;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {

        public OrderRepository(BookStoreDbContext context) 
            : base(context) {}

        public override async Task<Order> GetById(int id)
        {
            return await Db.Orders
                .Include(b => b.Books)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<List<Order>> GetAll()
        {
            return await Db.Orders
                .Include(b => b.Books)
                .ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByBookId(int bookId)
        {
            return await Db.Orders.AsNoTracking()
                .Include(b => b.Books)
                .Where(x => x.Books.Any(y => y.Id == bookId))
                .ToListAsync();

        }
    }
}