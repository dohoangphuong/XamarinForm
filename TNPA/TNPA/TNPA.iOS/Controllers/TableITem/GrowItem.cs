using System;
using UIKit;

namespace TNPA.iOS
{
	public class GrowItem
	{
		#region Computed Properties
		public string ImageName { get; set; } = "";
        public int Count { get; set; } = 0;
        public string Title { get; set; } = "";
		public string Description { get; set; } = "";
		#endregion

		#region Constructors
		public GrowItem ()
		{
		}

        public GrowItem(string imageName, string title, string description)
        {
            // Initialize
            this.ImageName = imageName;
            this.Title = title;
            this.Description = description;
        }

            public GrowItem(string imageName, string title, int count)
        {
            // Initialize
            this.ImageName = imageName;
            this.Title = title;
            this.Count = count;
        }

        #endregion

    }
}

