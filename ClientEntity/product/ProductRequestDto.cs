using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEntity.product
{
    public record ProductRequestDto(string name , int quantity , decimal price);
    
}
