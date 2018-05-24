using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Viewer.Models;

namespace Viewer.Droid.Helpers
{
    public class ListAdapter : RecyclerView.Adapter
    {
        private List<Event> mEvents;

        public ListAdapter(List<Event> Events)
        {
            mEvents = Events;
        }

        public class MyView : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            public TextView Name { get; set; }
            public TextView Place { get; set; }
            public TextView Price { get; set; }
            public TextView Date { get; set; }

            public MyView(View view) : base(view)
            {
                mMainView = view;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View row = LayoutInflater.From(parent.Context).Inflate(Viewer.Droid.Resource.Layout.list_view_datatemplate, parent, false);

            TextView txtName = row.FindViewById<TextView>(Resource.Id.textViewName);
            TextView txtPlace = row.FindViewById<TextView>(Resource.Id.textViewPlace);
            TextView txtPrice = row.FindViewById<TextView>(Resource.Id.textViewPrice);
            TextView txtDate = row.FindViewById<TextView>(Resource.Id.textViewDate);

            MyView view = new MyView(row) { Name = txtName, Place = txtPlace, Price = txtPrice, Date = txtDate };
            return view;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView myHolder = holder as MyView;
            myHolder.Name.Text = mEvents[position].Name;
            myHolder.Place.Text = mEvents[position].Place;
            myHolder.Price.Text = mEvents[position].Price;
            myHolder.Date.Text = mEvents[position].Date;
        }

        public override int ItemCount
        {
            get {
                
                    return mEvents.Count;

            }
        }
    }
}