namespace RelativityScriptViewer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btCancel = new System.Windows.Forms.Button();
            this.lbScripts = new System.Windows.Forms.ListBox();
            this.btView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(166, 281);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // lbScripts
            // 
            this.lbScripts.FormattingEnabled = true;
            this.lbScripts.Location = new System.Drawing.Point(22, 12);
            this.lbScripts.Name = "lbScripts";
            this.lbScripts.Size = new System.Drawing.Size(263, 251);
            this.lbScripts.TabIndex = 2;
            this.lbScripts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbScripts_MouseClick);
            this.lbScripts.SelectedIndexChanged += new System.EventHandler(this.lbScripts_SelectedIndexChanged);
            this.lbScripts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbScripts_MouseDoubleClick);
            // 
            // btView
            // 
            this.btView.Location = new System.Drawing.Point(51, 281);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(75, 23);
            this.btView.TabIndex = 3;
            this.btView.Text = "View";
            this.btView.UseVisualStyleBackColor = true;
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(305, 322);
            this.Controls.Add(this.btView);
            this.Controls.Add(this.lbScripts);
            this.Controls.Add(this.btCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Relativity Script Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ListBox lbScripts;
        private System.Windows.Forms.Button btView;
    }
}

