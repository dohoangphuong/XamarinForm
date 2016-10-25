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
using Android.Support.V7.App;
using Newtonsoft.Json;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using TNPA.Model;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using SearchView = Android.Support.V7.Widget.SearchView;
using Android.Preferences;

namespace TNPA.Droid
{
    [Activity(Theme = "@style/Theme.ActionBar")]
    public class LichSuActivity : AppCompatActivity
    {
        private LinhVucService _service;
        private SearchView _searchView;
        private ListView _listView;
        private List<DmLinhVuc> _listLinhVuc;
        private AsyncTask<string, DmLinhVuc, ListResult> newTask;
        private SwipeRefreshLayout _mSwipeRefreshLayout;
        private View _loadmore_progress;
        private LinearLayout _progressbar;

        private int _PageIndex = 1;
        private int _TotalItem = 0;
        private string searchKey = string.Empty;
        private bool isBuzy;
        private List<PhanAnh> _items;
        private DanhSachPhanAnhAdapter _adapter;
        private bool isSreach;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);
            SetContentView(Resource.Layout.danhsachphananh);
            // Set toobar cho activity
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);


            // Set title
            SupportActionBar.Title = Resources.GetString(Resource.String.lichsuphananh);

            searchKey = PreferenceManager.GetDefaultSharedPreferences(this).GetString(Config.SDT, "");

            _service = new LinhVucService();
            _listView = FindViewById<ListView>(Resource.Id.List);
            _mSwipeRefreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.swipe_refresh_layout);
            _progressbar = FindViewById<LinearLayout>(Resource.Id.progressbar_view);
            _loadmore_progress = ((LayoutInflater)GetSystemService(Context.LayoutInflaterService)).Inflate(Resource.Layout.progress_bar_footer, null, false);
            _items = new List<PhanAnh>();
            _adapter = new DanhSachPhanAnhAdapter(this, _items);
            _listView.Adapter = _adapter;
            _listView.ItemClick += OnListItemClick;
            _listView.ScrollStateChanged += OnScrollChange;

            _mSwipeRefreshLayout.Refresh += (sender, e) =>
            {
                if (isSreach)
                {
                    _mSwipeRefreshLayout.Refreshing = false;
                    return;
                }
                else
                {
                    _PageIndex = 1;
                    getDanhSachPhanAnh();
                }
            };

            getDanhSachPhanAnh();
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.timkiem, menu);
            var item = menu.FindItem(Resource.Id.action_search);

            var actionExpand = new OnActionExpandListener();
            // Tat search
            actionExpand.MenuItemCollaspe += (sender, e) =>
            {
                e.Handled = true;
                isSreach = false;
                _PageIndex = 1;
                //searchKey = string.Empty;
                _adapter.setSearch(false, string.Empty);
                _listView.SetSelection(0);
            };
            // Mo search
            actionExpand.MenuItemActionExpand += (sender, e) =>
            {
                if (isBuzy)
                    return;
                else
                {
                    _listView.SetSelection(0);
                    e.Handled = true;
                    isSreach = true;
                }
            };

            MenuItemCompat.SetOnActionExpandListener(item, actionExpand);
            var searchView = MenuItemCompat.GetActionView(item);
            _searchView = searchView.JavaCast<SearchView>();
            _searchView.QueryTextSubmit += (sender, e) =>
            {
                SearchView seft = (SearchView)sender;
                _PageIndex = 1;
                _adapter.setSearch(true, e.Query);
                seft.ClearFocus();
            };
            return base.OnCreateOptionsMenu(menu);
        }

        protected override void OnPause()
        {
            base.OnPause();
            OverridePendingTransition(Resource.Animation.trans_right_in, Resource.Animation.trans_right_out);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
            }

            return base.OnOptionsItemSelected(item);
        }
        /// <summary>
        /// Sự kiện chọn 1 dòng của listview chuyển qua trang chi tiết
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (!_mSwipeRefreshLayout.Refreshing && !isBuzy)
            {
                Intent intent = new Intent(this, typeof(ChiTietLichSuActivity));

                var json = JsonConvert.SerializeObject(_items.Select(p => p.PhanAnhKenhKhacID));
                intent.PutExtra("dsPhanAnh", json);
                intent.PutExtra("Position", e.Position);
                intent.PutExtra("totalItem", _TotalItem);
                StartActivity(intent);
            }
        }
        private void OnScrollChange(object sender, AbsListView.ScrollStateChangedEventArgs e)
        {
            if (!isBuzy)
            {
                // kiểm tra scroll dùng thì tải thêm trang mới nếu đã scroll tới vị trí cuối cùng -2
                if (e.ScrollState == ScrollState.Idle && (_listView.LastVisiblePosition >= _adapter.Count - 2))
                {
                    // kiểm tra còn trang để tải thêm hay không
                    if ((_PageIndex <= _TotalItem / Config.PageSize) && (_TotalItem > _items.Count))
                    {
                        _PageIndex += 1;
                        // show view cho progress bar
                        if (_listView.FooterViewsCount < 1)
                            _listView.AddFooterView(_loadmore_progress);
                        getDanhSachPhanAnh();
                    }
                }
            }
        }
        public async void getDanhSachPhanAnh()
        {
            TextView lblthongbao = FindViewById<TextView>(Resource.Id.lblthongbao);

            isBuzy = true;
            if (!_mSwipeRefreshLayout.Refreshing)
                _progressbar.Visibility = ViewStates.Visible;

            var result = await _service.GetListPhanAnhLichSu(searchKey, Config.MaNguonTiepNhan, Config.MaKenhTiepNhan, _PageIndex, Config.PageSize);
            if (result != null)
            {
                _TotalItem = result.PagingResult.TotalCount;
                if (_PageIndex == 1)
                    _items.Clear();
                _items.AddRange((List<PhanAnh>)result.ClassResult);
                _adapter.NotifyDataSetChanged();
            }


            if (_adapter.Count == 0)
            {
                lblthongbao.Visibility = ViewStates.Visible;
            }
            else
            {
                lblthongbao.Visibility = ViewStates.Gone;
            }
            _progressbar.Visibility = ViewStates.Gone;
            _listView.RemoveFooterView(_loadmore_progress);// ẩn progress bar
            _listView.Visibility = ViewStates.Visible;
            _mSwipeRefreshLayout.Refreshing = false;
            isBuzy = false;
        }
    }
}