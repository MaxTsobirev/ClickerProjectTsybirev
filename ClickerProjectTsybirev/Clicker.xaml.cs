using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClickerProjectTsybirev
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Clicker : ContentPage
    {
        Label lb;
        BoxView box;
        Image img;
        Switch sw;
        Button button;
        public Clicker()
        {
            this.BackgroundColor = Color.White;
            lb = new Label()
            {
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start

            };
            img = new Image { };

            sw = new Switch
            {
                IsToggled = true,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped; ;
            sw.Toggled += Sw_Toggled;
            img.GestureRecognizers.Add(tap);
            Button button = new Button
            {
                Text = "Нажми!",
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout st = new StackLayout { Children = { img, sw, button } };
            Content = st;
            st.Children.Add(lb);
            


        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (sw.IsToggled)
            {
                img.Source = "sonce.png";
                this.BackgroundImage = "nebo.jpg";
            }
            else
            {
                img.Source = "moon.png";
                this.BackgroundImage = "fon1.jpg";
            }
        }

        int i = 0;

        private void Tap_Tapped(object sender, EventArgs e)
        {
            i++;
            lb.Text = "Ты нажал " + i + " раз";
            if (i >= 1)
            {
                try
                {
                    // Use default vibration length
                    Vibration.Vibrate();

                    // Or use specified time
                    var duration = TimeSpan.FromSeconds(0.2);
                    Vibration.Vibrate(duration);
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Feature not supported on device
                }
                catch (Exception ex)
                {
                    // Other error has occurred.
                }
            }
        }
    }
}