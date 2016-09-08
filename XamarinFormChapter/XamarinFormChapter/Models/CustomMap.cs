using System.Collections.Generic;
using Xamarin.Forms.Maps;
using XamarinFormChapter.Models;

namespace XamarinFormChapter
{
	public class CustomMap : Map
	{
		public List<CustomPin> CustomPins { get; set; }
    }
}
