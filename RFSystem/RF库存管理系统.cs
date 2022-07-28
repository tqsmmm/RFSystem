using System;
using System.Collections;
using System.Windows.Forms;
using RFSystem.ArriveStore;

namespace RFSystem
{
    public class RF库存管理系统 : Form
    {
        private MenuStrip menuStripMainForm;
        private ToolStripMenuItem 打印机管理ToolStripMenuItem;
        private ToolStripMenuItem 到库通知ToolStripMenuItem;
        private ToolStripMenuItem 到库通知单列表ToolStripMenuItem;
        private ToolStripMenuItem 库存账套管理ToolStripMenuItem;
        private ToolStripMenuItem 库存保养ToolStripMenuItem;
        private ToolStripMenuItem 库存盘点ToolStripMenuItem;
        private ToolStripMenuItem 权限管理ToolStripMenuItem;
        private ToolStripMenuItem 日志管理ToolStripMenuItem;
        private ToolStripMenuItem 退出系统ToolStripMenuItem;
        private ToolStripMenuItem 系统管理ToolStripMenuItem;
        private ToolStripMenuItem 新建到库通知单ToolStripMenuItem;
        private ToolStripMenuItem 异议入库ToolStripMenuItem;
        private ToolStripMenuItem 用户管理ToolStripMenuItem;
        private ToolStripMenuItem 同步数据ToolStripMenuItem;
        private ToolStripMenuItem 同步库存数据ToolStripMenuItem;
        private ToolStripMenuItem 同步物理库区ToolStripMenuItem;
        private ToolStripMenuItem 同步保管员信息ToolStripMenuItem;
        private Panel panel1;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem 逻辑库区管理ToolStripMenuItem;
        private ToolStripMenuItem 标签打印ToolStripMenuItem1;
        private ToolStripMenuItem 物料标签打印ToolStripMenuItem1;
        private ToolStripMenuItem 储位标签打印ToolStripMenuItem;
        private ToolStripMenuItem 保管员标签打印ToolStripMenuItem1;
        private ToolStripMenuItem 查询统计ToolStripMenuItem;
        private ToolStripMenuItem 本地数据库查询ToolStripMenuItem;
        private ToolStripMenuItem 保管员物料查询ToolStripMenuItem;
        private ToolStripMenuItem 查询保养单ToolStripMenuItem;
        private ToolStripMenuItem 新建保养单ToolStripMenuItem;
        private ToolStripMenuItem 保养单列表ToolStripMenuItem;
        private ToolStripMenuItem 新建盘点单ToolStripMenuItem;
        private ToolStripMenuItem 盘点单列表ToolStripMenuItem;
        private ToolStripMenuItem 管理盘点单ToolStripMenuItem;
        private ToolStripMenuItem 查询盘点单ToolStripMenuItem;
        private ToolStripMenuItem 同步盘点单ToolStripMenuItem;
        private ToolStripMenuItem 管理保养单ToolStripMenuItem;

        // Methods
        public RF库存管理系统(UserInfo userItem, ArrayList userRoles)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.menuStripMainForm = new System.Windows.Forms.MenuStrip();
            this.系统管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.权限管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日志管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印机管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.库存账套管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.逻辑库区管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.到库通知ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建到库通知单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.到库通知单列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.异议入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.库存保养ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建保养单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保养单列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理保养单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询保养单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.库存盘点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建盘点单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.盘点单列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理盘点单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询盘点单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标签打印ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.物料标签打印ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.储位标签打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保管员标签打印ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.查询统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.本地数据库查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保管员物料查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步库存数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步物理库区ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步保管员信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.同步盘点单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMainForm
            // 
            this.menuStripMainForm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStripMainForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStripMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统管理ToolStripMenuItem,
            this.到库通知ToolStripMenuItem,
            this.库存保养ToolStripMenuItem,
            this.库存盘点ToolStripMenuItem,
            this.标签打印ToolStripMenuItem1,
            this.查询统计ToolStripMenuItem,
            this.同步数据ToolStripMenuItem});
            this.menuStripMainForm.Location = new System.Drawing.Point(0, 0);
            this.menuStripMainForm.Name = "menuStripMainForm";
            this.menuStripMainForm.Size = new System.Drawing.Size(1016, 28);
            this.menuStripMainForm.TabIndex = 1;
            // 
            // 系统管理ToolStripMenuItem
            // 
            this.系统管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户管理ToolStripMenuItem,
            this.权限管理ToolStripMenuItem,
            this.日志管理ToolStripMenuItem,
            this.打印机管理ToolStripMenuItem,
            this.库存账套管理ToolStripMenuItem,
            this.逻辑库区管理ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.退出系统ToolStripMenuItem});
            this.系统管理ToolStripMenuItem.Name = "系统管理ToolStripMenuItem";
            this.系统管理ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.系统管理ToolStripMenuItem.Text = "系统管理";
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.用户管理ToolStripMenuItem.Text = "用户管理";
            this.用户管理ToolStripMenuItem.Click += new System.EventHandler(this.用户管理ToolStripMenuItem_Click);
            // 
            // 权限管理ToolStripMenuItem
            // 
            this.权限管理ToolStripMenuItem.Name = "权限管理ToolStripMenuItem";
            this.权限管理ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.权限管理ToolStripMenuItem.Text = "权限管理";
            this.权限管理ToolStripMenuItem.Click += new System.EventHandler(this.权限管理ToolStripMenuItem_Click);
            // 
            // 日志管理ToolStripMenuItem
            // 
            this.日志管理ToolStripMenuItem.Name = "日志管理ToolStripMenuItem";
            this.日志管理ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.日志管理ToolStripMenuItem.Text = "日志管理";
            this.日志管理ToolStripMenuItem.Click += new System.EventHandler(this.日志管理ToolStripMenuItem_Click);
            // 
            // 打印机管理ToolStripMenuItem
            // 
            this.打印机管理ToolStripMenuItem.Name = "打印机管理ToolStripMenuItem";
            this.打印机管理ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.打印机管理ToolStripMenuItem.Text = "打印机管理";
            this.打印机管理ToolStripMenuItem.Click += new System.EventHandler(this.打印机管理ToolStripMenuItem_Click);
            // 
            // 库存账套管理ToolStripMenuItem
            // 
            this.库存账套管理ToolStripMenuItem.Name = "库存账套管理ToolStripMenuItem";
            this.库存账套管理ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.库存账套管理ToolStripMenuItem.Text = "库存账套管理";
            this.库存账套管理ToolStripMenuItem.Click += new System.EventHandler(this.库存账套及库存点信息管理ToolStripMenuItem_Click);
            // 
            // 逻辑库区管理ToolStripMenuItem
            // 
            this.逻辑库区管理ToolStripMenuItem.Name = "逻辑库区管理ToolStripMenuItem";
            this.逻辑库区管理ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.逻辑库区管理ToolStripMenuItem.Text = "逻辑库区管理";
            this.逻辑库区管理ToolStripMenuItem.Click += new System.EventHandler(this.逻辑库区管理ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 6);
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
            // 
            // 到库通知ToolStripMenuItem
            // 
            this.到库通知ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建到库通知单ToolStripMenuItem,
            this.到库通知单列表ToolStripMenuItem,
            this.异议入库ToolStripMenuItem});
            this.到库通知ToolStripMenuItem.Name = "到库通知ToolStripMenuItem";
            this.到库通知ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.到库通知ToolStripMenuItem.Text = "到库通知";
            // 
            // 新建到库通知单ToolStripMenuItem
            // 
            this.新建到库通知单ToolStripMenuItem.Name = "新建到库通知单ToolStripMenuItem";
            this.新建到库通知单ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.新建到库通知单ToolStripMenuItem.Text = "新建到库通知单";
            this.新建到库通知单ToolStripMenuItem.Click += new System.EventHandler(this.到库通知单ToolStripMenuItem_Click);
            // 
            // 到库通知单列表ToolStripMenuItem
            // 
            this.到库通知单列表ToolStripMenuItem.Name = "到库通知单列表ToolStripMenuItem";
            this.到库通知单列表ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.到库通知单列表ToolStripMenuItem.Text = "到库通知单列表";
            this.到库通知单列表ToolStripMenuItem.Click += new System.EventHandler(this.到库通知单列表ToolStripMenuItem_Click);
            // 
            // 异议入库ToolStripMenuItem
            // 
            this.异议入库ToolStripMenuItem.Name = "异议入库ToolStripMenuItem";
            this.异议入库ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.异议入库ToolStripMenuItem.Text = "异议入库";
            this.异议入库ToolStripMenuItem.Click += new System.EventHandler(this.异议入库ToolStripMenuItem_Click);
            // 
            // 库存保养ToolStripMenuItem
            // 
            this.库存保养ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建保养单ToolStripMenuItem,
            this.保养单列表ToolStripMenuItem,
            this.管理保养单ToolStripMenuItem,
            this.查询保养单ToolStripMenuItem});
            this.库存保养ToolStripMenuItem.Name = "库存保养ToolStripMenuItem";
            this.库存保养ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.库存保养ToolStripMenuItem.Text = "库存保养";
            // 
            // 新建保养单ToolStripMenuItem
            // 
            this.新建保养单ToolStripMenuItem.Name = "新建保养单ToolStripMenuItem";
            this.新建保养单ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.新建保养单ToolStripMenuItem.Text = "新建保养单";
            this.新建保养单ToolStripMenuItem.Click += new System.EventHandler(this.新建保养单ToolStripMenuItem_Click);
            // 
            // 保养单列表ToolStripMenuItem
            // 
            this.保养单列表ToolStripMenuItem.Name = "保养单列表ToolStripMenuItem";
            this.保养单列表ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.保养单列表ToolStripMenuItem.Text = "保养单列表";
            this.保养单列表ToolStripMenuItem.Click += new System.EventHandler(this.保养单列表ToolStripMenuItem_Click);
            // 
            // 管理保养单ToolStripMenuItem
            // 
            this.管理保养单ToolStripMenuItem.Name = "管理保养单ToolStripMenuItem";
            this.管理保养单ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.管理保养单ToolStripMenuItem.Text = "管理保养单";
            this.管理保养单ToolStripMenuItem.Click += new System.EventHandler(this.管理保养单ToolStripMenuItem_Click);
            // 
            // 查询保养单ToolStripMenuItem
            // 
            this.查询保养单ToolStripMenuItem.Name = "查询保养单ToolStripMenuItem";
            this.查询保养单ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.查询保养单ToolStripMenuItem.Text = "查询保养单";
            this.查询保养单ToolStripMenuItem.Click += new System.EventHandler(this.查询保养单ToolStripMenuItem_Click);
            // 
            // 库存盘点ToolStripMenuItem
            // 
            this.库存盘点ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建盘点单ToolStripMenuItem,
            this.盘点单列表ToolStripMenuItem,
            this.管理盘点单ToolStripMenuItem,
            this.查询盘点单ToolStripMenuItem});
            this.库存盘点ToolStripMenuItem.Name = "库存盘点ToolStripMenuItem";
            this.库存盘点ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.库存盘点ToolStripMenuItem.Text = "库存盘点";
            // 
            // 新建盘点单ToolStripMenuItem
            // 
            this.新建盘点单ToolStripMenuItem.Name = "新建盘点单ToolStripMenuItem";
            this.新建盘点单ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.新建盘点单ToolStripMenuItem.Text = "新建盘点单";
            this.新建盘点单ToolStripMenuItem.Click += new System.EventHandler(this.新建盘点单ToolStripMenuItem_Click);
            // 
            // 盘点单列表ToolStripMenuItem
            // 
            this.盘点单列表ToolStripMenuItem.Name = "盘点单列表ToolStripMenuItem";
            this.盘点单列表ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.盘点单列表ToolStripMenuItem.Text = "盘点单列表";
            this.盘点单列表ToolStripMenuItem.Click += new System.EventHandler(this.盘点单列表ToolStripMenuItem_Click);
            // 
            // 管理盘点单ToolStripMenuItem
            // 
            this.管理盘点单ToolStripMenuItem.Name = "管理盘点单ToolStripMenuItem";
            this.管理盘点单ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.管理盘点单ToolStripMenuItem.Text = "管理盘点单";
            this.管理盘点单ToolStripMenuItem.Click += new System.EventHandler(this.管理盘点单ToolStripMenuItem_Click);
            // 
            // 查询盘点单ToolStripMenuItem
            // 
            this.查询盘点单ToolStripMenuItem.Name = "查询盘点单ToolStripMenuItem";
            this.查询盘点单ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.查询盘点单ToolStripMenuItem.Text = "查询盘点单";
            this.查询盘点单ToolStripMenuItem.Click += new System.EventHandler(this.查询盘点单ToolStripMenuItem_Click);
            // 
            // 标签打印ToolStripMenuItem1
            // 
            this.标签打印ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.物料标签打印ToolStripMenuItem1,
            this.储位标签打印ToolStripMenuItem,
            this.保管员标签打印ToolStripMenuItem1});
            this.标签打印ToolStripMenuItem1.Name = "标签打印ToolStripMenuItem1";
            this.标签打印ToolStripMenuItem1.Size = new System.Drawing.Size(77, 24);
            this.标签打印ToolStripMenuItem1.Text = "标签打印";
            // 
            // 物料标签打印ToolStripMenuItem1
            // 
            this.物料标签打印ToolStripMenuItem1.Name = "物料标签打印ToolStripMenuItem1";
            this.物料标签打印ToolStripMenuItem1.Size = new System.Drawing.Size(176, 24);
            this.物料标签打印ToolStripMenuItem1.Text = "物料标签打印";
            this.物料标签打印ToolStripMenuItem1.Click += new System.EventHandler(this.物料标签打印ToolStripMenuItem1_Click);
            // 
            // 储位标签打印ToolStripMenuItem
            // 
            this.储位标签打印ToolStripMenuItem.Name = "储位标签打印ToolStripMenuItem";
            this.储位标签打印ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.储位标签打印ToolStripMenuItem.Text = "储位标签打印";
            this.储位标签打印ToolStripMenuItem.Click += new System.EventHandler(this.储位标签打印ToolStripMenuItem_Click);
            // 
            // 保管员标签打印ToolStripMenuItem1
            // 
            this.保管员标签打印ToolStripMenuItem1.Name = "保管员标签打印ToolStripMenuItem1";
            this.保管员标签打印ToolStripMenuItem1.Size = new System.Drawing.Size(176, 24);
            this.保管员标签打印ToolStripMenuItem1.Text = "保管员标签打印";
            this.保管员标签打印ToolStripMenuItem1.Click += new System.EventHandler(this.保管员标签打印ToolStripMenuItem1_Click);
            // 
            // 查询统计ToolStripMenuItem
            // 
            this.查询统计ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.本地数据库查询ToolStripMenuItem,
            this.保管员物料查询ToolStripMenuItem});
            this.查询统计ToolStripMenuItem.Name = "查询统计ToolStripMenuItem";
            this.查询统计ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.查询统计ToolStripMenuItem.Text = "查询统计";
            // 
            // 本地数据库查询ToolStripMenuItem
            // 
            this.本地数据库查询ToolStripMenuItem.Name = "本地数据库查询ToolStripMenuItem";
            this.本地数据库查询ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.本地数据库查询ToolStripMenuItem.Text = "本地数据库查询";
            this.本地数据库查询ToolStripMenuItem.Click += new System.EventHandler(this.本地数据库查询ToolStripMenuItem_Click);
            // 
            // 保管员物料查询ToolStripMenuItem
            // 
            this.保管员物料查询ToolStripMenuItem.Name = "保管员物料查询ToolStripMenuItem";
            this.保管员物料查询ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.保管员物料查询ToolStripMenuItem.Text = "保管员物料查询";
            this.保管员物料查询ToolStripMenuItem.Click += new System.EventHandler(this.保管员物料查询ToolStripMenuItem_Click);
            // 
            // 同步数据ToolStripMenuItem
            // 
            this.同步数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.同步库存数据ToolStripMenuItem,
            this.同步物理库区ToolStripMenuItem,
            this.同步保管员信息ToolStripMenuItem,
            this.同步盘点单ToolStripMenuItem});
            this.同步数据ToolStripMenuItem.Name = "同步数据ToolStripMenuItem";
            this.同步数据ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.同步数据ToolStripMenuItem.Text = "同步数据";
            // 
            // 同步库存数据ToolStripMenuItem
            // 
            this.同步库存数据ToolStripMenuItem.Name = "同步库存数据ToolStripMenuItem";
            this.同步库存数据ToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.同步库存数据ToolStripMenuItem.Text = "同步库存数据";
            this.同步库存数据ToolStripMenuItem.Click += new System.EventHandler(this.同步库存数据ToolStripMenuItem_Click);
            // 
            // 同步物理库区ToolStripMenuItem
            // 
            this.同步物理库区ToolStripMenuItem.Name = "同步物理库区ToolStripMenuItem";
            this.同步物理库区ToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.同步物理库区ToolStripMenuItem.Text = "同步库存账套及逻辑库区";
            this.同步物理库区ToolStripMenuItem.Click += new System.EventHandler(this.同步物理库区ToolStripMenuItem_Click);
            // 
            // 同步保管员信息ToolStripMenuItem
            // 
            this.同步保管员信息ToolStripMenuItem.Name = "同步保管员信息ToolStripMenuItem";
            this.同步保管员信息ToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.同步保管员信息ToolStripMenuItem.Text = "同步保管员信息";
            this.同步保管员信息ToolStripMenuItem.Click += new System.EventHandler(this.同步保管员信息ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 673);
            this.panel1.TabIndex = 2;
            // 
            // 同步盘点单ToolStripMenuItem
            // 
            this.同步盘点单ToolStripMenuItem.Name = "同步盘点单ToolStripMenuItem";
            this.同步盘点单ToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.同步盘点单ToolStripMenuItem.Text = "同步盘点单";
            this.同步盘点单ToolStripMenuItem.Click += new System.EventHandler(this.同步盘点单ToolStripMenuItem_Click);
            // 
            // RF库存管理系统
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
            this.ClientSize = new System.Drawing.Size(1016, 701);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStripMainForm);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMainForm;
            this.Name = "RF库存管理系统";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RF-PSCS库存管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_RF库存管理系统_Load);
            this.menuStripMainForm.ResumeLayout(false);
            this.menuStripMainForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitRolesMenu()
        {
            ToolStripMenuItem item = (ToolStripMenuItem)menuStripMainForm.Items["系统管理ToolStripMenuItem"];

            if (!AppSetter.User_Info.isAdmin)
            {
                item.Visible = false;

                item = (ToolStripMenuItem)menuStripMainForm.Items["到库通知ToolStripMenuItem"];

                if (AppSetter.User_Roles.Contains("ArriveStore"))
                {
                    if (!AppSetter.User_Roles.Contains("MakeArriveStoreRequisition"))
                    {
                        item.DropDownItems["新建到库通知单ToolStripMenuItem"].Visible = false;
                    }

                    if (!(AppSetter.User_Roles.Contains("MakeArriveStoreRequisition") || AppSetter.User_Roles.Contains("ApproveArriveStoreRequisition")))
                    {
                        item.DropDownItems["到库通知单列表ToolStripMenuItem"].Visible = false;
                    }

                    if (!(AppSetter.User_Roles.Contains("MakeArriveStoreRequisition") || AppSetter.User_Roles.Contains("ArriveStoreException")))
                    {
                        item.DropDownItems["异议入库ToolStripMenuItem"].Visible = false;
                    }
                }
                else
                {
                    item.Visible = false;
                }

                item = (ToolStripMenuItem)menuStripMainForm.Items["库存盘点ToolStripMenuItem"];

                item.Visible = true;

                item = (ToolStripMenuItem)menuStripMainForm.Items["库存保养ToolStripMenuItem"];

                item.Visible = true;

                item = (ToolStripMenuItem)menuStripMainForm.Items["查询统计ToolStripMenuItem"];
                item.DropDownItems["本地数据库查询ToolStripMenuItem"].Visible = true;
                item.DropDownItems["储位物料查询ToolStripMenuItem"].Visible = true;
                item.DropDownItems["保管员物料查询ToolStripMenuItem"].Visible = true;

                item = (ToolStripMenuItem)menuStripMainForm.Items["同步数据ToolStripMenuItem"];

                item.Visible = false;
            }
        }

        private void Frm_RF库存管理系统_Load(object sender, EventArgs e)
        {
            InitRolesMenu();

            Text = AppSetter.AppName;
        }

        private void 打印机管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            打印机信息列表 f = new 打印机信息列表();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 到库通知单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            到库通知单 f = new 到库通知单();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 到库通知单列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            到库通知单列表 f = new 到库通知单列表();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 库存账套及库存点信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            库存账套信息列表 f = new 库存账套信息列表();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 权限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            用户权限设置 f = new 用户权限设置();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 日志管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            日志管理 f = new 日志管理();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 异议入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            异议入库 f = new 异议入库();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            用户信息列表 f = new 用户信息列表();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 同步保管员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            同步保管员信息 f = new 同步保管员信息();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 同步物理库区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            同步物理库区 f = new 同步物理库区();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 同步库存数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            同步库存数据 f = new 同步库存数据();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 逻辑库区管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            逻辑库区信息列表 f = new 逻辑库区信息列表();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 物料标签打印ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            物料标签打印 f = new 物料标签打印();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 储位标签打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            储位标签打印 f = new 储位标签打印();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 保管员标签打印ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            保管员标签打印 f = new 保管员标签打印();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 本地数据库查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            本地数据库查询 f = new 本地数据库查询();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 保管员物料查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            保管员物料查询 f = new 保管员物料查询();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 查询保养单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            查询保养单 f = new 查询保养单();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 管理保养单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            管理保养单 f = new 管理保养单();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 新建保养单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            新建保养单 frm = new 新建保养单();
            frm.ShowDialog();
        }

        private void 保养单列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            保养单列表 f = new 保养单列表();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 新建盘点单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            新建盘点单 frm = new 新建盘点单();
            frm.ShowDialog();
        }

        private void 盘点单列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            盘点单列表 f = new 盘点单列表();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 管理盘点单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            管理盘点单 f = new 管理盘点单();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 查询盘点单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            查询盘点单 f = new 查询盘点单();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void 同步盘点单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            同步盘点单 f = new 同步盘点单();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }
    }
}
