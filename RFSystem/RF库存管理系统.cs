using System;
using System.Collections;
using System.Windows.Forms;
using RFSystem.Statistic;
using RFSystem.LabelPrint;
using RFSystem.SystemConfig;
using RFSystem.ArriveStore;
using System.Data;
using RFSystem.CommonClass;

namespace RFSystem
{
    public class RF������ϵͳ : Form
    {
        // Fields
        private ToolStripMenuItem excel�ļ�����ͬ��ToolStripMenuItem;
        private MenuStrip menuStripMainForm;
        private UserInfo userItem;
        private ArrayList userRoles;
        private ToolStripMenuItem ����Ա��ǩ��ӡToolStripMenuItem;
        private ToolStripMenuItem ����Ա��ƷToolStripMenuItem1;
        private ToolStripMenuItem �������ݿ��ѯToolStripMenuItem;
        private ToolStripMenuItem ��ǩ��ӡToolStripMenuItem;
        private ToolStripMenuItem ��ѯ������ToolStripMenuItem;
        private ToolStripMenuItem ��ѯͳ��ToolStripMenuItem;
        private ToolStripMenuItem �����̵��嵥ToolStripMenuItem;
        private ToolStripMenuItem ��ӡ������ToolStripMenuItem;
        private ToolStripMenuItem ����֪ͨToolStripMenuItem;
        private ToolStripMenuItem ����֪ͨ���б�ToolStripMenuItem;
        private ToolStripMenuItem ������־ͳ��ToolStripMenuItem;
        private ToolStripMenuItem ��˾����ToolStripMenuItem;
        private ToolStripMenuItem ��������ToolStripMenuItem;
        private ToolStripMenuItem ���ܱ�ǩ��ӡToolStripMenuItem;
        private ToolStripMenuItem ���п�汣��ToolStripMenuItem;
        private ToolStripMenuItem ��汣��ToolStripMenuItem;
        private ToolStripMenuItem ����̵�ToolStripMenuItem;
        private ToolStripMenuItem ��λ�����ѯToolStripMenuItem1;
        private ToolStripMenuItem �̵��嵥�б�ToolStripMenuItem;
        private ToolStripMenuItem Ȩ�޹���ToolStripMenuItem;
        private ToolStripMenuItem ��־����ToolStripMenuItem;
        private ToolStripMenuItem ����ͬ��ToolStripMenuItem;
        private ToolStripMenuItem �˳�ϵͳToolStripMenuItem;
        private ToolStripMenuItem ���ϱ�ǩ��ӡToolStripMenuItem;
        private ToolStripMenuItem ϵͳ����ToolStripMenuItem;
        private ToolStripMenuItem �½�����֪ͨ��ToolStripMenuItem;
        private ToolStripMenuItem �������ToolStripMenuItem;
        private ToolStripMenuItem �û�����ToolStripMenuItem;
        private ToolStripMenuItem ͬ������ToolStripMenuItem;
        private ToolStripMenuItem ͬ���������ToolStripMenuItem;
        private ToolStripMenuItem ͬ���������ToolStripMenuItem;
        private ToolStripMenuItem ͬ������Ա��ϢToolStripMenuItem;
        private ToolStripMenuItem ���ݿ��ѯToolStripMenuItem;
        private Panel panel1;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem ���ص����ToolStripMenuItem;
        private ToolStripMenuItem �ƶ�������ToolStripMenuItem;

        // Methods
        public RF������ϵͳ(UserInfo userItem, ArrayList userRoles)
        {
            this.userItem = null;
            this.userRoles = null;
            InitializeComponent();
            this.userItem = userItem;
            this.userRoles = userRoles;
        }

        private void InitializeComponent()
        {
            this.menuStripMainForm = new System.Windows.Forms.MenuStrip();
            this.ϵͳ����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�û�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Ȩ�޹���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��־����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ӡ������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��˾����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.�˳�ϵͳToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����֪ͨToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�½�����֪ͨ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����֪ͨ���б�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����̵�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�����̵��嵥ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�̵��嵥�б�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ǩ��ӡToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ܱ�ǩ��ӡToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ϱ�ǩ��ӡToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����Ա��ǩ��ӡToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��汣��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�ƶ�������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���п�汣��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ѯ������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ѯͳ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������־ͳ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excel�ļ�����ͬ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ͬ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����Ա��ƷToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.��λ�����ѯToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.�������ݿ��ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ݿ��ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͬ������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͬ���������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͬ���������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͬ������Ա��ϢToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.���ص����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMainForm
            // 
            this.menuStripMainForm.Font = new System.Drawing.Font("΢���ź�", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStripMainForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStripMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ϵͳ����ToolStripMenuItem,
            this.����֪ͨToolStripMenuItem,
            this.����̵�ToolStripMenuItem,
            this.��ǩ��ӡToolStripMenuItem,
            this.��汣��ToolStripMenuItem,
            this.��ѯͳ��ToolStripMenuItem,
            this.ͬ������ToolStripMenuItem});
            this.menuStripMainForm.Location = new System.Drawing.Point(0, 0);
            this.menuStripMainForm.Name = "menuStripMainForm";
            this.menuStripMainForm.Size = new System.Drawing.Size(1016, 28);
            this.menuStripMainForm.TabIndex = 1;
            // 
            // ϵͳ����ToolStripMenuItem
            // 
            this.ϵͳ����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�û�����ToolStripMenuItem,
            this.Ȩ�޹���ToolStripMenuItem,
            this.��־����ToolStripMenuItem,
            this.��ӡ������ToolStripMenuItem,
            this.��˾����ToolStripMenuItem,
            this.���ص����ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.�˳�ϵͳToolStripMenuItem});
            this.ϵͳ����ToolStripMenuItem.Name = "ϵͳ����ToolStripMenuItem";
            this.ϵͳ����ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.ϵͳ����ToolStripMenuItem.Text = "ϵͳ����";
            // 
            // �û�����ToolStripMenuItem
            // 
            this.�û�����ToolStripMenuItem.Name = "�û�����ToolStripMenuItem";
            this.�û�����ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.�û�����ToolStripMenuItem.Text = "�û�����";
            this.�û�����ToolStripMenuItem.Click += new System.EventHandler(this.�û�����ToolStripMenuItem_Click);
            // 
            // Ȩ�޹���ToolStripMenuItem
            // 
            this.Ȩ�޹���ToolStripMenuItem.Name = "Ȩ�޹���ToolStripMenuItem";
            this.Ȩ�޹���ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.Ȩ�޹���ToolStripMenuItem.Text = "Ȩ�޹���";
            this.Ȩ�޹���ToolStripMenuItem.Click += new System.EventHandler(this.Ȩ�޹���ToolStripMenuItem_Click);
            // 
            // ��־����ToolStripMenuItem
            // 
            this.��־����ToolStripMenuItem.Name = "��־����ToolStripMenuItem";
            this.��־����ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.��־����ToolStripMenuItem.Text = "��־����";
            this.��־����ToolStripMenuItem.Click += new System.EventHandler(this.��־����ToolStripMenuItem_Click);
            // 
            // ��ӡ������ToolStripMenuItem
            // 
            this.��ӡ������ToolStripMenuItem.Name = "��ӡ������ToolStripMenuItem";
            this.��ӡ������ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.��ӡ������ToolStripMenuItem.Text = "��ӡ������";
            this.��ӡ������ToolStripMenuItem.Click += new System.EventHandler(this.��ӡ������ToolStripMenuItem_Click);
            // 
            // ��˾����ToolStripMenuItem
            // 
            this.��˾����ToolStripMenuItem.Name = "��˾����ToolStripMenuItem";
            this.��˾����ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.��˾����ToolStripMenuItem.Text = "��˾����";
            this.��˾����ToolStripMenuItem.Click += new System.EventHandler(this.��˾��������Ϣ����ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // �˳�ϵͳToolStripMenuItem
            // 
            this.�˳�ϵͳToolStripMenuItem.Name = "�˳�ϵͳToolStripMenuItem";
            this.�˳�ϵͳToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.�˳�ϵͳToolStripMenuItem.Text = "�˳�ϵͳ";
            this.�˳�ϵͳToolStripMenuItem.Click += new System.EventHandler(this.�˳�ϵͳToolStripMenuItem_Click);
            // 
            // ����֪ͨToolStripMenuItem
            // 
            this.����֪ͨToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�½�����֪ͨ��ToolStripMenuItem,
            this.����֪ͨ���б�ToolStripMenuItem,
            this.�������ToolStripMenuItem});
            this.����֪ͨToolStripMenuItem.Name = "����֪ͨToolStripMenuItem";
            this.����֪ͨToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.����֪ͨToolStripMenuItem.Text = "����֪ͨ";
            this.����֪ͨToolStripMenuItem.Visible = false;
            // 
            // �½�����֪ͨ��ToolStripMenuItem
            // 
            this.�½�����֪ͨ��ToolStripMenuItem.Name = "�½�����֪ͨ��ToolStripMenuItem";
            this.�½�����֪ͨ��ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.�½�����֪ͨ��ToolStripMenuItem.Text = "�½�����֪ͨ��";
            this.�½�����֪ͨ��ToolStripMenuItem.Click += new System.EventHandler(this.����֪ͨ��ToolStripMenuItem_Click);
            // 
            // ����֪ͨ���б�ToolStripMenuItem
            // 
            this.����֪ͨ���б�ToolStripMenuItem.Name = "����֪ͨ���б�ToolStripMenuItem";
            this.����֪ͨ���б�ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.����֪ͨ���б�ToolStripMenuItem.Text = "����֪ͨ���б�";
            this.����֪ͨ���б�ToolStripMenuItem.Click += new System.EventHandler(this.����֪ͨ���б�ToolStripMenuItem_Click);
            // 
            // �������ToolStripMenuItem
            // 
            this.�������ToolStripMenuItem.Name = "�������ToolStripMenuItem";
            this.�������ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.�������ToolStripMenuItem.Text = "�������";
            this.�������ToolStripMenuItem.Click += new System.EventHandler(this.�������ToolStripMenuItem_Click);
            // 
            // ����̵�ToolStripMenuItem
            // 
            this.����̵�ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�����̵��嵥ToolStripMenuItem,
            this.�̵��嵥�б�ToolStripMenuItem});
            this.����̵�ToolStripMenuItem.Name = "����̵�ToolStripMenuItem";
            this.����̵�ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.����̵�ToolStripMenuItem.Text = "����̵�";
            // 
            // �����̵��嵥ToolStripMenuItem
            // 
            this.�����̵��嵥ToolStripMenuItem.Name = "�����̵��嵥ToolStripMenuItem";
            this.�����̵��嵥ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.�����̵��嵥ToolStripMenuItem.Text = "�����̵��嵥";
            this.�����̵��嵥ToolStripMenuItem.Click += new System.EventHandler(this.�����̵��嵥ToolStripMenuItem_Click);
            // 
            // �̵��嵥�б�ToolStripMenuItem
            // 
            this.�̵��嵥�б�ToolStripMenuItem.Name = "�̵��嵥�б�ToolStripMenuItem";
            this.�̵��嵥�б�ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.�̵��嵥�б�ToolStripMenuItem.Text = "�̵��嵥�б�";
            this.�̵��嵥�б�ToolStripMenuItem.Click += new System.EventHandler(this.�̵��嵥�б�ToolStripMenuItem_Click);
            // 
            // ��ǩ��ӡToolStripMenuItem
            // 
            this.��ǩ��ӡToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.���ܱ�ǩ��ӡToolStripMenuItem,
            this.���ϱ�ǩ��ӡToolStripMenuItem,
            this.����Ա��ǩ��ӡToolStripMenuItem});
            this.��ǩ��ӡToolStripMenuItem.Name = "��ǩ��ӡToolStripMenuItem";
            this.��ǩ��ӡToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.��ǩ��ӡToolStripMenuItem.Text = "��ѯ���ӡ";
            this.��ǩ��ӡToolStripMenuItem.Visible = false;
            // 
            // ���ܱ�ǩ��ӡToolStripMenuItem
            // 
            this.���ܱ�ǩ��ӡToolStripMenuItem.Name = "���ܱ�ǩ��ӡToolStripMenuItem";
            this.���ܱ�ǩ��ӡToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.���ܱ�ǩ��ӡToolStripMenuItem.Text = "���ܱ�ǩ��ӡ";
            this.���ܱ�ǩ��ӡToolStripMenuItem.Click += new System.EventHandler(this.���ܱ�ǩ��ӡToolStripMenuItem_Click);
            // 
            // ���ϱ�ǩ��ӡToolStripMenuItem
            // 
            this.���ϱ�ǩ��ӡToolStripMenuItem.Name = "���ϱ�ǩ��ӡToolStripMenuItem";
            this.���ϱ�ǩ��ӡToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.���ϱ�ǩ��ӡToolStripMenuItem.Text = "���ϱ�ǩ��ӡ";
            this.���ϱ�ǩ��ӡToolStripMenuItem.Click += new System.EventHandler(this.���ϱ�ǩ��ӡToolStripMenuItem_Click);
            // 
            // ����Ա��ǩ��ӡToolStripMenuItem
            // 
            this.����Ա��ǩ��ӡToolStripMenuItem.Name = "����Ա��ǩ��ӡToolStripMenuItem";
            this.����Ա��ǩ��ӡToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.����Ա��ǩ��ӡToolStripMenuItem.Text = "����Ա��ǩ��ӡ";
            this.����Ա��ǩ��ӡToolStripMenuItem.Click += new System.EventHandler(this.����Ա��ǩ��ӡToolStripMenuItem_Click);
            // 
            // ��汣��ToolStripMenuItem
            // 
            this.��汣��ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�ƶ�������ToolStripMenuItem,
            this.��������ToolStripMenuItem,
            this.���п�汣��ToolStripMenuItem,
            this.��ѯ������ToolStripMenuItem});
            this.��汣��ToolStripMenuItem.Name = "��汣��ToolStripMenuItem";
            this.��汣��ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.��汣��ToolStripMenuItem.Text = "��汣��";
            // 
            // �ƶ�������ToolStripMenuItem
            // 
            this.�ƶ�������ToolStripMenuItem.Name = "�ƶ�������ToolStripMenuItem";
            this.�ƶ�������ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.�ƶ�������ToolStripMenuItem.Text = "�ƶ�������";
            this.�ƶ�������ToolStripMenuItem.Click += new System.EventHandler(this.�ƶ�������ToolStripMenuItem_Click);
            // 
            // ��������ToolStripMenuItem
            // 
            this.��������ToolStripMenuItem.Name = "��������ToolStripMenuItem";
            this.��������ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.��������ToolStripMenuItem.Text = "��������";
            this.��������ToolStripMenuItem.Click += new System.EventHandler(this.��������ToolStripMenuItem_Click);
            // 
            // ���п�汣��ToolStripMenuItem
            // 
            this.���п�汣��ToolStripMenuItem.Name = "���п�汣��ToolStripMenuItem";
            this.���п�汣��ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.���п�汣��ToolStripMenuItem.Text = "���п�汣��";
            this.���п�汣��ToolStripMenuItem.Click += new System.EventHandler(this.���п�汣��ToolStripMenuItem_Click);
            // 
            // ��ѯ������ToolStripMenuItem
            // 
            this.��ѯ������ToolStripMenuItem.Name = "��ѯ������ToolStripMenuItem";
            this.��ѯ������ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.��ѯ������ToolStripMenuItem.Text = "��ѯ������";
            this.��ѯ������ToolStripMenuItem.Click += new System.EventHandler(this.��ѯ������ToolStripMenuItem_Click);
            // 
            // ��ѯͳ��ToolStripMenuItem
            // 
            this.��ѯͳ��ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.������־ͳ��ToolStripMenuItem,
            this.excel�ļ�����ͬ��ToolStripMenuItem,
            this.����ͬ��ToolStripMenuItem,
            this.����Ա��ƷToolStripMenuItem1,
            this.��λ�����ѯToolStripMenuItem1,
            this.�������ݿ��ѯToolStripMenuItem,
            this.���ݿ��ѯToolStripMenuItem});
            this.��ѯͳ��ToolStripMenuItem.Name = "��ѯͳ��ToolStripMenuItem";
            this.��ѯͳ��ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.��ѯͳ��ToolStripMenuItem.Text = "��ѯͳ��";
            // 
            // ������־ͳ��ToolStripMenuItem
            // 
            this.������־ͳ��ToolStripMenuItem.Name = "������־ͳ��ToolStripMenuItem";
            this.������־ͳ��ToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.������־ͳ��ToolStripMenuItem.Text = "������־ͳ��";
            this.������־ͳ��ToolStripMenuItem.Visible = false;
            this.������־ͳ��ToolStripMenuItem.Click += new System.EventHandler(this.������־ͳ��ToolStripMenuItem_Click);
            // 
            // excel�ļ�����ͬ��ToolStripMenuItem
            // 
            this.excel�ļ�����ͬ��ToolStripMenuItem.Name = "excel�ļ�����ͬ��ToolStripMenuItem";
            this.excel�ļ�����ͬ��ToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.excel�ļ�����ͬ��ToolStripMenuItem.Text = "Excel�ļ�����ͬ��";
            this.excel�ļ�����ͬ��ToolStripMenuItem.Visible = false;
            this.excel�ļ�����ͬ��ToolStripMenuItem.Click += new System.EventHandler(this.excel�ļ�����ͬ��ToolStripMenuItem_Click);
            // 
            // ����ͬ��ToolStripMenuItem
            // 
            this.����ͬ��ToolStripMenuItem.Name = "����ͬ��ToolStripMenuItem";
            this.����ͬ��ToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.����ͬ��ToolStripMenuItem.Text = "����ͬ��";
            this.����ͬ��ToolStripMenuItem.Visible = false;
            this.����ͬ��ToolStripMenuItem.Click += new System.EventHandler(this.����ͬ��ToolStripMenuItem_Click);
            // 
            // ����Ա��ƷToolStripMenuItem1
            // 
            this.����Ա��ƷToolStripMenuItem1.Name = "����Ա��ƷToolStripMenuItem1";
            this.����Ա��ƷToolStripMenuItem1.Size = new System.Drawing.Size(196, 24);
            this.����Ա��ƷToolStripMenuItem1.Text = "����Ա�����ѯ";
            this.����Ա��ƷToolStripMenuItem1.Visible = false;
            this.����Ա��ƷToolStripMenuItem1.Click += new System.EventHandler(this.����Ա�����ѯToolStripMenuItem_Click);
            // 
            // ��λ�����ѯToolStripMenuItem1
            // 
            this.��λ�����ѯToolStripMenuItem1.Name = "��λ�����ѯToolStripMenuItem1";
            this.��λ�����ѯToolStripMenuItem1.Size = new System.Drawing.Size(196, 24);
            this.��λ�����ѯToolStripMenuItem1.Text = "��λ�����ѯ";
            this.��λ�����ѯToolStripMenuItem1.Visible = false;
            this.��λ�����ѯToolStripMenuItem1.Click += new System.EventHandler(this.��λ�����ѯToolStripMenuItem1_Click);
            // 
            // �������ݿ��ѯToolStripMenuItem
            // 
            this.�������ݿ��ѯToolStripMenuItem.Name = "�������ݿ��ѯToolStripMenuItem";
            this.�������ݿ��ѯToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.�������ݿ��ѯToolStripMenuItem.Text = "�������ݿ��ѯ";
            this.�������ݿ��ѯToolStripMenuItem.Visible = false;
            this.�������ݿ��ѯToolStripMenuItem.Click += new System.EventHandler(this.�������ݿ��ѯToolStripMenuItem_Click);
            // 
            // ���ݿ��ѯToolStripMenuItem
            // 
            this.���ݿ��ѯToolStripMenuItem.Name = "���ݿ��ѯToolStripMenuItem";
            this.���ݿ��ѯToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.���ݿ��ѯToolStripMenuItem.Text = "���ݿ��ѯ";
            this.���ݿ��ѯToolStripMenuItem.Click += new System.EventHandler(this.���ݿ��ѯToolStripMenuItem_Click);
            // 
            // ͬ������ToolStripMenuItem
            // 
            this.ͬ������ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ͬ���������ToolStripMenuItem,
            this.ͬ���������ToolStripMenuItem,
            this.ͬ������Ա��ϢToolStripMenuItem});
            this.ͬ������ToolStripMenuItem.Name = "ͬ������ToolStripMenuItem";
            this.ͬ������ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.ͬ������ToolStripMenuItem.Text = "ͬ������";
            // 
            // ͬ���������ToolStripMenuItem
            // 
            this.ͬ���������ToolStripMenuItem.Name = "ͬ���������ToolStripMenuItem";
            this.ͬ���������ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.ͬ���������ToolStripMenuItem.Text = "ͬ���������";
            this.ͬ���������ToolStripMenuItem.Click += new System.EventHandler(this.ͬ���������ToolStripMenuItem_Click);
            // 
            // ͬ���������ToolStripMenuItem
            // 
            this.ͬ���������ToolStripMenuItem.Name = "ͬ���������ToolStripMenuItem";
            this.ͬ���������ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.ͬ���������ToolStripMenuItem.Text = "ͬ���������";
            this.ͬ���������ToolStripMenuItem.Click += new System.EventHandler(this.ͬ���������ToolStripMenuItem_Click);
            // 
            // ͬ������Ա��ϢToolStripMenuItem
            // 
            this.ͬ������Ա��ϢToolStripMenuItem.Name = "ͬ������Ա��ϢToolStripMenuItem";
            this.ͬ������Ա��ϢToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.ͬ������Ա��ϢToolStripMenuItem.Text = "ͬ������Ա��Ϣ";
            this.ͬ������Ա��ϢToolStripMenuItem.Click += new System.EventHandler(this.ͬ������Ա��ϢToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 673);
            this.panel1.TabIndex = 2;
            // 
            // ���ص����ToolStripMenuItem
            // 
            this.���ص����ToolStripMenuItem.Name = "���ص����ToolStripMenuItem";
            this.���ص����ToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.���ص����ToolStripMenuItem.Text = "���ص����";
            this.���ص����ToolStripMenuItem.Click += new System.EventHandler(this.���ص����ToolStripMenuItem_Click);
            // 
            // RF������ϵͳ
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
            this.ClientSize = new System.Drawing.Size(1016, 701);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStripMainForm);
            this.Font = new System.Drawing.Font("΢���ź�", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMainForm;
            this.Name = "RF������ϵͳ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RF������ϵͳ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_RF������ϵͳ_Load);
            this.menuStripMainForm.ResumeLayout(false);
            this.menuStripMainForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitRolesMenu()
        {
            ToolStripMenuItem item = (ToolStripMenuItem)menuStripMainForm.Items["ϵͳ����ToolStripMenuItem"];

            if (!userItem.isAdmin)
            {
                item.Visible = false;
                item = (ToolStripMenuItem)menuStripMainForm.Items["����֪ͨToolStripMenuItem"];

                if (userRoles.Contains("ArriveStore"))
                {
                    if (!userRoles.Contains("MakeArriveStoreRequisition"))
                    {
                        item.DropDownItems["�½�����֪ͨ��ToolStripMenuItem"].Visible = false;
                    }

                    if (!(userRoles.Contains("MakeArriveStoreRequisition") || userRoles.Contains("ApproveArriveStoreRequisition")))
                    {
                        item.DropDownItems["����֪ͨ���б�ToolStripMenuItem"].Visible = false;
                    }

                    if (!(userRoles.Contains("MakeArriveStoreRequisition") || userRoles.Contains("ArriveStoreException")))
                    {
                        item.DropDownItems["�������ToolStripMenuItem"].Visible = false;
                    }
                }
                else
                {
                    item.Visible = false;
                }

                item = (ToolStripMenuItem)menuStripMainForm.Items["����̵�ToolStripMenuItem"];

                if (!userRoles.Contains("MakeInventoryManage"))
                {
                    item.Visible = false;
                }
                else
                {
                    item.DropDownItems["�����̵��嵥ToolStripMenuItem"].Visible = false;
                }

                item = (ToolStripMenuItem)menuStripMainForm.Items["��汣��ToolStripMenuItem"];
                item.DropDownItems["��������ToolStripMenuItem"].Visible = false;
                item.DropDownItems["���п�汣��ToolStripMenuItem"].Visible = false;

                if (!userRoles.Contains("Maintain"))
                {
                    item.Visible = false;
                }

                item = (ToolStripMenuItem)menuStripMainForm.Items["��ѯͳ��ToolStripMenuItem"];
                item.DropDownItems["����ͬ��ToolStripMenuItem"].Visible = false;
            }
        }

        private void Frm_RF������ϵͳ_Load(object sender, EventArgs e)
        {
            InitRolesMenu();
        }

        private void excel�ļ�����ͬ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel�ļ�����ͬ�� f = new Excel�ļ�����ͬ��(userItem, userRoles);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ����Ա��ǩ��ӡToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContractorLabel f = new ContractorLabel();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ����Ա�����ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ����Ա��Ʒ f = new ����Ա��Ʒ();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void �������ݿ��ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �������ݿ��ѯ f = new �������ݿ��ѯ(userItem, userRoles);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ��ѯ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ��ѯ������ f = new ��ѯ������(userItem, userRoles);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void �����̵��嵥ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �����̵��嵥 f = new �����̵��嵥();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ��ӡ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ��ӡ����Ϣ�б� f = new ��ӡ����Ϣ�б�();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ����֪ͨ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ����֪ͨ�� f = new ����֪ͨ��(userItem);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ����֪ͨ���б�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ����֪ͨ���б� f = new ����֪ͨ���б�(userItem, userRoles);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ������־ͳ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ������־ͳ�� f = new ������־ͳ��(userItem, userRoles);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ��˾��������Ϣ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ��˾��Ϣ�б� f = new ��˾��Ϣ�б�();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �������� f = new ��������(userItem, userRoles);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ���ܱ�ǩ��ӡToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocationLabel f = new LocationLabel();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ���п�汣��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �������б� f = new �������б�(userItem, userRoles);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ��λ�����ѯToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ��λ��ѯ f = new ��λ��ѯ(userItem, userRoles);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void �̵��嵥�б�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �̵��嵥�б� f = new �̵��嵥�б�(userItem, userRoles);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void Ȩ�޹���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �û�Ȩ������ f = new �û�Ȩ������();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ��־����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ��־���� f = new ��־����();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ����ͬ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ����ͬ�� f = new ����ͬ��(userItem, userRoles);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void �˳�ϵͳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ���ϱ�ǩ��ӡToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductLabel f = new ProductLabel(userItem);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ������� f = new �������(userItem, userRoles);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void �û�����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �û���Ϣ�б� f = new �û���Ϣ�б�();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void �ƶ�������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �ƶ������� f = new �ƶ�������(userItem, userRoles);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ͬ������Ա��ϢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rfid2021Service.rfidService newService = new rfid2021Service.rfidService();
            DataSet _sendDs = new DataSet();

            DataTable _dt = _sendDs.Tables.Add("BODY");

            _dt.Columns.Add("auth", typeof(string));
            _dt.Columns["auth"].Caption = "��Ȩ";

            DataRow _dr = _dt.NewRow();
            _dr[0] = "getUsers";

            _dt.Rows.Add(_dr);

            rfid2021Service.MessagePack pack = newService.sendMsgNotOut("DVE130", ConstDefine.g_bxuserid, ConstDefine.g_bxusername, ConstDefine.g_bxjobid, _sendDs);

            if (pack.Result)
            {
                CommonFunction.Sys_MsgBox("ͬ���ɹ�");
            }
            else
            {
                CommonFunction.Sys_MsgBox(pack.Message);
            }
        }

        private void ͬ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rfid2021Service.rfidService newService = new rfid2021Service.rfidService();
            DataSet _sendDs = new DataSet();

            DataTable _dt = _sendDs.Tables.Add("BODY");

            _dt.Columns.Add("auth", typeof(string));
            _dt.Columns["auth"].Caption = "��㴫";

            DataRow _dr = _dt.NewRow();
            _dr[0] = "getUsers";

            _dt.Rows.Add(_dr);

            rfid2021Service.MessagePack pack = newService.sendMsgNotOut("DVE131", ConstDefine.g_bxuserid, ConstDefine.g_bxusername, ConstDefine.g_bxjobid, _sendDs);

            if (pack.Result)
            {
                CommonFunction.Sys_MsgBox("ͬ���ɹ�");
            }
            else
            {
                CommonFunction.Sys_MsgBox(pack.Message);
            }
        }

        private void ͬ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ͬ��������� f = new ͬ���������();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ���ݿ��ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ���ݿ��ѯ f = new ���ݿ��ѯ(userItem, userRoles);
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ���ص����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ���ص���Ϣ�б� f = new ���ص���Ϣ�б�();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }
    }
}
