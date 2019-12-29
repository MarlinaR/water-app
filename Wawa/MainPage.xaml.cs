using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wawa
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        ObservableCollection<Product> Prods { get; set; }

        public string a;

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Prods.Remove(((Product)(mi.CommandParameter)));
        }

        public MainPage()
        {
            InitializeComponent();

            Prods = new ObservableCollection<Product>();
            
            LV.ItemsSource = Prods;
            //var productDataTemplate = new DataTemplate(() =>
            //{
            //    var grid = new Grid();

            //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });
            //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });

            //    var nameLabel = new Label();
            //    var productImage = new Image { HeightRequest = 4, WidthRequest = 4 };
            //    var amountLabel = new Label();

            //    nameLabel.SetBinding(Label.TextProperty, "name");
            //    productImage.SetBinding(Image.SourceProperty, "imageSource");
            //    amountLabel.SetBinding(Label.TextProperty, "amount");
                
            //    grid.Children.Add(productImage);
            //    grid.Children.Add(nameLabel, 1, 0);
            //    grid.Children.Add(amountLabel, 2, 0);

            //    return new ViewCell { View = grid };
            //});

            ////var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true };
            ////deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            ////deleteAction.Clicked += async (sender, e) =>
            ////{
            ////    var mi = ((MenuItem)sender);
                
            ////};

            //products.Children.Add(new ListView { ItemsSource = prods, ItemTemplate = productDataTemplate });
            
        }

        private void Button_Clicked_p(object sender, EventArgs e)
        {
            var page1 = new Page1();

            page1.Disappearing += (a, b) =>
            {
                if (page1.success_)
                {
                    bool contains = false;
                    var p = new Product { name = page1.name_, imageSource = page1.img_, amount = int.Parse(page1.amount_) };
                    foreach (var t in Prods)
                    {
                        if (t.name == page1.name_) 
                        {
                            contains = true;
                            p = t;
                            Prods.Remove(t);
                            break;
                        } 
                    }

                    if (contains)
                    {
                        p.amount = int.Parse(page1.amount_);
                    }
                    
                    Prods.Add(p);
                    
                }
            };

            Navigation.PushAsync(page1);
        }

        private void Button_Clicked_o(object sender, EventArgs e)
        {
            if (Prods.Count > 0)
            {
                _ = DisplayAlert("Thank you!", "your order is sent", "Ok");
                Prods.Clear();
            }
        }
    }
}
