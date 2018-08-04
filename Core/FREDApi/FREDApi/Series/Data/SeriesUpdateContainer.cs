﻿using FRED.Api.Core;
using FRED.Api.Core.Data;
using System.Collections.Generic;

namespace FRED.Api.Series.Data
{
	/// <summary>
	/// Provides data properties for a series update container, including a collection of series (seriess). 
	/// </summary>
	public class SeriesUpdateContainer : ExtendedContainer<FREDData.series_order_by_values>
	{
		#region properties

		public string filter_variable { get; set; }
		public FREDData.filter_value_values filter_value { get; set; }

		public List<SeriesItem> seriess { get; set; }

		#endregion

	}
}
