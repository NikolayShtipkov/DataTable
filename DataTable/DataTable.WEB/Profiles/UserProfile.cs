using AutoMapper;
using DataTable.DAL.Entities;
using DataTable.WEB.Models;

namespace DataTable.WEB.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>()
                .ReverseMap();
        }
    }
}
