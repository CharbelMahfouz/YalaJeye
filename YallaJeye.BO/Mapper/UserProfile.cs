using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalaJeye.BO.Models;
using YalaJeye.BO.ViewModels;
using YalaJeye.DAL.Models;

namespace YalaJeye.BO.Mapper
{
    class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RestaurantCategory, RestaurantCategory_VM>()
                .ForMember(dest=> dest.CategoryName,opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant.RestaurantName))
                .ReverseMap();
            CreateMap<Restaurant, Restaurant_VM>()
                .ForMember(dest => dest.CityName, opt=> opt.MapFrom(src => src.City.CityName))
                .ReverseMap();
            CreateMap<Item, Item_VM>()
                .ForMember(dest=> dest.RestaurantName, opt=> opt.MapFrom(src=> src.RestaurantCategory.Restaurant.RestaurantName))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.RestaurantCategory.Category.CategoryName))
                .ReverseMap();
            CreateMap<QuickOrder, QuickOrder_VM>().ReverseMap();
            CreateMap<Event, Event_VM>().ReverseMap();
            CreateMap<Order, Order_VM>()
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus.StatusName))
                .ForMember(dest=> dest.CustomerName,opt=> opt.MapFrom(src=> src.OrderList.Customer.CustomerName))
                .ReverseMap();
            CreateMap<OrderList, OrderList_VM>()
                .ForMember(dest=> dest.CustomerName, opt=> opt.MapFrom(src=> src.Customer.CustomerName))
                .ForMember(dest=> dest.CustomerName, opt=> opt.MapFrom(src=> src.Customer.CustomerName))
                .ReverseMap();
            CreateMap<OrderItem, OrderItem_VM>()
                .ForMember(dest => dest.OrderItemType, opt => opt.MapFrom(src => src.OrderItemType.Type))
                .ForMember(dest=> dest.RestaurantOrder, opt=> opt.MapFrom(src=> src.RestaurantOrder))
                .ForMember(dest=> dest.PlacedQuickOrder, opt=> opt.MapFrom(src=> src.PlacedQuickOrder))
                .ForMember(dest=> dest.CustomOrder, opt => opt.MapFrom(src=> src.CustomOrder))
                .ReverseMap();
            CreateMap<CustomOrder, CustomOrder_VM>().ReverseMap();
            CreateMap<Customer, Customer_VM>()
                .ReverseMap();
            CreateMap<RestaurantOrderItem, RestaurantOrderItem_VM>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Item.ItemName))
                .ForMember(dest=> dest.RestaurantName, opt=> opt.MapFrom(src=> src.RestaurantOrder.Restaurant.RestaurantName))
                .ReverseMap();
            CreateMap<RestaurantOrder, RestaurantOrder_VM>()
                .ForMember(dest => dest.RestaurantOrderItems, opt => opt.MapFrom(src => src.RestaurantOrderItems))
                .ForMember(dest => dest.RestaurantName, opt=> opt.MapFrom(src=> src.Restaurant.RestaurantName))
                .ReverseMap();
            CreateMap<PlacedQuickOrder, PlacedQuickOrder_VM>()
                .ForMember(dest => dest.QuickOrderName, opt => opt.MapFrom(src => src.IdNavigation.QuickOrderName))
                .ReverseMap();
        }
    }
}
