using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class Game : UserControl
    {

        public Game()
        {
            InitializeComponent();
        }

        Logic logic;
        Congrat congrat;

        private void Game_Load(object sender, EventArgs e)
        {
            foreach (PictureBox Cell in tableLayoutPanel1.Controls)
            {
                color_setting(Cell, Cell.Tag.ToString());
            }
            List<string> colors = new List<string>();
            List<int> column_numbers = new List<int>();
            foreach (PictureBox picture in panel1.Controls)
            {
                string[] temp = picture.Tag.ToString().Split(';');
                color_setting(picture, temp[0]);
            }
            logic = new Logic(tableLayoutPanel1, panel1);
        }

        void color_setting(PictureBox picture, string color)
        {
            switch (color)
            {
                case "Red":
                    picture.BackColor = System.Drawing.Color.Red;
                    break;
                case "Blue":
                    picture.BackColor = System.Drawing.Color.Blue;
                    break;
                case "Yellow":
                    picture.BackColor = System.Drawing.Color.Yellow;
                    break;
                case "Block":
                    picture.BackColor = System.Drawing.Color.DarkSlateGray;
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (logic.CellIsClicked((PictureBox)sender))
                if (logic.check())
                {
                    congrat = new Congrat();
                    congrat.Owner = this.ParentForm;
                    congrat.StartPosition = FormStartPosition.CenterParent;
                    congrat.ShowDialog();
                }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            logic.move_back();
        }
    }
}
