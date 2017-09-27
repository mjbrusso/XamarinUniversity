using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace GroceryList
{
    [Activity(Label = "Grocery List", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private const int AddItemCode = 100;
        public static List<Item> Items = new List<Item>();

        protected override void OnCreate(Bundle bundle)
        {
            if (Items.Count == 0)
            {
                Items.Add(new Item { Name = "Milk", Count = 2 });
                Items.Add(new Item { Name = "Crackers", Count = 1 });
                Items.Add(new Item { Name = "Apples", Count = 5 });
                Items.Add(new Item { Name = "Coffee", Count = 6 });
            }

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.itemsButton).Click += OnItemsClick;
            FindViewById<Button>(Resource.Id.addItemButton).Click += OnAddItemClick;
            FindViewById<Button>(Resource.Id.aboutButton).Click += OnAboutClick;
        }

        void OnItemsClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(GroceryList.ItemsActivity));
            StartActivity(intent);
        }

        void OnAddItemClick(object sender, EventArgs e)
        {
            StartActivityForResult(new Intent(this, typeof(GroceryList.AddItemActivity)), AddItemCode);
        }

        void OnAboutClick(object sender, EventArgs e)
        {
            StartActivity(typeof(GroceryList.AboutActivity));
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok && requestCode == AddItemCode)
            {
                Items.Add(new Item { Name = data.GetStringExtra("ItemName"), Count = data.GetIntExtra("ItemCount", -1) });
            }
        }
    }
}