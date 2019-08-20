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
                new Tool { Icon = "fa fa-edit", Name = "Status Do Usuario", Route = "/statusdousuario", Key = "StatusDoUsuario" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Usuario", Route = "/usuario", Key = "Usuario" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Tipo De Usuario", Route = "/tipodeusuario", Key = "TipoDeUsuario" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Participante", Route = "/participante", Key = "Participante" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Tipo De Participante", Route = "/tipodeparticipante", Key = "TipoDeParticipante" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Turma do Participante", Route = "/turmaparticipante", Key = "TurmaParticipante" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Turma", Route = "/turma", Key = "Turma" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Status Da Turma", Route = "/statusdaturma", Key = "StatusDaTurma" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Foto do Participante", Route = "/fotodoparticipante", Key = "fotodoparticipante", Type = ETypeTools.Menu}
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
                new Tool { Icon = "fa fa-edit", Name = "StatusDoUsuario", Route = "/statusdousuario", Key = "StatusDoUsuario" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Usuario", Route = "/usuario", Key = "Usuario" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "TipoDeUsuario", Route = "/tipodeusuario", Key = "TipoDeUsuario" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Participante", Route = "/participante", Key = "Participante" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "TipoDeParticipante", Route = "/tipodeparticipante", Key = "TipoDeParticipante" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "TurmaParticipante", Route = "/turmaparticipante", Key = "TurmaParticipante" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "Turma", Route = "/turma", Key = "Turma" , Type = ETypeTools.Menu },
                new Tool { Icon = "fa fa-edit", Name = "StatusDaTurma", Route = "/statusdaturma", Key = "StatusDaTurma" , Type = ETypeTools.Menu },

            };

            var _toolsForSubscriber = JsonConvert.SerializeObject(tools);
            return new Dictionary<string, object>
            {
                { "tools", _toolsForSubscriber }
            };
        }

    }
}
