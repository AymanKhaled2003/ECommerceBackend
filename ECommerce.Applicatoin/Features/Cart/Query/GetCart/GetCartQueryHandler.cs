using Common.Application.Abstractions.Messaging;
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

        public GetCartQueryHandler(IGenericRepository<Carts> cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<ResponseModel<IList<CartDto>>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            // الحصول على الـ userId من الـ request
            var userId = "";

            if (string.IsNullOrEmpty(userId))
            {
                return ResponseModel.Failure<IList<CartDto>>("User ID is required");
            }

            var cart = (_cartRepository.GetEntityWithSpec(new GetCartByUserIdSpec(userId)));

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
                    Quantity = ci.Quantity,
                    Price = ci.Price,
                    TotalPrice = ci.Price * ci.Quantity
                }).ToList()
            };

            return ResponseModel.Success<IList<CartDto>>(new List<CartDto> { cartDto });
        }
    }


}
