using Common.Application.Abstractions.Messaging;
using ECommerce.Application.Features.Cart.Command.AddToCart;
using ECommerce.Applicatoin.Specifications.Cart;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Shared;

public class AddToCartCommandHandler : ICommandHandler<AddToCartCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Carts> _cartRepo;
    private readonly ITokenExtractor _tokenExtractor;

    public AddToCartCommandHandler(IUnitOfWork unitOfWork, IGenericRepository<Carts> cartRepo, ITokenExtractor tokenExtractor)
    {
        _unitOfWork = unitOfWork;
        _cartRepo = cartRepo;
        _tokenExtractor = tokenExtractor;
    }

    public async Task<ResponseModel> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        var userId = _tokenExtractor.GetUserId();
        var cart =  _unitOfWork.Repository<Carts>().GetEntityWithSpec(new GetCartByUserIdSpec(userId.ToString()));

        if (cart == null)
        {
            cart = new Carts();
            cart.CreateCartsToUser(request.UserId);
            await _cartRepo.AddAsync(cart);
            await _cartRepo.SaveChangesAsync();
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
