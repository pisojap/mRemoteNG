using mRemoteNG.App;
using mRemoteNG.Messages;
using mRemoteNG.UI.Controls.ConnectionTree;
using mRemoteNG.UI.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI.Window
{
    public partial class GridWindow : BaseWindow
    {
        public GridWindow()
        {
            InitializeComponent();
            this.SetFormText("Grid");
            var l = Runtime.ConnectionsService.ConnectionTreeModel.GetRecursiveChildList();

            foreach (var item in l)
            {
                Runtime.MessageCollector.AddMessage(MessageClass.InformationMsg, $"-{item.Name}");
            }
        }
    }
}
