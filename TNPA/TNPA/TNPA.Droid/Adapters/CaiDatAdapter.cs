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
using Android.Graphics;

namespace TNPA.Droid
{
    public class CaiDatAdapter : BaseAdapter<Dictionary<string, string>>
    {
        Dictionary<string, string> dictionary = Config.dictionaryAction;
        Activity context;

        public CaiDatAdapter(Activity context) : base()
        {
            this.context = context;
        }

        public override Dictionary<string, string> this[int position]
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    { dictionary.ElementAtOrDefault(position).Key, dictionary.ElementAtOrDefault(position).Value }
                };
            }
        }

        public override int Count
        {
            get
            {
                return dictionary.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            layoutParams.BottomMargin = 20;
            layoutParams.TopMargin = 20;
            if (view == null) // otherwise create a new one
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.SetBackgroundColor(Color.ParseColor("#FFFFFF"));
            view.LayoutParameters = layoutParams;
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = dictionary.ElementAtOrDefault(position).Value;
            return view;
        }
    }
}