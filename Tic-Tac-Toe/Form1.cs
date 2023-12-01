﻿using System;
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

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
