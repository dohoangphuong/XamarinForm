using Android.Support.V4.View;
using Android.Support.V4.App;
using System.Collections.Generic;
using System;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using TNPA.Model;
using Newtonsoft.Json;
using Java.Lang;
using Com.Bumptech.Glide;
using Android.Graphics;

namespace TNPA.Droid
{
    public class ChiTietPhanAnhAdapter : PagerAdapter
    {
        private readonly Context _context;
        private PhanAnh[] _phanAnh;
        private LayoutInflater mLayoutInflater;


        public ChiTietPhanAnhAdapter(Context context, PhanAnh[] phanAnh)
        {
            _context = context;
            _phanAnh = phanAnh;
            mLayoutInflater = (LayoutInflater)_context.GetSystemService(Context.LayoutInflaterService);
        }

        public override int GetItemPosition(Java.Lang.Object objectValue)
        {
            return PositionNone;
        }

        public override int Count
        {
            get
            {
                //throw new NotImplementedException();
                return _phanAnh.Length;
            }
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object objectValue)
        {
            //throw new NotImplementedException();
            return view == ((RelativeLayout)objectValue);
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            View itemView = mLayoutInflater.Inflate(Resource.Layout.chitietphananhView, container, false);
            LinearLayout _layout = itemView.FindViewById<LinearLayout>(Resource.Id.progressbar_view);
            ScrollView _scrollview = itemView.FindViewById<ScrollView>(Resource.Id.scrollview);
            LinearLayout _imageGroup = itemView.FindViewById<LinearLayout>(Resource.Id.imageLayout);

            TextView txtNoiDungPhanAnh = (TextView)itemView.FindViewById(Resource.Id.txtNoiDungPhanAnh);
            TextView txtNguoiPhanAnh = (TextView)itemView.FindViewById(Resource.Id.txtNguoiPhanAnh);
            TextView txtThoiGian = (TextView)itemView.FindViewById(Resource.Id.txtThoiGian);
            TextView txtDiaChi = (TextView)itemView.FindViewById(Resource.Id.txtDiaChi);

            TextView txtTieuDeXuLy = (TextView)itemView.FindViewById(Resource.Id.txtTieuDeXuLy);
            TextView txtNoiDungXuLy = (TextView)itemView.FindViewById(Resource.Id.txtNoiDungXuLy);

            if (_phanAnh[position] != null && !string.IsNullOrEmpty(_phanAnh[position].NoiDungPhanAnh))
            {
                _layout.Visibility = ViewStates.Invisible;
                _scrollview.Visibility = ViewStates.Visible;

                txtNoiDungPhanAnh.Text = _phanAnh[position].NoiDungPhanAnh;
                txtNguoiPhanAnh.Text = string.Format(Config.NguoiPhanAnh, _phanAnh[position].NguoiBao_HoTen);
                txtThoiGian.Text = string.Format(Config.ThoiGianPhanAnh, _phanAnh[position].thoiGian);
                txtDiaChi.Text = string.Format(Config.DiaDiemPhanAnh, _phanAnh[position].diaChi);


                if (_phanAnh[position].lstFileDinhKem != null &&
                    _phanAnh[position].lstFileDinhKem.Count > 0)
                {
                    foreach (var item in _phanAnh[position].lstFileDinhKem)
                    {
                        ImageView img = new ImageView(_context);
                        LinearLayout.LayoutParams layoutparams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 200);
                        layoutparams.TopMargin = 10;
                        Glide
                            .With(_context)
                            .Load(Config.UrlGetImage + item.FielUrl + "/" + item.FileName)
                            .Placeholder(Resource.Drawable.placeholder)
                            .Error(Resource.Drawable.phananhdefaut)
                            .SizeMultiplier(0.5f)
                            .Thumbnail(0.5f)
                            .DiskCacheStrategy(Com.Bumptech.Glide.Load.Engine.DiskCacheStrategy.Result)
                            .Into(img);
                        _imageGroup.AddView(img, layoutparams);
                    }
                }

                if(!string.IsNullOrEmpty(_phanAnh[position].NoiDungXuLy))
                {
                    txtNoiDungXuLy.Text = _phanAnh[position].NoiDungXuLy;
                    
                    txtTieuDeXuLy.Text = string.Format(Config.TieuDeXuLy, _phanAnh[position].GetDonViNhanFromDB.TenDonVi);
                }
                else
                {
                    txtTieuDeXuLy.Visibility = ViewStates.Gone;
                    txtNoiDungXuLy.Text = Config.NoiDungDangXuLy;
                }
            }
            container.AddView(itemView);
            return itemView;
        }
        public int GetPositon(string PhanAnhID)
        {
            for (int i = 0; i < _phanAnh.Length; i++)
            {
                if (_phanAnh[i].PhanAnhID.Equals(PhanAnhID))
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// Dùng cho màn hình chi tiết lịch sử
        /// </summary>
        /// <param name="PhanAnhKenhKhacID"></param>
        /// <returns></returns>
        public int GetPositonByPhanAnhKenhKhac(string PhanAnhKenhKhacID)
        {
            for (int i = 0; i < _phanAnh.Length; i++)
            {
                if (_phanAnh[i].PhanAnhKenhKhacID.Equals(PhanAnhKenhKhacID))
                    return i;
            }
            return -1;
        }
        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object objectValue)
        {
            container.RemoveView((RelativeLayout)objectValue);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}