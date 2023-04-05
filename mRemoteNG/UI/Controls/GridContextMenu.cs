using mRemoteNG.App;
using mRemoteNG.Connection;
using mRemoteNG.Resources.Language;
using mRemoteNG.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace mRemoteNG.UI.Controls
{
    public class GridContextMenu : ContextMenuStrip
    {
        private ToolStripMenuItem _cMenTreeConnect;
        private ToolStripMenuItem _cMenTreeToolsExternalApps;
        private readonly ConnectionInfo _connection;

        public GridContextMenu(Connection.ConnectionInfo connection)
        {
            this._connection = connection;
            InitializeComponent();
            ApplyLanguage();
            Opening += (sender, args) =>
            {
                AddExternalApps();
            };
        }

        private void InitializeComponent()
        {
            _cMenTreeConnect = new ToolStripMenuItem();
            _cMenTreeToolsExternalApps = new ToolStripMenuItem();

            Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular,
                                           System.Drawing.GraphicsUnit.Point, 0);
            Items.AddRange(new ToolStripItem[]
           {
                _cMenTreeConnect,
                _cMenTreeToolsExternalApps,
           });
            Name = "cMenTreeGrid";
            RenderMode = ToolStripRenderMode.Professional;
            Size = new System.Drawing.Size(200, 364);

            //_cMenConnect
            _cMenTreeConnect.Image = Properties.Resources.Run_16x;
            _cMenTreeConnect.Name = "_cMenTreeGridConnect";
            _cMenTreeConnect.Size = new System.Drawing.Size(199, 22);
            _cMenTreeConnect.Text = "Connect";
            _cMenTreeConnect.Click += OnConnectClicked;

            //_cMenTreeToolsExternalApps
            _cMenTreeToolsExternalApps.Image = Properties.Resources.Console_16x;
            _cMenTreeToolsExternalApps.Name = "_cMenTreeToolsExternalApps";
            _cMenTreeToolsExternalApps.Size = new System.Drawing.Size(199, 22);
            _cMenTreeToolsExternalApps.Text = "External Applications";
        }


        private void ApplyLanguage()
        {
            //throw new NotImplementedException();
        }

        private void AddExternalApps()
        {
            try
            {
                ResetExternalAppMenu();

                foreach (ExternalTool extA in Runtime.ExternalToolsService.ExternalTools)
                {
                    var menuItem = new ToolStripMenuItem
                    {
                        Text = extA.DisplayName,
                        Tag = extA,
                        Image = extA.Image
                    };

                    menuItem.Click += OnExternalToolClicked;
                    _cMenTreeToolsExternalApps.DropDownItems.Add(menuItem);
                }
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace(
                                                                "cMenTreeTools_DropDownOpening failed (UI.Window.ConnectionTreeWindow)",
                                                                ex);
            }
        }

        private void StartExternalApp(ExternalTool externalTool)
        {
            try
            {
                    externalTool.Start(_connection);
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace(
                                                                "cMenTreeToolsExternalAppsEntry_Click failed (UI.Window.ConnectionTreeWindow)",
                                                                ex);
            }
        }

        private void ResetExternalAppMenu()
        {
            if (_cMenTreeToolsExternalApps.DropDownItems.Count <= 0) return;
            for (var i = _cMenTreeToolsExternalApps.DropDownItems.Count - 1; i >= 0; i--)
                _cMenTreeToolsExternalApps.DropDownItems[i].Dispose();

            _cMenTreeToolsExternalApps.DropDownItems.Clear();
        }


        #region Click handlers

        private void OnExternalToolClicked(object sender, EventArgs e)
        {
            StartExternalApp((ExternalTool)((ToolStripMenuItem)sender).Tag);
        }

        private void OnConnectClicked(object sender, EventArgs e)
        {
            Runtime.ConnectionInitiator.OpenConnection(_connection, ConnectionInfo.Force.None);
        }

        #endregion

    }
}
