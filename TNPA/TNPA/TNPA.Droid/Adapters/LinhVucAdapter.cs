using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;
using TNPA.Model;
using Com.Bumptech.Glide;
using Com.Bumptech.Glide.Load.Engine;
using Java.Lang;

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
            var img = view.FindViewById<ImageView>(Resource.Id.circleimage);

            Glide
               .With(context)
               .Load(items[position].GetImageFromDB)
               .DiskCacheStrategy(DiskCacheStrategy.Result)
               .SizeMultiplier(0.5f)
               .Thumbnail(0.5f)
               .Into(img);
            return view;
        }
    }
}