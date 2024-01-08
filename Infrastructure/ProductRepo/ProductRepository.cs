using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task Create(Product product)
        {
            await _context.products.AddAsync(product);

        }

        public async Task<List<Product>> GetAll()
        {
            return await _context
                        .products
                        .Where(x => x.StatusId != 0)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            var product = await _context .products.Where(x => x.Id == id).FirstOrDefaultAsync();

            return product;
        }

      
    }
}
