using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Common;
using ProductManagement.Application.Common.Interfaces;
using ProductManagement.Application.DTOs.Products;
using ProductManagement.Application.Products.Commands.CreateProduct;
using ProductManagement.Application.Products.Queries.GetProduct;
using ProductManagement.Application.Products.Queries.ListProducts;
using ProductManagement.Domain.Products;

namespace ProductManagement.API.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ISender _mediator;
        private readonly ICurrentUserProvider _currentUserProvider;

        public ProductsController(ISender mediator, ICurrentUserProvider currentUserProvider)
        {
            _mediator = mediator;
            _currentUserProvider = currentUserProvider;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct(ProductToCreateDto request)
        {
            var user = _currentUserProvider.GetCurrentUser();

            var command = new CreateProductCommand(request.Name,request.ProduceDate, request.ManufacturePhone, request.ManufactureEmail, request.IsAvailable, user.Id);

            var createProductResult = await _mediator.Send(command);

            return Ok(createProductResult);
            //return createProductResult.Match(
            //    product => CreatedAtAction(
            //        nameof(GetProduct),
            //        new { ProductId = product.Id },
            //        new ProductResponse(product.Id, product.Name)),
            //    Problem);
        }

        //[HttpDelete("{productId:guid}")]
        //public async Task<IActionResult> DeleteProduct(Guid productId)
        //{
        //    var command = new DeleteProductCommand(productId);

        //    var deleteProductResult = await _mediator.Send(command);

        //    return deleteProductResult.Match(
        //        _ => NoContent(),
        //        Problem);
        //}

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> ListProducts(Guid? id = null)
        {
            var command = new ListProductsQuery(id);

            var listProductsResult = await _mediator.Send(command);

            return Ok(listProductsResult);
            //return listProductsResult.Match(
            //    products => Ok(products.ConvertAll(product => new ProductResponse(product.Id, product.Name))),
            //    Problem);
        }

        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var command = new GetProductQuery(productId);

            var getProductResult = await _mediator.Send(command);

            return Ok(getProductResult);
            //return getProductResult.Match(
            //    product => Ok(new ProductResponse(product.Id, product.Name)),
            //    Problem);
        }
    }
}
