using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RockPaperScissors
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false); // hide navbar
            InitializeComponent();

            // set positioning and size of mainpage buttons
            mainbuttons.Children.Add(playbutton, new Rectangle(0.5, 0.05, 1, 0.3), AbsoluteLayoutFlags.All);
            mainbuttons.Children.Add(helpbutton, new Rectangle(0.5, 0.5, 1, 0.3), AbsoluteLayoutFlags.All);
            mainbuttons.Children.Add(exitbutton, new Rectangle(0.5, 0.95, 1, 0.3), AbsoluteLayoutFlags.All);
            
        }
        // set width and height to 0
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
                if (width > height) // horizontal
                {
                    mainbuttons.Children.Add(playbutton, new Rectangle(0.16, 0.1, 0.25, 0.5), AbsoluteLayoutFlags.All);
                    mainbuttons.Children.Add(helpbutton, new Rectangle(0.5, 0.1, 0.25, 0.5), AbsoluteLayoutFlags.All);
                    mainbuttons.Children.Add(exitbutton, new Rectangle(0.84, 0.1, 0.25, 0.5), AbsoluteLayoutFlags.All);
                    mainlogo.HeightRequest = 200; // request 200px as mainlogos height
                }
                else // vertical
                {
                    mainbuttons.Children.Add(playbutton, new Rectangle(0.5, 0.05, 1, 0.3), AbsoluteLayoutFlags.All);
                    mainbuttons.Children.Add(helpbutton, new Rectangle(0.5, 0.5, 1, 0.3), AbsoluteLayoutFlags.All);
                    mainbuttons.Children.Add(exitbutton, new Rectangle(0.5, 0.95, 1, 0.3), AbsoluteLayoutFlags.All);
                    mainlogo.HeightRequest = -1; // set mainlogos height to auto
                }
            }
            else if (Device.RuntimePlatform == Device.UWP) // UWP
            {
                mainlogo.HeightRequest = 400; // request 400px as mainlogos height
                mainbuttons.Children.Add(playbutton, new Rectangle(0.5, 0.05, 0.5, 0.3), AbsoluteLayoutFlags.All);
                mainbuttons.Children.Add(helpbutton, new Rectangle(0.5, 0.5, 0.5, 0.3), AbsoluteLayoutFlags.All);
                mainbuttons.Children.Add(exitbutton, new Rectangle(0.5, 0.95, 0.5, 0.3), AbsoluteLayoutFlags.All);
            }
        }

        // checks for what button was clicked and redirects you to the right location
        private async void Navigate_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender; // cast sender to button b
            var name = b.ClassId; // assign the classID to name

            switch(name) // this switch lets us know what button was clicked and then can call the appropriate method
            {
                case "play":
                    await Navigation.PushAsync(new Game()); // navigate to game.xaml
                    break;
                case "help":
                    await Navigation.PushAsync(new Help()); // navigate to  help.xaml
                    break;
                case "exit":
                    System.Diagnostics.Process.GetCurrentProcess().Kill(); // exit app
                    break;
            }
            
        }
    }
}
