using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Viewer.Droid.Views;
using Viewer.Models;


namespace Viewer.Droid.Helpers
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtName { get; set; }
        public TextView txtdate { get; set; }
        public TextView txtPlace { get; set; }
        public TextView txtPrice { get; set; }
        public TextView txtcategory { get; set; }
    }

    class CustomAdapter : BaseAdapter<Event>
    {
        private Context context;
        private List<Event> events;
        private EventsListFragment eventsListFragment;
        LayoutInflater inflater;

        public CustomAdapter(Context context, List<Event> events, LayoutInflater inflater) 
        {
            this.context = context;
            this.events = events;
            this.inflater = LayoutInflater.From(context).Inflate(Resource.Layout.list_view_datatemplate, false,);
        }
    }

       /* public CustomAdapter(EventsListFragment eventsListFragment, List<Event> events) 
        {
            this.eventsListFragment = eventsListFragment;
            this.events = events;
        }*/

        public override Event this[int position]
        {
            get
            {
                return events[position];
            }
        }
        public override int Count
        {
            get
            {
                return events.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = events[position];
            var view = convertView;
            if(view == null)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.list_view_datatemplate, parent, false);
            }
            

            var txtName = view.FindViewById<TextView>(Resource.Id.textViewName);
            var txtdate = view.FindViewById<TextView>(Resource.Id.textViewDate);
            var txtPlace = view.FindViewById<TextView>(Resource.Id.textViewPlace);
            var txtPrice = view.FindViewById<TextView>(Resource.Id.textViewPrice);
            var txtcategory = view.FindViewById<TextView>(Resource.Id.textViewCategory);

            txtName.Text = events[position].Name;
            txtdate.Text = events[position].Date;
            txtPlace.Text = events[position].Place;
            txtPrice.Text = events[position].Price;
            txtcategory.Text = events[position].Category;

            return view;

        }
    }
}