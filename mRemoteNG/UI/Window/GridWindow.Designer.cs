using mRemoteNG.Properties;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridWindow));
            this.labelWindowName = new System.Windows.Forms.Label();
            this.comboBoxGridSelection = new System.Windows.Forms.ComboBox();
            this.labelSelectGrid = new System.Windows.Forms.Label();
            this.panelConnections = new System.Windows.Forms.Panel();
            this.buttonRefreshGrid = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWindowName
            // 
            this.labelWindowName.AutoSize = true;
            this.labelWindowName.Font = new System.Drawing.Font("Segoe UI", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.labelWindowName.Location = new System.Drawing.Point(230, 2);
            this.labelWindowName.Name = "labelWindowName";
            this.labelWindowName.Size = new System.Drawing.Size(51, 25);
            this.labelWindowName.TabIndex = 0;
            this.labelWindowName.Text = "Grid";
            // 
            // comboBoxGridSelection
            // 
            this.comboBoxGridSelection.FormattingEnabled = true;
            this.comboBoxGridSelection.ItemHeight = 15;
            this.comboBoxGridSelection.Location = new System.Drawing.Point(87, 4);
            this.comboBoxGridSelection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxGridSelection.Name = "comboBoxGridSelection";
            this.comboBoxGridSelection.Size = new System.Drawing.Size(110, 23);
            this.comboBoxGridSelection.TabIndex = 2;
            this.comboBoxGridSelection.SelectedValueChanged += new System.EventHandler(this.comboBoxGridSelection_SelectedValueChanged);
            // 
            // labelSelectGrid
            // 
            this.labelSelectGrid.AutoSize = true;
            this.labelSelectGrid.Location = new System.Drawing.Point(10, 7);
            this.labelSelectGrid.Name = "labelSelectGrid";
            this.labelSelectGrid.Size = new System.Drawing.Size(63, 15);
            this.labelSelectGrid.TabIndex = 3;
            this.labelSelectGrid.Text = "Select Grid";
            // 
            // panelConnections
            // 
            this.panelConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelConnections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelConnections.Location = new System.Drawing.Point(10, 33);
            this.panelConnections.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelConnections.Name = "panelConnections";
            this.panelConnections.Size = new System.Drawing.Size(664, 373);
            this.panelConnections.TabIndex = 4;
            // 
            // buttonRefreshGrid
            // 
            this.buttonRefreshGrid.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefreshGrid.Image")));
            this.buttonRefreshGrid.Location = new System.Drawing.Point(201, 4);
            this.buttonRefreshGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRefreshGrid.Name = "buttonRefreshGrid";
            this.buttonRefreshGrid.Size = new System.Drawing.Size(26, 25);
            this.buttonRefreshGrid.TabIndex = 5;
            this.buttonRefreshGrid.UseVisualStyleBackColor = true;
            this.buttonRefreshGrid.Click += new System.EventHandler(this.buttonRefreshGrid_click);
            // 
            // GridWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 415);
            this.Controls.Add(this.buttonRefreshGrid);
            this.Controls.Add(this.panelConnections);
            this.Controls.Add(this.labelSelectGrid);
            this.Controls.Add(this.comboBoxGridSelection);
            this.Controls.Add(this.labelWindowName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GridWindow";
            this.Load += new System.EventHandler(this.GridWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWindowName;
        private System.Windows.Forms.ComboBox comboBoxGridSelection;
        private System.Windows.Forms.Label labelSelectGrid;
        private System.Windows.Forms.Panel panelConnections;
        private System.Windows.Forms.Button buttonRefreshGrid;
    }
}
