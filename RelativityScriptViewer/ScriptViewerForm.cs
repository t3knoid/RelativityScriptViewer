using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelativityScriptViewer
{
    public partial class ScriptViewerForm : Form
    {
        public string ScriptText { get; set; }
        public string ScriptName { get; set; }
        public ScriptViewerForm()
        {
            InitializeComponent();
        }

        private void ScriptViewerForm_Load(object sender, EventArgs e)
        {
            tbViewer.Text = ScriptText;
            this.Text = this.Text + " " + ScriptName;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "SQL file|*.sql";
            saveFileDialog1.Title = "Save SQL Script";
            saveFileDialog1.FileName = ScriptName + ".sql";
            saveFileDialog1.ShowDialog();

            try
            {
                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    File.WriteAllText(@saveFileDialog1.FileName, ScriptText);
                }
            }
            catch (Exception ex)
            {
                // Something failed saving the file
                MessageBox.Show("Save error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
