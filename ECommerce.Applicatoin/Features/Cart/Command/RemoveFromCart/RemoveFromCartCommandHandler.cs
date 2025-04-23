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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenExtractor _tokenExtractor;
        public RemoveFromCartCommandHandler(
            ITokenExtractor tokenExtractor, IUnitOfWork unitOfWork)
        {

            _tokenExtractor = tokenExtractor;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
        {
            var userId = _tokenExtractor.GetUserId();

            var cart = _unitOfWork.Repository<Carts>().GetEntityWithSpec(new GetCartByUserIdSpec(userId.ToString()));
            if (cart == null)
                return ResponseModel.Failure("Cart not found");

            var cartItem = _unitOfWork.Repository<CartItem>().GetEntityWithSpec(new GetCartItemByProductIdAndCartIdSpecification(cart.Id, request.ProductId));
            if (cartItem == null)
                return ResponseModel.Failure("Product not found in cart");

            cart.CartItems.Remove(cartItem);
            _unitOfWork.Repository<CartItem>().Delete(cartItem);
            cart.RecalculateTotals();
            _unitOfWork.Repository<Carts>().Update(cart);

            await _unitOfWork.CompleteAsync(cancellationToken);

            return ResponseModel.Success("Product removed from cart successfully");
        }
    }
}


