using Business_Logic_Layer.DTOs;
using Entity;
using AutoMapper;

namespace Business_Logic_Layer.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmployeeEntity, EmployeeDto>()
                .ConstructUsing(user => new EmployeeDto(user.ID))
                .ReverseMap()
                .ConstructUsing(userDto => new EmployeeEntity(userDto.ID));

        }

    }
}
