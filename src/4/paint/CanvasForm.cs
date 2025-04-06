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
    [Serializable()]
    public partial class CanvasForm : Form
    {
        public CanvasForm()
        {
            InitializeComponent();
            array = new List<Figure>();
        }

        private void CanvasForm_MouseDown(object sender, MouseEventArgs e)
        {
            isMousePresed = true;
            array.Add(new Rectangle(e.X, e.Y, e.X, e.Y));
            g = CreateGraphics();
        }

        private void CanvasForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMousePresed)
            {
                Point mousePoint = new Point(e.X, e.Y);
                array.Last().MouseMove(g, mousePoint);
                isMouseMoved = true;
            }
        }

        private void CanvasForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMousePresed && !isMouseMoved)
            {
                array.RemoveAt(array.Count - 1);
                isMousePresed = false;
                isMouseMoved = false;
            }
            else if (isMousePresed && isMouseMoved)
            {
                array.Last().Draw(g);
                Invalidate();
                isMousePresed = false;
                isMouseMoved = false;
                isModificated = true;
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure i in array)
            {
                g = CreateGraphics();
                i.Draw(g);
                g.Dispose();
            }
        }

        private void CanvasForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm m = (MainForm)this.ParentForm;
            m.DisableSave();
        }

        private void CanvasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isModificated)
            {
                DialogResult dialogResult = MessageBox.Show("Сохранить последнее изменение?", this.Text, MessageBoxButtons.YesNoCancel);

                if (dialogResult == DialogResult.Yes)
                {
                    MainForm mainWindow = (MainForm)this.MdiParent;

                    mainWindow.saveToolStripMenuItem_Click(sender, e);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        internal List<Figure> Array { get => array; set => array = value; }
        
        Graphics g;
        List<Figure> array;
        bool isMousePresed = false;
        bool isMouseMoved = false;
        public bool isModificated = false;
        public string FilePathSave = "";

    }
}
