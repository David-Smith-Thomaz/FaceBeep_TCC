using Common.Gen;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seed.Gen
{
    public class ConfigContext
    {
        #region Config Contexts

        private Context ConfigContextDefault()
        {
            var contextName = "Seed";

            return new Context
            {

                ConnectionString = ConfigurationManager.ConnectionStrings["Seed"].ConnectionString,

                Namespace = "Seed",
                ContextName = contextName,
                ShowKeysInFront = false,
                LengthBigField = 250,
                OverrideFiles = true,
                UseRouteGuardInFront = true,

                OutputClassDomain = ConfigurationManager.AppSettings[string.Format("outputClassDomain")],
                OutputClassInfra = ConfigurationManager.AppSettings[string.Format("outputClassInfra")],
                OutputClassDto = ConfigurationManager.AppSettings[string.Format("outputClassDto")],
                OutputClassApp = ConfigurationManager.AppSettings[string.Format("outputClassApp")],
                OutputClassApi = ConfigurationManager.AppSettings[string.Format("outputClassApi")],
                OutputClassFilter = ConfigurationManager.AppSettings[string.Format("outputClassFilter")],
                OutputClassSummary = ConfigurationManager.AppSettings[string.Format("outputClassSummary")],
                OutputAngular = ConfigurationManager.AppSettings["OutputAngular"],
                OutputClassSso = ConfigurationManager.AppSettings["OutputClassSso"],
                OutputClassCrossCustingAuth = ConfigurationManager.AppSettings["OutputClassCrossCustingAuth"],

                Arquiteture = ArquitetureType.DDD,
                CamelCasing = true,
                MakeFront = true,
                AlertNotFoundTable = true,
                MakeToolsProfile = false,

                Routes = new List<RouteConfig> {
                    new RouteConfig{ Route = "{ path: 'dashboard',  canActivate: [AuthGuard], loadChildren: './main/dashboard/dashboard.module#DashBoardModule' }" }
                },
                
                TableInfo = new UniqueListTableInfo
                {
                   new TableInfo().FromTable("StatusDoUsuario").MakeBack().MakeFront(),
                   new TableInfo().FromTable("Usuario").MakeBack().MakeFront(),
                   new TableInfo().FromTable("TipoDeUsuario").MakeBack().MakeFront(),
                   new TableInfo().FromTable("Participante").MakeBack().MakeFront(),
                   new TableInfo().FromTable("TipoDeParticipante").MakeBack().MakeFront(),
                   new TableInfo().FromTable("Turma").MakeBack().MakeFront(),
                   new TableInfo().FromTable("StatusDaTurma").MakeBack().MakeFront(),
                   new TableInfo().FromTable("TurmaParticipante").MakeBack().MakeFront(),
                   new TableInfo().FromTable("FotoDoParticipante").MakeBack().MakeFront()
                }
            };
        }




        public IEnumerable<Context> GetConfigContext()
        {

            return new List<Context>
            {

                ConfigContextDefault(),

            };

        }

        #endregion
    }
}
