using AutoMapper;
using MP.Author.Api.Models.Request;
using MP.Author.Core.Dto.UseCaseRequests;

namespace MP.Author.Api.Mapping
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<ObjectsRequest, ObjectsDtoRequest>();
            CreateMap<OperationsRequest, OperationsDtoRequest>();
            CreateMap<PermissionsRequest, PermissionsDtoRequest>();
            CreateMap<RolePermissionRequest, RolePermissionDtoRequest>();
            CreateMap<RoleRequest, RoleDtoRequest>();
            CreateMap<UserRoleRequest, UserRoleDtoRequest>();
            CreateMap<AddUserRoleRequest, AddUserRoleDtoRequest>();
            CreateMap<MenusRequest, MenusDtoRequest>();
            //CreateMap<AppUser, User>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)).
            //                           ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash)).
            //                           ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
