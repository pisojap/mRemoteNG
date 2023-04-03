namespace UI.Window
{
    partial class GridWindow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelWindowName = new System.Windows.Forms.Label();
            this.comboBoxGridSelection = new System.Windows.Forms.ComboBox();
            this.labelSelectGrid = new System.Windows.Forms.Label();
            this.panelConnections = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelWindowName
            // 
            this.labelWindowName.AutoSize = true;
            this.labelWindowName.Font = new System.Drawing.Font("Segoe UI", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.labelWindowName.Location = new System.Drawing.Point(205, 3);
            this.labelWindowName.Name = "labelWindowName";
            this.labelWindowName.Size = new System.Drawing.Size(60, 31);
            this.labelWindowName.TabIndex = 0;
            this.labelWindowName.Text = "Grid";
            // 
            // comboBoxGridSelection
            // 
            this.comboBoxGridSelection.FormattingEnabled = true;
            this.comboBoxGridSelection.Location = new System.Drawing.Point(99, 6);
            this.comboBoxGridSelection.Name = "comboBoxGridSelection";
            this.comboBoxGridSelection.Size = new System.Drawing.Size(100, 28);
            this.comboBoxGridSelection.TabIndex = 2;
            this.comboBoxGridSelection.SelectedValueChanged += new System.EventHandler(this.comboBoxGridSelection_SelectedValueChanged);
            // 
            // labelSelectGrid
            // 
            this.labelSelectGrid.AutoSize = true;
            this.labelSelectGrid.Location = new System.Drawing.Point(12, 9);
            this.labelSelectGrid.Name = "labelSelectGrid";
            this.labelSelectGrid.Size = new System.Drawing.Size(81, 20);
            this.labelSelectGrid.TabIndex = 3;
            this.labelSelectGrid.Text = "Select Grid";
            // 
            // panelConnections
            // 
            this.panelConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelConnections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelConnections.Location = new System.Drawing.Point(12, 40);
            this.panelConnections.Name = "panelConnections";
            this.panelConnections.Size = new System.Drawing.Size(758, 501);
            this.panelConnections.TabIndex = 4;
            // 
            // GridWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.panelConnections);
            this.Controls.Add(this.labelSelectGrid);
            this.Controls.Add(this.comboBoxGridSelection);
            this.Controls.Add(this.labelWindowName);
            this.Name = "GridWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWindowName;
        private System.Windows.Forms.ComboBox comboBoxGridSelection;
        private System.Windows.Forms.Label labelSelectGrid;
        private System.Windows.Forms.Panel panelConnections;
    }
}
