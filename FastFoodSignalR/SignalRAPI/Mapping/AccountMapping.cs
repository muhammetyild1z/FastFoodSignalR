using AutoMapper;
using FastFoodSignalR.DtoLayer.AccountDtos;
using FastFoodSignalR.Entity.Entities;

namespace SignalRAPI.Mapping
{
    public class AccountMapping:Profile
    {
        public AccountMapping()
        {
                CreateMap<AppUser,SignUpDto>().ReverseMap();
        }
    }
}
