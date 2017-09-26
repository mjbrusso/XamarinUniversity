using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace TipCalculator
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private EditText inputBill;
        private Button calculateButton;
        private TextView outputTip, outputTotal;

        protected override void OnCreate(Bundle savedInstanceState)
        {            
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            inputBill = FindViewById<EditText>(Resource.Id.inputBill);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);

            calculateButton.Click += CalculateButton_Click;
        }

        private void CalculateButton_Click(object sender, System.EventArgs e)
        {
            float bill;
            if (float.TryParse(inputBill.Text, out bill))
            {
                float tip = bill * 0.15F;

                outputTip.Text = tip.ToString("C");
                bill += tip;
                outputTip.Text = bill.ToString("C");
            }
            else
            {
                Toast.MakeText(this, "Please enter amount", ToastLength.Long).Show();
                outputTip.Text = outputTip.Text = String.Empty;
            }

        }
    }
}

