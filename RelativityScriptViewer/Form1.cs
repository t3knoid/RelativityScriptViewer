using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelativityScriptViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbScripts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbScripts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ViewSelectedScript();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RelativityScriptViewer.Properties.Settings settings = RelativityScriptViewer.Properties.Settings.Default;
            try
            {
                Relativity relativity = new Relativity(settings.MSSQLServer, settings.MSSQLUsername, settings.MSSQLPassword);
                lbScripts.DataSource = relativity.GetScriptList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading scripts from the Relativity database. Make sure the Relativity database settings are set correctly. The application will now close. " + ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            btView.Enabled = false;
        }

        private void btView_Click(object sender, EventArgs e)
        {
            ViewSelectedScript();
        }

        private void ViewSelectedScript()
        {
            RelativityScriptViewer.Properties.Settings settings = RelativityScriptViewer.Properties.Settings.Default;
            Relativity relativity = new Relativity(settings.MSSQLServer, settings.MSSQLUsername, settings.MSSQLPassword);
            string selectedScriptName = this.lbScripts.SelectedItem.ToString();
            string script = relativity.GetScript(selectedScriptName);
            ScriptViewerForm viewer = new ScriptViewerForm();
            viewer.ScriptText = script;
            viewer.ScriptName = selectedScriptName;
            //viewer.Text = viewer.Text + " " + selectedScriptName;
            viewer.Show();
        }

        private void lbScripts_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.lbScripts.IndexFromPoint(e.Location);

            if (index != System.Windows.Forms.ListBox.NoMatches)
            {

                btView.Enabled = true;
            }
        }
    }
}
