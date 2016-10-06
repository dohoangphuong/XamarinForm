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

namespace TNPA.Droid
{
    public class PhanhAnhAdapter : BaseAdapter<PhanAnh>
    {
        List<PhanAnh> items;
        Activity context;
        public PhanhAnhAdapter(Activity context, List<PhanAnh> items) : base()
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
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = context.LayoutInflater.Inflate(Resource.Layout.phananhView, null);
            var text = view.FindViewById<TextView>(Resource.Id.TenLinhVuc);
            text.Text = items[position].tieuDe;
            var img = view.FindViewById<ImageView>(Resource.Id.circleimage);
            if (items[position].thumbnail != null && items[position].thumbnail.Length > 0)
            { 
                Bitmap imageBitmap = BitmapFactory.DecodeByteArray(items[position].thumbnail, 0, items[position].thumbnail.Length);
                // Bitmap.CreateScaledBitmap(bitmap,100,100,true);
                if (imageBitmap != null)
                {
                    img.SetImageBitmap(imageBitmap);
                    imageBitmap = null;
                    GC.Collect();
                }
               
            }
            else
            {
                img.SetImageResource(Resource.Drawable.phananhdefaut);
            }
            return view;
        }
    }
}