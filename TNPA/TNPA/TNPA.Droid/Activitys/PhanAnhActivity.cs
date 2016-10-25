using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Widget;

using Android.Views;
using Android.Locations;
using Android.Runtime;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Android.Gms.Maps.Model;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;
using System.IO;
using Android.Graphics.Drawables;
using TNPA.Model;
using Android.Preferences;
using Android.Database;
using Android.Views.InputMethods;
using Android.Gms.Gcm;

namespace TNPA.Droid
{
    public static class App
    {
        public static Java.IO.File _file;
        public static Java.IO.File _dir;
        public static Bitmap bitmap;
    }

    [Activity(Label = "TabActivity")]
    public class PhanAnhActivity : Activity, ILocationListener
    {
        private LinearLayout imageLayout;
        private EditText _addressText;
        private LatLng _currentLocation;
        private LocationManager _locationManager;
        private string _locationProvider;
        Button btnGui, btnMap;
        EditText txtVitri, txtNoiDung;
        List<Files> listFile = new List<Files>();
        ProgressDialog progress;
        ISharedPreferences prefs;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.phananh);
            btnMap = FindViewById<Button>(Resource.Id.btnGetMap);
            btnGui = FindViewById<Button>(Resource.Id.btnGui);
            txtVitri = FindViewById<EditText>(Resource.Id.txtViTri);
            txtNoiDung = FindViewById<EditText>(Resource.Id.txtNoiDung);
            _addressText = FindViewById<EditText>(Resource.Id.txtViTri);
            imageLayout = FindViewById<LinearLayout>(Resource.Id.imageLayout);

            if (IsThereAnAppToTakePictures())// Kiểm tra hình 
            {
                CreateDirectoryForPictures();// Tạo đường dẫn hình
                imageLayout.Visibility = ViewStates.Gone;// Ẩn view hình khi chưa có hình

                // Tạo sự kiện gọi dialog chọn hình
                Button button = FindViewById<Button>(Resource.Id.btnCamera);
                button.Click += CallImage;
            }

            btnMap.Click += OpenMap;
            txtVitri.FocusChange += checkFocus;
            txtNoiDung.FocusChange += checkFocus;

            btnGui.Visibility = ViewStates.Gone;// mới vào ẩn nút gửi

            // Sau khi nhập đầy đủ thông tin nhấp vào màn hình để hiện nút gửi
            LinearLayout scrolllayout = FindViewById<LinearLayout>(Resource.Id.scrolllayout);
            scrolllayout.Click +=checkView;
            RelativeLayout mainlayout = FindViewById<RelativeLayout>(Resource.Id.mainlayout);
            mainlayout.Click += checkView;
            
            // Gửi phản ánh
            btnGui.Click += (sender, arg) =>
            {
                if (string.IsNullOrEmpty(txtNoiDung.Text.Trim()) || string.IsNullOrEmpty(txtVitri.Text.Trim()))
                {
                    Toast.MakeText(this, Resource.String.nhapthieu, ToastLength.Short).Show();
                }
                else
                {
                    Intent intent = new Intent(this, typeof(ThongTinActivity));
                    StartActivityForResult(intent, (int)Config.Active.Caidat);
                }
            };

            // Hiện dialog tìm vị trí hiện tại
            progress = ProgressDialog.Show(this, Resources.GetString(Resource.String.vuilongcho), Resources.GetString(Resource.String.timvitri), true);
        }
        /// <summary>
        /// Hàm này sẽ kiểm tra giá trị được gửi về trừ các màn hình khác như map, camera , thư viện ảnh, cai dat
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="resultCode"></param>
        /// <param name="data"></param>
        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            
            if (requestCode == (int)Config.Active.TakeAPicture)
            {
                if (resultCode == Result.Ok)
                {
                    Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                    Uri contentUri = Uri.FromFile(App._file);
                    mediaScanIntent.SetData(contentUri);
                    SendBroadcast(mediaScanIntent);

                    int height = Resources.DisplayMetrics.HeightPixels;
                    int width = Resources.DisplayMetrics.WidthPixels;
                    App.bitmap = App._file.Path.LoadAndResizeBitmap(width, height);
                    if (App.bitmap != null)
                    {
                        ImageView _imageView = new ImageView(this);// Tạo hình và add vào view
                        _imageView.SetScaleType(ImageView.ScaleType.FitCenter);
                        _imageView.SetImageBitmap(App.bitmap);
                        LinearLayout.LayoutParams layoutparams  = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,200);
                        layoutparams.BottomMargin = 10;

                        imageLayout.AddView(_imageView, layoutparams);
                        imageLayout.Visibility = ViewStates.Visible;

                        _imageView.LongClick += DeleteImage;
                        using (var stream = new MemoryStream())
                        {
                            Files file = new Files();
                            file.FileName = App._file.Name;
                            file.FileExtension = file.FileName.Split('.')[1];
                            if ("png".Equals(file.FileExtension))
                            {
                                App.bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                            }
                            else
                            {
                                App.bitmap.Compress(Bitmap.CompressFormat.Jpeg, 0, stream);
                            }
                            file.arrByte = stream.ToArray();
                            listFile.Add(file);
                        }

                        App.bitmap = null;
                    }
                    GC.Collect();
                }
            }
            else if (requestCode == (int)Config.Active.TakeAGallery)
            {
                if (resultCode == Result.Ok)
                {
                    ImageView _imageView = new ImageView(this);// Tạo hình và add vào view
                    _imageView.SetScaleType(ImageView.ScaleType.FitCenter);
                    _imageView.SetImageURI(data.Data);
                    LinearLayout.LayoutParams layoutparams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,200);
                    layoutparams.BottomMargin = 10;

                    imageLayout.AddView(_imageView, layoutparams);

                    imageLayout.Visibility = ViewStates.Visible;
                    _imageView.LongClick += DeleteImage;
                    using (var stream = new MemoryStream())
                    {
                        Bitmap bitmap = ((BitmapDrawable)_imageView.Drawable).Bitmap;
                        string s = GetPathToImage(data.Data);
                        var array = s.Split('/');
                        Files file = new Files();
                        file.FileName = array[array.Length - 1];
                        file.FileExtension = file.FileName.Split('.')[1];
                        if ("png".Equals(file.FileExtension))
                        {
                            bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                        }
                        else
                        {
                            bitmap.Compress(Bitmap.CompressFormat.Jpeg, 0, stream);
                        }
                        file.arrByte = stream.ToArray();
                        listFile.Add(file);
                    }

                }
            }
            else if (requestCode == (int)Config.Active.Map)
            {
                if (resultCode == Result.Ok)
                {
                    _currentLocation = new LatLng(data.GetDoubleExtra("Latitude", Config.Latitude), data.GetDoubleExtra("Longitude", Config.Longitude));
                    Address address = await ReverseGeocodeCurrentLocation();
                    DisplayAddress(address);
                }
            }
            else if (requestCode == (int)Config.Active.Caidat)
            {
                if (resultCode == Result.Ok)
                {
                    // Lấy thông tin người dùng trong file cài đặt để tiến hành gửi phản ánh
                    prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                    PhanAnh model = new PhanAnh();
                    model.NguoiBao_HoTen = prefs.GetString(Config.HoTen, "");
                    model.NguoiBao_DienThoai = prefs.GetString(Config.SDT, "");
                    model.NguoiBao_Email = prefs.GetString(Config.Email, "");
                    model.NguoiBao_SoNha = prefs.GetString(Config.DiaChi, "");
                    model.SoNha = txtVitri.Text;
                    model.NoiDungPhanAnh = txtNoiDung.Text;
                    model.MaKenhTiepNhan = Config.MaKenhTiepNhan;
                    model.PortalID = Config.PortalID;
                    model.Active = Config.Actives;
                    model.lstFileDinhKem = listFile;
                    new SendRequestPhanAnh(this).Execute(model);
                }
            }
            showButton();
        }
        /// <summary>
        /// Lấy đường dẫn thực của file hình khi chọn từ thư viện
        /// </summary>
        /// <param name="contentURI"></param>
        /// <returns></returns>
        private string GetPathToImage(Android.Net.Uri contentURI)
        {
            ICursor cursor = ContentResolver.Query(contentURI, null, null, null, null);
            cursor.MoveToFirst();
            string documentId = cursor.GetString(0);
            documentId = documentId.Split(':')[1];
            cursor.Close();

            cursor = ContentResolver.Query(
            Android.Provider.MediaStore.Images.Media.ExternalContentUri,
            null, MediaStore.Images.Media.InterfaceConsts.Id + " = ? ", new[] { documentId }, null);
            cursor.MoveToFirst();
            string path;
            if (cursor.Count > 0)
                path = cursor.GetString(cursor.GetColumnIndex(MediaStore.Images.Media.InterfaceConsts.Data));
            else
               path = documentId;
            cursor.Close();
            return path;
        }
        /// <summary>
        /// Xóa hình khi người dùng long click vào hình
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteImage(object sender, EventArgs e)
        {
            // Hiện dialog cảnh báo
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle(Resources.GetString(Resource.String.xoahinh));
            alert.SetMessage(Resources.GetString(Resource.String.thongbaoxoahinh));
            alert.SetPositiveButton(Resources.GetString(Resource.String.xoahinh), (senderAlert, args) => {
                ImageView img = (ImageView)sender;
                for (int i = 0; i < imageLayout.ChildCount; i++)
                {
                    ImageView images = (ImageView)imageLayout.GetChildAt(i);
                    if (images == img)
                    {
                        listFile.RemoveAt(i);// Xóa dữ liệu hình
                    }
                }
                imageLayout.RemoveView((ImageView)sender);// Xóa hình khỏi view
                if (imageLayout.ChildCount == 0)
                {
                    imageLayout.Visibility = ViewStates.Gone;// Ẩn view nếu không có hình
                }
            });

            alert.SetNegativeButton(Resources.GetString(Resource.String.huybo), (senderAlert, args) => {
                alert.Dispose();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }
        protected override void OnResume()
        {
            base.OnResume();
            if (!string.IsNullOrEmpty(_locationProvider))
            {
                _locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
            }
            else
            {
                InitializeLocationManager();
            }
        }
        protected override void OnPause()
        {
            base.OnPause();
            _locationManager.RemoveUpdates(this);
        }
        /// <summary>
        /// Tạo đường dẫn để lưu hình mới chụp vào
        /// Mặc định tên thưc mục chính là tên app (Resource.String.app_name)
        /// </summary>
        private void CreateDirectoryForPictures()
        {
            App._dir = new Java.IO.File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), Resources.GetString(Resource.String.app_name));
            if (!App._dir.Exists())
            {
                App._dir.Mkdirs();
            }
        }
        /// <summary>
        /// Kiểm tra chụp hình
        /// </summary>
        /// <returns></returns>
        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }
        /// <summary>
        /// Hiện dialog thêm hình ảnh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void CallImage(object sender, EventArgs eventArgs)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle(Resources.GetString(Resource.String.btn_themanh));

            var items = new[] { Resources.GetString(Resource.String.chupanh),
                Resources.GetString(Resource.String.thuvienanh), Resources.GetString(Resource.String.huybo) };
            builder.SetItems(items, ((senderAlert, args) =>
                {
                    if (Resources.GetString(Resource.String.chupanh).Equals(items[args.Which]))
                    {
                        TakeAPicture(sender, eventArgs);// gọi hàm chụp hình
                    }
                    else if (Resources.GetString(Resource.String.thuvienanh).Equals(items[args.Which]))
                    {
                        TakeAGallery(sender, eventArgs);// gọi hàm bộ sưu tập
                    }
                    else
                    {
                        builder.Dispose();
                    }
                })
            );

            builder.Show();
        }
        /// <summary>
        /// Gọi map activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void OpenMap(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(MapActivity));
            if (_currentLocation != null)
            {
                intent.PutExtra("Latitude", _currentLocation.Latitude);
                intent.PutExtra("Longitude", _currentLocation.Longitude);
            }
            else
            {
                // Nếu không xác định được tạo độ hiện tại thì dùng giá trị config
                intent.PutExtra("Latitude", Config.Latitude);
                intent.PutExtra("Longitude", Config.Longitude);
            }
            StartActivityForResult(intent, (int)Config.Active.Map);
        }
        /// <summary>
        /// Gọi camera activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            // Tạo file lưu ảnh
            App._file = new Java.IO.File(App._dir, string.Format(Config.ImageName, Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App._file));
            StartActivityForResult(intent, (int)Config.Active.TakeAPicture);
            OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);
        }
        /// <summary>
        /// Gọi Gallery activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void TakeAGallery(object sender, EventArgs eventArgs)
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(imageIntent, Resources.GetString(Resource.String.btn_themanh)), (int)Config.Active.TakeAGallery);
            OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);
        }
        /// <summary>
        /// Khởi tạo giá trị location
        /// </summary>
        void InitializeLocationManager()
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Coarse,
                PowerRequirement = Power.Medium
            };
            IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

            if (acceptableLocationProviders.Any())
            {
                _locationProvider = acceptableLocationProviders.First();
            }
            else
            {
                _locationProvider = string.Empty;
                progress.Dismiss();
                if (_currentLocation == null)
                {
                    Toast.MakeText(this, Resources.GetString(Resource.String.timvitriloi), ToastLength.Short).Show();
                }
            }
        }
        /// <summary>
        /// Lấy địa chị từ vị trí hiện tại
        /// </summary>
        /// <returns></returns>
        async Task<Address> ReverseGeocodeCurrentLocation()
        {
            Geocoder geocoder = new Geocoder(this);
            IList<Address> addressList =
                await geocoder.GetFromLocationAsync(_currentLocation.Latitude, _currentLocation.Longitude, 1);

            Address address = addressList.FirstOrDefault();
            return address;
        }
        /// <summary>
        /// Hiện thị địa chỉ lên view
        /// </summary>
        /// <param name="address"></param>
        void DisplayAddress(Address address)
        {
            if (address != null)
            {
                StringBuilder deviceAddress = new StringBuilder();
                for (int i = 0; i < address.MaxAddressLineIndex; i++)
                {
                    deviceAddress.AppendLine(address.GetAddressLine(i));
                }
                _addressText.Text = deviceAddress.ToString();
            }
            else
            {
                Toast.MakeText(this, Resources.GetString(Resource.String.timvitriloi), ToastLength.Short).Show();
            }
            progress.Dismiss();
        }
        /// <summary>
        /// Theo dõi sự thay đổi vị trí để lấy tọa độ hiện tại
        /// </summary>
        /// <param name="location"></param>
        public async void OnLocationChanged(Location location)
        {
            // Khi người dùng chưa chọn vị trí thì lấy tọa độ hiện tại
            if (string.IsNullOrEmpty(txtVitri.Text.Trim()))
            {
                _currentLocation = new LatLng(location.Latitude, location.Longitude);
                Address address = await ReverseGeocodeCurrentLocation();
                DisplayAddress(address);
            }
            else
            {
                progress.Dismiss();// ẩn dialog
                // Nếu không tìm được vị trí hiện tại thì báo lỗi
                if (_currentLocation == null)
                {
                    Toast.MakeText(this, Resources.GetString(Resource.String.timvitriloi), ToastLength.Short).Show();
                }
            }
        }
        /// <summary>
        /// Khi hiện bàn phím thì ẩn nút gửi và ngược lại
        /// Gán marign cho form phản ánh là 0 khi hiện bàn phím 50 khi ẩn (50 tương ứng với độ cao của nút gửi)
        /// Nút gửi mặc định luôn ở dưới cùng nên form cần marign bottom 50 mới thấy dc đầy đủ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void checkFocus(object sender, View.FocusChangeEventArgs args)
        {
            ScrollView scrollView = FindViewById<ScrollView>(Resource.Id.scrollView);
            RelativeLayout.LayoutParams linearLayoutParams = 
                new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            linearLayoutParams.TopMargin = 30;
            if (args.HasFocus)
            {
                btnGui.Visibility = ViewStates.Gone;
                linearLayoutParams.BottomMargin = 10;
            }
            else
            {
                linearLayoutParams.BottomMargin = 70;
            }
            scrollView.LayoutParameters = linearLayoutParams;
        }
        /// <summary>
        /// Kiem tra hien nut gui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void checkView(object sender, EventArgs args)
        {
            showButton();
        }
        private void showButton()
        {
            if (!string.IsNullOrEmpty(txtNoiDung.Text.Trim()) && !string.IsNullOrEmpty(txtVitri.Text.Trim()))
                btnGui.Visibility = ViewStates.Visible;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Tiến trình gửi phán ánh
        /// </summary>
        private class SendRequestPhanAnh : AsyncTask<PhanAnh, string, UpdateResult>
        {
            private LinhVucService _service = new LinhVucService();
            private Activity _activity;
            private ProgressDialog progressDialog;
            public SendRequestPhanAnh(Activity activity)
            {
                _activity = activity;
            }
            protected override void OnPreExecute()
            {
                base.OnPreExecute();
                // Hiện dialog
                progressDialog = ProgressDialog.Show(_activity, _activity.Resources.GetString(Resource.String.vuilongcho),
                    _activity.Resources.GetString(Resource.String.guiphananh), true);
            }
            protected override UpdateResult RunInBackground(params PhanAnh[] @params)
            {
                return _service.SendRequestPhanAnh(@params[0]).Result;
            }
            protected override void OnPostExecute(UpdateResult result)
            {
                base.OnPostExecute(result);
                progressDialog.Dismiss();

                if ("0".Equals(result.Result))// Gửi thành công
                {
                    Toast.MakeText(_activity, _activity.Resources.GetString(Resource.String.phananhthatbai), ToastLength.Short).Show();
                    var sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(_activity);
                    var topic = sharedPreferences.GetStringSet(Config.GCMTopic, null);
                    if (topic == null)
                    {
                        topic = new List<string>();
                    }
                    topic.Add(result.Id);
                    sharedPreferences.Edit().PutStringSet(Config.GCMTopic, topic).Apply();
                    var intent = new Intent(_activity, typeof(RegistrationIntentService));
                    _activity.StartService(intent);
                }
                else
                {
                    Toast.MakeText(_activity, _activity.Resources.GetString(Resource.String.phananhthanhcong), ToastLength.Short).Show();
                }
            }
        }
    }
}