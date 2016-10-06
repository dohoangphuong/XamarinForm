using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;
using TNPA.Model;
using Android.Graphics;
using System.Net;
using System;

namespace TNPA.Droid
{
    public class LinhVucAdapter : BaseAdapter<DmLinhVuc>
    {
        List<DmLinhVuc> items;
        Activity context;
        public LinhVucAdapter(Activity context, List<DmLinhVuc> items) : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override DmLinhVuc this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.linhvucView, null);
            var text = view.FindViewById<TextView>(Resource.Id.TenLinhVuc);
            text.Text = items[position].TenLinhVuc;
            
            var imageBitmap = GetImageBitmapFromUrl(items[position].GetImageFromDB);
            
            var img = view.FindViewById<ImageView>(Resource.Id.circleimage);
            if (imageBitmap != null)
            {
                img.SetImageBitmap(imageBitmap);
                imageBitmap = null;
            }
            
            GC.Collect();
            return view;
        }
        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}