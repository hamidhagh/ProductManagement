using ErrorOr;
using MapsterMapper;
using MediatR;
using ProductManagement.Application.Common.Interfaces;
using ProductManagement.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly Mapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, Mapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.From(request).AdaptToType<Product>();

            await _productRepository.UpdateProductAsync(product);

        }
    }
}
