using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhoneService_API.Dtos;
using PhoneService_API.Models;

namespace PhoneService_API.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            //Source -> Target
            CreateMap<Client, ClientReadDto>();
            CreateMap<Client, ClientReadWithoutRepairsDto>();
            CreateMap<ClientReadWithoutRepairsDto, Client>();
            CreateMap<ClientCreateDto, Client>();
            CreateMap<ClientUpdateDto, Client>();
        }
    }
}
