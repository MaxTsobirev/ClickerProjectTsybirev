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
        public static bool size = false;
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
            img = new Image {  };

            sw = new Switch
            {
                IsToggled = true,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            TapGestureRecognizer tap = new TapGestureRecognizer();
            
            tap.Tapped += Tap_Tapped; 
            sw.Toggled += Sw_Toggled;
            img.GestureRecognizers.Add(tap);
            Button button = new Button
            {
                Text = "Bonus(25)",
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsVisible = true
            };
            Button button2 = new Button
            {
                Text = "Bonus(50)",
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsVisible = true
            };
            Button button3 = new Button
            {
                Text = "+10",
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsVisible = true
            };
            button.Clicked += Button_Clicked;
            button2.Clicked += Button2_Clicked;
            button3.Clicked += Button3_Clicked;
            StackLayout st = new StackLayout { Children = { img, sw, button, button2,button3 } };
            Content = st;
            st.Children.Add(lb);
            
            


        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            if (i >= 10)
            {
                i += 10;

            }
        }
        Random rd = new Random();

        private void Button2_Clicked(object sender, EventArgs e)
        {
            if (i >= 50 && size ==  false)
            {
                
                img.Source = "ao25.png";
                this.BackgroundImage = "fonaomine.jpg";
                if (i >=50)
                {
                    size = true;
                }
            }
            else
            {
                img.Source = "ao50.png";
                size= false;
            }

        }

       

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (i >= 25)
            {
                img.Source = "homer.png";
                this.BackgroundImage = "ss.jpg";

            }
        }
        

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (sw.IsToggled)
            {
                img.Source = "moon.png";
                this.BackgroundImage = "fon1.jpg";
            }
            else
            {
                img.Source = "moon.png";
                this.BackgroundImage = "fon1.jpg";
            }
        }

        int i = 0;

        private async void Tap_Tapped(object sender, EventArgs e)
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