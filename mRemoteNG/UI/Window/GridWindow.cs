using mRemoteNG.App;
using mRemoteNG.Connection;
using mRemoteNG.Messages;
using mRemoteNG.Messages.MessageWriters;
using mRemoteNG.Messages.WriterDecorators;
using mRemoteNG.Resources.Language;
using mRemoteNG.UI.Controls;
using mRemoteNG.UI.Controls.ConnectionTree;
using mRemoteNG.UI.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI.Window
{
    public partial class GridWindow : BaseWindow
    {
        public GridWindow()
        {
            InitializeComponent();
            this.SetFormText($"Grid window");
            var childList = Runtime.ConnectionsService.ConnectionTreeModel.GetRecursiveChildList();

            var c = from child in childList
                    where child.GridName != String.Empty
                    orderby child.GridName
                    group child by child.GridName
                    into newGroup
                    select newGroup;
            
            foreach (var item in c)
            {
                comboBoxGridSelection.Items.Add(item.Key);
                comboBoxGridSelection.SelectedIndex = 0;    
                Runtime.MessageCollector.AddMessage(MessageClass.DebugMsg, $"Existing Groups - {item.Key}");
            }
        }

        private void comboBoxGridSelection_SelectedValueChanged(object sender, EventArgs e)
        {
            labelWindowName.Text = $"{comboBoxGridSelection.Text}";

            var childList = Runtime.ConnectionsService.ConnectionTreeModel.GetRecursiveChildList();

            var childs = from child in childList
                         where child.GridName == comboBoxGridSelection.Text
                         select child;
                Runtime.MessageCollector.AddMessage(MessageClass.DebugMsg, $"Selected Grid-{childs.First().GridName} connections-{childs.Count()}");


            panelConnections.Controls.Clear();

            foreach (var child in childs)
            {
                

                // 
                // buttons
                //
                Button button = new Button();
                button.Name = $"button{ child.Name}";
                button.Text = child.Name;
                button.Font = new Font("Arial", 6);
                button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                button.BackColor = System.Drawing.SystemColors.ActiveCaption;
                button.Location = new System.Drawing.Point(child.GridX, child.GridY);
                button.Size = new System.Drawing.Size(child.GridW, child.GridH);
                button.UseVisualStyleBackColor = false;
                var cms = new ContextMenuStrip();
                cms.Items.Add("1");
                cms.Items.Add("2");
                cms.Click += GridWindow_Click;
                button.ContextMenuStrip = cms;
                panelConnections.Controls.Add(button);
            }
        }

        private void GridWindow_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola hej");
        }
    }
}
