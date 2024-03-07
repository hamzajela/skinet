
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   
    public class ProductsController: BaseApiController
    { 
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper; 

        public ProductsController(IGenericRepository<Product>productsRepo,
        IGenericRepository<ProductBrand> productBrandRepo,
        IGenericRepository<ProductType> productTypeRepo,
        IMapper mapper) 
        {
            _productsRepo = productsRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task <ActionResult<Pagination<ProducttoReturnDto>>> GetProducts(
            [FromQuery]ProductSpecParams productParams)
        {   
            var spec = new ProductsWithTypesAndBrandsWithSpecification(productParams); 
            var countSpec= new ProductWithFilterforCountSpecifications(productParams);
            var totalItems = await _productsRepo.CountAsync(countSpec);

            var products =await _productsRepo.ListAsync(spec);
            // return products.Select(product=>new ProducttoReturnDto{
            // Id=product.Id,
            // Name=product.Name,
            // Description=product.Description,
            // PictureUrl=product.PictureUrl,
            // Price=product.Price,
            // ProductBrand=product.ProductBrand.Name,
            // ProductType=product.ProductType.Name 
            // }).ToList();  
             var data=_mapper
          .Map<IReadOnlyList<Product>, IReadOnlyList<ProducttoReturnDto>>(products);
          return Ok(new Pagination<ProducttoReturnDto>(productParams.PageIndex,productParams.PageSize,totalItems,data));
    
        }  

         [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
         

        public async Task <ActionResult<ProducttoReturnDto>> GetProduct( int id)
        {
           var spec = new ProductsWithTypesAndBrandsWithSpecification(id);



            var product= await _productsRepo.GetEntityWithSpec(spec);
        //   return new ProducttoReturnDto
        //   {
        //     Id=product.Id,
        //     Name=product.Name,
        //     Description=product.Description,
        //     PictureUrl=product.PictureUrl,
        //     Price=product.Price,
        //     ProductBrand=product.ProductBrand.Name,
        //     ProductType=product.ProductType.Name

        //   };
        if (product==null) return NotFound(new ApiResponse(404));
        return _mapper.Map<Product, ProducttoReturnDto>(product);
        } 

         [HttpGet("brands")] 
         public async Task <ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
         {
            return Ok(await _productBrandRepo.ListAllAsync());
         }

         
         [HttpGet("types")] 
         public async Task <ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
         {
            return Ok(await _productTypeRepo.ListAllAsync());
         }
    }
}