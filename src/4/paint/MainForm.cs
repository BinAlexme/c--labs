using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace paint
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new CanvasForm
            {
                MdiParent = this,
                Text = "Рисунок " + this.MdiChildren.Length.ToString()
            };

            this.saveToolStripMenuItem.Enabled = true;
            this.saveAsToolStripMenuItem.Enabled = true;

            f.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory
            };

            DialogResult dialogResult = openFileDialog.ShowDialog();


            for (int i = 0; i < this.MdiChildren.Length; ++i)
            {
                CanvasForm canvas = (CanvasForm)this.MdiChildren[i];
                if (canvas.FilePathSave == openFileDialog.FileName)
                {
                    MessageBox.Show("Файл с данным именем уже открыт!");
                    return;
                }
            }


            if (dialogResult == DialogResult.OK)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                List<Figure> array = (List<Figure>)formatter.Deserialize(stream);
                stream.Close();

                CanvasForm canvas = new CanvasForm
                {
                    Array = array,
                    Text = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('\\') + 1),
                    FilePathSave = openFileDialog.FileName
                };

                Form f = canvas;
                f.MdiParent = this;

                this.saveToolStripMenuItem.Enabled = true;
                this.saveAsToolStripMenuItem.Enabled = true;

                f.Show();
            }
        }

        public void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanvasForm canvas = (CanvasForm)this.ActiveMdiChild;

            if (canvas.FilePathSave == "")
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(canvas.FilePathSave, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, canvas.Array);
                stream.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = "pic",
                Title = "Сохранить",
                FileName = "Изображение",
                InitialDirectory = Environment.CurrentDirectory
            };

            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                CanvasForm canvas = (CanvasForm)this.ActiveMdiChild;

                canvas.FilePathSave = saveFileDialog.FileName;
                canvas.Text = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('\\') + 1);

                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, canvas.Array);
                stream.Close();
            }
        }
        public void DisableSave()
        {
            if (this.MdiChildren.Length <= 1)
            {
                this.saveToolStripMenuItem.Enabled = false;
                this.saveAsToolStripMenuItem.Enabled = false;
            }
        }

    }
}
