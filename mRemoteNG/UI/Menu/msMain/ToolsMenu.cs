using System;
using System.Windows.Forms;
using mRemoteNG.App;
using mRemoteNG.Credential;
using mRemoteNG.Resources.Language;

namespace mRemoteNG.UI.Menu
{
    public class ToolsMenu : ToolStripMenuItem
    {
        private ToolStripMenuItem _mMenToolsSshTransfer;
        private ToolStripMenuItem _mMenToolsExternalApps;
        private ToolStripMenuItem _mMenToolsPortScan;
        private ToolStripMenuItem _mMenToolsUvncsc;
        private ToolStripMenuItem _mMenToolsGridView;

        public Form MainForm { get; set; }
        public ICredentialRepositoryList CredentialProviderCatalog { get; set; }

        public ToolsMenu()
        {
            Initialize();
        }

        private void Initialize()
        {
            _mMenToolsSshTransfer = new ToolStripMenuItem();
            _mMenToolsUvncsc = new ToolStripMenuItem();
            _mMenToolsExternalApps = new ToolStripMenuItem();
            _mMenToolsPortScan = new ToolStripMenuItem();
            _mMenToolsGridView = new ToolStripMenuItem();
            // 
            // mMenTools
            // 
            DropDownItems.AddRange(new ToolStripItem[]
            {
                _mMenToolsSshTransfer,
                _mMenToolsUvncsc,
                _mMenToolsExternalApps,
                _mMenToolsPortScan,
                _mMenToolsGridView,
            });
            Name = "mMenTools";
            Size = new System.Drawing.Size(48, 20);
            Text = Language._Tools;
            // 
            // mMenToolsSSHTransfer
            // 
            _mMenToolsSshTransfer.Image = Properties.Resources.SyncArrow_16x;
            _mMenToolsSshTransfer.Name = "mMenToolsSSHTransfer";
            _mMenToolsSshTransfer.Size = new System.Drawing.Size(184, 22);
            _mMenToolsSshTransfer.Text = Language.SshFileTransfer;
            _mMenToolsSshTransfer.Click += mMenToolsSSHTransfer_Click;
            // 
            // mMenToolsUVNCSC
            // 
            _mMenToolsUvncsc.Name = "mMenToolsUVNCSC";
            _mMenToolsUvncsc.Size = new System.Drawing.Size(184, 22);
            _mMenToolsUvncsc.Text = Language.UltraVNCSingleClick;
            _mMenToolsUvncsc.Visible = false;
            _mMenToolsUvncsc.Click += mMenToolsUVNCSC_Click;
            // 
            // mMenToolsExternalApps
            // 
            _mMenToolsExternalApps.Image = Properties.Resources.Console_16x;
            _mMenToolsExternalApps.Name = "mMenToolsExternalApps";
            _mMenToolsExternalApps.Size = new System.Drawing.Size(184, 22);
            _mMenToolsExternalApps.Text = Language.ExternalTool;
            _mMenToolsExternalApps.Click += mMenToolsExternalApps_Click;
            // 
            // mMenToolsPortScan
            // 
            _mMenToolsPortScan.Image = Properties.Resources.SearchAndApps_16x;
            _mMenToolsPortScan.Name = "mMenToolsPortScan";
            _mMenToolsPortScan.Size = new System.Drawing.Size(184, 22);
            _mMenToolsPortScan.Text = Language.PortScan;
            _mMenToolsPortScan.Click += mMenToolsPortScan_Click;
            // 
            // mMenToolsGrid
            // 
            _mMenToolsGridView.Image = Properties.Resources.Panel_16x;
            _mMenToolsGridView.Name = "mMenToolsGrid";
            _mMenToolsGridView.Size = new System.Drawing.Size(184, 22);
            _mMenToolsGridView.Text = Language.GridView;
            _mMenToolsGridView.Click += mMenToolsGridView_Click;
        }

        public void ApplyLanguage()
        {
            Text = Language._Tools;
            _mMenToolsSshTransfer.Text = Language.SshFileTransfer;
            _mMenToolsExternalApps.Text = Language.ExternalTool;
            _mMenToolsPortScan.Text = Language.PortScan;
            _mMenToolsGridView.Text = Language.GridView;
        }

        #region Tools

        private void mMenToolsSSHTransfer_Click(object sender, EventArgs e)
        {
            Windows.Show(WindowType.SSHTransfer);
        }

        private void mMenToolsUVNCSC_Click(object sender, EventArgs e)
        {
            Windows.Show(WindowType.UltraVNCSC);
        }

        private void mMenToolsExternalApps_Click(object sender, EventArgs e)
        {
            Windows.Show(WindowType.ExternalApps);
        }

        private void mMenToolsPortScan_Click(object sender, EventArgs e)
        {
            Windows.Show(WindowType.PortScan);
        }

        private void mMenToolsOptions_Click(object sender, EventArgs e)
        {
            Windows.Show(WindowType.Options);
        }

        private void mMenToolsGridView_Click(object sender, EventArgs e)
        {
            Windows.Show(WindowType.GridWindow);
        }

        #endregion
    }
}