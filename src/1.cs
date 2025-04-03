using System.Drawing;
using System.Windows.Forms;

namespace paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // Создаём графическую форму
            Graphics g = CreateGraphics();
            if (e.Button == MouseButtons.Left) //кнопка нажата левая
            {
                string pos = "X:" + e.X.ToString() + " Y:" + e.Y.ToString();
                g.DrawString(pos, new Font("Times New Roman", 8), 
                    new SolidBrush(Color.Black), new Point(e.X, e.Y));
            }
            else
            {
                MessageBox.Show("Нажата правая кнопка мыши"); //сообщение
                g.Clear(Color.White);
            }
        }
    }
}
