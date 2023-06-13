using AutoMapper;
using Domain.Models;
using Services.Stories.AdministratorStories;
using Services.Stories.CarStories;
using Services.Stories.ChargeSessionStories;
using Services.Stories.CompanyOwnerStories;
using Services.Stories.CompanyStories;
using Services.Stories.DriverStories;

namespace Services
{
    public class StoryAppMappingProfile : Profile
    {
        public StoryAppMappingProfile()
        {
            CreateMap<CreateCarStory, Car>();
            CreateMap<UpdateCarStory, Car>();

            CreateMap<CreateAdministratorStory, Administrator>();
            CreateMap<UpdateAdministratorStory, Administrator>();

            CreateMap<CreateCompanyStory, Company>();
            CreateMap<UpdateCompanyStory, Company>();

            CreateMap<CreateCompanyOwnerStory, CompanyOwner>();
            CreateMap<UpdateCompanyOwnerStory, CompanyOwner>();

            CreateMap<CreateChargeSessionStory, ChargeSession>();
            CreateMap<UpdateChargeSessionStory, ChargeSession>();

            CreateMap<CreateDriverStory, Driver>();
            CreateMap<UpdateDriverStory, Driver>();
        }
    }
}
