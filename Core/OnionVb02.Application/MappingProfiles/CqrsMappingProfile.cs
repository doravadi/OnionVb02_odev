using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.MappingProfiles
{
    public class CqrsMappingProfile : Profile
    {
        public CqrsMappingProfile()
        {
            // AppUser Mappings
            CreateMap<CreateAppUserCommand, AppUser>();
            CreateMap<UpdateAppUserCommand, AppUser>();
            CreateMap<AppUser, GetAppUserQueryResult>();
            CreateMap<AppUser, GetAppUserByIdQueryResult>();

            // Category Mappings
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Category, GetCategoryQueryResult>();
            CreateMap<Category, GetCategoryByIdQueryResult>();

            // Product Mappings
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Product, GetProductQueryResult>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<Product, GetProductByIdQueryResult>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));

            // Order Mappings
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<UpdateOrderCommand, Order>();
            CreateMap<Order, GetOrderQueryResult>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName));
            CreateMap<Order, GetOrderByIdQueryResult>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName));

            // OrderDetail Mappings
            CreateMap<CreateOrderDetailCommand, OrderDetail>();
            CreateMap<UpdateOrderDetailCommand, OrderDetail>();
            CreateMap<OrderDetail, GetOrderDetailQueryResult>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.OrderAddress, opt => opt.MapFrom(src => src.Order.ShippingAddress));
            CreateMap<OrderDetail, GetOrderDetailByIdQueryResult>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.OrderAddress, opt => opt.MapFrom(src => src.Order.ShippingAddress));

            // AppUserProfile Mappings
            CreateMap<CreateAppUserProfileCommand, AppUserProfile>();
            CreateMap<UpdateAppUserProfileCommand, AppUserProfile>();
            CreateMap<AppUserProfile, GetAppUserProfileQueryResult>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName));
            CreateMap<AppUserProfile, GetAppUserProfileByIdQueryResult>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName));
        }
    }
}
