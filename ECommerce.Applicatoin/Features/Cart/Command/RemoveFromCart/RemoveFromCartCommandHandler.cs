using Common.Application.Abstractions.Messaging;
using ECommerce.Applicatoin.Specifications.Cart;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Applicatoin.Features.Cart.Command.RemoveFromCart
{
    public class RemoveFromCartCommandHandler : ICommandHandler<RemoveFromCartCommand>
    {
        private readonly IGenericRepository<Carts> _cartRepository;
        private readonly IGenericRepository<CartItem> _cartItemRepository;

        public RemoveFromCartCommandHandler(IGenericRepository<Carts> cartRepository, IGenericRepository<CartItem> cartItemRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
        }

        public async Task<ResponseModel> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
        {
            var cart =  _cartRepository.GetEntityWithSpec(new GetCartByUserIdSpec(request.UserId));
            if (cart == null)
                return ResponseModel.Failure("Cart not found");

            var cartItem =  _cartItemRepository.GetEntityWithSpec(new GetCartItemByProductIdAndCartIdSpecification(cart.Id,request.ProductId));
            if (cartItem == null)
                return ResponseModel.Failure("Product not found in cart");

            _cartItemRepository.Delete(cartItem);

            cart.RecalculateTotals();

            await _cartRepository.SaveChangesAsync(cancellationToken);

            return ResponseModel.Success("Product removed from cart successfully");
        }
    }

}
