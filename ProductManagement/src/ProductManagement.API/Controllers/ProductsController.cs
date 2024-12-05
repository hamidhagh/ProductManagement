using MapsterMapper;
using MediatR;
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
        private readonly IMapper _mapper;
        private readonly ICurrentUserProvider _currentUserProvider;

        public ProductsController(ISender mediator, IMapper mapper, ICurrentUserProvider currentUserProvider)
        {
            _mediator = mediator;
            _mapper = mapper;
            _currentUserProvider = currentUserProvider;
        }
        [HttpPost]
        public async Task<IActionResult> CreateGym(ProductToCreateDto request)
        {
            var user = _currentUserProvider.GetCurrentUser();

            var command = new CreateProductCommand(request.Name,request.ProduceDate, request.ManufacturePhone, request.ManufactureEmail, request.IsAvailable, user.Id);

            var createProductResult = await _mediator.Send(command);

            return Ok(createProductResult);
            //return createProductResult.Match(
            //    gym => CreatedAtAction(
            //        nameof(GetGym),
            //        new { subscriptionId, GymId = gym.Id },
            //        new GymResponse(gym.Id, gym.Name)),
            //    Problem);
        }

        //[HttpDelete("{gymId:guid}")]
        //public async Task<IActionResult> DeleteProduct(Guid subscriptionId, Guid gymId)
        //{
        //    var command = new DeleteProductCommand(subscriptionId, gymId);

        //    var deleteGymResult = await _mediator.Send(command);

        //    return deleteGymResult.Match(
        //        _ => NoContent(),
        //        Problem);
        //}

        [HttpGet]
        public async Task<IActionResult> ListProducts(SearchParams? searchParams)
        {
            var command = new ListProductsQuery(searchParams);

            var listProductsResult = await _mediator.Send(command);

            return Ok(listProductsResult);
            //return listProductsResult.Match(
            //    gyms => Ok(gyms.ConvertAll(gym => new GymResponse(gym.Id, gym.Name))),
            //    Problem);
        }

        [HttpGet("{productId:guid}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var command = new GetProductQuery(productId);

            var getProductResult = await _mediator.Send(command);

            return Ok(getProductResult);
            //return getGymResult.Match(
            //    gym => Ok(new GymResponse(gym.Id, gym.Name)),
            //    Problem);
        }
    }
}
