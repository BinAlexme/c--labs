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

        private void Form2_MouseDown(object sender, MouseEventArgs e) // вызываем запрос взамодействия мыши
        {

            g = CreateGraphics();
            mousePresed = true; //мыши кнопка зажата 
            x1 = x2 = e.X;
            y1 = y2 = e.Y;
            rectangleDash = rectangleLine = Rectangle.FromLTRB(x1, y1, x2, y2); // прямоуголькин штриховка объединяем с прямоугольником линий
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e) // вызываем запрос перемещения мыши
        {
            if (mousePresed)
            {
                // даем описание
                Pen pen = new Pen(Color.Black, 3);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                Pen eraser = new Pen(Color.White, 3);

                g.DrawRectangle(eraser, rectangleDash); // рисуем ластик и прямоугольник

                x2 = e.X;
                y2 = e.Y;

                // сортировка координат
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

                // рисуем прямоугольнику линии и прочерки
                g.DrawRectangle(pen, rectangleLine);
                rectangleDash = rectangleLine;
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e) // вызываем запрос ведение мыши
        {
            if (mousePresed)
            {
                Pen pen = new Pen(Color.Black, 3);

                g.DrawRectangle(pen, rectangleLine);

                mousePresed = false;
            }
        }


        // обозначение всех точек
        int x1;
        int x2;
        int y1;
        int y2;

        Rectangle rectangleDash; // прямогульник прочерк
        Rectangle rectangleLine; // прямогульник линия

        Graphics g;

        bool mousePresed = false; // проверка нажата ли кнопка мыши (состояние мыши)

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
