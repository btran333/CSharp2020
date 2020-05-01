//Bao Tran
//Homework 5

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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[,] buttonBox = new string[3, 3];
        bool X_play = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            
            //extract row and col position when a button is clicked.
            string aStr = b.Tag.ToString();
            string[] aStrPlit = aStr.Split(',');
            int row = Convert.ToInt32(aStrPlit[0]);
            int col = Convert.ToInt32(aStrPlit[1]);

            //Set value and properties of each button when playing.
            if (X_play == true)
            {
                buttonBox[row, col] = "X";
                b.Content = "X";
                b.IsEnabled = false;
                X_play = false;
                uxTurn.Text = "O's turn";
            }
            else
            {
                buttonBox[row, col] = "O";
                b.Content = "O";
                b.IsEnabled = false;
                X_play = true;
                uxTurn.Text = "X's turn";
            }

            //Check if there is a winnder, disable any move.
            if (isWinner(row, col))
            {
                uxTurn.Text = b.Content + " won!";
                uxGrid.IsEnabled = false;
            }
        }

        //Check if there is a winner
        private bool isWinner(int curr_i, int curr_j)
        {
            bool result = true;

            //Check horizontal boxes
            for (int j = 0; j < 3; j++)
                if (buttonBox[curr_i, j] != buttonBox[curr_i, curr_j])
                    result = false;

            //if the horizontal check is not winning, 
            //reset result = true to contiue checking vertial boxes
            if (result) return true;
            else result = true;

            //check vertical boxes
            for (int i = 0; i < 3; i++)
                if (buttonBox[i, curr_j] != buttonBox[curr_i, curr_j])
                    result = false;

            //if the vertical check is not winning, 
            //reset result = true to contiue checking diagonal direction
            if (result) return true;
            else result = true;

            //check diagonal to the right
            for (int i = 0; i < 3; i++)
                if (buttonBox[i, i] != buttonBox[curr_i, curr_j])
                    result = false;

            //if the diagonal check is not winning, 
            //reset result = true to contiue checking diagonal left direction
            if (result) return true;
            else result = true;

            //check diagonal to the left
            for (int i = 0; i < 3; i++)
                if (buttonBox[i, 2-i] != buttonBox[curr_i, curr_j])
                    result = false;

            return result;
        }


        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            //clear and reset all buttons
            foreach (Control aControl in uxGrid.Children)
            {
                if (aControl is Button)
                {
                    var aButton = (Button)aControl;
                    aButton.Content = null;
                    aButton.IsEnabled = true;
                }
            }

            //Alo clear array holding "X" and "O"
            Array.Clear(buttonBox,0,buttonBox.Length);

            //Enable the game board.
            uxGrid.IsEnabled = true;

            //X plays first.
            X_play = true;
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
