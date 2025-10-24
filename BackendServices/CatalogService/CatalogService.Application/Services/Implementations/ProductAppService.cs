using AutoMapper;
using CatalogService.Application.DTOs;
using CatalogService.Application.Repositories;
using CatalogService.Application.Services.Abstractions;
using CatalogService.Domain.Entities;
using Microsoft.Extensions.Configuration;


namespace CatalogService.Application.Services.Implementations
{
    public class ProductAppService : IProductAppService
    {
        readonly IProductRepository _productRepository;
        readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        readonly string _imageServer;
        public ProductAppService(IProductRepository productRepository,IMapper mapper,IConfiguration configuration)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _configuration = configuration;
            _imageServer = _configuration["ImageServer"];
        }
        public void Add(ProductDTO product)
        {
            //First approch we can assign one by one properties
            //Product entity = new Product()
            //{
            //    Name = product.Name,
            //    Description = product.Description,
            //    UnitPrice = product.UnitPrice,
            //    CategoryId = product.CategoryId
            //};

            //Secound approch we can create Mapper and used it.
            Product entity = _mapper.Map<Product>(product);
            _productRepository.Add(entity);
            _productRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
            _productRepository.SaveChanges();
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var product = _productRepository.GetAll();
            if (product !=null)
            {
                product = product.Select(p =>
                {
                    p.ImageUrl = $"{_imageServer}{p.ImageUrl}";
                    return p;
                });
                return _mapper.Map<IEnumerable<ProductDTO>>(product);
            }
            return Enumerable.Empty<ProductDTO>();
        }

        public ProductDTO GetById(int id)
        {
            var product= _productRepository.GetById(id);
            if (product !=null)
            {
                product.ImageUrl = $"{_imageServer}{product.ImageUrl}";
                return _mapper.Map<ProductDTO>(product);
            }
            return null;
        }

        public IEnumerable<ProductDTO> GetByIds(int[] ids)
        {
            var products = _productRepository.GetByIds(ids);
            if (products!=null)
            {
                products = products.Select(p =>
                {
                    p.ImageUrl = $"{_imageServer}{p.ImageUrl}";
                    return p;
                });
                return _mapper.Map<IEnumerable<ProductDTO>>(products);
            }
            return Enumerable.Empty<ProductDTO>();
        }

        public void Update(ProductDTO prouduct)
        {
            Product entity = _mapper.Map<Product>(prouduct);
            _productRepository.Update(entity);
            _productRepository.SaveChanges();
        }
    }
}
