using AutoMapper;
using PBSA.Models;
using PBSA.Request;
using PBSA;

namespace PBSA.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerRequest, Customer>();
            CreateMap<Customer,Response.Customer>();
            CreateMap<AddressRequest, Address>();
            CreateMap<Address, Response.Address>();
            CreateMap<ProductRequest, Product>();
            CreateMap<Product, Response.Product>();
            CreateMap<Response.Sales, Sale>();
            CreateMap<Sale, Response.Sales>();
        }
    }
}
