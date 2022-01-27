using AutoMapper;
using Basket.API.Controllers;
using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Mapper;
using Basket.API.Repositories;
using Discount.Grpc.Protos;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Basket.API.UnitTests
{
    public class BasketControllerShould
    {
        //private readonly ITestOutputHelper _output;
        private readonly Mock<IBasketRepository> _mockBasketRepository;
        private readonly Mock<IDiscountGrpcService> _mockDiscountGrpcService;
        private readonly Mock<IPublishEndpoint> _mockPublishEndpoint;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<BasketController>> _mockLogger;

        private BasketController _sut;

        public BasketControllerShould()
        {
            _mockBasketRepository = new Mock<IBasketRepository>();
            _mockDiscountGrpcService = new Mock<IDiscountGrpcService>();
            _mockPublishEndpoint = new Mock<IPublishEndpoint>();

            _mockLogger = new Mock<ILogger<BasketController>>();

            var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new BasketProfile());
                });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
            this.IntialieBasketController();
        }

        private void IntialieBasketController()
        {
            this._sut = new BasketController(_mockBasketRepository.Object,
               _mockDiscountGrpcService.Object,
               _mockPublishEndpoint.Object,
               _mapper,
               _mockLogger.Object);

        }

        [Fact]
        public async Task ReturnEmptyShoppingCart()
        {
            // Arrange
            _mockBasketRepository.Setup(x => x.GetBasket("testUser")).ReturnsAsync(new ShoppingCart("testUser"));
            this.IntialieBasketController();

            // Act
            var result = await _sut.GetBasket("testUser");

            // Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<ShoppingCart>>(result);
            var okResult = response.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode.Value);
            var shoppingCart = Assert.IsType<ShoppingCart>(okResult.Value);
            Assert.Equal(0, shoppingCart.Items.Count);
        }

        [Fact]
        public async Task ReturnNonEmptyShoppingCart()
        {
            // Arrange          
            var userName = "testUser";
            var validShoppingCart = new ShoppingCart();
            validShoppingCart.Items = new List<ShoppingCartItem>(){
                new ShoppingCartItem
                {
                    Quantity = 1,
                    Color = "Red",
                    Price = 950.00M,
                    ProductId = "602d2149e773f2a3990b47f5",
                    ProductName = "IPhone X"
                }};


            _mockBasketRepository.Setup(x => x.GetBasket(userName)).ReturnsAsync(validShoppingCart);
            this.IntialieBasketController();

            // Act
            var result = await _sut.GetBasket("testUser");

            // Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<ShoppingCart>>(result);
            var okResult = response.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode.Value);
            var shoppingCart = Assert.IsType<ShoppingCart>(okResult.Value);
            Assert.Single(shoppingCart.Items);
            Assert.Equal("IPhone X", shoppingCart.Items[0].ProductName);
        }

        [Fact]
        public async void GetReturnInternalServerError()
        {
            // Arrange         
            _mockBasketRepository.Setup(x => x.GetBasket("testUser")).ThrowsAsync(new System.Exception());
            // Act
            var result = await _sut.GetBasket("testUser");
            var response = Assert.IsType<ActionResult<ShoppingCart>>(result);
            var objResult = response.Result as ObjectResult;

            // Assert
            Assert.Equal(500, objResult.StatusCode.Value);

        }

        [Fact]
        public async void UpdateBasketWithDiscount()
        {
            // Arrange
            var userName = "testUser";
            var validShoppingCart = new ShoppingCart();
            validShoppingCart.Items = new List<ShoppingCartItem>
            {
                new ShoppingCartItem
                {
                    Quantity = 1,
                    Color = "Red",
                    Price = 950.00M,
                    ProductId = "602d2149e773f2a3990b47f5",
                    ProductName = "IPhone X"
                }
            };

            _mockBasketRepository.Setup(x => x.GetBasket(userName)).ReturnsAsync(validShoppingCart);
            _mockBasketRepository.Setup(x => x.UpdateBasket(It.IsAny<ShoppingCart>())).ReturnsAsync(validShoppingCart);
            _mockDiscountGrpcService.Setup(x => x.GetDiscount(It.IsAny<string>())).ReturnsAsync(new CouponModel { Amount = 10 });

            this.IntialieBasketController();

            // Act
            var result = await _sut.UpdateBasket(validShoppingCart);

            // Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<ShoppingCart>>(result);
            var okResult = response.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode.Value);
            var shoppingCart = Assert.IsType<ShoppingCart>(okResult.Value);
            Assert.Equal(940m, shoppingCart.TotalPrice);

        }

        [Fact]
        public async void NotUpdateWithInternalServerError()
        {
            // Arrange
            var userName = "testUser";
            var validShoppingCart = new ShoppingCart();
            validShoppingCart.Items = new List<ShoppingCartItem>
            {
                new ShoppingCartItem
                {
                    Quantity = 1,
                    Color = "Red",
                    Price = 950.00M,
                    ProductId = "602d2149e773f2a3990b47f5",
                    ProductName = "IPhone X"
                }
            };

            _mockBasketRepository.Setup(x => x.GetBasket(userName)).ReturnsAsync(validShoppingCart);
            _mockBasketRepository.Setup(x => x.UpdateBasket(It.IsAny<ShoppingCart>())).ReturnsAsync(validShoppingCart);
            _mockDiscountGrpcService.Setup(x => x.GetDiscount(It.IsAny<string>())).ThrowsAsync(new System.Exception());

            this.IntialieBasketController();
            // Act
            var response = await _sut.UpdateBasket(validShoppingCart);
            var objResult = response.Result as ObjectResult;

            // Assert
            Assert.Equal(500, objResult.StatusCode.Value);

        }

        [Fact]
        public async void DeletedBasket()
        {
            // Arrange
            var userName = "testUser";

            _mockBasketRepository.Setup(x => x.DeleteBasket(userName)).Returns(Task.CompletedTask);

            this.IntialieBasketController();
            // Act
            var response = await _sut.DeleteBasket(userName);
            var okResult = response.Result as OkResult;

            // Assert
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public async void DeleteWithInternalServerError()
        {
            var userName = "testUser";

            _mockBasketRepository.Setup(x => x.DeleteBasket(userName)).ThrowsAsync(new System.Exception());
            this.IntialieBasketController();
            // Act
            var response = await _sut.DeleteBasket(userName);
            var objResult = response.Result as ObjectResult;

            // Assert
            Assert.Equal(500, objResult.StatusCode.Value);

        }

        [Fact]
        public async void CheckoutReturnBadResult()
        {

            // Arrange

            var userName = "testUser";
            var validShoppingCart = new ShoppingCart();
            validShoppingCart.Items = new List<ShoppingCartItem>
            {
                new ShoppingCartItem
                {
                    Quantity = 1,
                    Color = "Red",
                    Price = 950.00M,
                    ProductId = "602d2149e773f2a3990b47f5",
                    ProductName = "IPhone X"
                }
            };

            _mockBasketRepository.Setup(x => x.GetBasket(userName)).ReturnsAsync(validShoppingCart);

            var basketCheckout = new BasketCheckout
            {
                UserName = userName,
                TotalPrice = 1000
            };

            //
            _mockBasketRepository.Setup(x => x.GetBasket(userName)).ReturnsAsync((ShoppingCart)null);
            this.IntialieBasketController();

            // Act
            var result = await _sut.Checkout(basketCheckout);

            // Assert BadRequestResult
            Assert.NotNull(result);
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async void CheckoutReturnOkResult()
        {

            // Arrange
            var basketCheckout = new BasketCheckout
            {
                UserName = "testUser",
                TotalPrice = 1000
            };

            var basketCheckoutEvent = new BasketCheckoutEvent
            {
                UserName = "testUser",
                TotalPrice = 500
            };

            var userName = "testUser";
            //

            _mockPublishEndpoint.Setup(x => x.Publish(basketCheckoutEvent, default)).Returns(Task.CompletedTask);
            _mockBasketRepository.Setup(x => x.GetBasket(userName)).ReturnsAsync(new ShoppingCart());
            _mockBasketRepository.Setup(x => x.DeleteBasket(userName)).Returns(Task.CompletedTask);
            this.IntialieBasketController();

            // Act
            var result = await _sut.Checkout(basketCheckout);

            // Assert OkResult
            Assert.NotNull(result);
            var acceptedResult = Assert.IsType<AcceptedResult>(result);
            Assert.Equal(202, acceptedResult.StatusCode);
        }

        [Fact]
        public async void CheckoutReturnInternalServerError()
        {

            // Arrange
            var basketCheckout = new BasketCheckout
            {
                UserName = "testUser",
                TotalPrice = 1000
            };

            var basketCheckoutEvent = new BasketCheckoutEvent
            {
                UserName = "testUser",
                TotalPrice = 500
            };

            var userName = "testUser";
            //

            _mockPublishEndpoint.Setup(x => x.Publish(basketCheckoutEvent, default)).Returns(Task.CompletedTask);
            _mockBasketRepository.Setup(x => x.GetBasket(userName)).ReturnsAsync(new ShoppingCart());
            _mockBasketRepository.Setup(x => x.DeleteBasket(userName)).ThrowsAsync(new System.Exception());
            this.IntialieBasketController();

            // Act
            var result = await _sut.Checkout(basketCheckout);

            // Assert OkResult
            Assert.NotNull(result);
            var objResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objResult.StatusCode.Value);
        }
    }

}