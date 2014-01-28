using IWshRuntimeLibrary;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FileRanker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
            userControl11.SetType(ListViewType.Folder, path);
            userControl12.SetType(ListViewType.File, path);
            userControl11.listView1.BeginUpdate();
            userControl12.listView1.BeginUpdate();
            foreach (var linkName in Directory.EnumerateFiles(path))
            {
                userControl11.ListViewAddFile(linkName);
                userControl12.ListViewAddFile(linkName);
            }
            userControl11.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            userControl12.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            userControl11.listView1.EndUpdate();
            userControl12.listView1.EndUpdate();

            //スタートアップ
            var startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            startupPath = Path.Combine(startupPath, this.Text + ".lnk");
            StartupToolStripMenuItem.Checked = System.IO.File.Exists(startupPath);
        }

        private void StartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartupToolStripMenuItem.Checked = !StartupToolStripMenuItem.Checked;
            var startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            startupPath = Path.Combine(startupPath, this.Text + ".lnk");
            if (StartupToolStripMenuItem.Checked)
            {
                //ショートカットのリンク先
                var TheShell = new IWshShell_Class();
                var shortcut = TheShell.CreateShortcut(startupPath) as IWshShortcut_Class;
                shortcut.TargetPath = Application.ExecutablePath;
                shortcut.WorkingDirectory = Application.StartupPath;
                shortcut.IconLocation = Application.ExecutablePath + ",0";
                shortcut.Save();    
                //後始末
                Marshal.ReleaseComObject(shortcut);
                Marshal.ReleaseComObject(TheShell);
            }
            else
            {
                System.IO.File.Delete(startupPath);
            }
        }

        private void TaskTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void TaskTrayVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskTrayVisibleToolStripMenuItem.Checked = !TaskTrayVisibleToolStripMenuItem.Checked;
        }
        private void TaskTrayVisibleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            notifyIcon1.Visible = TaskTrayVisibleToolStripMenuItem.Checked;
            TaskTrayMinimumToolStripMenuItem.Enabled = TaskTrayVisibleToolStripMenuItem.Checked;
            TaskTrayCloseToolStripMenuItem.Enabled = TaskTrayVisibleToolStripMenuItem.Checked;
        }
        private void TaskTrayMinimumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskTrayMinimumToolStripMenuItem.Checked = !TaskTrayMinimumToolStripMenuItem.Checked;
        }

        private void TaskTrayCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskTrayCloseToolStripMenuItem.Checked = !TaskTrayCloseToolStripMenuItem.Checked;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (TaskTrayMinimumToolStripMenuItem.Enabled && TaskTrayMinimumToolStripMenuItem.Checked && WindowState == FormWindowState.Minimized)
            {
                Visible = false;
                notifyIcon1.Visible = true;
            }
            else
            {
                Visible = true;
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(TaskTrayCloseToolStripMenuItem.Enabled && TaskTrayCloseToolStripMenuItem.Checked && e.CloseReason != CloseReason.ApplicationExitCall)
            {
                WindowState = FormWindowState.Minimized;
                e.Cancel = true;
            }
            Properties.Settings.Default.TaskTrayVisible = TaskTrayVisibleToolStripMenuItem.Checked;
            Properties.Settings.Default.TaskTrayMinimum = TaskTrayMinimumToolStripMenuItem.Checked;
            Properties.Settings.Default.TaskTrayClose = TaskTrayCloseToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // 前バージョンからのUpgradeを実行していないときは、Upgradeを実施する
            if (Properties.Settings.Default.IsUpgrade == false)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.IsUpgrade = true;
                Properties.Settings.Default.Save();
            }
            TaskTrayVisibleToolStripMenuItem.Checked = Properties.Settings.Default.TaskTrayVisible;
            TaskTrayMinimumToolStripMenuItem.Checked = Properties.Settings.Default.TaskTrayMinimum;
            TaskTrayCloseToolStripMenuItem.Checked = Properties.Settings.Default.TaskTrayClose;
        }

    }
}
