﻿using Common.API;
using Common.API.Extensions;
using Common.Domain.Base;
using Common.Domain.Enums;
using Common.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Seed.Application.Interfaces;
using Seed.CrossCuting;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Repository;
using Seed.Dto;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Seed.Api.Controllers
{
	[Authorize]
    [Route("api/sample/more")]
    public class SampleMoreController : Controller
    {

        private readonly ISampleRepository _rep;
        private readonly ISampleApplicationService _app;
		private readonly ILogger _logger;
		private readonly EnviromentInfo _env;
		private readonly CurrentUser _user;

        public SampleMoreController(ISampleRepository rep, ISampleApplicationService app, ILoggerFactory logger, EnviromentInfo env,CurrentUser user)
        {
            this._rep = rep;
            this._app = app;
			this._logger = logger.CreateLogger<SampleMoreController>();
			this._env = env;
			this._user = user;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]SampleFilter filters)
        {
            var result = new HttpResult<dynamic>(this._logger);
            try
            {
                if (filters.FilterBehavior == FilterBehavior.GetDataItem)
                {
                    var searchResult = await this._rep.GetDataItem(filters);
                    return result.ReturnCustomResponse(searchResult, filters);
                }

				if (!this._user.GetClaims().GetTools().VerifyClaimsCanRead("Sample"))
                {
                    return new ObjectResult(null)
                    {
                        StatusCode = (int)HttpStatusCode.Forbidden
                    };
                }


                if (filters.FilterBehavior == FilterBehavior.GetDataCustom)
                {
                    var searchResult = await this._rep.GetDataCustom(filters);
                    return result.ReturnCustomResponse(searchResult, filters);
                }

                if (filters.FilterBehavior == FilterBehavior.GetDataListCustom)
                {
                    var searchResult = await this._rep.GetDataListCustom(filters);
                    return result.ReturnCustomResponse(searchResult, filters);
                }

				if (filters.FilterBehavior == FilterBehavior.GetDataListCustomPaging)
                {
                    var paginatedResult = await this._rep.GetDataListCustomPaging(filters);
                    return result.ReturnCustomResponse(paginatedResult.ToSearchResult<dynamic>(), filters);
                }

				
				if (filters.FilterBehavior == FilterBehavior.Export)
                {
					var searchResult = await this._rep.GetDataListCustom(filters);
                    var export = new ExportExcelCustom<dynamic>(filters);
                    var file = export.ExportFile(this.Response, searchResult, "Sample", this._env.RootPath);
                    return File(file, export.ContentTypeExcel(), export.GetFileName());
                }

                throw new InvalidOperationException("invalid FilterBehavior");

            }
            catch (Exception ex)
            {
                var responseEx = result.ReturnCustomException(ex,"Seed - Sample", filters, new ErrorMapCustom());
				return responseEx;
            }
        }

		[Authorize(Policy = "CanWrite")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]IEnumerable<SampleDtoSpecialized> dtos)
        {
            var result = new HttpResult<SampleDto>(this._logger);
            try
            {
                var returnModels = await this._app.Save(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                var responseEx = result.ReturnCustomException(ex,"Seed - Sample", dtos, new ErrorMapCustom());
				return responseEx;
            }

        }
		
		[Authorize(Policy = "CanWrite")]
		[HttpPut]
        public async Task<IActionResult> Put([FromBody]IEnumerable<SampleDtoSpecialized> dtos)
        {
            var result = new HttpResult<SampleDto>(this._logger);
            try
            {
                var returnModels = await this._app.SavePartial(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                var responseEx = result.ReturnCustomException(ex, "Seed - Sample", dtos, new ErrorMapCustom());
				return responseEx;
            }

        }

    }
}
