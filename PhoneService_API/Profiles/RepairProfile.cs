using System.Linq;
using AutoMapper;
using PhoneService_API.Dtos;
using PhoneService_API.Models;

namespace PhoneService_API.Profiles
{
    public class RepairProfile : Profile
    {
        public RepairProfile()
        {
            //Source -> Target
            CreateMap<Repair, RepairReadDto>();
            CreateMap<RepairReadForUpdateDto, Repair>();
            CreateMap<Repair, RepairReadWithoutClient>();
            CreateMap<Repair, RepairReadWithIdsDto>();
            CreateMap<RepairReadWithIdsDto, Repair>();
            CreateMap<RepairCreateDto, Repair>();
            CreateMap<RepairUpdateDto, Repair>();
        }
    }
}
