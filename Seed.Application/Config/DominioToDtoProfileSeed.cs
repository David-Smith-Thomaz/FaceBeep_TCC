using Seed.Domain.Entitys;
using Seed.Dto;

namespace Seed.Application.Config
{
    public class DominioToDtoProfileSeed : AutoMapper.Profile
    {

        public DominioToDtoProfileSeed()
        {
            CreateMap(typeof(Participant), typeof(ParticipantDto)).ReverseMap();
            CreateMap(typeof(Participant), typeof(ParticipantDtoSpecialized));
            CreateMap(typeof(Participant), typeof(ParticipantDtoSpecializedResult));
            CreateMap(typeof(Participant), typeof(ParticipantDtoSpecializedReport));
            CreateMap(typeof(Participant), typeof(ParticipantDtoSpecializedDetails));
            CreateMap(typeof(User), typeof(UserDto)).ReverseMap();
            CreateMap(typeof(User), typeof(UserDtoSpecialized));
            CreateMap(typeof(User), typeof(UserDtoSpecializedResult));
            CreateMap(typeof(User), typeof(UserDtoSpecializedReport));
            CreateMap(typeof(User), typeof(UserDtoSpecializedDetails));
            CreateMap(typeof(StatusUser), typeof(StatusUserDto)).ReverseMap();
            CreateMap(typeof(StatusUser), typeof(StatusUserDtoSpecialized));
            CreateMap(typeof(StatusUser), typeof(StatusUserDtoSpecializedResult));
            CreateMap(typeof(StatusUser), typeof(StatusUserDtoSpecializedReport));
            CreateMap(typeof(StatusUser), typeof(StatusUserDtoSpecializedDetails));
            CreateMap(typeof(TypeUser), typeof(TypeUserDto)).ReverseMap();
            CreateMap(typeof(TypeUser), typeof(TypeUserDtoSpecialized));
            CreateMap(typeof(TypeUser), typeof(TypeUserDtoSpecializedResult));
            CreateMap(typeof(TypeUser), typeof(TypeUserDtoSpecializedReport));
            CreateMap(typeof(TypeUser), typeof(TypeUserDtoSpecializedDetails));
            CreateMap(typeof(GroupParticipant), typeof(GroupParticipantDto)).ReverseMap();
            CreateMap(typeof(GroupParticipant), typeof(GroupParticipantDtoSpecialized));
            CreateMap(typeof(GroupParticipant), typeof(GroupParticipantDtoSpecializedResult));
            CreateMap(typeof(GroupParticipant), typeof(GroupParticipantDtoSpecializedReport));
            CreateMap(typeof(GroupParticipant), typeof(GroupParticipantDtoSpecializedDetails));
            CreateMap(typeof(Register), typeof(RegisterDto)).ReverseMap();
            CreateMap(typeof(Register), typeof(RegisterDtoSpecialized));
            CreateMap(typeof(Register), typeof(RegisterDtoSpecializedResult));
            CreateMap(typeof(Register), typeof(RegisterDtoSpecializedReport));
            CreateMap(typeof(Register), typeof(RegisterDtoSpecializedDetails));
            CreateMap(typeof(StatusRegister), typeof(StatusRegisterDto)).ReverseMap();
            CreateMap(typeof(StatusRegister), typeof(StatusRegisterDtoSpecialized));
            CreateMap(typeof(StatusRegister), typeof(StatusRegisterDtoSpecializedResult));
            CreateMap(typeof(StatusRegister), typeof(StatusRegisterDtoSpecializedReport));
            CreateMap(typeof(StatusRegister), typeof(StatusRegisterDtoSpecializedDetails));

        }

    }
}
