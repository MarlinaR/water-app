using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wawa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        public string amount_ = null;
        public string img_ = null;
        public string name_ = null;
        public bool success_ = false; 

        private void Button_Clicked_b(object sender, EventArgs e)
        {
            if (amount_ != null)
            {
                success_ = true;
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("You didn't choose anything!", "", "Ok");
            }

        }
        
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            step.Children.Clear();

            var l = new Label()
            {
                Margin = new Thickness(20, 0, 0, 35),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = "0",
                FontFamily = "2221.ttf#PTSans-Regular"
            };

            step.Children.Add(l, 0, 0);

            var s = new Stepper()
            {
                Value = 0,
                Minimum = 0,
                Increment = 1,
                HorizontalOptions = LayoutOptions.Center
            };

            step.Children.Add(s, 1, 0);

            s.ValueChanged += (a, b) =>
            {
                l.Text = b.NewValue.ToString();
                amount_ = l.Text;
            };

            name_ = $"{(sender as Picker)?.SelectedItem}";

            switch (name_) 
            {
                case "Water":
                    {
                        img.Source = "water.jpg";
                        img_ = "water.jpg";
                        break;
                    }
                case "Juice":
                    {
                        img.Source = "juice.jpeg";
                        img_ = "juice.jpeg";
                        break;
                    }
                case "Pepsi":
                    {
                        img.Source = "pepsi.jpg";
                        img_ = "pepsi.jpg";
                        break;
                    }
            }
        }
    }
}