using System;
using System.Collections;
using System.Windows.Forms;
using RFSystem.ArriveStore;

namespace RFSystem
{
    public class RF������ϵͳ : Form
    {
        private MenuStrip menuStripMainForm;
        private ToolStripMenuItem ��ӡ������ToolStripMenuItem;
        private ToolStripMenuItem ����֪ͨToolStripMenuItem;
        private ToolStripMenuItem ����֪ͨ���б�ToolStripMenuItem;
        private ToolStripMenuItem ������׹���ToolStripMenuItem;
        private ToolStripMenuItem ��汣��ToolStripMenuItem;
        private ToolStripMenuItem ����̵�ToolStripMenuItem;
        private ToolStripMenuItem Ȩ�޹���ToolStripMenuItem;
        private ToolStripMenuItem ��־����ToolStripMenuItem;
        private ToolStripMenuItem �˳�ϵͳToolStripMenuItem;
        private ToolStripMenuItem ϵͳ����ToolStripMenuItem;
        private ToolStripMenuItem �½�����֪ͨ��ToolStripMenuItem;
        private ToolStripMenuItem �������ToolStripMenuItem;
        private ToolStripMenuItem �û�����ToolStripMenuItem;
        private ToolStripMenuItem ͬ������ToolStripMenuItem;
        private ToolStripMenuItem ͬ���������ToolStripMenuItem;
        private ToolStripMenuItem ͬ���������ToolStripMenuItem;
        private ToolStripMenuItem ͬ������Ա��ϢToolStripMenuItem;
        private Panel panel1;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem �߼���������ToolStripMenuItem;
        private ToolStripMenuItem ��ǩ��ӡToolStripMenuItem1;
        private ToolStripMenuItem ���ϱ�ǩ��ӡToolStripMenuItem1;
        private ToolStripMenuItem ��λ��ǩ��ӡToolStripMenuItem;
        private ToolStripMenuItem ����Ա��ǩ��ӡToolStripMenuItem1;
        private ToolStripMenuItem ��ѯͳ��ToolStripMenuItem;
        private ToolStripMenuItem �������ݿ��ѯToolStripMenuItem;
        private ToolStripMenuItem ����Ա���ϲ�ѯToolStripMenuItem;
        private ToolStripMenuItem ��ѯ������ToolStripMenuItem;
        private ToolStripMenuItem �½�������ToolStripMenuItem;
        private ToolStripMenuItem �������б�ToolStripMenuItem;
        private ToolStripMenuItem �½��̵㵥ToolStripMenuItem;
        private ToolStripMenuItem �̵㵥�б�ToolStripMenuItem;
        private ToolStripMenuItem �����̵㵥ToolStripMenuItem;
        private ToolStripMenuItem ��ѯ�̵㵥ToolStripMenuItem;
        private ToolStripMenuItem ͬ���̵㵥ToolStripMenuItem;
        private ToolStripMenuItem ��������ToolStripMenuItem;

        // Methods
        public RF������ϵͳ(UserInfo userItem, ArrayList userRoles)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.menuStripMainForm = new System.Windows.Forms.MenuStrip();
            this.ϵͳ����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�û�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Ȩ�޹���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��־����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ӡ������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������׹���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�߼���������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.�˳�ϵͳToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����֪ͨToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�½�����֪ͨ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����֪ͨ���б�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��汣��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�½�������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�������б�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ѯ������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����̵�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�½��̵㵥ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�̵㵥�б�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�����̵㵥ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ѯ�̵㵥ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ǩ��ӡToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.���ϱ�ǩ��ӡToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.��λ��ǩ��ӡToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����Ա��ǩ��ӡToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.��ѯͳ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�������ݿ��ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����Ա���ϲ�ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͬ������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͬ���������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͬ���������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͬ������Ա��ϢToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ͬ���̵㵥ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.��汣��ToolStripMenuItem,
            this.����̵�ToolStripMenuItem,
            this.��ǩ��ӡToolStripMenuItem1,
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
            this.������׹���ToolStripMenuItem,
            this.�߼���������ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.�˳�ϵͳToolStripMenuItem});
            this.ϵͳ����ToolStripMenuItem.Name = "ϵͳ����ToolStripMenuItem";
            this.ϵͳ����ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.ϵͳ����ToolStripMenuItem.Text = "ϵͳ����";
            // 
            // �û�����ToolStripMenuItem
            // 
            this.�û�����ToolStripMenuItem.Name = "�û�����ToolStripMenuItem";
            this.�û�����ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.�û�����ToolStripMenuItem.Text = "�û�����";
            this.�û�����ToolStripMenuItem.Click += new System.EventHandler(this.�û�����ToolStripMenuItem_Click);
            // 
            // Ȩ�޹���ToolStripMenuItem
            // 
            this.Ȩ�޹���ToolStripMenuItem.Name = "Ȩ�޹���ToolStripMenuItem";
            this.Ȩ�޹���ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.Ȩ�޹���ToolStripMenuItem.Text = "Ȩ�޹���";
            this.Ȩ�޹���ToolStripMenuItem.Click += new System.EventHandler(this.Ȩ�޹���ToolStripMenuItem_Click);
            // 
            // ��־����ToolStripMenuItem
            // 
            this.��־����ToolStripMenuItem.Name = "��־����ToolStripMenuItem";
            this.��־����ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.��־����ToolStripMenuItem.Text = "��־����";
            this.��־����ToolStripMenuItem.Click += new System.EventHandler(this.��־����ToolStripMenuItem_Click);
            // 
            // ��ӡ������ToolStripMenuItem
            // 
            this.��ӡ������ToolStripMenuItem.Name = "��ӡ������ToolStripMenuItem";
            this.��ӡ������ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.��ӡ������ToolStripMenuItem.Text = "��ӡ������";
            this.��ӡ������ToolStripMenuItem.Click += new System.EventHandler(this.��ӡ������ToolStripMenuItem_Click);
            // 
            // ������׹���ToolStripMenuItem
            // 
            this.������׹���ToolStripMenuItem.Name = "������׹���ToolStripMenuItem";
            this.������׹���ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.������׹���ToolStripMenuItem.Text = "������׹���";
            this.������׹���ToolStripMenuItem.Click += new System.EventHandler(this.������׼�������Ϣ����ToolStripMenuItem_Click);
            // 
            // �߼���������ToolStripMenuItem
            // 
            this.�߼���������ToolStripMenuItem.Name = "�߼���������ToolStripMenuItem";
            this.�߼���������ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.�߼���������ToolStripMenuItem.Text = "�߼���������";
            this.�߼���������ToolStripMenuItem.Click += new System.EventHandler(this.�߼���������ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 6);
            // 
            // �˳�ϵͳToolStripMenuItem
            // 
            this.�˳�ϵͳToolStripMenuItem.Name = "�˳�ϵͳToolStripMenuItem";
            this.�˳�ϵͳToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
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
            // ��汣��ToolStripMenuItem
            // 
            this.��汣��ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�½�������ToolStripMenuItem,
            this.�������б�ToolStripMenuItem,
            this.��������ToolStripMenuItem,
            this.��ѯ������ToolStripMenuItem});
            this.��汣��ToolStripMenuItem.Name = "��汣��ToolStripMenuItem";
            this.��汣��ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.��汣��ToolStripMenuItem.Text = "��汣��";
            // 
            // �½�������ToolStripMenuItem
            // 
            this.�½�������ToolStripMenuItem.Name = "�½�������ToolStripMenuItem";
            this.�½�������ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.�½�������ToolStripMenuItem.Text = "�½�������";
            this.�½�������ToolStripMenuItem.Click += new System.EventHandler(this.�½�������ToolStripMenuItem_Click);
            // 
            // �������б�ToolStripMenuItem
            // 
            this.�������б�ToolStripMenuItem.Name = "�������б�ToolStripMenuItem";
            this.�������б�ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.�������б�ToolStripMenuItem.Text = "�������б�";
            this.�������б�ToolStripMenuItem.Click += new System.EventHandler(this.�������б�ToolStripMenuItem_Click);
            // 
            // ��������ToolStripMenuItem
            // 
            this.��������ToolStripMenuItem.Name = "��������ToolStripMenuItem";
            this.��������ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.��������ToolStripMenuItem.Text = "��������";
            this.��������ToolStripMenuItem.Click += new System.EventHandler(this.��������ToolStripMenuItem_Click);
            // 
            // ��ѯ������ToolStripMenuItem
            // 
            this.��ѯ������ToolStripMenuItem.Name = "��ѯ������ToolStripMenuItem";
            this.��ѯ������ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.��ѯ������ToolStripMenuItem.Text = "��ѯ������";
            this.��ѯ������ToolStripMenuItem.Click += new System.EventHandler(this.��ѯ������ToolStripMenuItem_Click);
            // 
            // ����̵�ToolStripMenuItem
            // 
            this.����̵�ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�½��̵㵥ToolStripMenuItem,
            this.�̵㵥�б�ToolStripMenuItem,
            this.�����̵㵥ToolStripMenuItem,
            this.��ѯ�̵㵥ToolStripMenuItem});
            this.����̵�ToolStripMenuItem.Name = "����̵�ToolStripMenuItem";
            this.����̵�ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.����̵�ToolStripMenuItem.Text = "����̵�";
            // 
            // �½��̵㵥ToolStripMenuItem
            // 
            this.�½��̵㵥ToolStripMenuItem.Name = "�½��̵㵥ToolStripMenuItem";
            this.�½��̵㵥ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.�½��̵㵥ToolStripMenuItem.Text = "�½��̵㵥";
            this.�½��̵㵥ToolStripMenuItem.Click += new System.EventHandler(this.�½��̵㵥ToolStripMenuItem_Click);
            // 
            // �̵㵥�б�ToolStripMenuItem
            // 
            this.�̵㵥�б�ToolStripMenuItem.Name = "�̵㵥�б�ToolStripMenuItem";
            this.�̵㵥�б�ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.�̵㵥�б�ToolStripMenuItem.Text = "�̵㵥�б�";
            this.�̵㵥�б�ToolStripMenuItem.Click += new System.EventHandler(this.�̵㵥�б�ToolStripMenuItem_Click);
            // 
            // �����̵㵥ToolStripMenuItem
            // 
            this.�����̵㵥ToolStripMenuItem.Name = "�����̵㵥ToolStripMenuItem";
            this.�����̵㵥ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.�����̵㵥ToolStripMenuItem.Text = "�����̵㵥";
            this.�����̵㵥ToolStripMenuItem.Click += new System.EventHandler(this.�����̵㵥ToolStripMenuItem_Click);
            // 
            // ��ѯ�̵㵥ToolStripMenuItem
            // 
            this.��ѯ�̵㵥ToolStripMenuItem.Name = "��ѯ�̵㵥ToolStripMenuItem";
            this.��ѯ�̵㵥ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.��ѯ�̵㵥ToolStripMenuItem.Text = "��ѯ�̵㵥";
            this.��ѯ�̵㵥ToolStripMenuItem.Click += new System.EventHandler(this.��ѯ�̵㵥ToolStripMenuItem_Click);
            // 
            // ��ǩ��ӡToolStripMenuItem1
            // 
            this.��ǩ��ӡToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.���ϱ�ǩ��ӡToolStripMenuItem1,
            this.��λ��ǩ��ӡToolStripMenuItem,
            this.����Ա��ǩ��ӡToolStripMenuItem1});
            this.��ǩ��ӡToolStripMenuItem1.Name = "��ǩ��ӡToolStripMenuItem1";
            this.��ǩ��ӡToolStripMenuItem1.Size = new System.Drawing.Size(77, 24);
            this.��ǩ��ӡToolStripMenuItem1.Text = "��ǩ��ӡ";
            // 
            // ���ϱ�ǩ��ӡToolStripMenuItem1
            // 
            this.���ϱ�ǩ��ӡToolStripMenuItem1.Name = "���ϱ�ǩ��ӡToolStripMenuItem1";
            this.���ϱ�ǩ��ӡToolStripMenuItem1.Size = new System.Drawing.Size(176, 24);
            this.���ϱ�ǩ��ӡToolStripMenuItem1.Text = "���ϱ�ǩ��ӡ";
            this.���ϱ�ǩ��ӡToolStripMenuItem1.Click += new System.EventHandler(this.���ϱ�ǩ��ӡToolStripMenuItem1_Click);
            // 
            // ��λ��ǩ��ӡToolStripMenuItem
            // 
            this.��λ��ǩ��ӡToolStripMenuItem.Name = "��λ��ǩ��ӡToolStripMenuItem";
            this.��λ��ǩ��ӡToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.��λ��ǩ��ӡToolStripMenuItem.Text = "��λ��ǩ��ӡ";
            this.��λ��ǩ��ӡToolStripMenuItem.Click += new System.EventHandler(this.��λ��ǩ��ӡToolStripMenuItem_Click);
            // 
            // ����Ա��ǩ��ӡToolStripMenuItem1
            // 
            this.����Ա��ǩ��ӡToolStripMenuItem1.Name = "����Ա��ǩ��ӡToolStripMenuItem1";
            this.����Ա��ǩ��ӡToolStripMenuItem1.Size = new System.Drawing.Size(176, 24);
            this.����Ա��ǩ��ӡToolStripMenuItem1.Text = "����Ա��ǩ��ӡ";
            this.����Ա��ǩ��ӡToolStripMenuItem1.Click += new System.EventHandler(this.����Ա��ǩ��ӡToolStripMenuItem1_Click);
            // 
            // ��ѯͳ��ToolStripMenuItem
            // 
            this.��ѯͳ��ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�������ݿ��ѯToolStripMenuItem,
            this.����Ա���ϲ�ѯToolStripMenuItem});
            this.��ѯͳ��ToolStripMenuItem.Name = "��ѯͳ��ToolStripMenuItem";
            this.��ѯͳ��ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.��ѯͳ��ToolStripMenuItem.Text = "��ѯͳ��";
            // 
            // �������ݿ��ѯToolStripMenuItem
            // 
            this.�������ݿ��ѯToolStripMenuItem.Name = "�������ݿ��ѯToolStripMenuItem";
            this.�������ݿ��ѯToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.�������ݿ��ѯToolStripMenuItem.Text = "�������ݿ��ѯ";
            this.�������ݿ��ѯToolStripMenuItem.Click += new System.EventHandler(this.�������ݿ��ѯToolStripMenuItem_Click);
            // 
            // ����Ա���ϲ�ѯToolStripMenuItem
            // 
            this.����Ա���ϲ�ѯToolStripMenuItem.Name = "����Ա���ϲ�ѯToolStripMenuItem";
            this.����Ա���ϲ�ѯToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.����Ա���ϲ�ѯToolStripMenuItem.Text = "����Ա���ϲ�ѯ";
            this.����Ա���ϲ�ѯToolStripMenuItem.Click += new System.EventHandler(this.����Ա���ϲ�ѯToolStripMenuItem_Click);
            // 
            // ͬ������ToolStripMenuItem
            // 
            this.ͬ������ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ͬ���������ToolStripMenuItem,
            this.ͬ���������ToolStripMenuItem,
            this.ͬ������Ա��ϢToolStripMenuItem,
            this.ͬ���̵㵥ToolStripMenuItem});
            this.ͬ������ToolStripMenuItem.Name = "ͬ������ToolStripMenuItem";
            this.ͬ������ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.ͬ������ToolStripMenuItem.Text = "ͬ������";
            // 
            // ͬ���������ToolStripMenuItem
            // 
            this.ͬ���������ToolStripMenuItem.Name = "ͬ���������ToolStripMenuItem";
            this.ͬ���������ToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.ͬ���������ToolStripMenuItem.Text = "ͬ���������";
            this.ͬ���������ToolStripMenuItem.Click += new System.EventHandler(this.ͬ���������ToolStripMenuItem_Click);
            // 
            // ͬ���������ToolStripMenuItem
            // 
            this.ͬ���������ToolStripMenuItem.Name = "ͬ���������ToolStripMenuItem";
            this.ͬ���������ToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.ͬ���������ToolStripMenuItem.Text = "ͬ��������׼��߼�����";
            this.ͬ���������ToolStripMenuItem.Click += new System.EventHandler(this.ͬ���������ToolStripMenuItem_Click);
            // 
            // ͬ������Ա��ϢToolStripMenuItem
            // 
            this.ͬ������Ա��ϢToolStripMenuItem.Name = "ͬ������Ա��ϢToolStripMenuItem";
            this.ͬ������Ա��ϢToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
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
            // ͬ���̵㵥ToolStripMenuItem
            // 
            this.ͬ���̵㵥ToolStripMenuItem.Name = "ͬ���̵㵥ToolStripMenuItem";
            this.ͬ���̵㵥ToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.ͬ���̵㵥ToolStripMenuItem.Text = "ͬ���̵㵥";
            this.ͬ���̵㵥ToolStripMenuItem.Click += new System.EventHandler(this.ͬ���̵㵥ToolStripMenuItem_Click);
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
            this.Text = "RF-PSCS������ϵͳ";
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

            if (!AppSetter.User_Info.isAdmin)
            {
                item.Visible = false;

                item = (ToolStripMenuItem)menuStripMainForm.Items["����֪ͨToolStripMenuItem"];

                if (AppSetter.User_Roles.Contains("ArriveStore"))
                {
                    if (!AppSetter.User_Roles.Contains("MakeArriveStoreRequisition"))
                    {
                        item.DropDownItems["�½�����֪ͨ��ToolStripMenuItem"].Visible = false;
                    }

                    if (!(AppSetter.User_Roles.Contains("MakeArriveStoreRequisition") || AppSetter.User_Roles.Contains("ApproveArriveStoreRequisition")))
                    {
                        item.DropDownItems["����֪ͨ���б�ToolStripMenuItem"].Visible = false;
                    }

                    if (!(AppSetter.User_Roles.Contains("MakeArriveStoreRequisition") || AppSetter.User_Roles.Contains("ArriveStoreException")))
                    {
                        item.DropDownItems["�������ToolStripMenuItem"].Visible = false;
                    }
                }
                else
                {
                    item.Visible = false;
                }

                item = (ToolStripMenuItem)menuStripMainForm.Items["����̵�ToolStripMenuItem"];

                item.Visible = true;

                item = (ToolStripMenuItem)menuStripMainForm.Items["��汣��ToolStripMenuItem"];

                item.Visible = true;

                item = (ToolStripMenuItem)menuStripMainForm.Items["��ѯͳ��ToolStripMenuItem"];
                item.DropDownItems["�������ݿ��ѯToolStripMenuItem"].Visible = true;
                item.DropDownItems["��λ���ϲ�ѯToolStripMenuItem"].Visible = true;
                item.DropDownItems["����Ա���ϲ�ѯToolStripMenuItem"].Visible = true;

                item = (ToolStripMenuItem)menuStripMainForm.Items["ͬ������ToolStripMenuItem"];

                item.Visible = false;
            }
        }

        private void Frm_RF������ϵͳ_Load(object sender, EventArgs e)
        {
            InitRolesMenu();

            Text = AppSetter.AppName;
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
            ����֪ͨ�� f = new ����֪ͨ��();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ����֪ͨ���б�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ����֪ͨ���б� f = new ����֪ͨ���б�();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ������׼�������Ϣ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ���������Ϣ�б� f = new ���������Ϣ�б�();
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

        private void �˳�ϵͳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ������� f = new �������();
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

        private void ͬ������Ա��ϢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ͬ������Ա��Ϣ f = new ͬ������Ա��Ϣ();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ͬ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ͬ��������� f = new ͬ���������();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ͬ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ͬ��������� f = new ͬ���������();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void �߼���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �߼�������Ϣ�б� f = new �߼�������Ϣ�б�();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ���ϱ�ǩ��ӡToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ���ϱ�ǩ��ӡ f = new ���ϱ�ǩ��ӡ();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ��λ��ǩ��ӡToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ��λ��ǩ��ӡ f = new ��λ��ǩ��ӡ();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ����Ա��ǩ��ӡToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ����Ա��ǩ��ӡ f = new ����Ա��ǩ��ӡ();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void �������ݿ��ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �������ݿ��ѯ f = new �������ݿ��ѯ();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ����Ա���ϲ�ѯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ����Ա���ϲ�ѯ f = new ����Ա���ϲ�ѯ();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ��ѯ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ��ѯ������ f = new ��ѯ������();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �������� f = new ��������();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void �½�������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �½������� frm = new �½�������();
            frm.ShowDialog();
        }

        private void �������б�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �������б� f = new �������б�();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void �½��̵㵥ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �½��̵㵥 frm = new �½��̵㵥();
            frm.ShowDialog();
        }

        private void �̵㵥�б�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �̵㵥�б� f = new �̵㵥�б�();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void �����̵㵥ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �����̵㵥 f = new �����̵㵥();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ��ѯ�̵㵥ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ��ѯ�̵㵥 f = new ��ѯ�̵㵥();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void ͬ���̵㵥ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ͬ���̵㵥 f = new ͬ���̵㵥();
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }
    }
}
