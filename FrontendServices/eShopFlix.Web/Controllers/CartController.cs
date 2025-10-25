using eShopFlix.Web.HttpClients;
using eShopFlix.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace eShopFlix.Web.Controllers
{
    public class CartController : BaseController
    {
        CartServiceClient _cartServiceClient;
        public CartController(CartServiceClient cartServiceClient)
        {
            _cartServiceClient = cartServiceClient;
        }

        public IActionResult Index()
        {
            if (CurrentUser != null)
            {
                CartModel cartModel = _cartServiceClient.GetUserCartAsync(CurrentUser.UserId).Result;
                return View(cartModel);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = "/" });
            }
        }

        [Route("Cart/AddToCart/{ItemId}/{UnitPrice}/{Quantity}")]
        public async Task<IActionResult> AddToCart(int ItemId, decimal UnitPrice, int Quantity)
        {
            CartItemModel cartItemModel = new CartItemModel
            {
                ItemId = ItemId,
                Quantity = Quantity,
                UnitPrice = UnitPrice
            };

            CartModel cartModel = await _cartServiceClient.AddToCartAsync(cartItemModel, CurrentUser.UserId);
            if (cartModel != null)
            {
                return Json(new { status = "success", count = cartModel.CartItems.Count });
            }
            return Json(new { status = "failed", count = 0 });
        }

        [Route("Cart/UpdateQuantity/{Id}/{Quantity}/{CartId}")]
        public IActionResult UpdateQuantity(int Id, int Quantity, long CartId)
        {
            int count = _cartServiceClient.UpdateQuantity(CartId, Id, Quantity).Result;
            return Json(count);
        }

        [Route("Cart/DeleteItem/{Id}/{CartId}")]
        public IActionResult DeleteItem(int Id, long CartId)
        {
            int count = _cartServiceClient.DeleteCartItemAsync(CartId, Id).Result;
            return Json(count);
        }

        public IActionResult GetCartCount()
        {
            if (CurrentUser != null)
            {
                try
                {
                    var count = _cartServiceClient.GetCartItemCount(CurrentUser.UserId).Result;
                    return Json(count);
                }
                catch (Exception)
                {
                }

            }
            return Json(0);
        }
    }
}
