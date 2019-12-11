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
            NavigationPage.SetHasNavigationBar(this, false); // removes action bar
            InitializeComponent ();

            // header layout
            AbsoluteLayout.SetLayoutBounds(header, new Rectangle(0, 0, 1, 0.07));
            AbsoluteLayout.SetLayoutFlags(header, AbsoluteLayoutFlags.All);
            header.Children.Add(titletext, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

            // score and result layout
            AbsoluteLayout.SetLayoutBounds(scorelabel, new Rectangle(0.5, 0.1, 1, 0.2));
            AbsoluteLayout.SetLayoutFlags(scorelabel, AbsoluteLayoutFlags.All);
            scorelabel.Children.Add(score, new Rectangle(0.5, 0, 0.4, 0.5), AbsoluteLayoutFlags.All);
            scorelabel.Children.Add(result, new Rectangle(0.5, 0.75, 1, 0.4), AbsoluteLayoutFlags.All);

            // moves layout
            AbsoluteLayout.SetLayoutBounds(moves, new Rectangle(0, 0.4, 1, 0.4));
            AbsoluteLayout.SetLayoutFlags(moves, AbsoluteLayoutFlags.All);
            moves.Children.Add(mymove, new Rectangle(0.1, 0.6, 0.35, 0.7), AbsoluteLayoutFlags.All);
            moves.Children.Add(computergo, new Rectangle(0.9, 0.6, 0.35, 0.7), AbsoluteLayoutFlags.All);
            moves.Children.Add(myturn, new Rectangle(0.17, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);
            moves.Children.Add(computersturn, new Rectangle(0.9, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);
            moves.Children.Add(versus, new Rectangle(0.5, 0.6, 0.2, 0.2), AbsoluteLayoutFlags.All);

            // imagebuttons layout
            AbsoluteLayout.SetLayoutBounds(images, new Rectangle(0, 0.8, 1, 0.2));
            AbsoluteLayout.SetLayoutFlags(images, AbsoluteLayoutFlags.All);
            images.Children.Add(rock, new Rectangle(0.15, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);
            images.Children.Add(paper, new Rectangle(0.5, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);
            images.Children.Add(scissors, new Rectangle(0.85, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);

            // main buttons layout
            AbsoluteLayout.SetLayoutBounds(buttons, new Rectangle(0, 1, 1, 0.15));
            AbsoluteLayout.SetLayoutFlags(buttons, AbsoluteLayoutFlags.All);
            buttons.Children.Add(best3, new Rectangle(0.28, 0, 0.3, 0.47), AbsoluteLayoutFlags.All);
            buttons.Children.Add(best5, new Rectangle(0.72, 0, 0.3, 0.47), AbsoluteLayoutFlags.All);
            buttons.Children.Add(homebutton, new Rectangle(0.5, 0.95, 0.3, 0.47), AbsoluteLayoutFlags.All);

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
                    // header layout
                    AbsoluteLayout.SetLayoutBounds(header, new Rectangle(0, 0, 1, 0.11));
                    AbsoluteLayout.SetLayoutFlags(header, AbsoluteLayoutFlags.All);
                    header.Children.Add(titletext, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

                    // score and results layout
                    AbsoluteLayout.SetLayoutBounds(scorelabel, new Rectangle(0.5, 0.17, 1, 0.3));
                    AbsoluteLayout.SetLayoutFlags(scorelabel, AbsoluteLayoutFlags.All);
                    scorelabel.Children.Add(score, new Rectangle(0.5, 0, 0.4, 0.55), AbsoluteLayoutFlags.All);
                    scorelabel.Children.Add(result, new Rectangle(0.5, 0.77, 1, 0.4), AbsoluteLayoutFlags.All);

                    // moves layout
                    AbsoluteLayout.SetLayoutBounds(moves, new Rectangle(0.5, 1, 0.6, 0.6));
                    AbsoluteLayout.SetLayoutFlags(moves, AbsoluteLayoutFlags.All);
                    moves.Children.Add(mymove, new Rectangle(0.1, 0.6, 0.35, 0.7), AbsoluteLayoutFlags.All);
                    moves.Children.Add(computergo, new Rectangle(0.9, 0.6, 0.35, 0.7), AbsoluteLayoutFlags.All);
                    moves.Children.Add(myturn, new Rectangle(0.17, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);
                    moves.Children.Add(computersturn, new Rectangle(0.9, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);
                    moves.Children.Add(versus, new Rectangle(0.5, 0.6, 0.2, 0.2), AbsoluteLayoutFlags.All);

                    // imagebuttons layout
                    AbsoluteLayout.SetLayoutBounds(images, new Rectangle(0, 0.15, 0.2, 1));
                    AbsoluteLayout.SetLayoutFlags(images, AbsoluteLayoutFlags.All);
                    images.Children.Add(rock, new Rectangle(0.5, 0.15, 100, 100), AbsoluteLayoutFlags.PositionProportional);
                    images.Children.Add(paper, new Rectangle(0.5, 0.56, 100, 100), AbsoluteLayoutFlags.PositionProportional);
                    images.Children.Add(scissors, new Rectangle(0.5, 0.97, 100, 100), AbsoluteLayoutFlags.PositionProportional);

                    // main buttons layout
                    AbsoluteLayout.SetLayoutBounds(buttons, new Rectangle(1, 0, 0.2, 1));
                    AbsoluteLayout.SetLayoutFlags(buttons, AbsoluteLayoutFlags.All);
                    buttons.Children.Add(best3, new Rectangle(0.5, 0.15, 0.8, 0.12), AbsoluteLayoutFlags.All);
                    buttons.Children.Add(best5, new Rectangle(0.5, 0.3, 0.8, 0.12), AbsoluteLayoutFlags.All);
                    buttons.Children.Add(homebutton, new Rectangle(0.5, 0.95, 0.8, 0.12), AbsoluteLayoutFlags.All);
                    best3.FontSize = 15;
                    best5.FontSize = 15;
                    homebutton.FontSize = 15;
                }
                else // portrait
                {
                    // header layout
                    AbsoluteLayout.SetLayoutBounds(header, new Rectangle(0, 0, 1, 0.07));
                    AbsoluteLayout.SetLayoutFlags(header, AbsoluteLayoutFlags.All);
                    header.Children.Add(titletext, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

                    // score and result layout
                    AbsoluteLayout.SetLayoutBounds(scorelabel, new Rectangle(0.5, 0.1, 1, 0.2));
                    AbsoluteLayout.SetLayoutFlags(scorelabel, AbsoluteLayoutFlags.All);
                    scorelabel.Children.Add(score, new Rectangle(0.5, 0, 0.4, 0.5), AbsoluteLayoutFlags.All);
                    scorelabel.Children.Add(result, new Rectangle(0.5, 0.75, 1, 0.4), AbsoluteLayoutFlags.All);

                    // moves layout
                    AbsoluteLayout.SetLayoutBounds(moves, new Rectangle(0, 0.4, 1, 0.4));
                    AbsoluteLayout.SetLayoutFlags(moves, AbsoluteLayoutFlags.All);
                    moves.Children.Add(mymove, new Rectangle(0.1, 0.6, 0.35, 0.7), AbsoluteLayoutFlags.All);
                    moves.Children.Add(computergo, new Rectangle(0.9, 0.6, 0.35, 0.7), AbsoluteLayoutFlags.All);
                    moves.Children.Add(myturn, new Rectangle(0.17, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);
                    moves.Children.Add(computersturn, new Rectangle(0.9, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);
                    moves.Children.Add(versus, new Rectangle(0.5, 0.6, 0.2, 0.2), AbsoluteLayoutFlags.All);

                    // imagebuttons layout
                    AbsoluteLayout.SetLayoutBounds(images, new Rectangle(0, 0.8, 1, 0.2));
                    AbsoluteLayout.SetLayoutFlags(images, AbsoluteLayoutFlags.All);
                    images.Children.Add(rock, new Rectangle(0.15, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);
                    images.Children.Add(paper, new Rectangle(0.5, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);
                    images.Children.Add(scissors, new Rectangle(0.85, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);

                    // mainbuttons layout
                    AbsoluteLayout.SetLayoutBounds(buttons, new Rectangle(0, 1, 1, 0.15));
                    AbsoluteLayout.SetLayoutFlags(buttons, AbsoluteLayoutFlags.All);
                    buttons.Children.Add(best3, new Rectangle(0.28, 0, 0.3, 0.47), AbsoluteLayoutFlags.All);
                    buttons.Children.Add(best5, new Rectangle(0.72, 0, 0.3, 0.47), AbsoluteLayoutFlags.All);
                    buttons.Children.Add(homebutton, new Rectangle(0.5, 0.95, 0.3, 0.47), AbsoluteLayoutFlags.All);
                }
            }
            else if (Device.RuntimePlatform == Device.UWP) // UWP
            {
                // moves layout
                moves.Children.Add(myturn, new Rectangle(0.26, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);
                moves.Children.Add(computersturn, new Rectangle(1, 0, 0.3, 0.2), AbsoluteLayoutFlags.All);

                // imagebuttons layout
                images.Children.Add(rock, new Rectangle(0.35, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);
                images.Children.Add(paper, new Rectangle(0.5, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);
                images.Children.Add(scissors, new Rectangle(0.65, 0.9, 100, 100), AbsoluteLayoutFlags.PositionProportional);

                // mainbuttons layout
                buttons.Children.Add(best3, new Rectangle(0.28, 0, 0.3, 0.47), AbsoluteLayoutFlags.All);
                buttons.Children.Add(best5, new Rectangle(0.72, 0, 0.3, 0.47), AbsoluteLayoutFlags.All);
                buttons.Children.Add(homebutton, new Rectangle(0.5, 0.95, 0.3, 0.47), AbsoluteLayoutFlags.All);
                best3.FontSize = 25;
                best5.FontSize = 25;
                homebutton.FontSize = 25;
            }
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

            // if/else to find out what choice user picked and place corresponding image in moves layout
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

            DisableAllButtons(); // disables all buttons once one button is clicked

            await Task.Delay(300); // 300ms delay before my move gets shown
            mymove.Opacity = 1;

            ComputersTurn(move, b); // call ComputersTurn method
        }

        void DisableAllButtons() // disables all buttons
        {
            rock.IsEnabled = false;
            paper.IsEnabled = false;
            scissors.IsEnabled = false;
        }

        void EnableAllButtons() // enables all buttons
        {
            rock.IsEnabled = true;
            paper.IsEnabled = true;
            scissors.IsEnabled = true ;
        }

        private async void ComputersTurn(String move, ImageButton b)
        {
            // random generator to choose number between 0 and 2
            Random random = new Random();
            int randomNumber = random.Next(0, 3);
            String computerMove = String.Empty;

            await Task.Delay(1000); // 1000ms delay before computer move is displayed to moves layout
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

        // Winner method uses if/else to determine whether you won, lost or drew
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
            b.Opacity = 1; // set current imagebuttons opacity back to 1
            EnableAllButtons(); // enable all buttons after the result is in
        }
        
        // Scoreboard method adjusts the scoreboard when you win or lose
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

        // click event for the BestOf buttons
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
            mymove.Opacity = 0; // make the current moves invisible
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