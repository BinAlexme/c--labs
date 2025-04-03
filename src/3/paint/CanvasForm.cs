using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint
{
    public partial class CanvasForm : Form
    {
        public CanvasForm()
        {
            InitializeComponent();
            array = new List<Figure>();
        }

        private void CanvasForm_MouseDown(object sender, MouseEventArgs e)
        {
            g = CreateGraphics();
            mousePresed = true;
            array.Add(new Rectangle(e.X, e.Y, e.X, e.Y));
        }

        private void CanvasForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePresed)
            {
                Point mousePoint = new Point(e.X, e.Y);
                array.Last().MouseMove(g, mousePoint);
            }
        }

        private void CanvasForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (mousePresed)
            {
                array.Last().Draw(g);
                Invalidate();
                mousePresed = false;
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure i in array)
            {
                i.Draw(g);
            }
        }



        Graphics g;
        List<Figure> array;
        bool mousePresed = false;

        private void CanvasForm_Load(object sender, EventArgs e)
        {

        }
    }
}
