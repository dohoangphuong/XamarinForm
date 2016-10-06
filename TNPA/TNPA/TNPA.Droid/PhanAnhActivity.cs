using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Widget;
using Java.IO;

using Android.Views;
using Android.Locations;
using Android.Runtime;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Android.Gms.Maps.Model;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;
using TNPA.Model;
using Java.Nio;

namespace TNPA.Droid
{
    public static class App
    {
        public static File _file;
        public static File _dir;
        public static Bitmap bitmap;
    }

    public enum eTypeAction
    {
        Map = 0,
        TakePicture = 1,
        AddPicture = 2,
        Setting = 3,
    }

    [Activity(Label = "TabActivity")]
    public class PhanAnhActivity : Activity, ILocationListener
    {
        private ImageView _imageView;
        private LinearLayout imageLayout;
        private EditText _addressText;
        private LatLng _currentLocation;
        private LocationManager _locationManager;
        private string _locationProvider;
        Button btnGui, btnMap;
        EditText txtVitri, txtNoiDung;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.gopy);
            btnMap = FindViewById<Button>(Resource.Id.btnGetMap);
            btnGui = FindViewById<Button>(Resource.Id.btnGui);
            txtVitri = FindViewById<EditText>(Resource.Id.txtViTri);
            txtNoiDung = FindViewById<EditText>(Resource.Id.txtNoiDung);
            _addressText = FindViewById<EditText>(Resource.Id.txtViTri);

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();

                Button button = FindViewById<Button>(Resource.Id.btnCamera);
                _imageView = new ImageView(this);
                imageLayout = FindViewById<LinearLayout>(Resource.Id.imageLayout);

                imageLayout.AddView(_imageView, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent));
                button.Click += CallImage;
            }
            
           
            InitializeLocationManager();
            if (_currentLocation == null)
            {
                //_addressText.Text = "Can't determine the current address. Try again in a few minutes.";
            }
            else
            {
                Address address = await ReverseGeocodeCurrentLocation();
                DisplayAddress(address);
            }
            

            btnMap.Click += OpenMap;

            txtVitri.FocusChange += (sender, args) =>
            {
                if (args.HasFocus)  
                {
                    btnGui.Visibility = ViewStates.Invisible;
                }else
                {
                    btnGui.Visibility = ViewStates.Visible;
                }
            };
            txtNoiDung.FocusChange += checkFocus;
            RelativeLayout mainlayout = FindViewById<RelativeLayout>(Resource.Id.mainlayout);
            mainlayout.Click += (sender, args) =>
            {
                //if(CurrentFocus.GetType() != typeof(EditText))
                //{
                btnGui.Visibility = ViewStates.Visible;
                //}
            };

            //button Gui was clicked
            btnGui.Click += BtnGui_Click;
        }

        private void BtnGui_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CaiDatActivity));
            //intent.PutExtra("Latitude", 10.8421601);
            StartActivityForResult(intent, (int)eTypeAction.Setting);
        }

        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery
            if (requestCode == 1)
            {
                if (resultCode == Result.Ok)
                {
                    Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                    Uri contentUri = Uri.FromFile(App._file);
                    mediaScanIntent.SetData(contentUri);
                    SendBroadcast(mediaScanIntent);

                    int height = Resources.DisplayMetrics.HeightPixels;
                    int width = _imageView.Height;
                    App.bitmap = App._file.Path.LoadAndResizeBitmap(width, height);
                    if (App.bitmap != null)
                    {
                        _imageView.SetImageBitmap(App.bitmap);
                        App.bitmap = null;
                    }
                    GC.Collect();
                }
            }
            else if (requestCode == 2)
            {
                if (resultCode == Result.Ok)
                {
                    _imageView.SetImageURI(data.Data);
                    App._file = new File(data.Data.ToString());

                }
            }
            else if (requestCode == 0)
            {
                if (resultCode == Result.Ok)
                {
                    double Latitude = _currentLocation != null ? _currentLocation.Latitude : 10.8421601;
                    double Longitude = _currentLocation != null ? _currentLocation.Longitude : 106.7465938;
                    _currentLocation = new LatLng(data.GetDoubleExtra("Latitude", Latitude), data.GetDoubleExtra("Longitude", Longitude));
                    Address address = await ReverseGeocodeCurrentLocation();
                    DisplayAddress(address);
                }
            }
            else if (requestCode == (int)eTypeAction.Setting)
            {
                if (resultCode == Result.Ok)
                {
                    if (txtVitri.Text == null || txtNoiDung.Text == null)
                    {
                    }
                    else
                    {
                        if (txtVitri.Text.Trim() == "" || txtNoiDung.Text.Trim() == "")
                        {

                        }
                        else
                        {
                            //File đính kèm

                            DateTime CurrenTime = DateTime.Now;
                            PhanAnh iPhanAnh = new PhanAnh();

                            // for(int i=0;i< App.bitmap.Count();i++)
                            files fileDinhKemModel = new files();
                            if(App._file==null)
                            {
                                App._file = App._dir;
                                int height = Resources.DisplayMetrics.HeightPixels;
                                int width = _imageView.Height;
                                App.bitmap = App._dir.Path.LoadAndResizeBitmap(width, height);
                                if (App.bitmap != null)
                                {
                                    _imageView.SetImageBitmap(App.bitmap);
                                    App.bitmap = null;
                                }
                            }
                            
                            if (App.bitmap != null)
                            {
                                var byteBuffer = ByteBuffer.Allocate(App.bitmap.ByteCount);
                                App.bitmap.CopyPixelsToBuffer(byteBuffer);
                                var iByteImage = byteBuffer.ToArray<byte>();

                                fileDinhKemModel.arrByte = iByteImage;

                                //Lấy tên công thêm giờ giây phút            
                                string fileName = App._file.Name;
                                fileDinhKemModel.FileName = fileName;
                                fileDinhKemModel.FileExtension = System.IO.Path.GetExtension(fileName).Substring(1);
                                fileDinhKemModel.FileUrl = "";

                               iPhanAnh.lstFileDinhKem.Add(fileDinhKemModel);
                            }
                            
                            iPhanAnh.NguoiBao_Email = "123";// entEmail.Text;
                            iPhanAnh.NguoiBao_HoTen = "Hữu Đạt";// entFullName.Text;
                            iPhanAnh.NguoiBao_DienThoai = "0123456788";// entPhone.Text;
                            iPhanAnh.PortalID = Constants.PortailID;
                            iPhanAnh.MaKenhTiepNhan = Constants.MaKenhTiepNhan;
                            iPhanAnh.NoiDungPhanAnh = txtNoiDung.Text;
                            iPhanAnh.Active = true;
                            iPhanAnh.Duong = txtVitri.Text;

                            LinhVucService iLinhVuc = new LinhVucService();
                            var result = iLinhVuc.SendRequestPhanAnh(iPhanAnh);
                        }
                    }
                }
            }
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
        private void CreateDirectoryForPictures()
        {
            App._dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), Resources.GetString(Resource.String.app_name));
            if (!App._dir.Exists())
            {
                App._dir.Mkdirs();
            }
        }
        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }
        private void CallImage(object sender, EventArgs eventArgs)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle(Resources.GetString(Resource.String.btn_themanh));
            
            var items = new[] { Resources.GetString(Resource.String.chupanh), Resources.GetString(Resource.String.thuvienanh), Resources.GetString(Resource.String.huybo) };
            builder.SetItems(items, ((senderAlert, args) =>
                {
                    if (Resources.GetString(Resource.String.chupanh).Equals(items[args.Which]))
                    {
                        TakeAPicture(sender, eventArgs);
                    }
                    else if (Resources.GetString(Resource.String.thuvienanh).Equals(items[args.Which]))
                    {
                        TakeAGallery(sender, eventArgs);
                    }
                    else {
                        builder.Dispose();
                    }
                })
            );
            
            builder.Show();
        }
        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            App._file = new File(App._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App._file));
            StartActivityForResult(intent, 1);
            OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);
        }
        private void OpenMap(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(MapActivity));
            intent.PutExtra("Latitude", 10.8421601);
            intent.PutExtra("Longitude", 106.7465938);
            StartActivityForResult(intent, 0);
        }
        private void TakeAGallery(object sender, EventArgs eventArgs)
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(imageIntent, Resources.GetString(Resource.String.btn_themanh)), 2);
            OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);
        }

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
            }
            // Log.Debug(TAG, "Using " + _locationProvider + ".");
        }
        async void AddressButton_OnClick(object sender, EventArgs eventArgs)
        {
            if (_currentLocation == null)
            {
                //_addressText.Text = "Can't determine the current address. Try again in a few minutes.";
                return;
            }

            Address address = await ReverseGeocodeCurrentLocation();
            DisplayAddress(address);
        }

        async Task<Address> ReverseGeocodeCurrentLocation()
        {
            Geocoder geocoder = new Geocoder(this);
            IList<Address> addressList =
                await geocoder.GetFromLocationAsync(_currentLocation.Latitude, _currentLocation.Longitude, 1);

            Address address = addressList.FirstOrDefault();
            return address;
        }
        void DisplayAddress(Address address)
        {
            if (address != null)
            {
                StringBuilder deviceAddress = new StringBuilder();
                for (int i = 0; i < address.MaxAddressLineIndex; i++)
                {
                    deviceAddress.AppendLine(address.GetAddressLine(i));
                }
                // Remove the last comma from the end of the address.
                _addressText.Text = deviceAddress.ToString();
            }
            else
            {
                _addressText.Text = "Unable to determine the address. Try again in a few minutes.";
            }
        }
        public async void OnLocationChanged(Location location)
        {
            _currentLocation = new LatLng(location.Latitude, location.Longitude);
            if (_currentLocation == null)
            {
                // _locationText.Text = "Unable to determine your location. Try again in a short while.";
            }
            else
            {
                // _locationText.Text = string.Format("{0:f6},{1:f6}", _currentLocation.Latitude, _currentLocation.Longitude);
                Address address = await ReverseGeocodeCurrentLocation();
                DisplayAddress(address);
            }
        }
        private void checkFocus(object sender, View.FocusChangeEventArgs args)
        {
            if (args.HasFocus)
            {
                btnGui.Visibility = ViewStates.Invisible;
            }
            else
            {
                btnGui.Visibility = ViewStates.Visible;
            }
        }
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
    }
}