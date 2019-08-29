using Common.API.Extensions;
using Common.Domain.Enums;
using Common.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Seed.CrossCuting
{
    public static class ProfileCustom
    {

        enum ETypeRole
        {
            Admin = 1,
            Tenant = 2,
            Owner = 3,
        }

        enum ERole
        {
            Contributor,
            Reader
        }
		

		public static IDictionary<string, object> Define(IEnumerable<Claim> _claims)
        {
            var user = new CurrentUser().Init(Guid.NewGuid().ToString(), _claims.ConvertToDictionary());
            return Define(user);
        }

        public static IDictionary<string, object> Define(CurrentUser user)
        {
            var _claims = user.GetClaims();
            var roles = JsonConvert.DeserializeObject<IEnumerable<string>>(user.GetRole());
            var typeTole = user.GetTypeRole();

            if (typeTole.ToLower() == ETypeRole.Admin.ToString().ToLower())
                _claims.AddRange(ClaimsForAdmin());
            else
                _claims.AddRange(ClaimsForTenant(user.GetSubjectId<int>()));

            return _claims;
        }

        public static Dictionary<string, object> ClaimsForAdmin()
        {
            var tools = new List<dynamic>
            {
                new Tool { Icon = "fa fa-edit", Name = "DashBoard", Route = "/dashboard", Key = "DashBoard" , Type = ETypeTools.Menu },

                new Tool { Icon = "fa fa-edit", Name = "Usuários", Key = "MenuUsuario" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Usuario", Route = "/usuario", Key = "Usuario", ParentKey = "MenuUsuario" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Status", Route = "/statusdousuario", Key = "StatusDoUsuario", ParentKey = "MenuUsuario" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Tipo", Route = "/tipodeusuario", Key = "TipoDeUsuario", ParentKey = "MenuUsuario" , Type = ETypeTools.Menu },

                new Tool { Icon = "fa fa-edit", Name = "Turmas", Key = "MenuTurmaParticipante" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Alocar Aluno", Route = "/turmaparticipante", Key = "TurmaParticipante", ParentKey = "MenuTurmaParticipante" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Config Turma", Route = "/turma", Key = "Turma" , ParentKey = "MenuTurmaParticipante", Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Status", Route = "/statusdaturma", Key = "StatusDaTurma", ParentKey = "MenuTurmaParticipante" ,Type = ETypeTools.Menu },

                new Tool { Icon = "fa fa-edit", Name = "Alunos", Key = "MenuParticipante" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Config Aluno", Route = "/participante", Key = "Participante", ParentKey = "MenuParticipante" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Tipo", Route = "/tipodeparticipante", Key = "TipoDeParticipante", ParentKey = "MenuParticipante" , Type = ETypeTools.Menu },

            };
            var _toolsForAdmin = JsonConvert.SerializeObject(tools);
            return new Dictionary<string, object>
            {
                { "tools", _toolsForAdmin }
            };
        }

        public static Dictionary<string, object> ClaimsForTenant(int tenantId)
        {

            var tools = new List<Tool>
            {
                new Tool { Icon = "fa fa-edit", Name = "DashBoard", Route = "/dashboard", Key = "DashBoard" , Type = ETypeTools.Menu },

                new Tool { Icon = "fa fa-edit", Name = "Usuários", Key = "MenuUsuario" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Usuario", Route = "/usuario", Key = "Usuario", ParentKey = "MenuUsuario" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Status", Route = "/statusdousuario", Key = "StatusDoUsuario", ParentKey = "MenuUsuario" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Tipo", Route = "/tipodeusuario", Key = "TipoDeUsuario", ParentKey = "MenuUsuario" , Type = ETypeTools.Menu },

                new Tool { Icon = "fa fa-edit", Name = "Turmas", Key = "MenuTurmaParticipante" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Turma do Participante", Route = "/turmaparticipante", Key = "TurmaParticipante", ParentKey = "MenuTurmaParticipante" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Config Turma", Route = "/turma", Key = "Turma" , ParentKey = "MenuTurmaParticipante", Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Status", Route = "/statusdaturma", Key = "StatusDaTurma", ParentKey = "MenuTurmaParticipante" ,Type = ETypeTools.Menu },

                new Tool { Icon = "fa fa-edit", Name = "Alunos", Key = "MenuParticipante" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Config Aluno", Route = "/participante", Key = "Participante", ParentKey = "MenuParticipante" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Tipo", Route = "/tipodeparticipante", Key = "TipoDeParticipante", ParentKey = "MenuParticipante" , Type = ETypeTools.Menu },

            };

            var _toolsForSubscriber = JsonConvert.SerializeObject(tools);
            return new Dictionary<string, object>
            {
                { "tools", _toolsForSubscriber }
            };
        }

    }
}
