﻿using AngularConsumer1.Configuration.Interfaces;
using AngularConsumer1.Models.Categories;
using FRED.Api.Series.ApiFacades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AngularConsumer1.Controllers.Series
{
	[Route("api/[controller]")]
	public class SeriesCategoriesController : ControllerBase
	{
		#region fields

		private readonly IControllerCommon controllerCommon;
		private readonly ISeriesCategories api;
		private readonly IAppSettings appSettings;
		private readonly ILogger<SeriesCategoriesController> logger;

		#endregion

		#region constructors

		public SeriesCategoriesController(
			IControllerCommon controllerCommon,
			ISeriesCategories api,
			IAppSettings appSettings,
			ILogger<SeriesCategoriesController> logger)
		{
			this.controllerCommon = controllerCommon;
			this.api = api;
			this.appSettings = appSettings;
			this.logger = logger;
		}

		#endregion

		#region public methods

		[Produces("application/json")]
		[ProducesResponseType(200, Type = typeof(string))]
		[ProducesResponseType(500, Type = typeof(string))]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAsync(string id, DateTime? realtime_start, DateTime? realtime_end,
			int? limit, int? offset, string order_by, string sort_order,
			string tag_names, string tag_group_id, string search_text)
		{
			CategoryResponse result = new CategoryResponse();

			try
			{
				api.Arguments.ApiKey = appSettings.ApiKey;
				api.Arguments.series_id = id;

				result.container = await api.FetchAsync();

				controllerCommon.SetApiValues(api, api.Arguments.ValidationErrors, result);
			}
			catch (Exception exception)
			{
				logger.LogError(exception, "GetSeriesCategories failed");
				return StatusCode(500);
			}

			return Ok(result);
		}

		#endregion

	}

}