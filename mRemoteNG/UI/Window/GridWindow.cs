using mRemoteNG.App;
using mRemoteNG.Connection;
using mRemoteNG.Connection.Protocol;
using mRemoteNG.Messages;
using mRemoteNG.Messages.MessageWriters;
using mRemoteNG.Messages.WriterDecorators;
using mRemoteNG.Resources.Language;
using mRemoteNG.Tools;
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
        private IReadOnlyList<ConnectionInfo> _mConnectionInfoList;
        private IEnumerable<ConnectionInfo> _selectedGridConnectionInfo;
        private List<string> _gridList;
        private IEnumerable<ConnectionInfo> _groupListForSelectedGrid;

        private ToolTip toolTip = new ToolTip();

        public GridWindow()
        {
            InitializeComponent();
            this.SetFormText($"Grid window");

            var childList = Runtime.ConnectionsService.ConnectionTreeModel.GetRecursiveChildList();

            //get list of grids and populate combobox
            var c = from child in childList
                    where child.GridName != String.Empty
                    orderby child.GridName
                    group child by child.GridName
                    into newGroup
                    select newGroup;
            
            _gridList = new List<string>();

            foreach (var item in c)
            {
                comboBoxGridSelection.Items.Add(item.Key);
                _gridList.Add(item.Key);
                Runtime.MessageCollector.AddMessage(MessageClass.DebugMsg, $"Existing Groups - {item.Key}");
            }
            comboBoxGridSelection.SelectedIndex = 0;
        }

        private void GridWindow_Load(object sender, EventArgs e)
        {
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
        }

        private void comboBoxGridSelection_SelectedValueChanged(object sender, EventArgs e)
        {
            ChangeGrid();
        }

        private void ChangeGrid()
        {
            labelWindowName.Text = $"{comboBoxGridSelection.Text}";

            _mConnectionInfoList = Runtime.ConnectionsService.ConnectionTreeModel.GetRecursiveChildList();

            _selectedGridConnectionInfo = from child in _mConnectionInfoList
                                          where child.GridName == comboBoxGridSelection.Text
                                          select child;
            Runtime.MessageCollector.AddMessage(MessageClass.DebugMsg, $"Selected Grid-{_selectedGridConnectionInfo.First().GridName} connections-{_selectedGridConnectionInfo.Count()}");


            panelConnections.Controls.Clear();

            var g = (from c in _selectedGridConnectionInfo
                     where c.GridGroupName != string.Empty
                     group c by c.GridGroupName
                         into newGroup
                     select newGroup);
            _groupListForSelectedGrid = g.SelectMany(group => group);

            foreach (var group in _groupListForSelectedGrid)
            {
                // 
                // buttons for group Names
                //
                Button button = new Button();
                button.Name = $"button{group.Name}";
                button.Text = group.GridGroupName;
                button.Font = new Font("Arial", 8, FontStyle.Bold);
                button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                button.BackColor = System.Drawing.SystemColors.ActiveCaption;
                button.Location = new System.Drawing.Point(group.GridGroupX, group.GridGroupY);
                button.BackColor = Color.Gold;
                button.AutoSize = true;
                button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                button.UseVisualStyleBackColor = false;
                panelConnections.Controls.Add(button);
                button.BringToFront();
            }

            foreach (var child in _selectedGridConnectionInfo)
            {
                // 
                // buttons for Connections
                //
                Button button = new Button();
                button.Name = $"button{child.Name}";
                button.Text = child.Name;
                button.Font = new Font("Arial", 8);
                button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                button.BackColor = System.Drawing.SystemColors.ActiveCaption;
                button.Location = new System.Drawing.Point(child.GridX, child.GridY);
                button.Size = new System.Drawing.Size(child.GridW, child.GridH);
                button.UseVisualStyleBackColor = false;
                var cms = new GridContextMenu(child);
                button.ContextMenuStrip = cms;
                panelConnections.Controls.Add(button);

                if (child.GridZ == 0)
                {
                    button.BringToFront();
                    button.BackColor = Color.Azure;
                }

                toolTip.SetToolTip(button, $"{child.GridDescription}{Environment.NewLine}" +
                    $"{child.Hostname}{Environment.NewLine}" +
                    $"{child.Protocol}{Environment.NewLine}" +
                    $"{((child.Protocol == ProtocolType.IntApp) ? child.ExtApp + Environment.NewLine : "")}" +
                    $"{child.Username}");

            }
        }


        private void buttonRefreshGrid_click(object sender, EventArgs e)
        {
            ChangeGrid();
        }
    }
}
