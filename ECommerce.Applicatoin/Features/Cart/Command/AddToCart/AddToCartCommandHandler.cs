using Common.Application.Abstractions.Messaging;
using ECommerce.Applicatoin.Features.Cart.Command.AddToCart;
using ECommerce.Applicatoin.Specifications.Cart;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Shared;

public class AddToCartCommandHandler : ICommandHandler<AddToCartCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddToCartCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        var cart =  _unitOfWork.Repository<Carts>().GetEntityWithSpec(new GetCartByUserIdSpec(request.UserId));

        if (cart == null)
        {
            cart = new Carts
            {
                UserId = request.UserId,
                CreatedOnUtc = DateTime.UtcNow
            };
            await _unitOfWork.Repository<Carts>().AddAsync(cart);
        }

        var product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.ProductId);
        if (product == null)
            return ResponseModel.Failure("Product not found");

        var cartItem =  _unitOfWork.Repository<CartItem>().GetEntityWithSpec(new GetCartItemByProductIdAndCartIdSpecification(cart.Id, request.ProductId));

        if (cartItem == null)
        {
            cartItem = new CartItem
            {
                CartId = cart.Id,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Price = product.Price
            };
            await _unitOfWork.Repository<CartItem>().AddAsync(cartItem);
        }
        else
        {
            cartItem.Quantity += request.Quantity;
            _unitOfWork.Repository<CartItem>().Update(cartItem);
        }

        cart.RecalculateTotals();

        await _unitOfWork.CompleteAsync(cancellationToken);

        return ResponseModel.Success("Product added to cart successfully");
    }
}
