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
            NavigationPage.SetHasNavigationBar(this, false); // hide navbar
            InitializeComponent();
        }

        // Click event for the home button
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private double width = 0;
        private double height = 0;

        // if/else  to check if user is in portrait or landscape mode or using UWP
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if ((width != this.width || height != this.height) && Device.RuntimePlatform != Device.UWP)
            {
                this.width = width;
                this.height = height;
                if (width > height) // landscape
                {
                    // SLcontent layout
                    slcontent.Spacing = 30;
                    Thickness margin3 = slcontent.Margin;
                    margin3.Top = 0;
                    slcontent.Margin = margin3;
                    // rulestitle label
                    Thickness margin1 = rulestitle.Margin;
                    margin1.Top = -5;
                    rulestitle.Margin = margin1;
                    // rulescontent layout
                    Thickness margin = rulescontent.Margin;
                    margin.Top = -30;
                    rulescontent.Margin = margin;
                    rulescontent.Orientation = StackOrientation.Vertical;
                    // image layout
                    imagelayout.Orientation = StackOrientation.Horizontal;
                    imagelayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
                    imagelayout.Spacing = 40;
                    // rules text
                    rules.Orientation = StackOrientation.Horizontal;
                    rules.Spacing = 40;
                    rules.HorizontalOptions = LayoutOptions.CenterAndExpand;
                    Thickness margin2 = rules.Margin;
                    margin2.Right = -40;
                    rules.Margin = margin2;
                    
                }
                else // Portait
                {
                    // slcontent layout
                    slcontent.Spacing = 10;
                    // rulescontent layout
                    Thickness margin4 = rulescontent.Margin;
                    margin4.Top = 0;
                    rulescontent.Margin = margin4;
                    rulescontent.Orientation = StackOrientation.Horizontal;
                    // image layout
                    imagelayout.Orientation = StackOrientation.Vertical;
                    imagelayout.VerticalOptions = LayoutOptions.CenterAndExpand;
                    imagelayout.Spacing = 0;
                    // rules text 
                    rules.Orientation = StackOrientation.Vertical;
                    rules.Spacing = 110;
                    rules.VerticalOptions = LayoutOptions.CenterAndExpand;
                    Thickness margin5 = rules.Margin;
                    margin5.Right = 0;
                    rules.Margin = margin5;
                }
            }
            else if (Device.RuntimePlatform == Device.UWP) // UWP
            {
                // main layout
                mainlayout.Children.Add(homebutton, new Rectangle(0.5, 0.9, 0.4, 0.1), AbsoluteLayoutFlags.All);
                //slcontent layout
                slcontent.Spacing = 20;
                // rulestitle label
                rulestitle.FontSize = 40;
                // image layout
                imagelayout.Spacing = 30;
                // rules text
                rules.Spacing = 140;
                
            }
        }
    }
}