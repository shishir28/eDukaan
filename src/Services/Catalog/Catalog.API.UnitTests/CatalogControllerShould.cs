using Catalog.API.Controllers;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Catalog.API.UnitTests
{
    public class CatalogControllerShould
    {
        private readonly Mock<ILogger<CatalogController>> _mockLogger;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IProductBrandRepository> _mockProductBrandRepository;
        private readonly Mock<IProductCategoryRepository> _mockProductCategoryRepository;

        private CatalogController _sut;

        public CatalogControllerShould()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _mockProductBrandRepository = new Mock<IProductBrandRepository>();
            _mockProductCategoryRepository = new Mock<IProductCategoryRepository>();

            _mockLogger = new Mock<ILogger<CatalogController>>();
            this.IntialieCatalogController();
        }


        private void IntialieCatalogController() => this._sut = new CatalogController(_mockProductRepository.Object,
            _mockProductBrandRepository.Object,
            _mockProductCategoryRepository.Object,
            _mockLogger.Object);

        private List<CatalogItem> DesiredProductList => new List<CatalogItem>()
            {
                new CatalogItem()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "IPhone X",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFileName = "product-1.png",
                    Price = 950.00M,
                },
                new CatalogItem()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Samsung 10",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFileName = "product-2.png",
                    Price = 840.00M,
                }
            };

        [Fact]
        public async Task ReturnValidProductList()
        {
            var productList = DesiredProductList;
            // Arrange
            _mockProductRepository.Setup(x => x.GetProducts()).ReturnsAsync(productList);

            this.IntialieCatalogController();

            // Act
            var result = await this._sut.GetProducts();

            // Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<IEnumerable<CatalogItem>>>(result);
            var okResult = response.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode.Value);

            var returnedProductList = Assert.IsType<List<CatalogItem>>(okResult.Value);
            Assert.Equal(2, returnedProductList.Count);
            Assert.Equal("IPhone X", returnedProductList.FirstOrDefault().Name);

        }


        [Fact]
        public async Task GetReturnInternalServerError()
        {
            // Arrange
            _mockProductRepository.Setup(x => x.GetProducts()).ThrowsAsync(new System.Exception());

            this.IntialieCatalogController();

            // Act
            var result = await this._sut.GetProducts();

            var response = Assert.IsType<ActionResult<IEnumerable<CatalogItem>>>(result);
            var objResult = response.Result as ObjectResult;

            // Assert
            Assert.Equal(500, objResult.StatusCode.Value);
        }

        [Fact]
        public async Task GetProductByIdReturnNotFound()
        {
            // Arrange
            var productId = "602d2149e773f2a3990b47f5";
            _mockProductRepository.Setup(x => x.GetProductById(It.IsAny<string>())).ReturnsAsync((CatalogItem)null);

            this.IntialieCatalogController();

            // Act
            var result = await _sut.GetProductById(productId);

            // Assert 
            Assert.NotNull(result);
            var notFoundResult = Assert.IsType<NotFoundResult>(result.Result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }


        [Fact]
        public async Task GetProductByIdReturnValidProduct()
        {
            // Arrange
            var desiredProduct = DesiredProductList[0];
            var productId = "602d2149e773f2a3990b47f5";
            _mockProductRepository.Setup(x => x.GetProductById(productId)).ReturnsAsync(desiredProduct);

            // Act
            var result = await _sut.GetProductById(productId);

            // Assert 
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<CatalogItem>>(result);
            var okResult = response.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode.Value);
            var returnedProduct = Assert.IsType<CatalogItem>(okResult.Value);
            Assert.Equal(desiredProduct.Name, returnedProduct.Name);

        }

        [Fact]
        public async Task GetProductByIdReturnInternalServerError()
        {
            // Arrange
            var productId = "602d2149e773f2a3990b47f5";
            _mockProductRepository.Setup(x => x.GetProductById(It.IsAny<string>())).ThrowsAsync(new System.Exception());

            this.IntialieCatalogController();

            // Act
            var result = await _sut.GetProductById(productId);

            // Assert 
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<CatalogItem>>(result);
            var objResult = response.Result as ObjectResult;
            Assert.Equal(500, objResult.StatusCode.Value);
        }

        [Fact]
        public async Task ReturnValidProductListForCategory()
        {
            var productList = DesiredProductList;

            // Arrange
            _mockProductRepository.Setup(x => x.GetProductsByCategory(It.IsAny<string>())).ReturnsAsync(productList);

            this.IntialieCatalogController();

            // Act
            var result = await this._sut.GetProductByCategory("Smart Phone");

            // Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<IEnumerable<CatalogItem>>>(result);
            var okResult = response.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode.Value);

            var returnedProductList = Assert.IsType<List<CatalogItem>>(okResult.Value);
            Assert.Equal(2, returnedProductList.Count);
            Assert.Equal("IPhone X", returnedProductList.FirstOrDefault().Name);

        }


        [Fact]
        public async Task GetProductByCategoryReturnNotFound()
        {
            // Arrange
            _mockProductRepository.Setup(x => x.GetProductsByCategory(It.IsAny<string>())).ReturnsAsync((List<CatalogItem>)null);

            this.IntialieCatalogController();

            // Act
            var result = await _sut.GetProductByCategory("Smart Phone");

            // Assert 
            Assert.NotNull(result);
            var notFoundResult = Assert.IsType<NotFoundResult>(result.Result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }


        [Fact]
        public async Task GetProductByCategoryReturnInternalServerError()
        {
            // Arrange

            _mockProductRepository.Setup(x => x.GetProductsByCategory(It.IsAny<string>())).ThrowsAsync(new System.Exception());

            this.IntialieCatalogController();

            // Act
            var result = await _sut.GetProductByCategory("Smart Phone");

            var response = Assert.IsType<ActionResult<IEnumerable<CatalogItem>>>(result);
            var objResult = response.Result as ObjectResult;

            // Assert
            Assert.Equal(500, objResult.StatusCode.Value);
        }


        [Fact]
        public async Task ReturnValidProductListForName()
        {
            var productList = DesiredProductList;

            // Arrange
            _mockProductRepository.Setup(x => x.GetProductsByName(It.IsAny<string>())).ReturnsAsync(productList);

            this.IntialieCatalogController();

            // Act
            var result = await this._sut.GetProductByName("IPhone X");

            // Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<IEnumerable<CatalogItem>>>(result);
            var okResult = response.Result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode.Value);

            var returnedProductList = Assert.IsType<List<CatalogItem>>(okResult.Value);
            Assert.Equal(2, returnedProductList.Count);
            Assert.Equal("IPhone X", returnedProductList.FirstOrDefault().Name);

        }


        [Fact]
        public async Task GetProductByNameReturnNotFound()
        {
            // Arrange
            _mockProductRepository.Setup(x => x.GetProductsByName(It.IsAny<string>())).ReturnsAsync((List<CatalogItem>)null);

            this.IntialieCatalogController();

            // Act
            var result = await _sut.GetProductByName("Smart Phone");

            // Assert 
            Assert.NotNull(result);
            var notFoundResult = Assert.IsType<NotFoundResult>(result.Result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }


        [Fact]
        public async Task GetProductByNameReturnInternalServerError()
        {
            // Arrange

            _mockProductRepository.Setup(x => x.GetProductsByName(It.IsAny<string>())).ThrowsAsync(new System.Exception());

            this.IntialieCatalogController();

            // Act
            var result = await _sut.GetProductByName("Smart Phone");

            var response = Assert.IsType<ActionResult<IEnumerable<CatalogItem>>>(result);
            var objResult = response.Result as ObjectResult;

            // Assert
            Assert.Equal(500, objResult.StatusCode.Value);
        }

        [Fact]
        public async Task CreateProductReturnValidProduct()
        {
            // Arrange
            var product = DesiredProductList[0];

            _mockProductRepository.Setup(x => x.Create(It.IsAny<CatalogItem>())).Returns(Task.CompletedTask);

            this.IntialieCatalogController();

            // Act
            var result = await _sut.CreateProduct(product);

            // Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<CatalogItem>>(result);
            var createResult = response.Result as CreatedAtRouteResult;
            Assert.Equal(201, createResult.StatusCode.Value);

            var returnedProduct = Assert.IsType<CatalogItem>(createResult.Value);
            Assert.Equal(product.Name, returnedProduct.Name);

        }

        [Fact]
        public async Task CreateProductReturnInternalServerError()
        {
            // Arrange
            var product = DesiredProductList[0];

            _mockProductRepository.Setup(x => x.Create(It.IsAny<CatalogItem>())).ThrowsAsync(new System.Exception());

            this.IntialieCatalogController();

            // Act
            var result = await _sut.CreateProduct(product);

            // Assert
            Assert.NotNull(result);
            var response = Assert.IsType<ActionResult<CatalogItem>>(result);
            var objResult = response.Result as ObjectResult;
            Assert.Equal(500, objResult.StatusCode.Value);
        }

        [Fact]
        public async Task UpdateProductSuccessfully()
        {
            // Arrange
            var product = DesiredProductList[0];

            _mockProductRepository.Setup(x => x.Update(It.IsAny<CatalogItem>())).ReturnsAsync(true);

            this.IntialieCatalogController();

            // Act
            var result = await _sut.UpdateProduct(product);

            // Assert
            Assert.NotNull(result);
            var noContentResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, noContentResult.StatusCode);

        }

        [Fact]
        public async Task UpdateProductReturnInternalServerError()
        {
            // Arrange
            var product = DesiredProductList[0];

            _mockProductRepository.Setup(x => x.Update(It.IsAny<CatalogItem>())).ThrowsAsync(new System.Exception());

            this.IntialieCatalogController();

            // Act
            var result = await _sut.UpdateProduct(product);

            // Assert
            Assert.NotNull(result);
            var objResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objResult.StatusCode.Value);
        }

        [Fact]
        public async Task DeleteProducSuccessfully()
        {
            // Arrange
            var product = DesiredProductList[0];

            _mockProductRepository.Setup(x => x.Delete(It.IsAny<string>())).ReturnsAsync(true);

            this.IntialieCatalogController();

            // Act
            var result = await _sut.DeleteProduct(product.Id);

            // Assert
            Assert.NotNull(result);
            var noContentResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, noContentResult.StatusCode);

        }

        [Fact]
        public async Task DeleteProductReturnInternalServerError()
        {
            // Arrange
            var product = DesiredProductList[0];

            _mockProductRepository.Setup(x => x.Delete(It.IsAny<string>())).ThrowsAsync(new System.Exception());

            this.IntialieCatalogController();

            // Act
            var result = await _sut.DeleteProduct(product.Id);

            // Assert
            Assert.NotNull(result);
            var objResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objResult.StatusCode.Value);
        }


    }
}