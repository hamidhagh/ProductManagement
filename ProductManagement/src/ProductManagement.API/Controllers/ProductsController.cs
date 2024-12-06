using Azure.Core;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Common;
using ProductManagement.Application.Common.Interfaces;
using ProductManagement.Application.DTOs.Products;
using ProductManagement.Application.Products.Commands.CreateProduct;
using ProductManagement.Application.Products.Commands.DeleteProduct;
using ProductManagement.Application.Products.Commands.UpdateProduct;
using ProductManagement.Application.Products.Queries.GetProduct;
using ProductManagement.Application.Products.Queries.GetProductNoTracking;
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

            var command = new CreateProductCommand(request.Name, request.ProduceDate, request.ManufacturePhone, request.ManufactureEmail, request.IsAvailable, user.Id);

            var createProductResult = await _mediator.Send(command);

            return Ok(createProductResult);
            //return createProductResult.Match(
            //    product => CreatedAtAction(
            //        nameof(GetProduct),
            //        new { ProductId = product.Id },
            //        new ProductResponse(product.Id, product.Name)),
            //    Problem);
        }



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

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(ProductToUpdateDto request)
        {
            var user = _currentUserProvider.GetCurrentUser();

            var getCommand = new GetProductNoTrackingQuery(request.Id);

            var getProductResult = await _mediator.Send(getCommand);

            if (getProductResult.UserId != user.Id)
            {
                return Unauthorized();
            }

            var command = new UpdateProductCommand(request.Id, request.Name,
                request.ProduceDate, request.ManufacturePhone, request.ManufactureEmail,
                request.IsAvailable, user.Id);

            await _mediator.Send(command);

            return Ok();
        }


        [HttpDelete("{productId:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var user = _currentUserProvider.GetCurrentUser();

            var getCommand = new GetProductQuery(productId);

            var getProductResult = await _mediator.Send(getCommand);

            if (getProductResult.UserId != user.Id)
            {
                return Unauthorized();
            }
            var command = new DeleteProductCommand(getProductResult.Id, getProductResult.Name,
                getProductResult.ProduceDate, getProductResult.ManufacturePhone,
                getProductResult.ManufactureEmail, getProductResult.IsAvailable, user.Id);

            await _mediator.Send(command);

            return Ok();
        }
    }
}
