using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneService_API.Data;
using PhoneService_API.Dtos;
using PhoneService_API.Models;

namespace PhoneService_API.Controllers
{
    
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepo _repository;

        public ProductsController(IProductRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ICollection<ProductReadDto>> GetProductsList()
        {
            var products = _repository.GetListProducts();
            var mappedProducts = _mapper.Map<ICollection<ProductReadDto>>(products);
            return Ok(mappedProducts);
        }

        [HttpGet("groups")]
        public ActionResult GetProductsGroupedList()
        {
            var products = _repository.GetListProducts();
            var groupedProducts = products.GroupBy(x => x.Brand, x => x.Model + " " + x.Color, (key, value) => new
            {
                Brand = key,
                Models = value
            }, StringComparer.CurrentCultureIgnoreCase);
            return Ok(groupedProducts);
        }


        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductReadDto> GetProductById(int id)
        {
            var product = _repository.GetProductById(id);
            if (product != null)
                return Ok(_mapper.Map<ProductReadDto>(product));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<ProductReadDto> CreateProduct(ProductCreateDto product)
        {
            var productModel = _mapper.Map<Product>(product);
            _repository.CreateProduct(productModel);
            _repository.SaveChanges();

            var productReadDto = _mapper.Map<ProductReadDto>(productModel);

            return CreatedAtRoute(nameof(GetProductById), new {productReadDto.Id}, productReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductUpdateDto product)
        {
            var productFromRepo = _repository.GetProductById(id);
            if (productFromRepo == null) return NotFound();

            _mapper.Map(product, productFromRepo);

            _repository.UpdateProduct(productFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var productFromRepo = _repository.GetProductById(id);
            if (productFromRepo == null) return NotFound();

            _repository.DeleteProduct(productFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}