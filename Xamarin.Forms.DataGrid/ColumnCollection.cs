﻿using System.Collections.Generic;

namespace Xamarin.Forms.DataGrid
{
	public sealed class ColumnCollection : List<DataGridColumn>
	{
		public ColumnCollection()
		{
		}

		public ColumnCollection(ColumnCollection columns)
			:base(columns)
		{
		}
	}
}
