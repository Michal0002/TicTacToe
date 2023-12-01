using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {

        private Button[,] buttons;
        private char currentPlayer = 'X';
        private Label playerXInfoLabel;
        private Label playerOInfoLabel;

        public Form1()
        {
            InitializeComponent();
            InitializeBoard();
            InitializePlayerInfo();
        }
        private void InitializeBoard()
        {
            buttons = new Button[3, 3];

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    buttons[row, col] = new Button();
                    buttons[row, col].Width = 100;
                    buttons[row, col].Height = 100;
                    buttons[row, col].Top = row * 100;
                    buttons[row, col].Left = col * 100;
                    buttons[row, col].Tag = new Tuple<int, int>(row, col);
                    buttons[row, col].Font = new System.Drawing.Font("Arial", 50F);
                    buttons[row, col].Click += new EventHandler(Button_Click);

                    Controls.Add(buttons[row, col]);
                }
            }
            this.ClientSize = new System.Drawing.Size(400, 300);
        }

        private void InitializePlayerInfo()
        {
            playerXInfoLabel = new Label();
            playerXInfoLabel.Text = "Player 1: X";
            playerXInfoLabel.Font = new System.Drawing.Font("Arial", 10F);
            playerXInfoLabel.Top = 10;
            playerXInfoLabel.Left = 310;
            Controls.Add(playerXInfoLabel);

            playerOInfoLabel = new Label();
            playerOInfoLabel.Text = "Player 2: O";
            playerOInfoLabel.Font = new System.Drawing.Font("Arial", 10F);
            playerOInfoLabel.Top = 50;
            playerOInfoLabel.Left = 310;
            Controls.Add(playerOInfoLabel);
        }



        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton.Text != "")
            {
                MessageBox.Show("This field is already taken!", "Error");
                return;
            }

            UpdateButton(clickedButton);
            if (CheckForWinner())
            {
                MessageBox.Show("Player " + currentPlayer + " wins!", "Game result");
                ResetGame();
            }
            else if (IsBoardFull())
            {
                MessageBox.Show("Draw!", "Game result");
                ResetGame();

            }
            else
            {
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                
            }

        }

        private void UpdateButton(Button button)
        {
            Tuple<int, int> position = (Tuple<int, int>)button.Tag;
            buttons[position.Item1, position.Item2].Text = currentPlayer.ToString();
            button.BackColor = (currentPlayer == 'X') ? Color.LightSkyBlue : Color.LightSalmon;
        }
        private bool CheckForWinner()
        {
            for (int i = 0; i<3; i++)
            {
                //row victory
                if (buttons[i, 0].Text == currentPlayer.ToString() && buttons[i,1].Text == currentPlayer.ToString() && buttons[i,2].Text == currentPlayer.ToString())
                {
                    return true;
                }
                //column victoryr
                if (buttons[0,i].Text == currentPlayer.ToString() && buttons[1,i].Text == currentPlayer.ToString() && buttons[2,i].Text == currentPlayer.ToString())
                {
                    return true;
                }
            }
            //diag1
            if (buttons[0,0].Text == currentPlayer.ToString() && buttons[1,1].Text == currentPlayer.ToString() && buttons[2, 2].Text == currentPlayer.ToString())
            {
                return true;
            }
            //diag2
            else if (buttons[0, 2].Text == currentPlayer.ToString() && buttons[1, 1].Text == currentPlayer.ToString() && buttons[2, 0].Text == currentPlayer.ToString())
            {
                return true;
            }

            return false;
        }
        private bool IsBoardFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (buttons[row, col].Text == "")
                    {
                        return false;
                    }
                }

            }
            return true;

        }

        private void ResetGame()
        {
            foreach (Button button in buttons)
            {
                button.Text = "";
                button.BackColor = DefaultBackColor;
            }
            currentPlayer = 'X';
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
