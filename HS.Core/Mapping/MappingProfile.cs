using AutoMapper;
using Exam_question_BE.HS.Core.DTOs.Request;
using Exam_question_BE.HS.Core.DTOs.Response;
using Exam_question_BE.HS.Core.Entities;

namespace Exam_question_BE.HS.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTORes>()
                     .ForMember(dest => dest.Roles,
                     opt => opt.MapFrom(src =>
                     src.Roles.Select(r =>
                     r.Name).ToList()));

            CreateMap<UserDTOReq, User>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore());
        }
    }
}
