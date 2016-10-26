using Alliance.Charts;
using Foundation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNPA.Model;
using UIKit;

namespace TNPA.iOS
{
    public partial class ThongKeController : UIViewController
    {

        //Create Instance for AllianceChart Classes
        public AllianceChart AllianceChart { get; set; }
        private Random random = new Random();
        private List<ModelReport> resultLstLinhVuc = new List<ModelReport>();
        private LinhVucService _service = new LinhVucService();
        private DatePhanAnhTK dtPhanAnh = new DatePhanAnhTK();

        public ThongKeController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Khai báo thời gian mặc định: Từ ngày đầu tháng đến ngày hiện tại
            dtPhanAnh.dtEnd = DateTime.Now;
            dtPhanAnh.dtStart = new DateTime(dtPhanAnh.dtEnd.Year, dtPhanAnh.dtEnd.Month, 01);
            getNameButton();
            //Khai báo sự kiện click button Biểu đồ
            btnBieuDo.TouchUpInside += BtnBieuDo_TouchUpInside;
            btnDateStart.TouchUpInside += BtnDateStart_TouchUpInside;
            btnDateEnd.TouchUpInside += BtnDateEnd_TouchUpInside;
            var result = getDataLinhVuc();
            if (result!=null)
				createPieChart();
        }

        private void getNameButton()
        {
            btnDateStart.SetTitle(dtPhanAnh.dtStart.ToString("dd/MM/yyyy"), UIControlState.Normal);
            btnDateEnd.SetTitle(dtPhanAnh.dtEnd.ToString("dd/MM/yyyy"), UIControlState.Normal);
        }

        public void createPieChart()
        {
            //Pie Chart: Create object for AllianceChart by Passing ChartType and the View in which chart need to be populated.
            this.AllianceChart = new AllianceChart(Chart.Pie, this.View);

            //Add more ChartComponent for more Slices in Pie Chart
            AllianceChart.PieChart.SameColorLabel = false;
            AllianceChart.PieChart.TitleFont = UIFont.FromName("HelveticaNeue-Bold", 15f);
            AllianceChart.PieChart.PercentageFont = UIFont.FromName("HelveticaNeue-Bold", 15f);

            //Khai báo dữ liệu vào biểu đồ
            getDataChart();
            this.View.SetNeedsDisplay();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        /// <summary>
        /// ModalPickerViewController: Class này chứa các mô tả về DateTimePicker
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //event click của button btnDateStart
        private async void BtnDateStart_TouchUpInside(object sender, EventArgs e)
        {
            var modalPicker = new ModalPickerViewController(ModalPickerType.Date, "Ngày bắt đầu", this)
            {
                HeaderBackgroundColor = UIColor.Blue,
                HeaderTextColor = UIColor.White,
                TransitioningDelegate = new ModalPickerTransitionDelegate(),
                ModalPresentationStyle = UIModalPresentationStyle.Custom
            };

            modalPicker.DatePicker.Mode = UIDatePickerMode.Date;

            modalPicker.OnModalPickerDismissed += (s, ea) =>
            {
                var dateFormatter = new NSDateFormatter()
                {
                    DateFormat = "dd/MM/yyyy"
                };

                btnDateStart.SetTitle(dateFormatter.ToString(modalPicker.DatePicker.Date), UIControlState.Normal);
                dtPhanAnh.dtStart = DateTime.ParseExact(dateFormatter.ToString(modalPicker.DatePicker.Date), "dd/MM/yyyy", null);
            };

            await PresentViewControllerAsync(modalPicker, true);
        }

        //event click của button btnDateEnd
        private void BtnDateEnd_TouchUpInside(object sender, EventArgs e)
        {
            var modalPicker = new ModalPickerViewController(ModalPickerType.Date, "Ngày kết thúc", this)
            {
                HeaderBackgroundColor = UIColor.Blue,
                HeaderTextColor = UIColor.White,
                TransitioningDelegate = new ModalPickerTransitionDelegate(),
                ModalPresentationStyle = UIModalPresentationStyle.Custom
            };

            modalPicker.DatePicker.Mode = UIDatePickerMode.Date;

            modalPicker.OnModalPickerDismissed += (s, ea) =>
            {
                var dateFormatter = new NSDateFormatter()
                {
                    DateFormat = "dd/MM/yyyy"
                };

                btnDateEnd.SetTitle(dateFormatter.ToString(modalPicker.DatePicker.Date), UIControlState.Normal);
                dtPhanAnh.dtEnd = DateTime.ParseExact(dateFormatter.ToString(modalPicker.DatePicker.Date), "dd/MM/yyyy", null);
            };
        }

        private async void BtnBieuDo_TouchUpInside(object sender, EventArgs e)
        {
			var result = await getDataLinhVuc();
			if(result!=null)
				createPieChart();
        }

        private void getDataChart()
        {
            //Nếu có danh sách lĩnh vực       
            if (resultLstLinhVuc.Count > 0)
            {
                //kiểm tra có phản ánh không
                bool resultNotData = true;
                for (int i = 0; i < resultLstLinhVuc.Count; i++)
                {
                    if (resultLstLinhVuc[i].TOTAL > 0)
                    {
                        resultNotData = false;
                        break;
                    }
                }
               
                //Nếu có danh sách lĩnh vực mà không có phản ánh nào thì hiển thị thông báo.
                if (resultNotData)
                {
                    // modellP1.Title = Config.scrReportDuLieu;
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "Thông báo",
                        Message = "Không có phản ánh nào trong khoảng thời gian trên"
                    };
                    alert.AddButton("OK");
                    alert.Show();
                }
                //Nếu ngược lại có dữ liệu
                else
                {             
                    List<ChartComponent> Components = new List<ChartComponent>();
                    
                    for (int i = 1; i < resultLstLinhVuc.Count; i++)
                    {
                        Components.Add(createComponents(resultLstLinhVuc[i].TenLinhVuc, (float)resultLstLinhVuc[i].TOTAL));
                    }

                    AllianceChart.LoadChart(Components, Chart.Pie, this.View);
                }
            }
            //Nếu không có danh sách lĩnh vực nào
            else
            {
                UIAlertView alert = new UIAlertView()
                {
                    Title = "Lỗi",
                    Message = "Không có lĩnh vực, vui lòng kiểm tra lại"
                };
                alert.AddButton("OK");
                alert.Show();
            }
        }


        //lấy dữ liệu từ Webservice
        public async Task<List<ModelReport>> getDataLinhVuc()
        {
            resultLstLinhVuc = await _service.GetListPhanAnhThongKe(dtPhanAnh.dtStart, dtPhanAnh.dtEnd);

            return resultLstLinhVuc;
        }

        public void createPieChartDemo()
        {
            List<ChartComponent> Components = new List<ChartComponent>();

            Components.Add(createComponents("Africa", 1030));
            Components.Add(createComponents("Americas", 929));
            Components.Add(createComponents("Asia", 4157));
            Components.Add(createComponents("Europe", 739));
            Components.Add(createComponents("Oceania", 35));

            //Add more ChartComponent for more Slices in Pie Chart
            AllianceChart.PieChart.SameColorLabel = false;
            AllianceChart.PieChart.TitleFont = UIFont.FromName("HelveticaNeue-Bold", 15f);
            AllianceChart.PieChart.PercentageFont = UIFont.FromName("HelveticaNeue-Bold", 15f);

            AllianceChart.LoadChart(Components, Chart.Pie, this.View);
        }

        public ChartComponent createComponents(string name, float value)
        {
            //Khai báo thuộc tính component
            ChartComponent ChartComponents = new ChartComponent();
            ChartComponents.Name = name;
            ChartComponents.axisLabelColor = UIColor.Black;
            ChartComponents.value = value;

            //thêm auto color
            System.Threading.Thread.Sleep(10);
            float red = random.Next(0, 256);
            System.Threading.Thread.Sleep(10);
            nfloat screen = random.Next(0, 256);
            System.Threading.Thread.Sleep(10);
            nfloat blue = random.Next(0, 256);
            ChartComponents.color = UIColor.FromRGBA(red / 255, screen / 255, blue / 255, 1.0f);

            return ChartComponents;
        }

        ////Ví dụ demo thêm dữ liệu vào biểu đồ
        //public void createPieChartDemo()
        //{
        //    List<ChartComponent> Components = new List<ChartComponent>();

        //    Components.Add(createComponents("Africa", 1030));
        //    Components.Add(createComponents("Americas", 929));
        //    Components.Add(createComponents("Asia", 4157));
        //    Components.Add(createComponents("Europe", 739));
        //    Components.Add(createComponents("Oceania", 35));

        //    //Add more ChartComponent for more Slices in Pie Chart
        //    AllianceChart.PieChart.SameColorLabel = false;
        //    AllianceChart.PieChart.TitleFont = UIFont.FromName("HelveticaNeue-Bold", 15f);
        //    AllianceChart.PieChart.PercentageFont = UIFont.FromName("HelveticaNeue-Bold", 15f);

        //    AllianceChart.LoadChart(Components, Chart.Pie, this.View);
        //}
        /*Một số tùy chỉnh
        //To show value color same as PieChart slice color
        AllianceChart.PieChart.SameColorLabel = true; 

        //To customize Font of Name given to slice
        AllianceChart.PieChart.TitleFont = UIFont.FromName ("HelveticaNeue-Bold",15f);

        //To customize Font of Value given to slice 
        AllianceChart.PieChart.PercentageFont = UIFont.FromName ("HelveticaNeue-Bold",15f);

        //To show arrow to from the PieChart slice to value. By default it will be true
        AllianceChart.PieChart.ShowArrow = false;

        //To draw outline for the PieChart. By default it will be true
        AllianceChart.PieChart.Outline = false;

        //To set color to Arrow
        AllianceChart.PieChart.ArrowColor = UIColor.Black;

        //To show value or calculate and show percentange value of slice
        AllianceChart.PieChart.ShowPercentage = false; 
         */
    }

    public class DatePhanAnhTK
    {
        public DateTime dtStart { get; set; }
        public DateTime dtEnd { get; set; }
    }
}