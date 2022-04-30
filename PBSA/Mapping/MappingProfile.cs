using AutoMapper;
using PBSA.Models;
using PBSA.Request;
using PBSA;
using PBSA.Models.DB;

namespace PBSA.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerModel, Customer>();
            CreateMap<Customer, CustomerModel>();
            CreateMap<AddressModel, Address>();
            CreateMap<Address, AddressModel>();
            CreateMap<ProductRequest, Product>();
            CreateMap<Product, Response.ProductResponse>();
            CreateMap<Response.SaleResponse, Sale>();
            CreateMap<Sale, Response.SaleResponse>();
        }
    }
}
