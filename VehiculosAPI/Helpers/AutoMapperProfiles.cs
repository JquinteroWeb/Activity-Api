using AutoMapper;
using VehiculosAPI.DTOs;
using VehiculosAPI.Entidades;

namespace VehiculosAPI.Helpers
{
    public class AutoMapperProfiles: Profile
    {

        public AutoMapperProfiles()
        {
           
            CreateMap<Times, TimesDTO>();
            CreateMap<TimesCreacionDTO, Times>();

            CreateMap<Activities, ActivitiesDTO>();
            CreateMap<ActivitiesCreacionDTO, Activities>();

        }

    }
}
