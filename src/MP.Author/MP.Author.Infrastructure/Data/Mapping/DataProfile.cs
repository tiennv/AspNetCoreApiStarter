using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Infrastructure.Identity;

namespace MP.Author.Infrastructure.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<User, AppUser>().ConstructUsing(u => new AppUser { UserName = u.UserName, Email = u.Email }).ForMember(au => au.Id, opt => opt.Ignore());
            CreateMap<AppUser, User>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)).
                                       ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash)).
                                       ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<IdentityRole, RoleDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                                              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                              .ForAllOtherMembers(opt=>opt.Ignore());

            CreateMap<ObjectsDtoRequest, Objects>();
            CreateMap<OperationsDtoRequest, Operations>();
            CreateMap<PermissionsDtoRequest, Permissions>();
            CreateMap<RolePermissionDtoRequest, Role_Permission>();
        }
    }
}
