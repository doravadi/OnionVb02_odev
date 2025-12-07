using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Application.DTOClasses;
using OnionVb02.WebApi.RequestModels.AppUserProfiles;
using OnionVb02.WebApi.RequestModels.AppUsers;
using OnionVb02.WebApi.RequestModels.Categories;
using OnionVb02.WebApi.RequestModels.OrderDetails;
using OnionVb02.WebApi.RequestModels.Orders;
using OnionVb02.WebApi.RequestModels.Products;
using OnionVb02.WebApi.ResponseModels.AppUserProfiles;
using OnionVb02.WebApi.ResponseModels.AppUsers;
using OnionVb02.WebApi.ResponseModels.Categories;
using OnionVb02.WebApi.ResponseModels.OrderDetails;
using OnionVb02.WebApi.ResponseModels.Orders;
using OnionVb02.WebApi.ResponseModels.Products;

namespace OnionVb02.WebApi.MappingProfiles
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            // Category Mappings
            CreateMap<CreateCategoryRequestModel, CreateCategoryCommand>();
            CreateMap<UpdateCategoryRequestModel, UpdateCategoryCommand>();
            CreateMap<GetCategoryQueryResult, CategoryResponseModel>();
            CreateMap<GetCategoryByIdQueryResult, CategoryResponseModel>();

            // Product Mappings
            CreateMap<CreateProductRequestModel, CreateProductCommand>();
            CreateMap<UpdateProductRequestModel, UpdateProductCommand>();
            CreateMap<GetProductQueryResult, ProductResponseModel>();
            CreateMap<GetProductByIdQueryResult, ProductResponseModel>();

            // Order Mappings
            CreateMap<CreateOrderRequestModel, CreateOrderCommand>();
            CreateMap<UpdateOrderRequestModel, UpdateOrderCommand>();
            CreateMap<GetOrderQueryResult, OrderResponseModel>();
            CreateMap<GetOrderByIdQueryResult, OrderResponseModel>();

            // OrderDetail Mappings
            CreateMap<CreateOrderDetailRequestModel, CreateOrderDetailCommand>();
            CreateMap<UpdateOrderDetailRequestModel, UpdateOrderDetailCommand>();
            CreateMap<GetOrderDetailQueryResult, OrderDetailResponseModel>();
            CreateMap<GetOrderDetailByIdQueryResult, OrderDetailResponseModel>();

            // AppUser Mappings
            CreateMap<CreateAppUserRequestModel, CreateAppUserCommand>();
            CreateMap<UpdateAppUserRequestModel, UpdateAppUserCommand>();
            CreateMap<GetAppUserQueryResult, AppUserResponseModel>();
            CreateMap<GetAppUserByIdQueryResult, AppUserResponseModel>();

            // AppUserProfile Mappings
            CreateMap<CreateAppUserProfileRequestModel, CreateAppUserProfileCommand>();
            CreateMap<UpdateAppUserProfileRequestModel, UpdateAppUserProfileCommand>();
            CreateMap<GetAppUserProfileQueryResult, AppUserProfileResponseModel>();
            CreateMap<GetAppUserProfileByIdQueryResult, AppUserProfileResponseModel>();

            // DTO Mappings (for compatibility with Manager-based operations if needed)
            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel, CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();
        }
    }
}
