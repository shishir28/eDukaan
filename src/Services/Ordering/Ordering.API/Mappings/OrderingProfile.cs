using AutoMapper;
using EventBus.Messages.Events;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;

namespace Ordering.API.Mappings
{
    public class OrderingProfile : Profile
    {
        public OrderingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();

        }
    }
}