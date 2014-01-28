namespace FileRanker
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.StartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskTrayVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskTrayMinimumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskTrayCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userControl11 = new FileRanker.UserControl1();
            this.userControl12 = new FileRanker.UserControl1();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(678, 444);
            this.panel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(678, 444);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.userControl11);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(670, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "フォルダ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.userControl12);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(670, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ファイル";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(678, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartupToolStripMenuItem,
            this.TaskTrayToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // StartupToolStripMenuItem
            // 
            this.StartupToolStripMenuItem.Name = "StartupToolStripMenuItem";
            this.StartupToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.StartupToolStripMenuItem.Text = "スタートアップに登録";
            this.StartupToolStripMenuItem.Click += new System.EventHandler(this.StartupToolStripMenuItem_Click);
            // 
            // TaskTrayToolStripMenuItem
            // 
            this.TaskTrayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TaskTrayVisibleToolStripMenuItem,
            this.TaskTrayMinimumToolStripMenuItem,
            this.TaskTrayCloseToolStripMenuItem});
            this.TaskTrayToolStripMenuItem.Name = "TaskTrayToolStripMenuItem";
            this.TaskTrayToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.TaskTrayToolStripMenuItem.Text = "タスクトレイ";
            this.TaskTrayToolStripMenuItem.Click += new System.EventHandler(this.TaskTrayToolStripMenuItem_Click);
            // 
            // TaskTrayVisibleToolStripMenuItem
            // 
            this.TaskTrayVisibleToolStripMenuItem.Checked = true;
            this.TaskTrayVisibleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TaskTrayVisibleToolStripMenuItem.Name = "TaskTrayVisibleToolStripMenuItem";
            this.TaskTrayVisibleToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.TaskTrayVisibleToolStripMenuItem.Text = "タスクトレイに表示";
            this.TaskTrayVisibleToolStripMenuItem.CheckedChanged += new System.EventHandler(this.TaskTrayVisibleToolStripMenuItem_CheckedChanged);
            this.TaskTrayVisibleToolStripMenuItem.Click += new System.EventHandler(this.TaskTrayVisibleToolStripMenuItem_Click);
            // 
            // TaskTrayMinimumToolStripMenuItem
            // 
            this.TaskTrayMinimumToolStripMenuItem.Name = "TaskTrayMinimumToolStripMenuItem";
            this.TaskTrayMinimumToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.TaskTrayMinimumToolStripMenuItem.Text = "最小化でタスクバーから消す";
            this.TaskTrayMinimumToolStripMenuItem.Click += new System.EventHandler(this.TaskTrayMinimumToolStripMenuItem_Click);
            // 
            // TaskTrayCloseToolStripMenuItem
            // 
            this.TaskTrayCloseToolStripMenuItem.Name = "TaskTrayCloseToolStripMenuItem";
            this.TaskTrayCloseToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.TaskTrayCloseToolStripMenuItem.Text = "終了してもタスクトレイに常駐";
            this.TaskTrayCloseToolStripMenuItem.Click += new System.EventHandler(this.TaskTrayCloseToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 48);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.OpenToolStripMenuItem.Text = "開く(&O)";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.ExitToolStripMenuItem.Text = "終了(&X)";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // userControl11
            // 
            this.userControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl11.Location = new System.Drawing.Point(3, 3);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(664, 412);
            this.userControl11.TabIndex = 0;
            // 
            // userControl12
            // 
            this.userControl12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl12.Location = new System.Drawing.Point(3, 3);
            this.userControl12.Name = "userControl12";
            this.userControl12.Size = new System.Drawing.Size(664, 412);
            this.userControl12.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 469);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "最近ミタゾゥ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imageList1;
        private UserControl1 userControl11;
        private UserControl1 userControl12;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem StartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TaskTrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TaskTrayMinimumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TaskTrayCloseToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem TaskTrayVisibleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
    }
}

