using ClientEntity.product;
using Entity;
using Infrastructure.ProductRepo;
using Infrastructure.unitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.product
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(ProductRequestDto product)
        {
            var DbProduct = new Product();

            DbProduct.Name = product.name;
            DbProduct.Price = product.price;
            DbProduct.Quantity = product.quantity;
            DbProduct.CreatedAt = DateTime.UtcNow;
            DbProduct.CreatedBy = 1;
            DbProduct.LastUpdatedAt = DateTime.UtcNow;
            DbProduct.LastUpdatedBy = 1;
            DbProduct.StatusId = 1;


           await _unitOfWork.ProductRepository.Create(DbProduct);
           
           return await _unitOfWork.SaveChangesAsync();


        }

        public async Task<bool> Delete(int id)
        {
            var ExistingProduct = await _unitOfWork.ProductRepository.GetById(id);

            if(ExistingProduct is not null)
            {
                ExistingProduct.StatusId = 0;

                return await _unitOfWork.SaveChangesAsync();
            }

            return false;

            


        }

        public async Task<List<ProductResponseDto>> GetAll()
        {
            var listOfProduct = await _unitOfWork.ProductRepository.GetAll();

            var result = new List<ProductResponseDto>();
            foreach (var product in listOfProduct)
            {
                result.Add(new ProductResponseDto(product.Id,product.Name,product.Quantity,product.Price));
            }

            return result;
        }

        public async Task<ProductResponseDto?> GetById(int id)
        {
            var product  = await _unitOfWork.ProductRepository.GetById(id);

            return product is not null ? new ProductResponseDto(product.Id , product.Name, product.Quantity, product.Price) : null;


        }

        public async Task<bool> Update(ProductRequestDto product,int id)
        {
            var ExistingProduct = await _unitOfWork.ProductRepository.GetById(id);

            if(ExistingProduct is not null)
            {
                ExistingProduct.Name = product.name;
                ExistingProduct.Quantity = product.quantity;
                ExistingProduct.Price = product.price;

                return await _unitOfWork.SaveChangesAsync();
            }

            return false;
        }
    }
}
