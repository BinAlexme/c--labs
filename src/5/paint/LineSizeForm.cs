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
    public partial class LineSizeForm : Form
    {
        public LineSizeForm()
        {
            InitializeComponent();
        }

        public int GetSize()
        {
            Console.WriteLine(this.comboBox1.Text);
            return Convert.ToInt32(this.comboBox1.Text);
        }

        public void SetSize(int size)
        {
            this.comboBox1.Text = Convert.ToString(size);
        }
    }
}
