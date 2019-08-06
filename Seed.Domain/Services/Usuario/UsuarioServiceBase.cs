using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Repository;
using Seed.Domain.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seed.Domain.Services
{
    public class UsuarioServiceBase : ServiceBase<Usuario>
    {
        protected readonly IUsuarioRepository _rep;

        public UsuarioServiceBase(IUsuarioRepository rep, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
			this._user = user;
        }

        public virtual async Task<Usuario> GetOne(UsuarioFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Usuario>> GetByFilters(UsuarioFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Usuario>> GetByFiltersPaging(UsuarioFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(Usuario usuario)
        {
            this._rep.Remove(usuario);
        }

        public virtual Summary GetSummary(PaginateResult<Usuario> paginateResult)
        {
            return new Summary
            {
                Total = paginateResult.TotalCount,
				PageSize = paginateResult.PageSize,
            };
        }

        public virtual ValidationSpecificationResult GetDomainValidation(FilterBase filters = null)
        {
            return this._validationResult;
        }

        public virtual ConfirmEspecificationResult GetDomainConfirm(FilterBase filters = null)
        {
            return this._validationConfirm;
        }

        public virtual WarningSpecificationResult GetDomainWarning(FilterBase filters = null)
        {
            return this._validationWarning;
        }

        public override async Task<Usuario> Save(Usuario usuario, bool questionToContinue = false)
        {
			var usuarioOld = await this.GetOne(new UsuarioFilter { UsuarioId = usuario.UsuarioId });
			var usuarioOrchestrated = await this.DomainOrchestration(usuario, usuarioOld);

            if (questionToContinue)
            {
                if (this.Continue(usuarioOrchestrated, usuarioOld) == false)
                    return usuarioOrchestrated;
            }

            return this.SaveWithValidation(usuarioOrchestrated, usuarioOld);
        }

        public override async Task<Usuario> SavePartial(Usuario usuario, bool questionToContinue = false)
        {
            var usuarioOld = await this.GetOne(new UsuarioFilter { UsuarioId = usuario.UsuarioId });
			var usuarioOrchestrated = await this.DomainOrchestration(usuario, usuarioOld);

            if (questionToContinue)
            {
                if (this.Continue(usuarioOrchestrated, usuarioOld) == false)
                    return usuarioOrchestrated;
            }

            return SaveWithOutValidation(usuarioOrchestrated, usuarioOld);
        }

        protected override Usuario SaveWithOutValidation(Usuario usuario, Usuario usuarioOld)
        {
            usuario = this.SaveDefault(usuario, usuarioOld);
			this._cacheHelper.ClearCache();

			if (!usuario.IsValid())
			{
				this._validationResult = usuario.GetDomainValidation();
				this._validationWarning = usuario.GetDomainWarning();
				return usuario;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return usuario;
        }

		protected override Usuario SaveWithValidation(Usuario usuario, Usuario usuarioOld)
        {
            if (!this.IsValid(usuario))
				return usuario;
            
            usuario = this.SaveDefault(usuario, usuarioOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return usuario;
        }
		
		protected virtual bool IsValid(Usuario entity)
        {
            var isValid = true;
            if (!this.DataAnnotationIsValid() || !entity.IsValid())
            {
                if (this._validationResult.IsNull())
                    this._validationResult = entity.GetDomainValidation();
                else
                    this._validationResult.Merge(entity.GetDomainValidation());

                if (this._validationWarning.IsNull())
                    this._validationWarning = entity.GetDomainWarning();
                else
                    this._validationWarning.Merge(entity.GetDomainWarning());

                isValid = false;
            }

            this.Specifications(entity);
            if (!this._validationResult.IsValid)
                isValid = false;

            return isValid;
        }

		protected virtual void Specifications(Usuario usuario)
        {
            this._validationResult  = this._validationResult.Merge(new UsuarioIsSuitableValidation(this._rep).Validate(usuario));
			this._validationWarning  = this._validationWarning.Merge(new UsuarioIsSuitableWarning(this._rep).Validate(usuario));
        }

        protected virtual Usuario SaveDefault(Usuario usuario, Usuario usuarioOld)
        {
			usuario = this.AuditDefault(usuario, usuarioOld);

            var isNew = usuarioOld.IsNull();			
            if (isNew)
                usuario = this.AddDefault(usuario);
            else
				usuario = this.UpdateDefault(usuario);

            return usuario;
        }
		
        protected virtual Usuario AddDefault(Usuario usuario)
        {
            usuario = this._rep.Add(usuario);
            return usuario;
        }

		protected virtual Usuario UpdateDefault(Usuario usuario)
        {
            usuario = this._rep.Update(usuario);
            return usuario;
        }
				
		public virtual async Task<Usuario> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Usuario.UsuarioFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<Usuario> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Usuario.UsuarioFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
