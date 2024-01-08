
using ClientEntity.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.product
{
    public interface IProductService
    {
        public Task<List<ProductResponseDto>> GetAll();

        public Task<ProductResponseDto?> GetById(int id);

        public Task<bool> Create(ProductRequestDto product);

        public Task<bool> Update(ProductRequestDto product,int id);

        public Task<bool> Delete(int id);
    }
}
