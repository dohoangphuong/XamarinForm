using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Series;
using TNPA.Model;
using System.Threading.Tasks;

namespace TNPA.Droid
{
    [Activity(Icon = "@drawable/icon", Theme = "@style/Theme.ActionBar")]
    public class ChartPieActivity : Activity
    {
        PlotView view;
        Button btnPieSeries;
        Button btnStart;
        Button btnEnd;
        TextView txtStart;
        TextView txtEnd;
        List<ModelReport> resultLstLinhVuc = new List<ModelReport>();
        DatePhanAnhTK dtPhanAnh = new DatePhanAnhTK();
        AsyncTask<DatePhanAnhTK, ModelReport, bool> tasks;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PageChartPie);

            //OxyPlot
            view = FindViewById<PlotView>(Resource.Id.plot_view);

            btnPieSeries = FindViewById<Button>(Resource.Id.btnPieSeries);
            btnStart = FindViewById<Button>(Resource.Id.btnStart);
            btnEnd = FindViewById<Button>(Resource.Id.btnEnd);
            txtStart = FindViewById<TextView>(Resource.Id.txtStart);
            txtEnd = FindViewById<TextView>(Resource.Id.txtEnd);

            //even click
            btnPieSeries.Click += btnPieSeries_Click;
            btnStart.Click += btnStart_Click;
            btnEnd.Click += btnEnd_Click;

            dtPhanAnh.dtEnd = DateTime.Now;
            dtPhanAnh.dtStart = new DateTime(dtPhanAnh.dtEnd.Year, dtPhanAnh.dtEnd.Month, 1);
            txtStart.Text = dtPhanAnh.dtStart.ToString("dd/MM/yyyy");
            txtEnd.Text = dtPhanAnh.dtEnd.ToString("dd/MM/yyyy");
            tasks = new getListTaskLinhVuc(this).Execute(dtPhanAnh);
        }
        public async Task<List<ModelReport>> getdata()
        {
            LinhVucService iLinhVuc = new LinhVucService();
            return await iLinhVuc.GetListPhanAnhThongKe(dtPhanAnh.dtStart, dtPhanAnh.dtEnd);
        }
        private async void btnPieSeries_Click(object sender, EventArgs e)
        {
             tasks = new getListTaskLinhVuc(this).Execute(dtPhanAnh);
        }

        //Chọn ngày bắt đầu
        private void btnStart_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                txtStart.Text = time.ToString("dd/MM/yyyy");
                dtPhanAnh.dtStart = time;
                //Nếu ngày bắt đầu lớn hơn ngày kết thúc cập nhật lại ngày kết thúc
                if (time > dtPhanAnh.dtEnd)
                {
                    txtEnd.Text = txtStart.Text;
                    dtPhanAnh.dtEnd = time;
                }
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        //chọn ngày kết thúc
        private void btnEnd_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                if (time >= dtPhanAnh.dtStart)
                {
                    txtEnd.Text = time.ToString("dd/MM/yyyy");
                    dtPhanAnh.dtEnd = time;
                }
                else
                {
                    txtEnd.Text = txtStart.Text;
                    dtPhanAnh.dtEnd = dtPhanAnh.dtStart;
                }
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

       public class DatePhanAnhTK
        {
            public DateTime dtStart { get; set; }
            public DateTime dtEnd { get; set; }
        }

        private class getListTaskLinhVuc : AsyncTask<DatePhanAnhTK, ModelReport, bool>
        {
            private LinhVucService _service = new LinhVucService();
            private Activity _activity;
            private PlotView view;
            List<ModelReport> resultLstLinhVuc = new List<ModelReport>();
            public getListTaskLinhVuc(Activity activity)
            {
                _activity = activity;
            }

            protected override void OnPreExecute()
            {
                base.OnPreExecute();
                //OxyPlot
                view = _activity.FindViewById<PlotView>(Resource.Id.plot_view);
                view.Model = new PlotModel
                {
                    Title = "Đang tải . . .",
                    Padding = new OxyThickness(45, 30, 45, 30),
                   // TitleFontSize = 30,
                };
            }
                       
            protected override bool RunInBackground(params DatePhanAnhTK[] @dtPhanAnh)
            {
                resultLstLinhVuc = _service.GetListPhanAnhThongKe(dtPhanAnh[0].dtStart, dtPhanAnh[0].dtEnd).Result;

                if (resultLstLinhVuc == null)
                    return false;
                return true;
            }

            protected override void OnPostExecute(bool result)
            {
                base.OnPostExecute(result);

                if (result)
                {
                    view.Model = GetChartPie();
                }
                else
                {
                    view.Model = new PlotModel
                    {
                        Title = Config.scrReportDuLieu,
                        Padding = new OxyThickness(45, 30, 45, 30),
                       // TitleFontSize = 30,
                    };
                   
                    Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(_activity);
                    alert.SetTitle(_activity.Resources.GetString(Resource.String.loi));
                    alert.SetMessage(_activity.Resources.GetString(Resource.String.loidata));
                    alert.SetNegativeButton(_activity.Resources.GetString(Resource.String.dongy), (senderAlert, args) =>
                    {
                        Dispose();
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                }
            }

            //Chart pie
            private PlotModel GetChartPie()
            {
                PlotModel modellP1 = new PlotModel
                {
                    //Title = "BIỂU ĐỒ",
                    Padding = new OxyThickness(45, 30, 45, 30),
                    //TitleFontSize = 30,
                };

                //DefaultFontSize            
                if (resultLstLinhVuc.Count() > 0)
                {
                    //kiểm tra có phản ánh không
                    bool resultNotData = true;
                    for (int i = 0; i < resultLstLinhVuc.Count(); i++)
                    {
                        if (resultLstLinhVuc[i].TOTAL > 0)
                        {
                            resultNotData = false;
                            break;
                        }
                    }
                    if (resultNotData)
                    {
                        modellP1.Title = Config.scrReportDuLieu;
                    }
                    else
                    {
                        var seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

                        seriesP1.Slices.Add(new PieSlice(resultLstLinhVuc[0].TenLinhVuc, (double)resultLstLinhVuc[0].TOTAL) { IsExploded = false, Fill = OxyColors.PaleVioletRed });

                        if (resultLstLinhVuc.Count() > 1)
                        {
                            for (int i = 1; i < resultLstLinhVuc.Count(); i++)
                            {
                                seriesP1.Slices.Add(new PieSlice(resultLstLinhVuc[i].TenLinhVuc, (double)resultLstLinhVuc[i].TOTAL) { IsExploded = true });
                            }
                            modellP1.Series.Add(seriesP1);
                        }
                    }
                }
                else
                {
                    modellP1.Title = Config.scrReportDuLieu;
                }

                return modellP1;
            }
        }
    }
}