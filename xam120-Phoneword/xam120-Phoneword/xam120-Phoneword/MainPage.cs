using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Phoneword

{
    public partial class MainPage : ContentPage
    {
        private Label phonewordLabel = new Label
        {
            Text = "Enter a Phoneword:",
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
        };
        private Entry phonewordEntry = new Entry
        {
            Text = "1-855-XAMARIN"
        };
        private Button translateButton = new Button
        {
            Text = "Translate",
        };
        private Button callButton = new Button
        {
            Text = "Call",
            IsEnabled = false
        };

        private String translatedNumber;

        public MainPage()
        {
            

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 2,
                Padding = new Thickness(5),
                Children = { phonewordLabel, phonewordEntry, translateButton, callButton }
            };
            translateButton.Clicked += TranslateButton_Clicked;
            callButton.Clicked += CallButton_ClickedAsync;
            phonewordEntry.TextChanged += PhonewordEntry_TextChanged;
        }

        private void PhonewordEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            callButton.Text = "Call";
            callButton.IsEnabled = false;
        }

        private async void CallButton_ClickedAsync(object sender, EventArgs e)
        {
            if(await DisplayAlert("Dial a Number", String.Format("Would you like to call {0}?", translatedNumber), "Yes", "No")){
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                    await dialer.DialAsync(translatedNumber);
            }
        }

        private void TranslateButton_Clicked(object sender, EventArgs e)
        {
            translatedNumber = PhonewordTranslator.ToNumber(phonewordEntry.Text);
            if (!String.IsNullOrEmpty(translatedNumber))
            {
                callButton.Text = "Call " + translatedNumber;
                callButton.IsEnabled = true;
            }
            else
            {
                callButton.Text = "Call";
                callButton.IsEnabled = false;
            }

        }
    }
}