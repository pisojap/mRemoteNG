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
        private ToolStripMenuItem _cMenTreeConnectWithOptions;
        private ToolStripMenuItem _cMenTreeConnectWithOptionsConnectToConsoleSession;
        private ToolStripMenuItem _cMenTreeConnectWithOptionsNoCredentials;
        private ToolStripMenuItem _cMenTreeConnectWithOptionsConnectInFullscreen;
        private ToolStripMenuItem _cMenTreeConnectWithOptionsViewOnly;
        private ToolStripMenuItem _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting;
        private ToolStripMenuItem _cMenTreeConnectWithOptionsDontConnectToConsoleSession;
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
            _cMenTreeConnectWithOptions = new ToolStripMenuItem();
            _cMenTreeConnectWithOptionsConnectToConsoleSession = new ToolStripMenuItem();
            _cMenTreeConnectWithOptionsDontConnectToConsoleSession = new ToolStripMenuItem();
            _cMenTreeConnectWithOptionsConnectInFullscreen = new ToolStripMenuItem();
            _cMenTreeConnectWithOptionsNoCredentials = new ToolStripMenuItem();
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting = new ToolStripMenuItem();
            _cMenTreeConnectWithOptionsViewOnly = new ToolStripMenuItem();
            _cMenTreeToolsExternalApps = new ToolStripMenuItem();

            Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular,
                                           System.Drawing.GraphicsUnit.Point, 0);
            Items.AddRange(new ToolStripItem[]
           {
                _cMenTreeConnect,
                _cMenTreeConnectWithOptions,
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

            //_cMenConnectWithOptions
            _cMenTreeConnectWithOptions.DropDownItems.AddRange(new ToolStripItem[]
            {
                _cMenTreeConnectWithOptionsConnectToConsoleSession,
                _cMenTreeConnectWithOptionsDontConnectToConsoleSession,
                _cMenTreeConnectWithOptionsConnectInFullscreen,
                _cMenTreeConnectWithOptionsNoCredentials,
                _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting,
                _cMenTreeConnectWithOptionsViewOnly
            });
            _cMenTreeConnectWithOptions.Name = "_cMenTreeConnectWithOptions";
            _cMenTreeConnectWithOptions.Size = new System.Drawing.Size(199, 22);
            _cMenTreeConnectWithOptions.Text = "Connect (with options)";

            //
            // cMenTreeConnectWithOptionsConnectToConsoleSession
            //
            _cMenTreeConnectWithOptionsConnectToConsoleSession.Name =
                "_cMenTreeConnectWithOptionsConnectToConsoleSession";
            _cMenTreeConnectWithOptionsConnectToConsoleSession.Size = new System.Drawing.Size(245, 22);
            _cMenTreeConnectWithOptionsConnectToConsoleSession.Text = "Connect to console session";
            _cMenTreeConnectWithOptionsConnectToConsoleSession.Click += OnConnectToConsoleSessionClicked;
            //
            // cMenTreeConnectWithOptionsDontConnectToConsoleSession
            //
            _cMenTreeConnectWithOptionsDontConnectToConsoleSession.Name =
                "_cMenTreeConnectWithOptionsDontConnectToConsoleSession";
            _cMenTreeConnectWithOptionsDontConnectToConsoleSession.Size = new System.Drawing.Size(245, 22);
            _cMenTreeConnectWithOptionsDontConnectToConsoleSession.Text = "Don\'t connect to console session";
            _cMenTreeConnectWithOptionsDontConnectToConsoleSession.Visible = false;
            _cMenTreeConnectWithOptionsDontConnectToConsoleSession.Click += OnDontConnectToConsoleSessionClicked;
            //
            // cMenTreeConnectWithOptionsConnectInFullscreen
            //
            _cMenTreeConnectWithOptionsConnectInFullscreen.Image = Properties.Resources.FullScreen_16x;
            _cMenTreeConnectWithOptionsConnectInFullscreen.Name = "_cMenTreeConnectWithOptionsConnectInFullscreen";
            _cMenTreeConnectWithOptionsConnectInFullscreen.Size = new System.Drawing.Size(245, 22);
            _cMenTreeConnectWithOptionsConnectInFullscreen.Text = "Connect in fullscreen";
            _cMenTreeConnectWithOptionsConnectInFullscreen.Click += OnConnectInFullscreenClicked;
            //
            // cMenTreeConnectWithOptionsNoCredentials
            //
            _cMenTreeConnectWithOptionsNoCredentials.Image = Properties.Resources.UniqueKeyError_16x;
            _cMenTreeConnectWithOptionsNoCredentials.Name = "_cMenTreeConnectWithOptionsNoCredentials";
            _cMenTreeConnectWithOptionsNoCredentials.Size = new System.Drawing.Size(245, 22);
            _cMenTreeConnectWithOptionsNoCredentials.Text = "Connect without credentials";
            _cMenTreeConnectWithOptionsNoCredentials.Click += OnConnectWithNoCredentialsClick;
            //
            // cMenTreeConnectWithOptionsChoosePanelBeforeConnecting
            //
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Image = Properties.Resources.Panel_16x;
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Name =
                "_cMenTreeConnectWithOptionsChoosePanelBeforeConnecting";
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Size = new System.Drawing.Size(245, 22);
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Text = "Choose panel before connecting";
            _cMenTreeConnectWithOptionsChoosePanelBeforeConnecting.Click += OnChoosePanelBeforeConnectingClicked;
            //
            // cMenTreeConnectWithOptionsViewOnly
            //
            _cMenTreeConnectWithOptionsViewOnly.Image = Properties.Resources.Monitor_16x;
            _cMenTreeConnectWithOptionsViewOnly.Name =
                "_cMenTreeConnectWithOptionsViewOnly";
            _cMenTreeConnectWithOptionsViewOnly.Size = new System.Drawing.Size(245, 22);
            _cMenTreeConnectWithOptionsViewOnly.Text = Language.ConnectInViewOnlyMode;
            _cMenTreeConnectWithOptionsViewOnly.Click += ConnectWithOptionsViewOnlyOnClick;

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
            MessageBox.Show("Connect clicked.");
        }

        private void ConnectWithOptionsViewOnlyOnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnChoosePanelBeforeConnectingClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnConnectWithNoCredentialsClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnConnectInFullscreenClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnDontConnectToConsoleSessionClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnConnectToConsoleSessionClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}
