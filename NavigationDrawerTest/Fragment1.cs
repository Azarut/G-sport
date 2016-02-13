using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;
using RestSharp.Authenticators;
using RestSharp;
using System.Threading.Tasks;
namespace NavigationDrawerTest
{
    public class ProfileFragment : Fragment
    {
        public ProfileFragment()
        {
            this.RetainInstance = true;
        }

        private readonly RestClient restClient = new RestClient(@"http://ihorvds.kryksyh.org:8000/api/Exercises/?format=json");

        private void StartRestRequestAsync()
        {
            restClient.Authenticator = new HttpBasicAuthenticator("kryksyh", "zxcasdqwe");
            Task.Factory.StartNew(() => {
                //var rxcui = "198440";
                var request = new RestRequest(String.Format("/", Method.POST));
                request.RequestFormat = DataFormat.Json;

                return this.restClient.Execute(request);
            }).ContinueWith(t => {
                text.Text = t.Result.Content;
            }, uiScheduler);
        }

        private readonly TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        private TextView text;

       

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.layout1, null);
            text = view.FindViewById<TextView>(Resource.Id.Text);
            view.FindViewById<Button>(Resource.Id.Request).Click += (s, e) => StartRestRequestAsync();
            return view;
            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
        
        }
}