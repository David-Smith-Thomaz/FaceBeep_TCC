﻿using Common.Domain.Interfaces;
using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using Seed.Domain.Interfaces.Services;

namespace Seed.Domain.Services
{
    public class TipoDeParticipanteService : TipoDeParticipanteServiceBase, ITipoDeParticipanteService
    {

        public TipoDeParticipanteService(ITipoDeParticipanteRepository rep, ICache cache, CurrentUser user) 
            : base(rep, cache, user)
        {


        }
        
    }
}
