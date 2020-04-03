using AutoMapper;
using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto;
using MP.Author.Core.Dto.GatewayResponses.Repositories;
using MP.Author.Core.Dto.UseCaseRequests;


namespace MP.Author.Core.Mapping
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<ObjectsDtoRequest, Objects>();//.ForMember(dest=>dest.Permissions, opt=>opt.Ignore());
            CreateMap<OperationsDtoRequest, Operations>();//.ForMember(dest=>dest.Permissions, opt=>opt.Ignore());
            CreateMap<RoleResponse, RoleDto>();
            CreateMap<Permissions, PermissionDto>();
        }
    }
}
