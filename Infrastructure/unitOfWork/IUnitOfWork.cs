using Infrastructure.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.unitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; set; }

        Task<bool> SaveChangesAsync();
    }
}
