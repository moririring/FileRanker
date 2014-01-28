using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
//using IWshRuntimeLibrary;

namespace FileRanker
{
    public enum ListViewType
    {
        Folder,
        File,
    }
    public partial class UserControl1 : UserControl
    {
        private ListViewType Type;
        public void SetType(ListViewType i, string path)
        {
            Type = i;
            if (Type == ListViewType.Folder)
            {
                contextMenuStrip1.Items[1].Visible = false;
            }
            fileSystemWatcher1.Path = path;
        }
        // SHGetFileInfo関数
        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
        private const uint SHGFI_ICON = 0x100; // アイコン・リソースの取得
        private const uint SHGFI_LARGEICON = 0x0; // 大きいアイコン
        private const uint SHGFI_SMALLICON = 0x1; // 小さいアイコン
        // SHGetFileInfo関数で使用する構造体
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        public void ListViewAddFile(string linkName)
        {
            if (Path.GetExtension(linkName) != ".lnk") return;
            if (!File.Exists(linkName)) return;

            var TheShell = new IWshRuntimeLibrary.IWshShell_Class();
            var shortcut = TheShell.CreateShortcut(linkName) as IWshRuntimeLibrary.IWshShortcut_Class;

            if (Type == ListViewType.Folder && !Directory.Exists(shortcut.TargetPath)) return;
            else if (Type == ListViewType.File && !File.Exists(shortcut.TargetPath)) return;

            var item = listView1.Items.Add(Path.GetFileName(shortcut.TargetPath));
            item.SubItems.Add(shortcut.TargetPath);
            item.Tag = linkName;
            item.ImageIndex = listView1.Items.Count - 1;
            //アイコン
            var shinfo = new SHFILEINFO();
            var hSuccess = SHGetFileInfo(shortcut.TargetPath, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
            if (hSuccess == IntPtr.Zero) return;
            imageList1.Images.Add(linkName, Icon.FromHandle(shinfo.hIcon));

            Marshal.ReleaseComObject(shortcut);
            Marshal.ReleaseComObject(TheShell);
        }
        private string ListViewSelectName()
        {
            return (listView1.SelectedItems.Count > 0) ? listView1.SelectedItems[0].SubItems[1].Text : "";
        }
        private void CopyListViewName()
        {
            var name = ListViewSelectName();
            if (name != "")
            {
                Clipboard.SetText(name);
            }
        }
        private void DeleteListViewName()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var name = listView1.SelectedItems[0].Tag.ToString();
                if (File.Exists(name))
                {
                    File.Delete(name);
                }
            }
        }
        private void DeleteListViewName(string name)
        {
            var hit = listView1.Items.Cast<ListViewItem>().FirstOrDefault(i => i.Tag.ToString() == name);
            if (hit != null)
            {
                //ただ削除するとImageIndexがずれる？全部作り直しかな？
                //imageList1.Images.RemoveByKey(hit.Tag.ToString());
                hit.Remove();
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }



        public UserControl1()
        {
            InitializeComponent();
            PropertyInfo prop = listView1.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            prop.SetValue(listView1, true, null);
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = ListViewSelectName();
            textBox1.Text = name;
            if (name != "")
            {
                listView1.SelectedItems[0].ForeColor = (!File.Exists(name) && !Directory.Exists(name)) ? Color.Gray : Color.Black;
                contextMenuStrip1.Items[0].Image = imageList1.Images[listView1.SelectedItems[0].ImageIndex];
            }
        }
/*        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Control)
            {
                CopyListViewName();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteListViewName();
            }
        }*/
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyListViewName();
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var name = ListViewSelectName();
            if (File.Exists(name) || Directory.Exists(name))
            {
                Process.Start(name);
            }
        }
        private void FolderOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var name = Path.GetDirectoryName(ListViewSelectName());
            if (Directory.Exists(name))
            {
                Process.Start(name);
            }
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteListViewName();
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                    ListViewAddFile(e.FullPath);
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    break;

                case WatcherChangeTypes.Deleted:
                    DeleteListViewName(e.FullPath);
                    break;
            }
        }
    }
}
