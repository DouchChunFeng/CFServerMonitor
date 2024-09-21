namespace cfmanager
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示隐藏项HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.暂停监视PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重启次数归零ZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.编辑服务器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增服务器NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除服务器DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.显示服务器SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏服务器HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.重启服务器RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭服务器CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选项OToolStripMenuItem,
            this.退出EToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.文件FToolStripMenuItem.Text = "设置(&S)";
            // 
            // 选项OToolStripMenuItem
            // 
            this.选项OToolStripMenuItem.Name = "选项OToolStripMenuItem";
            this.选项OToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.选项OToolStripMenuItem.Text = "选项(&O)...";
            this.选项OToolStripMenuItem.Click += new System.EventHandler(this.选项OToolStripMenuItem_Click);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.退出EToolStripMenuItem.Text = "退出(&X)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem,
            this.显示隐藏项HToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.关于AToolStripMenuItem.Text = "关于(&A)...";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // 显示隐藏项HToolStripMenuItem
            // 
            this.显示隐藏项HToolStripMenuItem.Name = "显示隐藏项HToolStripMenuItem";
            this.显示隐藏项HToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.显示隐藏项HToolStripMenuItem.Text = "显示隐藏项(&H)";
            this.显示隐藏项HToolStripMenuItem.Click += new System.EventHandler(this.显示隐藏项HToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 176);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 150);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "服务器列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(994, 144);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView1_ColumnWidthChanging);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "服务器名";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "IP 地址";
            this.columnHeader2.Width = 113;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "端口";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "可执行文件";
            this.columnHeader4.Width = 258;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "优先级";
            this.columnHeader5.Width = 59;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "进程状态";
            this.columnHeader6.Width = 93;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "网络状态";
            this.columnHeader7.Width = 93;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "地图";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "玩家";
            this.columnHeader9.Width = 67;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "重启";
            this.columnHeader10.Width = 55;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "应用程序Pid";
            this.columnHeader11.Width = 0;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "窗口句柄id";
            this.columnHeader12.Width = 0;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "控制台";
            this.columnHeader13.Width = 0;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "CPU";
            this.columnHeader14.Width = 0;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "启动项";
            this.columnHeader15.Width = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1000, 150);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "日志";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(994, 144);
            this.textBox1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.暂停监视PToolStripMenuItem,
            this.重启次数归零ZToolStripMenuItem,
            this.toolStripSeparator1,
            this.编辑服务器ToolStripMenuItem,
            this.新增服务器NToolStripMenuItem,
            this.删除服务器DToolStripMenuItem,
            this.toolStripSeparator2,
            this.显示服务器SToolStripMenuItem,
            this.隐藏服务器HToolStripMenuItem,
            this.toolStripSeparator3,
            this.重启服务器RToolStripMenuItem,
            this.关闭服务器CToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 220);
            // 
            // 暂停监视PToolStripMenuItem
            // 
            this.暂停监视PToolStripMenuItem.Name = "暂停监视PToolStripMenuItem";
            this.暂停监视PToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.暂停监视PToolStripMenuItem.Text = "暂停监视(&P)";
            this.暂停监视PToolStripMenuItem.Click += new System.EventHandler(this.暂停监视PToolStripMenuItem_Click);
            // 
            // 重启次数归零ZToolStripMenuItem
            // 
            this.重启次数归零ZToolStripMenuItem.Name = "重启次数归零ZToolStripMenuItem";
            this.重启次数归零ZToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.重启次数归零ZToolStripMenuItem.Text = "重启次数归零(&Z)";
            this.重启次数归零ZToolStripMenuItem.Click += new System.EventHandler(this.重启次数归零ZToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // 编辑服务器ToolStripMenuItem
            // 
            this.编辑服务器ToolStripMenuItem.Name = "编辑服务器ToolStripMenuItem";
            this.编辑服务器ToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.编辑服务器ToolStripMenuItem.Text = "编辑服务器(&E)";
            this.编辑服务器ToolStripMenuItem.Click += new System.EventHandler(this.编辑服务器ToolStripMenuItem_Click);
            // 
            // 新增服务器NToolStripMenuItem
            // 
            this.新增服务器NToolStripMenuItem.Name = "新增服务器NToolStripMenuItem";
            this.新增服务器NToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.新增服务器NToolStripMenuItem.Text = "新增服务器(&N)";
            this.新增服务器NToolStripMenuItem.Click += new System.EventHandler(this.新增服务器NToolStripMenuItem_Click);
            // 
            // 删除服务器DToolStripMenuItem
            // 
            this.删除服务器DToolStripMenuItem.Name = "删除服务器DToolStripMenuItem";
            this.删除服务器DToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.删除服务器DToolStripMenuItem.Text = "删除服务器(&D)";
            this.删除服务器DToolStripMenuItem.Click += new System.EventHandler(this.删除服务器DToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // 显示服务器SToolStripMenuItem
            // 
            this.显示服务器SToolStripMenuItem.Name = "显示服务器SToolStripMenuItem";
            this.显示服务器SToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.显示服务器SToolStripMenuItem.Text = "显示服务器(&S)";
            this.显示服务器SToolStripMenuItem.Click += new System.EventHandler(this.显示服务器SToolStripMenuItem_Click);
            // 
            // 隐藏服务器HToolStripMenuItem
            // 
            this.隐藏服务器HToolStripMenuItem.Name = "隐藏服务器HToolStripMenuItem";
            this.隐藏服务器HToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.隐藏服务器HToolStripMenuItem.Text = "隐藏服务器(&H)";
            this.隐藏服务器HToolStripMenuItem.Click += new System.EventHandler(this.隐藏服务器HToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
            // 
            // 重启服务器RToolStripMenuItem
            // 
            this.重启服务器RToolStripMenuItem.Name = "重启服务器RToolStripMenuItem";
            this.重启服务器RToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.重启服务器RToolStripMenuItem.Text = "重启服务器(&R)";
            this.重启服务器RToolStripMenuItem.Click += new System.EventHandler(this.重启服务器RToolStripMenuItem_Click);
            // 
            // 关闭服务器CToolStripMenuItem
            // 
            this.关闭服务器CToolStripMenuItem.Name = "关闭服务器CToolStripMenuItem";
            this.关闭服务器CToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.关闭服务器CToolStripMenuItem.Text = "关闭服务器(&C)";
            this.关闭服务器CToolStripMenuItem.Click += new System.EventHandler(this.关闭服务器CToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 4000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 201);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CF Server Monitor";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选项OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 暂停监视PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重启次数归零ZToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 编辑服务器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增服务器NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除服务器DToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 隐藏服务器HToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 重启服务器RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭服务器CToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ToolStripMenuItem 显示隐藏项HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示服务器SToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}

