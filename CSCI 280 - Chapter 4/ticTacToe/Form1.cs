using System;
using System.Windows.Forms;

namespace ticTacToe
{
    public partial class mainForm : Form
    {
        private const string PLAYER = "X", AI = "O";

        private string [,] textButtonValues;
        public mainForm()
        {
            InitializeComponent();
            textButtonValues = new string[3, 3] { { " ", " ", " " },
                                                { " ", " ", " " },
                                                { " ", " ", " " }};
        }

        private void button_Click(object sender, EventArgs e)
        {

            // Get the sender as a Button.
            Button myButton = sender as Button;
            

            switch (myButton.Name)
            {
                case "firstLeftButton":
                    textButtonValues[0, 0] = PLAYER;
                    break;
                case "firstMiddleButton":
                    textButtonValues[0, 1] = PLAYER;
                    break;

                case "firstRightButton":
                    textButtonValues[0, 2] = PLAYER;
                    break;

                case "secondLeftButton":
                    textButtonValues[1, 0] = PLAYER;
                    break;
                case "secondMiddleButton":
                    textButtonValues[1, 1] = PLAYER;
                    break;

                case "secondRightButton":
                    textButtonValues[1, 2] = PLAYER;
                    break;

                case "thirdLeftButton":
                    textButtonValues[2, 0] = PLAYER;
                    break;
                case "thirdMiddleButton":
                    textButtonValues[2, 1] = PLAYER;
                    break;

                case "thirdRightButton":
                    textButtonValues[2, 2] = PLAYER;
                    break;
            }
           

            updateAllButtons();
            disableAllButtons();
        }

        private void updateAllButtons()
        {
            firstLeftButton.Text = textButtonValues[0,0]; 
            firstMiddleButton.Text = textButtonValues[0,1];
            firstRightButton.Text = textButtonValues[0,2];
            secondLeftButton.Text = textButtonValues[1,0];
            secondMiddleButton.Text = textButtonValues[1,1];
            secondRightButton.Text = textButtonValues[1,2];
            thirdLeftButton.Text = textButtonValues[2,0];
            thirdMiddleButton.Text = textButtonValues[2,1];
            thirdRightButton.Text = textButtonValues[2,2];
        }

        private void disableAllButtons()
        {
            firstLeftButton.Enabled = false;
            firstMiddleButton.Enabled = false;
            firstRightButton.Enabled = false;
            secondLeftButton.Enabled = false;
            secondMiddleButton.Enabled = false;
            secondRightButton.Enabled = false;
            thirdLeftButton.Enabled = false;
            thirdMiddleButton.Enabled = false;
            thirdRightButton.Enabled = false;
        }

        private void enableAllButtons()
        {
            firstLeftButton.Enabled = true;
            firstMiddleButton.Enabled = true;
            firstRightButton.Enabled = true;
            secondLeftButton.Enabled = true;
            secondMiddleButton.Enabled = true;
            secondRightButton.Enabled = true;
            thirdLeftButton.Enabled = true;
            thirdMiddleButton.Enabled = true;
            thirdRightButton.Enabled = true;
        }

        private void aiButton_Click(object sender, EventArgs e)
        {
            takeAIturn();
            enableAllButtons();
        }


        // Tic Tac Toe is a very small game, so we are going to traverse the entire tree
        private void takeAIturn()
        {
            int bestScore = -2;
            int move_i = -1, move_j = -1;

            // Move through all possible positions
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (textButtonValues[i, j] == " ")
                    {
                        textButtonValues[i, j] = AI;

                        var newScore = -negamax(textButtonValues, -1); // test board for player
                        if (newScore > bestScore)
                        {
                            bestScore = newScore;
                            move_i = i;
                            move_j = j;
                        }

                        // undo move
                        textButtonValues[i, j] = " ";
                    }
                }
            }

            if (move_i != -1 && move_j != -1) // if -1 game is over
                textButtonValues[move_i, move_j] = AI;

            updateAllButtons();
        }

        // Tree is small enough that we don't care about depth, we can do the entire thing
        private int negamax(string[,] board, int player = 1)
        {
            int win = getWinner(board);

            if (win == 1 || win == -1)
                return win*player; // eg. -1*-1 = 1 (So -negamax works below)

            int score = -2;

            // track if we find a possible winning move
            bool found = false;

            // Move through all possible positions
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == " ") // can move
                    {
                        board[i, j] = player == 1 ? "O" : "X"; // 1 for AI, -1 for player

                        var newScore = -negamax(board, -player); // negamax formula
                        if (newScore > score)
                        {
                            score = newScore;
                            found = true;
                        }

                        // undo move
                        board[i, j] = " ";
                    }
                }
            }

            if (!found)
                return 0; // draw

            return score;
        }

        // Checks board for a winner. Return 1 for AI win, -1 for player win
        private int getWinner(string[,] board)
        {
            // Checks row and columns for winner
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != " " && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return board[i, 0] == AI ? 1 : -1;
                }

                if (board[0, i] != " " && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return board[0, i] == AI ? 1 : -1;
                }
            }

            // Diagonals
            if (board[0, 0] != " " && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return board[0, 0] == AI ? 1 : -1;
            }
            if (board[0, 2] != " " && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return board[0, 2] == AI ? 1 : -1;
            }

            return 0; // no win/draw
        }
    }
}
