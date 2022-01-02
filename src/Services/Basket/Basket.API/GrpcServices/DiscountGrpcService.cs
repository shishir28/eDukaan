using Discount.Grpc.Protos;
using static Discount.Grpc.Protos.DiscountProtoService;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly ILogger<DiscountGrpcService> _logger;
        private readonly DiscountProtoServiceClient _discountProtoService;

        public DiscountGrpcService(DiscountProtoServiceClient discountProtoService, ILogger<DiscountGrpcService> logger)
        {
            _discountProtoService = discountProtoService ?? throw new ArgumentNullException(nameof(discountProtoService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new Discount.Grpc.Protos.GetDiscountRequest { ProductName = productName };
            return await _discountProtoService.GetDiscountAsync(discountRequest);
        }
    }
}