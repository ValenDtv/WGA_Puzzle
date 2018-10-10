using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    class Logic
    {
        struct Plase
        {
            public int x;
            public int y;
        }

        struct Move
        {
            public Plase Old;
            public Plase New;
        }

        PictureBox ActiveСell = null;
        PictureBox[,] Field;
        List<string> Colors = new List<string>();
        List<int> Column_numbers = new List<int>();
        Stack<Move> Moves = new Stack<Move>();


        public Logic(TableLayoutPanel Pole, Panel panel)
        {
            foreach (PictureBox picture in panel.Controls)
            {
                string[] temp = picture.Tag.ToString().Split(';');
                Colors.Add(temp[0]);
                Column_numbers.Add(Convert.ToInt32(temp[1]));;
            }
            Field = new PictureBox[Pole.RowCount, Pole.ColumnCount];
            int k = Pole.Controls.Count - 1;
            for (int i = 0; i < Pole.RowCount; i++)
                for (int j = 0; j < Pole.ColumnCount; j++)
                {
                    Field[i, j] = (PictureBox)Pole.Controls[k];
                    k--;
                }
        }

        public bool check()
        {
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j=0; j<Colors.Count; j++)
                    if (Colors[j] != (string)Field[i, Column_numbers[j]].Tag)
                        return false;
            }
            return true;
        }

        public void move_back ()
        {
            if (Moves.Count <= 0)
                return;
            Move temp_move = Moves.Pop();
            int x_old = temp_move.Old.x, y_old = temp_move.Old.y;
            int x_new = temp_move.New.x, y_new = temp_move.New.y;
            System.Drawing.Color color = Field[x_old,y_old].BackColor;
            string temp_tag = (string)Field[x_old, y_old].Tag;
            Field[x_old, y_old].BackColor = Field[x_new, y_new].BackColor;
            Field[x_old, y_old].Tag = Field[x_new, y_new].Tag;
            Field[x_new, y_new].BackColor = color;
            Field[x_new, y_new].Tag = temp_tag;
            return;
        }

        public bool CellIsClicked(PictureBox Cell)
        {
            if ((string)Cell.Tag == "Block")
                return false;
            if (ActiveСell == null)
            {
                if ((string)Cell.Tag == "Empty")
                    return false;
                ActiveСell = Cell;
                Cell.BorderStyle = BorderStyle.Fixed3D;
                Padding pad = new Padding(4,4,4,4);
                Cell.Margin = pad;
                return false;
            }
            if (ActiveСell == Cell)
            {
                Cell.BorderStyle = BorderStyle.FixedSingle;
                Padding pad = new Padding(3, 3, 3, 3);
                Cell.Margin = pad;
                ActiveСell = null;
                return false;
            }
            if ((string)Cell.Tag != "Empty")
                return false;
            int x_act = 0, y_act = 0, x_clk = 0, y_clk = 0;
            for (int i=0; i < Field.GetLength(0); i++)
                for (int j = 0; j < Field.GetLength(1); j++)
                    {
                    if (ActiveСell == Field[i,j])
                        {
                            x_act = i;
                            y_act = j;
                        }
                    if (Cell == Field[i, j])
                        {
                            x_clk = i;
                            y_clk = j;
                        }
                }
            if (Math.Abs(x_act - x_clk) + Math.Abs(y_act - y_clk) <= 1)
            {
                ActiveСell.BorderStyle = BorderStyle.FixedSingle;
                Padding pad = new Padding(3, 3, 3, 3);
                ActiveСell.Margin = pad;
                System.Drawing.Color color = Cell.BackColor;
                string temp_tag = (string)Cell.Tag;
                Cell.Tag = ActiveСell.Tag;
                ActiveСell.Tag = temp_tag;
                Cell.BackColor = ActiveСell.BackColor;
                ActiveСell.BackColor = color;
                ActiveСell = null;
                Move move = new Move();
                move.Old.x = x_act; move.Old.y = y_act;
                move.New.x = x_clk; move.New.y = y_clk;
                Moves.Push(move);
                return true;
            }
            return false;

        }
    }
}
