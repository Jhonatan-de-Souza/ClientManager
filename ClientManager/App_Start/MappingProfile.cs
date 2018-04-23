using System.Web.Services.Description;
using AutoMapper;
using ClientManager.Core.Domain;
using ClientManager.ViewModels;

namespace ClientManager
{
    public static class MappingProfile
    {
        public static void ConfigureUserMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Person, PersonViewModel>().ReverseMap();
            });
        }
    }
}