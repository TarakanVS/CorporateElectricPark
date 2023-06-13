using AutoMapper;
using Domain.Models;

namespace Repository
{
    public class BaseAppMappingProfile : Profile
    {
        public BaseAppMappingProfile()
        {
            CreateMap<Car, Car>();
            CreateMap<Company, Company>();
            CreateMap<Administrator, Administrator>();
            CreateMap<CompanyOwner, CompanyOwner>();
            CreateMap<Driver, Driver>();
            CreateMap<ChargeSession, ChargeSession>();
        }
    }
}
