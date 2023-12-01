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
        public Form1()
        {
            InitializeComponent();
            InitializeBoard();
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
                    buttons[row, col].Font = new System.Drawing.Font("Arial", 20F);
                    buttons[row, col].Click += new EventHandler(Button_Click);

                    Controls.Add(buttons[row, col]);
                }
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton.Text != "")
            {
                MessageBox.Show("This field is already taken!", "Error");
            }

            UpdateButton(clickedButton);
            if (CheckForWinner())
            {
                MessageBox.Show("Player " + currentPlayer + " wins!", "Game result");
            }
            else if (IsBoardFull())
            {
                MessageBox.Show("Draw!", "Game result");

            }
            else
            {
                currentPlayer = (currentPlayer == 'X') ? '0' : 'X';
            }

        }

        private void UpdateButton(Button button)
        {
            Tuple<int, int> position = (Tuple<int, int>)button.Tag;
            buttons[position.Item1, position.Item2].Text = currentPlayer.ToString();
        }
        private bool CheckForWinner()
        {
            return true;
        }
        private bool IsBoardFull()
        {
            return false;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
