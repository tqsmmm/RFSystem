﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using RFSystem.CommonClass;
using BL;

namespace RFSystem.ArriveStore
{
    public partial class 到库通知单修改 : Form
    {
        // Fields
        private ArrayList arriveListInfo;
        private Button btnAdd;
        private Button btnCancel;
        private Button btnDel;
        private Button btnMod;
        private Button btnRevert;
        private ComboBox comboBoxBankrollKinds;
        private ComboBox comboBoxConveyanceMode;
        private ComboBox comboBoxPackagingKinds;
        private ComboBox comboBoxQuantityUnits;
        private DataGridView dataGridViewStorageInfo;
        private ArrayList getStorageInfo;
        private GroupBox groupBox2;
        private GroupBox groupBoxInputInfo;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label27;
        private Label label28;
        private Label label3;
        private Label label30;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label labelArriveListID;
        private Regex regex;
        private DataTable storageInfoList;
        private TextBox textBoxAcceptAmount;
        private TextBox textBoxAcceptWeight;
        private TextBox textBoxBargainID;
        private TextBox textBoxBargainMakerID;
        private TextBox textBoxConsigner;
        private TextBox textBoxConsignmentAmount;
        private TextBox textBoxConsignmentBillID;
        private TextBox textBoxConsignmentStation;
        private TextBox textBoxConveyanceID;
        private TextBox textBoxEquipmentName;
        private TextBox textBoxKeeper;
        private TextBox textBoxKeeperID;
        private TextBox textBoxKeepPlace;
        private TextBox textBoxProjectID;
        private TextBox textBoxProvider;
        private TextBox textBoxRemark;
        private TextBox textBoxTableMakeDate;
        private TextBox textBoxTableMaker;
        private TextBox textBoxTableMakerID;
        private DataGridViewTextBoxColumn ColumnStorePosition;
        private DataGridViewTextBoxColumn ColumnAmount;
        private DataGridViewTextBoxColumn ColumnRemark;
        private TextBox textBoxVehicleNO;

        private void InitializeComponent()
        {
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxAcceptWeight = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxKeeperID = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxKeeper = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBoxConsigner = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewStorageInfo = new System.Windows.Forms.DataGridView();
            this.textBoxTableMakeDate = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxRemark = new System.Windows.Forms.TextBox();
            this.labelArriveListID = new System.Windows.Forms.Label();
            this.textBoxTableMaker = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxTableMakerID = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxKeepPlace = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textBoxProvider = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnMod = new System.Windows.Forms.Button();
            this.textBoxVehicleNO = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxConveyanceID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxConsignmentBillID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxProjectID = new System.Windows.Forms.TextBox();
            this.groupBoxInputInfo = new System.Windows.Forms.GroupBox();
            this.comboBoxBankrollKinds = new System.Windows.Forms.ComboBox();
            this.comboBoxConveyanceMode = new System.Windows.Forms.ComboBox();
            this.comboBoxPackagingKinds = new System.Windows.Forms.ComboBox();
            this.comboBoxQuantityUnits = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxAcceptAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxConsignmentAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxEquipmentName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxConsignmentStation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxBargainMakerID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBargainID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRevert = new System.Windows.Forms.Button();
            this.ColumnStorePosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorageInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBoxInputInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(247, 169);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 20);
            this.label19.TabIndex = 0;
            this.label19.Text = "车　　号：";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAcceptWeight
            // 
            this.textBoxAcceptWeight.Location = new System.Drawing.Point(533, 134);
            this.textBoxAcceptWeight.Name = "textBoxAcceptWeight";
            this.textBoxAcceptWeight.Size = new System.Drawing.Size(91, 26);
            this.textBoxAcceptWeight.TabIndex = 110;
            this.textBoxAcceptWeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            this.textBoxAcceptWeight.Leave += new System.EventHandler(this.RegexNum);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(448, 137);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "实收重量：";
            // 
            // textBoxKeeperID
            // 
            this.textBoxKeeperID.Location = new System.Drawing.Point(533, 70);
            this.textBoxKeeperID.Name = "textBoxKeeperID";
            this.textBoxKeeperID.Size = new System.Drawing.Size(91, 26);
            this.textBoxKeeperID.TabIndex = 40;
            this.textBoxKeeperID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(448, 73);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 20);
            this.label22.TabIndex = 0;
            this.label22.Text = "保管员码：";
            // 
            // textBoxKeeper
            // 
            this.textBoxKeeper.Location = new System.Drawing.Point(715, 70);
            this.textBoxKeeper.Name = "textBoxKeeper";
            this.textBoxKeeper.Size = new System.Drawing.Size(91, 26);
            this.textBoxKeeper.TabIndex = 50;
            this.textBoxKeeper.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(636, 73);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(73, 20);
            this.label23.TabIndex = 0;
            this.label23.Text = "保 管 员：";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxConsigner
            // 
            this.textBoxConsigner.Location = new System.Drawing.Point(150, 70);
            this.textBoxConsigner.Name = "textBoxConsigner";
            this.textBoxConsigner.Size = new System.Drawing.Size(272, 26);
            this.textBoxConsigner.TabIndex = 30;
            this.textBoxConsigner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(71, 73);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "发 货 人：";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(764, 71);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 40);
            this.btnDel.TabIndex = 512;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(764, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 511;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewStorageInfo
            // 
            this.dataGridViewStorageInfo.AllowUserToAddRows = false;
            this.dataGridViewStorageInfo.AllowUserToResizeRows = false;
            this.dataGridViewStorageInfo.ColumnHeadersHeight = 30;
            this.dataGridViewStorageInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStorageInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStorePosition,
            this.ColumnAmount,
            this.ColumnRemark});
            this.dataGridViewStorageInfo.Location = new System.Drawing.Point(6, 20);
            this.dataGridViewStorageInfo.MultiSelect = false;
            this.dataGridViewStorageInfo.Name = "dataGridViewStorageInfo";
            this.dataGridViewStorageInfo.ReadOnly = true;
            this.dataGridViewStorageInfo.RowHeadersWidth = 30;
            this.dataGridViewStorageInfo.RowTemplate.Height = 23;
            this.dataGridViewStorageInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStorageInfo.Size = new System.Drawing.Size(752, 150);
            this.dataGridViewStorageInfo.TabIndex = 510;
            this.dataGridViewStorageInfo.SelectionChanged += new System.EventHandler(this.dataGridViewStorageInfo_SelectionChanged);
            // 
            // textBoxTableMakeDate
            // 
            this.textBoxTableMakeDate.Location = new System.Drawing.Point(715, 264);
            this.textBoxTableMakeDate.Name = "textBoxTableMakeDate";
            this.textBoxTableMakeDate.ReadOnly = true;
            this.textBoxTableMakeDate.Size = new System.Drawing.Size(91, 26);
            this.textBoxTableMakeDate.TabIndex = 290;
            this.textBoxTableMakeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(630, 267);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "制表日期：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxRemark
            // 
            this.textBoxRemark.Location = new System.Drawing.Point(532, 232);
            this.textBoxRemark.Name = "textBoxRemark";
            this.textBoxRemark.Size = new System.Drawing.Size(271, 26);
            this.textBoxRemark.TabIndex = 230;
            this.textBoxRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // labelArriveListID
            // 
            this.labelArriveListID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelArriveListID.ForeColor = System.Drawing.Color.Red;
            this.labelArriveListID.Location = new System.Drawing.Point(150, 41);
            this.labelArriveListID.Name = "labelArriveListID";
            this.labelArriveListID.Size = new System.Drawing.Size(106, 26);
            this.labelArriveListID.TabIndex = 1;
            this.labelArriveListID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxTableMaker
            // 
            this.textBoxTableMaker.Location = new System.Drawing.Point(532, 264);
            this.textBoxTableMaker.Name = "textBoxTableMaker";
            this.textBoxTableMaker.ReadOnly = true;
            this.textBoxTableMaker.Size = new System.Drawing.Size(91, 26);
            this.textBoxTableMaker.TabIndex = 260;
            this.textBoxTableMaker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(453, 267);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(73, 20);
            this.label30.TabIndex = 0;
            this.label30.Text = "制 表 员：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.dataGridViewStorageInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 341);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(870, 176);
            this.groupBox2.TabIndex = 1202;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "存放信息";
            // 
            // textBoxTableMakerID
            // 
            this.textBoxTableMakerID.Location = new System.Drawing.Point(332, 264);
            this.textBoxTableMakerID.Name = "textBoxTableMakerID";
            this.textBoxTableMakerID.ReadOnly = true;
            this.textBoxTableMakerID.Size = new System.Drawing.Size(90, 26);
            this.textBoxTableMakerID.TabIndex = 250;
            this.textBoxTableMakerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(247, 267);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(79, 20);
            this.label24.TabIndex = 0;
            this.label24.Text = "制表员码：";
            // 
            // textBoxKeepPlace
            // 
            this.textBoxKeepPlace.Location = new System.Drawing.Point(150, 264);
            this.textBoxKeepPlace.Name = "textBoxKeepPlace";
            this.textBoxKeepPlace.ReadOnly = true;
            this.textBoxKeepPlace.Size = new System.Drawing.Size(91, 26);
            this.textBoxKeepPlace.TabIndex = 240;
            this.textBoxKeepPlace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(65, 267);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(79, 20);
            this.label25.TabIndex = 0;
            this.label25.Text = "存放位置：";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(248, 202);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(79, 20);
            this.label27.TabIndex = 0;
            this.label27.Text = "资金类别：";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxProvider
            // 
            this.textBoxProvider.Location = new System.Drawing.Point(150, 232);
            this.textBoxProvider.Name = "textBoxProvider";
            this.textBoxProvider.Size = new System.Drawing.Size(273, 26);
            this.textBoxProvider.TabIndex = 200;
            this.textBoxProvider.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(65, 235);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(79, 20);
            this.label28.TabIndex = 0;
            this.label28.Text = "供货单位：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(447, 169);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 20);
            this.label18.TabIndex = 0;
            this.label18.Text = "数量单位：";
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(570, 523);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(100, 40);
            this.btnMod.TabIndex = 1203;
            this.btnMod.Text = "修改";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // textBoxVehicleNO
            // 
            this.textBoxVehicleNO.Location = new System.Drawing.Point(332, 166);
            this.textBoxVehicleNO.Name = "textBoxVehicleNO";
            this.textBoxVehicleNO.Size = new System.Drawing.Size(91, 26);
            this.textBoxVehicleNO.TabIndex = 140;
            this.textBoxVehicleNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(782, 523);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 1205;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(630, 169);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "包装种类：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxConveyanceID
            // 
            this.textBoxConveyanceID.Location = new System.Drawing.Point(150, 166);
            this.textBoxConveyanceID.Name = "textBoxConveyanceID";
            this.textBoxConveyanceID.Size = new System.Drawing.Size(91, 26);
            this.textBoxConveyanceID.TabIndex = 130;
            this.textBoxConveyanceID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(71, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "运 输 号：";
            // 
            // textBoxConsignmentBillID
            // 
            this.textBoxConsignmentBillID.Location = new System.Drawing.Point(715, 134);
            this.textBoxConsignmentBillID.Name = "textBoxConsignmentBillID";
            this.textBoxConsignmentBillID.Size = new System.Drawing.Size(91, 26);
            this.textBoxConsignmentBillID.TabIndex = 120;
            this.textBoxConsignmentBillID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(636, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "运 单 号：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(447, 235);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "备　　注：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxProjectID
            // 
            this.textBoxProjectID.Location = new System.Drawing.Point(532, 200);
            this.textBoxProjectID.Name = "textBoxProjectID";
            this.textBoxProjectID.Size = new System.Drawing.Size(272, 26);
            this.textBoxProjectID.TabIndex = 190;
            this.textBoxProjectID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // groupBoxInputInfo
            // 
            this.groupBoxInputInfo.Controls.Add(this.comboBoxBankrollKinds);
            this.groupBoxInputInfo.Controls.Add(this.comboBoxConveyanceMode);
            this.groupBoxInputInfo.Controls.Add(this.comboBoxPackagingKinds);
            this.groupBoxInputInfo.Controls.Add(this.comboBoxQuantityUnits);
            this.groupBoxInputInfo.Controls.Add(this.labelArriveListID);
            this.groupBoxInputInfo.Controls.Add(this.textBoxTableMaker);
            this.groupBoxInputInfo.Controls.Add(this.label30);
            this.groupBoxInputInfo.Controls.Add(this.textBoxTableMakerID);
            this.groupBoxInputInfo.Controls.Add(this.label24);
            this.groupBoxInputInfo.Controls.Add(this.textBoxKeepPlace);
            this.groupBoxInputInfo.Controls.Add(this.label25);
            this.groupBoxInputInfo.Controls.Add(this.label27);
            this.groupBoxInputInfo.Controls.Add(this.textBoxProvider);
            this.groupBoxInputInfo.Controls.Add(this.label28);
            this.groupBoxInputInfo.Controls.Add(this.label18);
            this.groupBoxInputInfo.Controls.Add(this.textBoxVehicleNO);
            this.groupBoxInputInfo.Controls.Add(this.label19);
            this.groupBoxInputInfo.Controls.Add(this.textBoxAcceptWeight);
            this.groupBoxInputInfo.Controls.Add(this.label20);
            this.groupBoxInputInfo.Controls.Add(this.textBoxKeeperID);
            this.groupBoxInputInfo.Controls.Add(this.label22);
            this.groupBoxInputInfo.Controls.Add(this.textBoxKeeper);
            this.groupBoxInputInfo.Controls.Add(this.label23);
            this.groupBoxInputInfo.Controls.Add(this.textBoxConsigner);
            this.groupBoxInputInfo.Controls.Add(this.label17);
            this.groupBoxInputInfo.Controls.Add(this.textBoxTableMakeDate);
            this.groupBoxInputInfo.Controls.Add(this.label16);
            this.groupBoxInputInfo.Controls.Add(this.textBoxRemark);
            this.groupBoxInputInfo.Controls.Add(this.label13);
            this.groupBoxInputInfo.Controls.Add(this.textBoxProjectID);
            this.groupBoxInputInfo.Controls.Add(this.label14);
            this.groupBoxInputInfo.Controls.Add(this.label11);
            this.groupBoxInputInfo.Controls.Add(this.label12);
            this.groupBoxInputInfo.Controls.Add(this.textBoxConveyanceID);
            this.groupBoxInputInfo.Controls.Add(this.label9);
            this.groupBoxInputInfo.Controls.Add(this.textBoxConsignmentBillID);
            this.groupBoxInputInfo.Controls.Add(this.label10);
            this.groupBoxInputInfo.Controls.Add(this.textBoxAcceptAmount);
            this.groupBoxInputInfo.Controls.Add(this.label7);
            this.groupBoxInputInfo.Controls.Add(this.textBoxConsignmentAmount);
            this.groupBoxInputInfo.Controls.Add(this.label8);
            this.groupBoxInputInfo.Controls.Add(this.textBoxEquipmentName);
            this.groupBoxInputInfo.Controls.Add(this.label6);
            this.groupBoxInputInfo.Controls.Add(this.textBoxConsignmentStation);
            this.groupBoxInputInfo.Controls.Add(this.label5);
            this.groupBoxInputInfo.Controls.Add(this.textBoxBargainMakerID);
            this.groupBoxInputInfo.Controls.Add(this.label4);
            this.groupBoxInputInfo.Controls.Add(this.textBoxBargainID);
            this.groupBoxInputInfo.Controls.Add(this.label3);
            this.groupBoxInputInfo.Controls.Add(this.label1);
            this.groupBoxInputInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInputInfo.Name = "groupBoxInputInfo";
            this.groupBoxInputInfo.Size = new System.Drawing.Size(870, 323);
            this.groupBoxInputInfo.TabIndex = 1201;
            this.groupBoxInputInfo.TabStop = false;
            this.groupBoxInputInfo.Text = "到库货物信息";
            // 
            // comboBoxBankrollKinds
            // 
            this.comboBoxBankrollKinds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBankrollKinds.FormattingEnabled = true;
            this.comboBoxBankrollKinds.Location = new System.Drawing.Point(333, 198);
            this.comboBoxBankrollKinds.Name = "comboBoxBankrollKinds";
            this.comboBoxBankrollKinds.Size = new System.Drawing.Size(92, 28);
            this.comboBoxBankrollKinds.TabIndex = 180;
            this.comboBoxBankrollKinds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // comboBoxConveyanceMode
            // 
            this.comboBoxConveyanceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConveyanceMode.FormattingEnabled = true;
            this.comboBoxConveyanceMode.Location = new System.Drawing.Point(150, 198);
            this.comboBoxConveyanceMode.Name = "comboBoxConveyanceMode";
            this.comboBoxConveyanceMode.Size = new System.Drawing.Size(92, 28);
            this.comboBoxConveyanceMode.TabIndex = 170;
            this.comboBoxConveyanceMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // comboBoxPackagingKinds
            // 
            this.comboBoxPackagingKinds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPackagingKinds.FormattingEnabled = true;
            this.comboBoxPackagingKinds.Location = new System.Drawing.Point(715, 166);
            this.comboBoxPackagingKinds.Name = "comboBoxPackagingKinds";
            this.comboBoxPackagingKinds.Size = new System.Drawing.Size(92, 28);
            this.comboBoxPackagingKinds.TabIndex = 160;
            this.comboBoxPackagingKinds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // comboBoxQuantityUnits
            // 
            this.comboBoxQuantityUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQuantityUnits.FormattingEnabled = true;
            this.comboBoxQuantityUnits.Location = new System.Drawing.Point(532, 166);
            this.comboBoxQuantityUnits.Name = "comboBoxQuantityUnits";
            this.comboBoxQuantityUnits.Size = new System.Drawing.Size(92, 28);
            this.comboBoxQuantityUnits.TabIndex = 150;
            this.comboBoxQuantityUnits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(447, 203);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "工程编号：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(65, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "运输方式：";
            // 
            // textBoxAcceptAmount
            // 
            this.textBoxAcceptAmount.Location = new System.Drawing.Point(332, 134);
            this.textBoxAcceptAmount.Name = "textBoxAcceptAmount";
            this.textBoxAcceptAmount.Size = new System.Drawing.Size(91, 26);
            this.textBoxAcceptAmount.TabIndex = 90;
            this.textBoxAcceptAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            this.textBoxAcceptAmount.Leave += new System.EventHandler(this.RegexNum);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "实收件数：";
            // 
            // textBoxConsignmentAmount
            // 
            this.textBoxConsignmentAmount.Location = new System.Drawing.Point(150, 134);
            this.textBoxConsignmentAmount.Name = "textBoxConsignmentAmount";
            this.textBoxConsignmentAmount.Size = new System.Drawing.Size(91, 26);
            this.textBoxConsignmentAmount.TabIndex = 80;
            this.textBoxConsignmentAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            this.textBoxConsignmentAmount.Leave += new System.EventHandler(this.RegexNum);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(65, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "运单件数：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxEquipmentName
            // 
            this.textBoxEquipmentName.Location = new System.Drawing.Point(533, 102);
            this.textBoxEquipmentName.Name = "textBoxEquipmentName";
            this.textBoxEquipmentName.Size = new System.Drawing.Size(272, 26);
            this.textBoxEquipmentName.TabIndex = 70;
            this.textBoxEquipmentName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(448, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "设备名称：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxConsignmentStation
            // 
            this.textBoxConsignmentStation.Location = new System.Drawing.Point(150, 102);
            this.textBoxConsignmentStation.Name = "textBoxConsignmentStation";
            this.textBoxConsignmentStation.Size = new System.Drawing.Size(272, 26);
            this.textBoxConsignmentStation.TabIndex = 60;
            this.textBoxConsignmentStation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "发　　站：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxBargainMakerID
            // 
            this.textBoxBargainMakerID.Location = new System.Drawing.Point(715, 38);
            this.textBoxBargainMakerID.Name = "textBoxBargainMakerID";
            this.textBoxBargainMakerID.Size = new System.Drawing.Size(91, 26);
            this.textBoxBargainMakerID.TabIndex = 20;
            this.textBoxBargainMakerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(630, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "合同员码：";
            // 
            // textBoxBargainID
            // 
            this.textBoxBargainID.Location = new System.Drawing.Point(533, 38);
            this.textBoxBargainID.Name = "textBoxBargainID";
            this.textBoxBargainID.Size = new System.Drawing.Size(91, 26);
            this.textBoxBargainID.TabIndex = 10;
            this.textBoxBargainID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectNextControl);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "合 同 号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "到库单号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRevert
            // 
            this.btnRevert.Location = new System.Drawing.Point(676, 523);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(100, 40);
            this.btnRevert.TabIndex = 1206;
            this.btnRevert.Text = "还原";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // ColumnStorePosition
            // 
            this.ColumnStorePosition.DataPropertyName = "StorePosition";
            this.ColumnStorePosition.HeaderText = "库位";
            this.ColumnStorePosition.Name = "ColumnStorePosition";
            this.ColumnStorePosition.ReadOnly = true;
            this.ColumnStorePosition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnStorePosition.Width = 105;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.DataPropertyName = "Amount";
            this.ColumnAmount.HeaderText = "库位数量";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            this.ColumnAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnRemark
            // 
            this.ColumnRemark.DataPropertyName = "Remark";
            this.ColumnRemark.HeaderText = "备注";
            this.ColumnRemark.Name = "ColumnRemark";
            this.ColumnRemark.ReadOnly = true;
            this.ColumnRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnRemark.Width = 400;
            // 
            // 到库通知单修改
            // 
            this.ClientSize = new System.Drawing.Size(894, 575);
            this.ControlBox = false;
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBoxInputInfo);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "到库通知单修改";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "到库通知单修改";
            this.Load += new System.EventHandler(this.到库通知单修改_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorageInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBoxInputInfo.ResumeLayout(false);
            this.groupBoxInputInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        // Methods
        public 到库通知单修改(ArrayList arriveListInfo)
        {
            this.storageInfoList = null;
            this.arriveListInfo = null;
            this.getStorageInfo = null;
            this.InitializeComponent();
            this.regex = new Regex(ConstDefine.REGEX_NUM);
            this.InitializeFormControls();
            this.arriveListInfo = arriveListInfo;
            this.RevertInputControl();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            到库货物存放信息 到库货物存放信息 = new 到库货物存放信息();
            if (到库货物存放信息.ShowDialog() == DialogResult.OK)
            {
                this.getStorageInfo = 到库货物存放信息.ArriveStoreStorageInfo;
                this.storageInfoList.Rows.Add(new object[] { (string)this.getStorageInfo[0], (int)this.getStorageInfo[1], (string)this.getStorageInfo[2] });
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            this.storageInfoList.Rows.RemoveAt(this.dataGridViewStorageInfo.SelectedRows[0].Index);
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            decimal num = 0M;
            foreach (DataRow row in this.storageInfoList.Rows)
            {
                num += Convert.ToDecimal(row["Amount"]);
            }
            if (num.ToString().Equals(this.textBoxAcceptAmount.Text))
            {
                ArrayList billInfo = new ArrayList();
                billInfo.Add(this.labelArriveListID.Text);
                Control textBoxBargainID = this.textBoxBargainID;
                for (int i = 0; i < 0x18; i++)
                {
                    if (!(!(textBoxBargainID is ComboBox) || textBoxBargainID.Name.Equals("comboBoxQuantityUnits")))
                    {
                        billInfo.Add(((ComboBox)textBoxBargainID).SelectedIndex + 1);
                    }
                    else
                    {
                        billInfo.Add(textBoxBargainID.Text);
                    }
                    textBoxBargainID = base.GetNextControl(textBoxBargainID, true);
                }
                if (!DBOperate.ArriveStoreMod(billInfo, this.storageInfoList).Equals("-1"))
                {
                    CommonFunction.Sys_MsgBox("到库通知单 " + billInfo[0].ToString() + " 修改成功");
                    base.DialogResult = DialogResult.OK;
                }
                else
                {
                    CommonFunction.Sys_MsgBox("数据库出错，请联系系统管理员确认");
                }
            }
            else
            {
                CommonFunction.Sys_MsgBox("实收数量和临时入库数量不一致，请确认");
            }
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            this.RevertInputControl();
        }

        private void dataGridViewStorageInfo_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dataGridViewStorageInfo.Rows != null) && (this.dataGridViewStorageInfo.SelectedRows.Count != 0))
            {
                this.btnDel.Enabled = true;
            }
            else
            {
                this.btnDel.Enabled = false;
            }
        }

        private void InitializeFormControls()
        {
            this.comboBoxQuantityUnits.Items.Add("台");
            this.comboBoxQuantityUnits.Items.Add("件");
            this.comboBoxQuantityUnits.Items.Add("箱");
            this.comboBoxQuantityUnits.Items.Add("捆");
            this.comboBoxQuantityUnits.Items.Add("磅");
            this.comboBoxQuantityUnits.Items.Add("米");
            this.comboBoxQuantityUnits.Items.Add("公斤");
            this.comboBoxQuantityUnits.Items.Add("升");
            this.comboBoxQuantityUnits.Items.Add("千件");
            this.comboBoxQuantityUnits.Items.Add("袋");
            this.comboBoxPackagingKinds.Items.Add("纸箱");
            this.comboBoxPackagingKinds.Items.Add("木箱");
            this.comboBoxPackagingKinds.Items.Add("集装箱");
            this.comboBoxPackagingKinds.Items.Add("其它箱");
            this.comboBoxPackagingKinds.Items.Add("筐");
            this.comboBoxPackagingKinds.Items.Add("捆");
            this.comboBoxPackagingKinds.Items.Add("裸");
            this.comboBoxConveyanceMode.Items.Add("零担");
            this.comboBoxConveyanceMode.Items.Add("邮包");
            this.comboBoxConveyanceMode.Items.Add("送货");
            this.comboBoxConveyanceMode.Items.Add("整车局卸");
            this.comboBoxConveyanceMode.Items.Add("整车厂卸");
            this.comboBoxConveyanceMode.Items.Add("航空");
            this.comboBoxConveyanceMode.Items.Add("自提");
            this.comboBoxBankrollKinds.Items.Add("生产");
            this.comboBoxBankrollKinds.Items.Add("技改");
        }

        private void RegexNum(object sender, EventArgs e)
        {
            if (!((TextBox)sender).Text.Equals(string.Empty) && !this.regex.IsMatch(((TextBox)sender).Text))
            {
                CommonFunction.Sys_MsgBox("对不起，您所输入的不符合数字格式要求，请从新输入");
                ((TextBox)sender).Focus();
            }
        }

        private void RevertInputControl()
        {
            this.labelArriveListID.Text = this.arriveListInfo[0].ToString();
            this.storageInfoList = DBOperate.SelectArriveStoreStorageInfo(this.labelArriveListID.Text);
            this.dataGridViewStorageInfo.DataSource = this.storageInfoList;
            Control textBoxBargainID = this.textBoxBargainID;
            for (int i = 0; i < 0x18; i++)
            {
                if (!(!(textBoxBargainID is ComboBox) || textBoxBargainID.Name.Equals("comboBoxQuantityUnits")))
                {
                    ((ComboBox)textBoxBargainID).SelectedIndex = Convert.ToInt32(this.arriveListInfo[i + 1]) - 1;
                }
                else
                {
                    textBoxBargainID.Text = this.arriveListInfo[i + 1].ToString();
                }
                textBoxBargainID = base.GetNextControl(textBoxBargainID, true);
            }
        }

        private void SelectNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                base.GetNextControl(base.ActiveControl, true).Focus();
            }
        }

        private void 到库通知单修改_Load(object sender, EventArgs e)
        {
        }
    }
}
