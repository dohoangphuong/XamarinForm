using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNPA.Model;
using UIKit;

namespace TNPA.iOS
{
	public partial class GrowRowTableViewController : UITableViewController
	{
        private LinhVucService _service = new LinhVucService();
        private List<DmLinhVuc> _items;
        #region Computed Properties
        public GrowRowTableDataSource DataSource {
			get { return TableView.DataSource as GrowRowTableDataSource; }
		}

		public GrowRowTableDelegate TableDelegate {
			get { return TableView.Delegate as GrowRowTableDelegate; }
		}
		#endregion

		#region Constructors
		public GrowRowTableViewController (IntPtr handle) : base (handle)
		{
		}
        #endregion

        #region Get data to service
        protected async Task<ListResult> RunInBackground()
        {
            return _service.GetListLinhVuc().Result;
        }
        protected async void OnPostExecute()
        {
            var result = await RunInBackground();
            if (result != null)
            {
                _items = (List<DmLinhVuc>)result.ClassResult;
                TableView.DataSource = new GrowRowTableDataSource(this, _items);                
            }
            else
            {
                UIAlertView alert = new UIAlertView()
                {
                    Title = "Lỗi",
                    Message = "Không thể kết nối với server vui lòng kiểm tra lại"
                };
                alert.AddButton("OK");
                alert.Show();
            }
        }
        #endregion

        #region Override Methods
        public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

            // Initialize table
            OnPostExecute();
            TableView.Delegate = new GrowRowTableDelegate (this);
			TableView.EstimatedRowHeight = 50f;
			TableView.ReloadData ();
		}
			

		#endregion
	}
}
