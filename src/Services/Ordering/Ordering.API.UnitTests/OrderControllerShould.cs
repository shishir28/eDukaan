using Microsoft.Extensions.Logging;
using Moq;
using Ordering.API.Controllers;
using Xunit;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using System;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using GetOrdersList = Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System.Collections.Generic;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;

namespace Ordering.API.UnitTests
{
    public class OrderControllerShould
    {
        private readonly Mock<ILogger<OrderController>> _mockLogger;
        private Mock<IMediator> _mockMediator;
        private OrderController _sut;

        public OrderControllerShould()
        {
            _mockMediator = new Mock<IMediator>();
            _mockLogger = new Mock<ILogger<OrderController>>();
            this.IntialieOrderController();
        }

        private void IntialieOrderController() => this._sut = new OrderController(_mockMediator.Object, _mockLogger.Object);


        [Fact]
        public async Task ReturnsValidOrder()
        {
            //Arrange
            var expectedOrderList = new List<OrdersVm>()
            {
                new OrdersVm {
                    UserName = "skm",
                    FirstName = "Shishir",
                    LastName = "Mishra",
                    EmailAddress = "shishir28@gmail.com",
                    AddressLine = "Test",
                    Country = "Australia",
                    State = "NSW",
                    ZipCode = "2145",
                    CardName = "Australia",
                    CardNumber = "123456789",
                    Expiration = "12/12",
                    CVV = "123",
                    TotalPrice = 350
                }
            };

            _mockMediator.Setup(x => x.Send(It.IsAny<GetOrdersListQuery>(), default)).ReturnsAsync(expectedOrderList);

            //Act
            var result = await _sut.GetOrdersByUserName("skm");

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetOrdersListQuery>(), default), Times.Once());
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<IEnumerable<OrdersVm>>>(result);
            var okResult = response.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode.Value);

            var returnedOrderList = Assert.IsType<List<OrdersVm>>(okResult.Value);
            Assert.Single(returnedOrderList);

        }

        [Fact]
        public async Task GetReturnOrderInternalServerError()
        {
            //Arrange
            _mockMediator.Setup(x => x.Send(It.IsAny<GetOrdersListQuery>(), default)).ThrowsAsync(new System.Exception());

            //Act
            var result = await _sut.GetOrdersByUserName("skm");

            // Assert 
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<IEnumerable<OrdersVm>>>(result);
            var objResult = response.Result as ObjectResult;
            Assert.Equal(500, objResult.StatusCode.Value);
        }

        [Fact]
        public async Task CheckoutOrder()
        {
            //Arrange
            var checkoutCommand = new CheckoutOrderCommand();
            _mockMediator.Setup(x => x.Send(It.IsAny<CheckoutOrderCommand>(), default)).ReturnsAsync(1);
            this.IntialieOrderController();

            //Act
            var result = await _sut.CheckoutOrder(checkoutCommand);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<CheckoutOrderCommand>(), default), Times.Once());
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<int>>(result);
            var okResult = response.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode.Value);
            Assert.Equal(1, okResult.Value);
        }

        [Fact]
        public async Task ReturnsInternalServerError()
        {
            //Arrange
            var checkoutCommand = new CheckoutOrderCommand();
            _mockMediator.Setup(x => x.Send(It.IsAny<CheckoutOrderCommand>(), default)).ThrowsAsync(new Exception());
            this.IntialieOrderController();

            //Act
            var result = await _sut.CheckoutOrder(checkoutCommand);

            //Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<int>>(result);
            var objResult = response.Result as ObjectResult;
            Assert.Equal(500, objResult.StatusCode.Value);
        }

        [Fact]
        public async Task UpdateOrderSuccessfully()
        {
            //Arrange
            _mockMediator.Setup(x => x.Send(It.IsAny<UpdateOrderCommand>(), default)).ReturnsAsync(new Unit());
            this.IntialieOrderController();

            //Act
            var result = await _sut.UpdateOrder(new UpdateOrderCommand());

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<UpdateOrderCommand>(), default), Times.Once());
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<Unit>>(result);
            var okResult = response.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode.Value);
        }

        [Fact]
        public async Task UpdateOrderInternalServerError()
        {
            //Arrange
            _mockMediator.Setup(x => x.Send(It.IsAny<UpdateOrderCommand>(), default)).ThrowsAsync(new Exception());
            this.IntialieOrderController();

            //Act
            var result = await _sut.UpdateOrder(new UpdateOrderCommand());

            //Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<Unit>>(result);
            var objResult = response.Result as ObjectResult;
            Assert.Equal(500, objResult.StatusCode.Value);
        }

        [Fact]
        public async Task DeleteOrderSuccessfully()
        {
            //Arrange

            _mockMediator.Setup(x => x.Send(It.IsAny<DeleteOrderCommand>(), default)).ReturnsAsync(new Unit());
            this.IntialieOrderController();

            //Act
            var result = await _sut.DeleteOrder(1);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<DeleteOrderCommand>(), default), Times.Once());
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<Unit>>(result);
            var okResult = response.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode.Value);
        }


        [Fact]
        public async Task DeleteOrderInternalServerError()
        {
            //Arrange
            _mockMediator.Setup(x => x.Send(It.IsAny<DeleteOrderCommand>(), default)).ThrowsAsync(new Exception());
            this.IntialieOrderController();

            //Act
            var result = await _sut.DeleteOrder(1);

            //Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<Unit>>(result);
            var objResult = response.Result as ObjectResult;
            Assert.Equal(500, objResult.StatusCode.Value);
        }
    }
}