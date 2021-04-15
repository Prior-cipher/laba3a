using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamforms
{
    public partial class MainPage : ContentPage
    {
        WebView webView;
        Entry alength;
        
        Label Anslabel;

        public MainPage()
        {
            alength = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };
            Anslabel = new Label { HorizontalOptions = LayoutOptions.FillAndExpand };
           Button button = new Button { Text = "Вычислить" };
            button.Clicked += button_Clicked;
            StackLayout stack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { alength ,button, Anslabel }
            };
            webView = new WebView
            {
                IsEnabled = false,
               IsVisible=false,
                Source = new UrlWebViewSource { Url = "https://threejs.org/docs/scenes/geometry-browser.html#DodecahedronGeometry" },
                // или так
                // Source = "https://devblogs.microsoft.com/xamarin/",
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            this.Content = new StackLayout { Children = { stack, webView } };
        }

        void button_Clicked(object sender, EventArgs e)
        {
            double a;
            double.TryParse(alength.Text,out a);
            a = 3 * Math.Pow(a, 2) * Math.Sqrt(5 * (5 + 2 * Math.Sqrt(5)));
            Anslabel.Text = a.ToString();
            webView.IsEnabled = true;
            webView.IsVisible = true;
        }
    }
}
