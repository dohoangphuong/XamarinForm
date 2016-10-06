using Android.Support.V4.View;
using Android.Support.V4.App;
using System.Collections.Generic;
using System;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using TNPA.Model;

namespace TNPA.Droid
{
    public class ChiTietPhanAnhAdapter : FragmentStatePagerAdapter
    {
        private class ViewPagerItem
        {
            public Type Type { get; set; }
            public Fragment CachedFragment { get; set; }
        }

        private readonly Dictionary<int, ViewPagerItem> _fragments = new Dictionary<int, ViewPagerItem>();
        private readonly Context _context;
        private readonly ViewPager _viewPager;
        List<PhanAnh> _phanAnh;
        private const int PageCount = 5;
        public ChiTietPhanAnhAdapter(Context context, ViewPager pager,List<PhanAnh> phanAnh, FragmentManager fm) : base(fm)
        {
            _context = context;
            _viewPager = pager;
            _phanAnh = phanAnh;
        }

        public override Fragment GetItem(int position)
        {
            //if (!_fragments.ContainsKey(position)) return null;

            //var bundle = new Bundle();
            //bundle.PutInt("number", position);
            //_fragments[position].CachedFragment = Fragment.Instantiate(_context,
            //    FragmentJavaName(_fragments[position].Type), bundle);
            //return _fragments[position].CachedFragment;
            return new PagerFragment(_phanAnh[position]);
        }
        public override int Count
        {
            //get { return _fragments.Count; }
            get { return _phanAnh.Count; }
        }

        public void AddFragment(Type fragType, int position = -1)
        {
            if (position < 0 && _fragments.Count == 0)
                position = 0;
            else if (position < 0 && _fragments.Count > 0)
                position = _fragments.Count;

            _fragments.Add(position, new ViewPagerItem
            {
                Type = fragType
            });

            NotifyDataSetChanged();
        }

        public void RemoveFragment(int position)
        {
            DestroyItem(null, position, _fragments[position].CachedFragment);
            _fragments.Remove(position);
            NotifyDataSetChanged();
            _viewPager.SetCurrentItem(position - 1, false);
        }

        protected virtual string FragmentJavaName(Type fragmentType)
        {
            var namespaceText = fragmentType.Namespace ?? "";
            if (namespaceText.Length > 0)
                namespaceText = namespaceText.ToLowerInvariant() + ".";
            return namespaceText + fragmentType.Name;
        }

    }
    public class PagerFragment : Fragment
    {
        private PhanAnh _phanAnh;

        public PagerFragment(PhanAnh phanAnh)
        {
            _phanAnh = phanAnh;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.chitietphananhFragment, container, false);
            TextView txtNoiDungPhanAnh = view.FindViewById<TextView>(Resource.Id.txtNoiDungPhanAnh);
            txtNoiDungPhanAnh.Text = _phanAnh.NoiDungPhanAnh;
            return view;
        }
    }
    public class FadeTransformer : Java.Lang.Object, ViewPager.IPageTransformer
    {
        private float MinAlpha = 0.3f; // Minimum alpha value.

        public void TransformPage(View view, float position)
        {
            if (position < -1 || position > 1)
            {
                view.Alpha = 0; // The view is offscreen.
            }
            else
            {
                float scale = 1 - Math.Abs(position); // The scale should be 1 at position 0, and 0 at positions 1 and -1
                float alpha = MinAlpha + (1 - MinAlpha) * scale; // Calculate the alpha value
                view.Alpha = alpha; // Apply the value to the view

                view.FindViewById<TextView>(Resource.Id.txtNoiDungPhanAnh).Text = string.Format("Position: {0}\r\nAlpha: {1}", position, alpha);
            }
        }
    }
}