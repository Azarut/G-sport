using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.Design.Widget;
using RestSharp.Authenticators;
using RestSharp;

namespace NavigationDrawerTest
{
	[Activity(Label = "G-SPOrT", MainLauncher = true, Icon = "@drawable/icon")]
    

    public class MainActivity : AppCompatActivity
	{
		DrawerLayout drawerLayout;
       
        
        protected override void OnCreate(Bundle bundle)
		{			
			base.OnCreate(bundle);

            // Create UI

     

            SetContentView(Resource.Layout.Main);
			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            // Init toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);	

			// Attach item selected handler to navigation view
			var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
			navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

			// Create ActionBarDrawerToggle button and add it to the toolbar
			var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
            drawerLayout.SetDrawerListener(drawerToggle);
			drawerToggle.SyncState();
        }

		void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
		{
            Android.Support.V4.App.Fragment fragment = null;
            switch (e.MenuItem.ItemId)
            {
                
                case (Resource.Id.nav_home):
                    // React on 'Home' selection
                    fragment = new HomeScreen();
                    break;
                case (Resource.Id.nav_messages):
                    fragment = new ProfileFragment();
                    // React on 'Messages' selection
                    break;
                case (Resource.Id.nav_friends):
                   // fragment = new ProfileFragment();
                    // React on 'Friends' selection
                    break;
                case (Resource.Id.nav_discussion):
                   // fragment = new ProfileFragment();
                    // React on 'Discussion' selection
                    break;                
            }
            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
            drawerLayout.CloseDrawers();
		}
	}
}