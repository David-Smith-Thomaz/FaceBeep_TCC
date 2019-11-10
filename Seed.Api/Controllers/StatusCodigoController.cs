﻿using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Seed.Application.Interfaces;
using Seed.Domain.Filter;
using Seed.Dto;
using Common.API;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Seed.CrossCuting;

namespace Seed.Api.Controllers
{
	[Authorize]
    [Route("api/[controller]")]
    public class StatusCodigoController : Controller
    {

        private readonly IStatusCodigoApplicationService _app;
		private readonly ILogger _logger;
		private readonly IHostingEnvironment _env;
      
        public StatusCodigoController(IStatusCodigoApplicationService app, ILoggerFactory logger, IHostingEnvironment env)
        {
            this._app = app;
			this._logger = logger.CreateLogger<StatusCodigoController>();
			this._env = env;
        }

		[Authorize(Policy = "CanRead")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]StatusCodigoFilter filters)
        {
            var result = new HttpResult<StatusCodigoDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                var responseEx = result.ReturnCustomException(ex,"Seed - StatusCodigo", filters, new ErrorMapCustom());
				return responseEx;
            }

        }


		[HttpGet("{id}")]
		[Authorize(Policy = "CanRead")]
		public async Task<IActionResult> Get(int id, [FromQuery]StatusCodigoFilter filters)
		{
			var result = new HttpResult<StatusCodigoDto>(this._logger);
            try
            {
				if (id.IsSent()) filters.StatusCodigoId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                var responseEx = result.ReturnCustomException(ex,"Seed - StatusCodigo", id);
				return responseEx;
            }

		}



        [Authorize(Policy = "CanSave")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]StatusCodigoDtoSpecialized dto)
        {
            var result = new HttpResult<StatusCodigoDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                var responseEx = result.ReturnCustomException(ex,"Seed - StatusCodigo", dto, new ErrorMapCustom());
				return responseEx;
            }
        }


		[Authorize(Policy = "CanEdit")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]StatusCodigoDtoSpecialized dto)
        {
            var result = new HttpResult<StatusCodigoDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                var responseEx = result.ReturnCustomException(ex,"Seed - StatusCodigo", dto, new ErrorMapCustom());
				return responseEx;
            }
        }

		[Authorize(Policy = "CanDelete")]
        [HttpDelete]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, StatusCodigoDto dto)
        {
            var result = new HttpResult<StatusCodigoDto>(this._logger);
            try
            {
				if (id.IsSent()) dto.StatusCodigoId = id;
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                var responseEx = result.ReturnCustomException(ex,"Seed - StatusCodigo", dto, new ErrorMapCustom());
				return responseEx;
            }
        }



    }
}