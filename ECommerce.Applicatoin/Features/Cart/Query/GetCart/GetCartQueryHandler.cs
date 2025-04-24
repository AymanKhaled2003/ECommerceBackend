using Common.Application.Abstractions.Messaging;
using ECommerce.Application.Features.Cart.Query.GetCart;
using ECommerce.Applicatoin.SharedDTOs.CartItems;
using ECommerce.Applicatoin.SharedDTOs.Carts;
using ECommerce.Applicatoin.Specifications.Cart;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Applicatoin.Features.Cart.Query.GetCart
{
    public class GetCartQueryHandler : IQueryHandler<GetCartQuery, IList<CartDto>>
    {
        private readonly IGenericRepository<Carts> _cartRepository;
        private readonly ITokenExtractor _tokenExtractor;

        public GetCartQueryHandler(IGenericRepository<Carts> cartRepository, ITokenExtractor tokenExtractor)
        {
            _cartRepository = cartRepository;
            _tokenExtractor = tokenExtractor;
        }
        public async Task<ResponseModel<IList<CartDto>>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var userId = _tokenExtractor.GetUserId();

            if (string.IsNullOrEmpty(userId.ToString()))
            {
                return ResponseModel.Failure<IList<CartDto>>("User ID is required");
            }

            var cart = (_cartRepository.GetEntityWithSpec(new GetCartByUserIdSpec(userId.ToString())));

            if (cart == null)
            {
                return ResponseModel.Failure<IList<CartDto>>("Cart not found for the user");
            }

            var cartDto = new CartDto
            {
                UserId = cart.UserId,
                TotalQuantity = cart.TotalQuantity,
                TotalPrice = cart.TotalPrice,
                CartItems = cart.CartItems.Select(ci => new CartItemDto
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.Product?.Name, 
                    Quantity = ci.Quantity,
                    Price = ci.Price,
                    TotalPrice = ci.Price * ci.Quantity
                }).ToList()
            };

            return ResponseModel.Success<IList<CartDto>>(new List<CartDto> { cartDto });
        }
    }


}
