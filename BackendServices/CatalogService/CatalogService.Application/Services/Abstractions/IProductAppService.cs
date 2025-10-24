using CatalogService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Services.Abstractions
{
    public interface IProductAppService
    {
        IEnumerable<ProductDTO> GetAll();
        ProductDTO GetById(int id);
        IEnumerable<ProductDTO> GetByIds(int[] ids);
        void Add(ProductDTO product);
        void Update(ProductDTO prouduct);
        void Delete(int id);

    }
}
