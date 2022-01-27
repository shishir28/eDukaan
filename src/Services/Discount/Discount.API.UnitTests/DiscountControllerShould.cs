using Discount.API.Controllers;
using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Discount.API.UnitTests
{
    public class DiscountControllerShould
    {
        private readonly Mock<ILogger<DiscountController>> _mockLogger;
        private readonly Mock<IDiscountRepository> _mockDiscountRepository;
        private DiscountController _sut;

        private Coupon DesiredDiscount => new Coupon
        {
            Id = 1,
            ProductName = "IPhone X",
            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            Amount = 50
        };

        public DiscountControllerShould()
        {
            _mockDiscountRepository = new Mock<IDiscountRepository>();
            _mockLogger = new Mock<ILogger<DiscountController>>();
            this.IntialieCatalogController();
        }

        private void IntialieCatalogController() => this._sut = new DiscountController(_mockDiscountRepository.Object, _mockLogger.Object);

        [Fact]
        public async Task ReturnsValidDiscountCoupon()
        {
            //Arrange
            var expectedCoupon = this.DesiredDiscount;
            _mockDiscountRepository.Setup(x => x.GetDiscount(It.IsAny<string>())).ReturnsAsync(expectedCoupon);

            //Act
            var result = await _sut.GetDiscount("IPhone X");

            //Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<Coupon>>(result);
            var okResult = response.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode.Value);

            var returnedCoupon = Assert.IsType<Coupon>(okResult.Value);
            Assert.Equal(expectedCoupon.ProductName, returnedCoupon.ProductName);
            Assert.Equal(expectedCoupon.Amount, returnedCoupon.Amount);
        }

        [Fact]
        public async Task GetReturnInternalServerError()
        {
            //Arrange
            _mockDiscountRepository.Setup(x => x.GetDiscount(It.IsAny<string>())).ThrowsAsync(new System.Exception());

            //Act
            var result = await _sut.GetDiscount("IPhone X");

            //Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<Coupon>>(result);
            var objResult = response.Result as ObjectResult;
            Assert.Equal(500, objResult.StatusCode.Value);
        }

        [Fact]
        public async Task CreateDiscountReturnValidDiscount()
        {
            //Arrange
            var expectedCoupon = this.DesiredDiscount;

            _mockDiscountRepository.Setup(x => x.CreateDiscount(It.IsAny<Coupon>())).ReturnsAsync(true);

            //Act
            var result = await _sut.CreateDiscount(expectedCoupon);

            //Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<Coupon>>(result);
            var createResult = response.Result as CreatedAtRouteResult;
            Assert.Equal(201, createResult.StatusCode.Value);

            var returnedCoupon = Assert.IsType<Coupon>(createResult.Value);
            Assert.Equal(expectedCoupon.ProductName, returnedCoupon.ProductName);
        }

        [Fact]
        public async Task CreateDiscountReturnInternalServerError()
        {
            //Arrange
            var expectedCoupon = this.DesiredDiscount;

            _mockDiscountRepository.Setup(x => x.CreateDiscount(It.IsAny<Coupon>())).ThrowsAsync(new System.Exception());

            //Act
            var result = await _sut.CreateDiscount(expectedCoupon);

            //Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<Coupon>>(result);
            var objResult = response.Result as ObjectResult;

            // Assert
            Assert.Equal(500, objResult.StatusCode.Value);
        }

        [Fact]
        public async Task UpdateDiscountSuccessfully()
        {
            //Arrange
            var expectedCoupon = this.DesiredDiscount;

            _mockDiscountRepository.Setup(x => x.UpdateDiscount(It.IsAny<Coupon>())).ReturnsAsync(true);

            //Act
            var result = await _sut.UpdateDiscount(expectedCoupon);

            //Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<bool>>(result);
            var okResult = response.Result as OkObjectResult;
            Assert.True(Convert.ToBoolean(okResult.Value));
        }

        [Fact]
        public async Task UpdateDiscountReturnInternalServerError()
        {
            //Arrange
            var expectedCoupon = this.DesiredDiscount;

            _mockDiscountRepository.Setup(x => x.UpdateDiscount(It.IsAny<Coupon>())).ThrowsAsync(new System.Exception());

            //Act
            var result = await _sut.UpdateDiscount(expectedCoupon);

            //Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<bool>>(result);
            var objResult = response.Result as ObjectResult;

            // Assert
            Assert.Equal(500, objResult.StatusCode.Value);
        }

        [Fact]
        public async Task DeleteDiscountSuccessfully()
        {
            //Arrange

            _mockDiscountRepository.Setup(x => x.DeleteDiscount(It.IsAny<string>())).ReturnsAsync(true);

            //Act
            var result = await _sut.DeleteDiscount(this.DesiredDiscount.ProductName);

            //Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<bool>>(result);
            var okResult = response.Result as OkObjectResult;
            Assert.True(Convert.ToBoolean(okResult.Value));
        }

        [Fact]
        public async Task DeleteDiscountReturnInternalServerError()
        {
            //Arrange

            _mockDiscountRepository.Setup(x => x.DeleteDiscount(It.IsAny<string>())).ThrowsAsync(new System.Exception());

            //Act
            var result = await _sut.DeleteDiscount(this.DesiredDiscount.ProductName);

            //Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<bool>>(result);
            var objResult = response.Result as ObjectResult;

            // Assert
            Assert.Equal(500, objResult.StatusCode.Value);
        }


    }
}