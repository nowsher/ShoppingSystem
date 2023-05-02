using ShoppingCart.Data;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public class EfOrderItemRepository : IOrderItemRepository
    {
        private readonly DataContext _context;

        public EfOrderItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            try
            {
                _context.OrderItems.Add(orderItem);
                await _context.SaveChangesAsync();
                return orderItem;
            }
            catch (DbUpdateException ex)
            {
                var message = ex.InnerException?.Message ?? ex.Message;
                // log the error message
                Console.WriteLine($"Error while saving changes to the database: {message}");
                throw;
            }
            
        }

         public async Task<List<OrderItem>> GetOrderItemByVendorItAsync(string vendorId)
        {
            return await _context.OrderItems
                 .Where(o => o.Product.VendorId == vendorId)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Category, OrderItem>>> GetOrderItemByVendorItAsyncGrouByCategory(string vendorId)
        {
            return await _context.OrderItems
                .Where(oi => oi.Product.VendorId == vendorId)
                // .Join(_context.Products,
                //     oi => oi.ProductId,
                //     p => p.Id,
                //     (oi, p) => new { OrderItem = oi, Product = p })
                .GroupBy(op => op.Product.Category)
                .ToListAsync();
        }
    }
}