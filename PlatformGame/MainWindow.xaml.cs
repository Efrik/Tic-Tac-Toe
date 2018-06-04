using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlatformGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UploadScore();
        }

        public enum players { X, O } //one player is called X, the other O
        public players player = players.X;
        public int turn = 0;
        public int winX = 0;
        public int winO = 0;
        public int draw = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Content == "")
            {
                if (player == players.X)
                {
                    button.Content = "X";
                    player = players.O;
                }
                else if (player == players.O)
                {
                    button.Content = "O";
                    player = players.X;

                }
                turn++;
                if (CheckWins())
                {
                    if (button.Content == "X")
                    {
                        MessageBox.Show("Player X won!");
                        winX++;
                    }
                    else
                    {
                        MessageBox.Show("Player O won!");
                        winO++;
                    }
                    NewGame();
                }
                if (CheckDraw())
                {
                    MessageBox.Show("Draw!");
                    draw++;
                    NewGame();
                }
                UploadScore();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void UploadScore()
        {
            Scores.Content = "Scores:\n" + " X wins: " + winX + "\n O wins: " + winO + "\n Draws: " + draw;
            Turn.Content = "Turn : " + turn;
        }

        private void Reset_Click(object sender, RoutedEventArgs e) //Reset the whole game
        {
            winX = 0;
            winO = 0;
            draw = 0;
            NewGame();
        }

        private void NewGame() //Start a new game
        { 
            Button11.Content = "";
            Button12.Content = "";
            Button13.Content = "";
            Button21.Content = "";
            Button22.Content = "";
            Button23.Content = "";
            Button31.Content = "";
            Button32.Content = "";
            Button33.Content = "";
            turn = 0;
        }

        private bool CheckDraw()
        {
            if (turn == 9) return true;
            else return false;
        }

        private bool CheckWins()
        {
            //Horizontals
            if ((Button11.Content == Button12.Content) && (Button12.Content == Button13.Content) && (Button13.Content != "")) return true;
            else if ((Button21.Content == Button22.Content) && (Button22.Content == Button23.Content) && (Button23.Content != "")) return true;
            else if ((Button31.Content == Button32.Content) && (Button32.Content == Button33.Content) && (Button33.Content != "")) return true;

            //Verticals
            else if ((Button11.Content == Button21.Content) && (Button21.Content == Button31.Content) && (Button31.Content != "")) return true;
            else if ((Button12.Content == Button22.Content) && (Button22.Content == Button32.Content) && (Button32.Content != "")) return true;
            else if ((Button13.Content == Button23.Content) && (Button23.Content == Button33.Content) && (Button33.Content != "")) return true;

            //Diagonals
            else if ((Button11.Content == Button22.Content) && (Button22.Content == Button33.Content) && (Button33.Content != "")) return true;
            else if ((Button13.Content == Button22.Content) && (Button22.Content == Button31.Content) && (Button31.Content != "")) return true;

            //otherwise
            else return false;
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }
    }
}
