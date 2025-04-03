using System;
using System.Drawing;
using System.Windows.Forms;

namespace paint
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            g = CreateGraphics();
            mousePresed = true;
            x1 = x2 = e.X;
            y1 = y2 = e.Y;
            rectangleDash = rectangleLine = Rectangle.FromLTRB(x1, y1, x2, y2);
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePresed)
            {
                Pen pen = new Pen(Color.Black, 3);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                Pen eraser = new Pen(Color.White, 3);

                g.DrawRectangle(eraser, rectangleDash);

                x2 = e.X;
                y2 = e.Y;

                // упорядочивание координат
                // таким образом, чтобы в первой паре аргументов
                // передавались всегда меньшие значения координа
                if ((x1 <= e.X) && (y1 >= e.Y))
                {
                    rectangleLine = Rectangle.FromLTRB(x1, y2, x2, y1);
                }
                else if ((x1 >= e.X) && (y1 >= e.Y))
                {
                    rectangleLine = Rectangle.FromLTRB(x2, y2, x1, y1);
                }
                else if ((x1 >= e.X) && (y1 <= e.Y))
                {
                    rectangleLine = Rectangle.FromLTRB(x2, y1, x1, y2);
                }
                else
                {
                    rectangleLine = Rectangle.FromLTRB(x1, y1, x2, y2);
                }

                g.DrawRectangle(pen, rectangleLine);
                rectangleDash = rectangleLine;
            }
        }


        int x1;
        int x2;
        int y1;
        int y2;

        Graphics g;

        bool mousePresed = false;

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
