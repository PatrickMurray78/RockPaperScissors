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
	public partial class Game : ContentPage
	{
        // declare and initialise global variables
        public static int myScore = 0;
        public static int computerScore = 0;
        public static int bestOf = 0;

        public Game ()
		{
            NavigationPage.SetHasNavigationBar(this, false); // hide action bar
            InitializeComponent ();

            // headerlayout
            AbsoluteLayout.SetLayoutBounds(headerlayout, new Rectangle(0, 0, 1, 0.07));
            AbsoluteLayout.SetLayoutFlags(headerlayout, AbsoluteLayoutFlags.All);
            headerlayout.Children.Add(titletext, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

            // scorelayout
            AbsoluteLayout.SetLayoutBounds(scorelayout, new Rectangle(0.5, 0.1, 1, 0.2));
            AbsoluteLayout.SetLayoutFlags(scorelayout, AbsoluteLayoutFlags.All);
            scorelayout.Children.Add(score, new Rectangle(0.5, 0, 0.4, 0.5), AbsoluteLayoutFlags.All);
            scorelayout.Children.Add(result, new Rectangle(0.5, 0.75, 1, 0.4), AbsoluteLayoutFlags.All);

            // moveslayout
            AbsoluteLayout.SetLayoutBounds(moveslayout, new Rectangle(0, 0.4, 1, 0.4));
            AbsoluteLayout.SetLayoutFlags(moveslayout, AbsoluteLayoutFlags.All);
            moveslayout.Children.Add(mymove, new Rectangle(0.1, 0.6, 0.35, 0.7), AbsoluteLayoutFlags.All);
            moveslayout.Children.Add(computergo, new Rectangle(0.9, 0.6, 0.35, 0.7), AbsoluteLayoutFlags.All);
            moveslayout.Children.Add(myturn, new Rectangle(0.17, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);
            moveslayout.Children.Add(computersturn, new Rectangle(0.9, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);
            moveslayout.Children.Add(versus, new Rectangle(0.5, 0.6, 0.2, 0.2), AbsoluteLayoutFlags.All);

            // imagebuttonslayout
            AbsoluteLayout.SetLayoutBounds(imagebuttonslayout, new Rectangle(0, 0.8, 1, 0.2));
            AbsoluteLayout.SetLayoutFlags(imagebuttonslayout, AbsoluteLayoutFlags.All);
            imagebuttonslayout.Children.Add(rock, new Rectangle(0.15, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);
            imagebuttonslayout.Children.Add(paper, new Rectangle(0.5, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);
            imagebuttonslayout.Children.Add(scissors, new Rectangle(0.85, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);

            // mainbuttonslayout
            AbsoluteLayout.SetLayoutBounds(mainbuttonslayout, new Rectangle(0, 1, 1, 0.15));
            AbsoluteLayout.SetLayoutFlags(mainbuttonslayout, AbsoluteLayoutFlags.All);
            mainbuttonslayout.Children.Add(best3, new Rectangle(0.28, 0, 0.3, 0.47), AbsoluteLayoutFlags.All);
            mainbuttonslayout.Children.Add(best5, new Rectangle(0.72, 0, 0.3, 0.47), AbsoluteLayoutFlags.All);
            mainbuttonslayout.Children.Add(homebutton, new Rectangle(0.5, 0.95, 0.3, 0.47), AbsoluteLayoutFlags.All);

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
                if (width > height) // landscape
                {
                    // headerlayout
                    AbsoluteLayout.SetLayoutBounds(headerlayout, new Rectangle(0, 0, 1, 0.11));
                    AbsoluteLayout.SetLayoutFlags(headerlayout, AbsoluteLayoutFlags.All);
                    headerlayout.Children.Add(titletext, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

                    // scorelayout
                    AbsoluteLayout.SetLayoutBounds(scorelayout, new Rectangle(0.5, 0.17, 1, 0.3));
                    AbsoluteLayout.SetLayoutFlags(scorelayout, AbsoluteLayoutFlags.All);
                    scorelayout.Children.Add(score, new Rectangle(0.5, 0, 0.4, 0.55), AbsoluteLayoutFlags.All);
                    scorelayout.Children.Add(result, new Rectangle(0.5, 0.77, 1, 0.4), AbsoluteLayoutFlags.All);

                    // moveslayout
                    AbsoluteLayout.SetLayoutBounds(moveslayout, new Rectangle(0.5, 1, 0.6, 0.6));
                    AbsoluteLayout.SetLayoutFlags(moveslayout, AbsoluteLayoutFlags.All);
                    moveslayout.Children.Add(mymove, new Rectangle(0.1, 0.6, 0.35, 0.7), AbsoluteLayoutFlags.All);
                    moveslayout.Children.Add(computergo, new Rectangle(0.9, 0.6, 0.35, 0.7), AbsoluteLayoutFlags.All);
                    moveslayout.Children.Add(myturn, new Rectangle(0.17, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);
                    moveslayout.Children.Add(computersturn, new Rectangle(0.9, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);
                    moveslayout.Children.Add(versus, new Rectangle(0.5, 0.6, 0.2, 0.2), AbsoluteLayoutFlags.All);

                    // imagebuttonslayout
                    AbsoluteLayout.SetLayoutBounds(imagebuttonslayout, new Rectangle(0, 0.15, 0.2, 1));
                    AbsoluteLayout.SetLayoutFlags(imagebuttonslayout, AbsoluteLayoutFlags.All);
                    imagebuttonslayout.Children.Add(rock, new Rectangle(0.5, 0.15, 100, 100), AbsoluteLayoutFlags.PositionProportional);
                    imagebuttonslayout.Children.Add(paper, new Rectangle(0.5, 0.56, 100, 100), AbsoluteLayoutFlags.PositionProportional);
                    imagebuttonslayout.Children.Add(scissors, new Rectangle(0.5, 0.97, 100, 100), AbsoluteLayoutFlags.PositionProportional);

                    // mainbuttonslayout
                    AbsoluteLayout.SetLayoutBounds(mainbuttonslayout, new Rectangle(1, 0, 0.2, 1));
                    AbsoluteLayout.SetLayoutFlags(mainbuttonslayout, AbsoluteLayoutFlags.All);
                    mainbuttonslayout.Children.Add(best3, new Rectangle(0.5, 0.15, 0.8, 0.12), AbsoluteLayoutFlags.All);
                    mainbuttonslayout.Children.Add(best5, new Rectangle(0.5, 0.3, 0.8, 0.12), AbsoluteLayoutFlags.All);
                    mainbuttonslayout.Children.Add(homebutton, new Rectangle(0.5, 0.95, 0.8, 0.12), AbsoluteLayoutFlags.All);
                    best3.FontSize = 15;
                    best5.FontSize = 15;
                    homebutton.FontSize = 15;
                }
                else // portrait
                {
                    // headerlayout
                    AbsoluteLayout.SetLayoutBounds(headerlayout, new Rectangle(0, 0, 1, 0.07));
                    AbsoluteLayout.SetLayoutFlags(headerlayout, AbsoluteLayoutFlags.All);
                    headerlayout.Children.Add(titletext, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

                    // scorelayout
                    AbsoluteLayout.SetLayoutBounds(scorelayout, new Rectangle(0.5, 0.1, 1, 0.2));
                    AbsoluteLayout.SetLayoutFlags(scorelayout, AbsoluteLayoutFlags.All);
                    scorelayout.Children.Add(score, new Rectangle(0.5, 0, 0.4, 0.5), AbsoluteLayoutFlags.All);
                    scorelayout.Children.Add(result, new Rectangle(0.5, 0.75, 1, 0.4), AbsoluteLayoutFlags.All);

                    // moveslayout
                    AbsoluteLayout.SetLayoutBounds(moveslayout, new Rectangle(0, 0.4, 1, 0.4));
                    AbsoluteLayout.SetLayoutFlags(moveslayout, AbsoluteLayoutFlags.All);
                    moveslayout.Children.Add(mymove, new Rectangle(0.1, 0.6, 0.35, 0.7), AbsoluteLayoutFlags.All);
                    moveslayout.Children.Add(computergo, new Rectangle(0.9, 0.6, 0.35, 0.7), AbsoluteLayoutFlags.All);
                    moveslayout.Children.Add(myturn, new Rectangle(0.17, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);
                    moveslayout.Children.Add(computersturn, new Rectangle(0.9, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);
                    moveslayout.Children.Add(versus, new Rectangle(0.5, 0.6, 0.2, 0.2), AbsoluteLayoutFlags.All);

                    // imagebuttonslayout
                    AbsoluteLayout.SetLayoutBounds(imagebuttonslayout, new Rectangle(0, 0.8, 1, 0.2));
                    AbsoluteLayout.SetLayoutFlags(imagebuttonslayout, AbsoluteLayoutFlags.All);
                    imagebuttonslayout.Children.Add(rock, new Rectangle(0.15, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);
                    imagebuttonslayout.Children.Add(paper, new Rectangle(0.5, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);
                    imagebuttonslayout.Children.Add(scissors, new Rectangle(0.85, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);

                    // mainbuttonslayout
                    AbsoluteLayout.SetLayoutBounds(mainbuttonslayout, new Rectangle(0, 1, 1, 0.15));
                    AbsoluteLayout.SetLayoutFlags(mainbuttonslayout, AbsoluteLayoutFlags.All);
                    mainbuttonslayout.Children.Add(best3, new Rectangle(0.28, 0, 0.3, 0.47), AbsoluteLayoutFlags.All);
                    mainbuttonslayout.Children.Add(best5, new Rectangle(0.72, 0, 0.3, 0.47), AbsoluteLayoutFlags.All);
                    mainbuttonslayout.Children.Add(homebutton, new Rectangle(0.5, 0.95, 0.3, 0.47), AbsoluteLayoutFlags.All);
                }
            }
            else if (Device.RuntimePlatform == Device.UWP) // UWP
            {
                // moveslayout
                moveslayout.Children.Add(myturn, new Rectangle(0.26, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);
                moveslayout.Children.Add(computersturn, new Rectangle(1, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);

                // imagebuttonslayout
                imagebuttonslayout.Children.Add(rock, new Rectangle(0.35, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);
                imagebuttonslayout.Children.Add(paper, new Rectangle(0.5, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);
                imagebuttonslayout.Children.Add(scissors, new Rectangle(0.65, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);

                // mainbuttonslayout
                mainbuttonslayout.Children.Add(best3, new Rectangle(0.28, 0, 0.3, 0.47), AbsoluteLayoutFlags.All);
                mainbuttonslayout.Children.Add(best5, new Rectangle(0.72, 0, 0.3, 0.47), AbsoluteLayoutFlags.All);
                mainbuttonslayout.Children.Add(homebutton, new Rectangle(0.5, 0.95, 0.3, 0.47), AbsoluteLayoutFlags.All);
                best3.FontSize = 25;
                best5.FontSize = 25;
                homebutton.FontSize = 25;
            }
        }

        void DisableAllmainbuttonslayout() // disables all mainbuttons
        {
            rock.IsEnabled = false;
            paper.IsEnabled = false;
            scissors.IsEnabled = false;
        }

        void EnableAllmainbuttonslayout() // enables all mainbuttons
        {
            rock.IsEnabled = true;
            paper.IsEnabled = true;
            scissors.IsEnabled = true;
        }

        // click event for when the imagebuttons are clicked
        private async void Button_Clicked(object sender, EventArgs e)
        {
            // check to see if the current score is on a bestOf score, if so reset the game
            if ((bestOf == myScore || bestOf == computerScore) && bestOf != 0)
            {
                Reset();
            }

            ImageButton b = (ImageButton)sender; // cast sender to imagebutton
            b.Opacity = .5;
            String move;
            computergo.Opacity = 0;
            result.Text = string.Empty;

            // if/else to find out what choice user picked and place corresponding image in moveslayout
            if (b.Id == rock.Id)
            {
                move = "rock";
                mymove.Source = "Rock.png";
                
            }
            else if (b.Id == paper.Id)
            {
                move = "paper";
                mymove.Source = "Paper.png";
               
            }
            else
            {
                move = "scissors";
                mymove.Source = "Scissors.png";
            }

            DisableAllmainbuttonslayout(); // disables all mainbuttons once one button is clicked

            await Task.Delay(300); // 300ms delay before my move gets shown
            mymove.Opacity = 1;

            ComputersTurn(move, b); // call ComputersTurn function
        }
        
        private async void ComputersTurn(String move, ImageButton b)
        {
            // random generator to choose number between 0 and 2
            Random random = new Random();
            int randomNumber = random.Next(0, 3);
            String computerMove = String.Empty;

            await Task.Delay(1000); // 1000ms delay before computer move is displayed to moveslayout layout
            switch (randomNumber) // switch statement to match the random number to a move
            {
                case 0:
                    computerMove = "rock";
                    computergo.Source = "Rock.png";
                    break;
                case 1:
                    computerMove = "paper";
                    computergo.Source = "Paper.png";
                    break;
                case 2:
                    computerMove = "scissors";
                    computergo.Source = "Scissors.png";
                    break;
            }
            computergo.Opacity = 1;
            Winner(move, computerMove, b); // call Winner method
        }

        // Winner function uses if/else to determine whether you won, lost or drew
        private async void Winner(String move, String computerMove, ImageButton b)
        {
            int win = 0;
            var str = string.Empty;

            await Task.Delay(300); // 300ms delay before the result is shown
            if (move == computerMove)
            {
                str = "Draw";
            }

            if (move == "rock" && computerMove == "paper")
            {
                str = "You Lose";
                win = 1;
            }
            else if (move == "rock" && computerMove == "scissors")
            {
                str = "You Win";
                win = 2;
            }
            else if (move == "paper" && computerMove == "rock")
            {
                str = "You Win";
                win = 2;
            }
            else if (move == "paper" && computerMove == "scissors")
            {
                str = "You Lose";
                win = 1;
            }
            else if (move == "scissors" && computerMove == "rock")
            {
                str = "You Lose";
                win = 1;
            }
            else if (move == "scissors" && computerMove == "paper")
            {
                str = "You Win";
                win = 2;
            }
            result.Text = str; // update the result label with the outcome

            Scoreboard(win); // call Scoreboard method
            b.Opacity = 1; // set current imagemainbuttonslayout opacity back to 1
            EnableAllmainbuttonslayout(); // enable all mainbuttonslayout after the result is in
        }
        
        // Scoreboard function adjusts the scoreboard when you win or lose
        private void Scoreboard(int win)
        {
            switch (win)
            {
                case 1:
                    computerScore++; // computers score increments with a win
                    break;
                case 2:
                    myScore++; // myscore increments with a win
                    break;
            }

            var str = String.Format("{0}-{1}", myScore, computerScore); // format the string with the variables
            score.Text = str; // update the scoreboard

            // When you play Best of 3 or Best of 5, the below code will inform you when you win overall
            var strWin = string.Empty;

            if(myScore == bestOf && bestOf != 0)
            {
                strWin = String.Format("You Win Best Of {0}", bestOf);
                result.Text = strWin;
                
            }
            else if(computerScore == bestOf && bestOf != 0)
            {
                strWin = String.Format("You Lose Best Of {0}", bestOf);
                result.Text = strWin;
            }
        }

        // function to check whether chose best of 3 or best of 5
        private void BestOf_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // cast button to btn
            Reset(); // reset the board as new game mode commences
            
            // if/else to determine whether the button clicked is best of 3 or best of 5
            if (btn.Id == best3.Id)
            {
                bestOf = 3;
                best3.BackgroundColor = Color.LightGray; // change button background so we know which mode we are in
            }
            else
            {
                bestOf = 5;
                best5.BackgroundColor = Color.LightGray;
            }
                
        }

        // the reset method, resets everything in the game and is called upon in a few situations
        private void Reset()
        {
            bestOf = 0;
            myScore = 0;
            computerScore = 0;
            var str = String.Format("{0}-{1}", myScore, computerScore);
            score.Text = str;
            result.Text = string.Empty;
            best3.BackgroundColor = Color.White;
            best5.BackgroundColor = Color.White;
            mymove.Opacity = 0; // make the current moveslayout invisible
            computergo.Opacity = 0;
        }

        // click event for home button which resets game as it goes to mainpage
        private async void Home_Clicked(object sender, EventArgs e)
        {
            Reset();
            await Navigation.PushAsync(new MainPage()); // navigate to mainpage
        }
    }
}