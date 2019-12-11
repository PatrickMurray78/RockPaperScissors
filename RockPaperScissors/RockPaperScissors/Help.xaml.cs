using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RockPaperScissors
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Help : ContentPage
    {
        public Help()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private double width = 0;
        private double height = 0;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if ((width != this.width || height != this.height) && Device.RuntimePlatform != Device.UWP)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    Thickness margin = rulescontent.Margin;
                    margin.Top = -30;
                    rulescontent.Margin = margin;
                    rulescontent.Orientation = StackOrientation.Vertical;
                    images.Orientation = StackOrientation.Horizontal;
                    images.HorizontalOptions = LayoutOptions.CenterAndExpand;
                    images.Spacing = 40;
                    rules.Orientation = StackOrientation.Horizontal;
                    rules.Spacing = 40;
                    rules.HorizontalOptions = LayoutOptions.CenterAndExpand;
                    Thickness margin1 = rulestitle.Margin;
                    margin1.Top = -5;
                    rulestitle.Margin = margin1;
                    Thickness margin2 = rules.Margin;
                    margin2.Right = -40;
                    rules.Margin = margin2;
                    slcontent.Spacing = 30;
                    Thickness margin3 = slcontent.Margin;
                    margin3.Top = 0;
                    slcontent.Margin = margin3;
                }
                else
                {
                    Thickness margin4 = rulescontent.Margin;
                    margin4.Top = 0;
                    rulescontent.Margin = margin4;
                    rulescontent.Orientation = StackOrientation.Horizontal;
                    images.Orientation = StackOrientation.Vertical;
                    images.VerticalOptions = LayoutOptions.CenterAndExpand;
                    images.Spacing = 0;
                    rules.Orientation = StackOrientation.Vertical;
                    rules.Spacing = 110;
                    rules.VerticalOptions = LayoutOptions.CenterAndExpand;
                    Thickness margin5 = rules.Margin;
                    margin5.Right = 0;
                    rules.Margin = margin5;
                    slcontent.Spacing = 10;
                }
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                images.Spacing = 30;
                rules.Spacing = 140;
                slcontent.Spacing = 20;
                rulestitle.FontSize = 40;
                mainlayout.Children.Add(homebutton, new Rectangle(0.5, 0.9, 0.4, 0.1), AbsoluteLayoutFlags.All);
            }
        }
    }
}