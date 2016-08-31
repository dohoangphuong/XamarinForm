using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace XamarinFormChapter.Models
{
	public class CustomMap : Map
	{
		public List<CustomPin> CustomPins { get; set; }
	}
}
