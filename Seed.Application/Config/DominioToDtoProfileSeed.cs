using Seed.Domain.Entitys;
using Seed.Dto;

namespace Seed.Application.Config
{
    public class DominioToDtoProfileSeed : AutoMapper.Profile
    {

        public DominioToDtoProfileSeed()
        {
            CreateMap(typeof(StatusCodigo), typeof(StatusCodigoDto)).ReverseMap();
            CreateMap(typeof(StatusCodigo), typeof(StatusCodigoDtoSpecialized));
            CreateMap(typeof(StatusCodigo), typeof(StatusCodigoDtoSpecializedResult));
            CreateMap(typeof(StatusCodigo), typeof(StatusCodigoDtoSpecializedReport));
            CreateMap(typeof(StatusCodigo), typeof(StatusCodigoDtoSpecializedDetails));
            CreateMap(typeof(CodigoVerificacao), typeof(CodigoVerificacaoDto)).ReverseMap();
            CreateMap(typeof(CodigoVerificacao), typeof(CodigoVerificacaoDtoSpecialized));
            CreateMap(typeof(CodigoVerificacao), typeof(CodigoVerificacaoDtoSpecializedResult));
            CreateMap(typeof(CodigoVerificacao), typeof(CodigoVerificacaoDtoSpecializedReport));
            CreateMap(typeof(CodigoVerificacao), typeof(CodigoVerificacaoDtoSpecializedDetails));
            CreateMap(typeof(StatusDoUsuario), typeof(StatusDoUsuarioDto)).ReverseMap();
            CreateMap(typeof(StatusDoUsuario), typeof(StatusDoUsuarioDtoSpecialized));
            CreateMap(typeof(StatusDoUsuario), typeof(StatusDoUsuarioDtoSpecializedResult));
            CreateMap(typeof(StatusDoUsuario), typeof(StatusDoUsuarioDtoSpecializedReport));
            CreateMap(typeof(StatusDoUsuario), typeof(StatusDoUsuarioDtoSpecializedDetails));
            CreateMap(typeof(Usuario), typeof(UsuarioDto)).ReverseMap();
            CreateMap(typeof(Usuario), typeof(UsuarioDtoSpecialized));
            CreateMap(typeof(Usuario), typeof(UsuarioDtoSpecializedResult));
            CreateMap(typeof(Usuario), typeof(UsuarioDtoSpecializedReport));
            CreateMap(typeof(Usuario), typeof(UsuarioDtoSpecializedDetails));
            CreateMap(typeof(TipoDeUsuario), typeof(TipoDeUsuarioDto)).ReverseMap();
            CreateMap(typeof(TipoDeUsuario), typeof(TipoDeUsuarioDtoSpecialized));
            CreateMap(typeof(TipoDeUsuario), typeof(TipoDeUsuarioDtoSpecializedResult));
            CreateMap(typeof(TipoDeUsuario), typeof(TipoDeUsuarioDtoSpecializedReport));
            CreateMap(typeof(TipoDeUsuario), typeof(TipoDeUsuarioDtoSpecializedDetails));
            CreateMap(typeof(Participante), typeof(ParticipanteDto)).ReverseMap();
            CreateMap(typeof(Participante), typeof(ParticipanteDtoSpecialized));
            CreateMap(typeof(Participante), typeof(ParticipanteDtoSpecializedResult));
            CreateMap(typeof(Participante), typeof(ParticipanteDtoSpecializedReport));
            CreateMap(typeof(Participante), typeof(ParticipanteDtoSpecializedDetails));
            CreateMap(typeof(TipoDeParticipante), typeof(TipoDeParticipanteDto)).ReverseMap();
            CreateMap(typeof(TipoDeParticipante), typeof(TipoDeParticipanteDtoSpecialized));
            CreateMap(typeof(TipoDeParticipante), typeof(TipoDeParticipanteDtoSpecializedResult));
            CreateMap(typeof(TipoDeParticipante), typeof(TipoDeParticipanteDtoSpecializedReport));
            CreateMap(typeof(TipoDeParticipante), typeof(TipoDeParticipanteDtoSpecializedDetails));
            CreateMap(typeof(Turma), typeof(TurmaDto)).ReverseMap();
            CreateMap(typeof(Turma), typeof(TurmaDtoSpecialized));
            CreateMap(typeof(Turma), typeof(TurmaDtoSpecializedResult));
            CreateMap(typeof(Turma), typeof(TurmaDtoSpecializedReport));
            CreateMap(typeof(Turma), typeof(TurmaDtoSpecializedDetails));
            CreateMap(typeof(StatusDaTurma), typeof(StatusDaTurmaDto)).ReverseMap();
            CreateMap(typeof(StatusDaTurma), typeof(StatusDaTurmaDtoSpecialized));
            CreateMap(typeof(StatusDaTurma), typeof(StatusDaTurmaDtoSpecializedResult));
            CreateMap(typeof(StatusDaTurma), typeof(StatusDaTurmaDtoSpecializedReport));
            CreateMap(typeof(StatusDaTurma), typeof(StatusDaTurmaDtoSpecializedDetails));
            CreateMap(typeof(TurmaParticipante), typeof(TurmaParticipanteDto)).ReverseMap();
            CreateMap(typeof(TurmaParticipante), typeof(TurmaParticipanteDtoSpecialized));
            CreateMap(typeof(TurmaParticipante), typeof(TurmaParticipanteDtoSpecializedResult));
            CreateMap(typeof(TurmaParticipante), typeof(TurmaParticipanteDtoSpecializedReport));
            CreateMap(typeof(TurmaParticipante), typeof(TurmaParticipanteDtoSpecializedDetails));
            CreateMap(typeof(FotoDoParticipante), typeof(FotoDoParticipanteDto)).ReverseMap();
            CreateMap(typeof(FotoDoParticipante), typeof(FotoDoParticipanteDtoSpecialized));
            CreateMap(typeof(FotoDoParticipante), typeof(FotoDoParticipanteDtoSpecializedResult));
            CreateMap(typeof(FotoDoParticipante), typeof(FotoDoParticipanteDtoSpecializedReport));
            CreateMap(typeof(FotoDoParticipante), typeof(FotoDoParticipanteDtoSpecializedDetails));

        }

    }
}
