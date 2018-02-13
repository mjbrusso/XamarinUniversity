using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(Phoneword.Droid.PhoneDialer))]

namespace Phoneword.Droid
{
    class PhoneDialer : Phoneword.IDialer
    {
        public Task<bool> DialAsync(string number)
        {
            return Task.Run(() =>
            {
                var uri = Android.Net.Uri.Parse("tel:"+number);
                var intent = new Intent(Intent.ActionDial, uri);
                
                MainActivity.Current.StartActivity(intent);
                return true;
            }
        );
        }
    }
}