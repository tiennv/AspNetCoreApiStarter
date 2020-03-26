using AutoMapper;
using MP.Author.Api.Models.Request;

namespace MP.Author.Api.Mapping
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<ObjectsRequest, Core.Dto.UseCaseRequests.ObjectsRequest>();
                
            //CreateMap<AppUser, User>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)).
            //                           ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash)).
            //                           ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
