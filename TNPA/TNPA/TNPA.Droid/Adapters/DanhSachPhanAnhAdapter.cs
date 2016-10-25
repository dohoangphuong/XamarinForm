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
using TNPA.Model;
using Android.Graphics;
using System.IO;
using System.Threading.Tasks;
using Android.Graphics.Drawables;
using Java.IO;
using Com.Bumptech.Glide;
using Com.Bumptech.Glide.Load.Resource.Bitmap;
using Com.Bumptech.Glide.Load.Engine.Bitmap_recycle;

namespace TNPA.Droid
{
    public class DanhSachPhanAnhAdapter : BaseAdapter<PhanAnh>
    {
        List<PhanAnh> items;
        List<PhanAnh> filterItems = new List<PhanAnh>();
        Activity context;
        bool searchEnable=false;
        string searckKey;

        public DanhSachPhanAnhAdapter(Activity context, List<PhanAnh> items) : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override PhanAnh this[int position]
        {
            get {
                if (searchEnable)
                    return filterItems[position];
                else
                    return items[position];
            }
        }
        public override int Count
        {
            get {
                if (searchEnable)
                    return filterItems.Count;
                else
                    return items.Count;
            }
        }
        public void setSearch(bool enabled, string text)
        {
            searchEnable = enabled;
            searckKey = text;
            NotifyDataSetChanged();
        }
        private void Filter()
        {
            filterItems.Clear();
            filterItems = items.Where(m => m.NoiDungPhanAnh.Contains(searckKey) || m.NguoiBao_HoTen.Contains(searckKey)).ToList();
        }
        public override void NotifyDataSetChanged()
        {
            if (searchEnable)
            {
                Filter();
            }
            else
            {
                filterItems.Clear();
            }
            base.NotifyDataSetChanged();
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            DanhSachPhanhAnhViewHolder holder=null;
            PhanAnh temp = searchEnable ? filterItems[position] : items[position];
            View view = convertView; 

            if (view != null)
                holder = view.Tag as DanhSachPhanhAnhViewHolder;
            if (holder == null)
            {
                holder = new DanhSachPhanhAnhViewHolder();
                view = context.LayoutInflater.Inflate(Resource.Layout.danhsachphananhView, null);
                holder.tieuDe = view.FindViewById<TextView>(Resource.Id.TenLinhVuc);
                holder.thoiGian = view.FindViewById<TextView>(Resource.Id.ThoiGian);
                holder.viTri = view.FindViewById<TextView>(Resource.Id.ViTri);
                holder.thumbnail = view.FindViewById<ImageView>(Resource.Id.thumbnail);
                view.Tag = holder;
            }

            holder.tieuDe.Text = temp.tieuDe;
            holder.thoiGian.Text = temp.thoiGian;
            holder.viTri.Text = temp.diaChi;
            
            if (temp.thumbnails != null)
            {
                Glide
                .With(context)
                .Load(Config.UrlGetImage+temp.thumbnails.FielUrl+"/"+temp.thumbnails.FileName)
                .Placeholder(Resource.Drawable.placeholder)
                //.Load(temp.thumbnail)
                .Error(Resource.Drawable.phananhdefaut)
                .SizeMultiplier(0.4f)
                .Thumbnail(0.4f)
                .DiskCacheStrategy(Com.Bumptech.Glide.Load.Engine.DiskCacheStrategy.Result)
                .Into(holder.thumbnail);
            }
            else
            {
                Glide.With(context)
               .Load(Resource.Drawable.phananhdefaut)
               .Error(Resource.Drawable.placeholder)
               .SizeMultiplier(0.5f)
               .Thumbnail(0.5f)
               .DiskCacheStrategy(Com.Bumptech.Glide.Load.Engine.DiskCacheStrategy.Result)
               .Into(holder.thumbnail);
            }
            return view;
        }
    }
}