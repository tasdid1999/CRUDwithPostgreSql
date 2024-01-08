using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ProductRepo
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();

        public Task Create(Product product);

        public Task<Product?> GetById(int id);

       
    }
}
