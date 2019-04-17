namespace ChessProjectOOP
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.ChessTableContainer = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ipField2 = new Utilities.Controls.IpField();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.colorPreferenceOptionBlack = new System.Windows.Forms.RadioButton();
            this.colorPreferenceOptionNone = new System.Windows.Forms.RadioButton();
            this.colorPreferenceOptionWhite = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.playerNameField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.NumericUpDown();
            this.endGameBtn = new System.Windows.Forms.Button();
            this.joinGameBtn = new System.Windows.Forms.Button();
            this.openGameBtn = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.networkConnection = new Utilities.Networking.OneToOneNetworkConnection();
            this.historyDisplay = new ChessProjectOOP.PictureListbox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portTextBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChessTableContainer
            // 
            this.ChessTableContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChessTableContainer.Location = new System.Drawing.Point(12, 12);
            this.ChessTableContainer.Name = "ChessTableContainer";
            this.ChessTableContainer.Size = new System.Drawing.Size(500, 500);
            this.ChessTableContainer.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ipField2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.playerNameField);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.portTextBox);
            this.groupBox1.Location = new System.Drawing.Point(679, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 170);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network game settings";
            // 
            // ipField2
            // 
            this.ipField2.Location = new System.Drawing.Point(29, 42);
            this.ipField2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ipField2.Name = "ipField2";
            this.ipField2.Size = new System.Drawing.Size(133, 20);
            this.ipField2.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.colorPreferenceOptionBlack);
            this.groupBox2.Controls.Add(this.colorPreferenceOptionNone);
            this.groupBox2.Controls.Add(this.colorPreferenceOptionWhite);
            this.groupBox2.Location = new System.Drawing.Point(6, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 73);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Color preference";
            // 
            // colorPreferenceOptionBlack
            // 
            this.colorPreferenceOptionBlack.AutoSize = true;
            this.colorPreferenceOptionBlack.Location = new System.Drawing.Point(6, 49);
            this.colorPreferenceOptionBlack.Name = "colorPreferenceOptionBlack";
            this.colorPreferenceOptionBlack.Size = new System.Drawing.Size(52, 17);
            this.colorPreferenceOptionBlack.TabIndex = 13;
            this.colorPreferenceOptionBlack.Text = "Black";
            this.colorPreferenceOptionBlack.UseVisualStyleBackColor = true;
            // 
            // colorPreferenceOptionNone
            // 
            this.colorPreferenceOptionNone.AutoSize = true;
            this.colorPreferenceOptionNone.Checked = true;
            this.colorPreferenceOptionNone.Location = new System.Drawing.Point(6, 15);
            this.colorPreferenceOptionNone.Name = "colorPreferenceOptionNone";
            this.colorPreferenceOptionNone.Size = new System.Drawing.Size(51, 17);
            this.colorPreferenceOptionNone.TabIndex = 11;
            this.colorPreferenceOptionNone.TabStop = true;
            this.colorPreferenceOptionNone.Text = "None";
            this.colorPreferenceOptionNone.UseVisualStyleBackColor = true;
            // 
            // colorPreferenceOptionWhite
            // 
            this.colorPreferenceOptionWhite.AutoSize = true;
            this.colorPreferenceOptionWhite.Location = new System.Drawing.Point(6, 32);
            this.colorPreferenceOptionWhite.Name = "colorPreferenceOptionWhite";
            this.colorPreferenceOptionWhite.Size = new System.Drawing.Size(53, 17);
            this.colorPreferenceOptionWhite.TabIndex = 12;
            this.colorPreferenceOptionWhite.Text = "White";
            this.colorPreferenceOptionWhite.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Name";
            // 
            // playerNameField
            // 
            this.playerNameField.Location = new System.Drawing.Point(50, 16);
            this.playerNameField.MaxLength = 255;
            this.playerNameField.Name = "playerNameField";
            this.playerNameField.Size = new System.Drawing.Size(112, 20);
            this.playerNameField.TabIndex = 7;
            this.playerNameField.Text = "Player";
            this.playerNameField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ip";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(95, 65);
            this.portTextBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portTextBox.Minimum = new decimal(new int[] {
            8888,
            0,
            0,
            0});
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(67, 20);
            this.portTextBox.TabIndex = 3;
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.portTextBox.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.portTextBox.Value = new decimal(new int[] {
            8888,
            0,
            0,
            0});
            // 
            // endGameBtn
            // 
            this.endGameBtn.Enabled = false;
            this.endGameBtn.Location = new System.Drawing.Point(685, 245);
            this.endGameBtn.Name = "endGameBtn";
            this.endGameBtn.Size = new System.Drawing.Size(149, 23);
            this.endGameBtn.TabIndex = 10;
            this.endGameBtn.Text = "End game";
            this.endGameBtn.UseVisualStyleBackColor = true;
            // 
            // joinGameBtn
            // 
            this.joinGameBtn.Location = new System.Drawing.Point(685, 187);
            this.joinGameBtn.Name = "joinGameBtn";
            this.joinGameBtn.Size = new System.Drawing.Size(149, 23);
            this.joinGameBtn.TabIndex = 2;
            this.joinGameBtn.Text = "Join";
            this.joinGameBtn.UseVisualStyleBackColor = true;
            this.joinGameBtn.Click += new System.EventHandler(this.joinGameBtn_Click);
            // 
            // openGameBtn
            // 
            this.openGameBtn.Location = new System.Drawing.Point(685, 216);
            this.openGameBtn.Name = "openGameBtn";
            this.openGameBtn.Size = new System.Drawing.Size(149, 23);
            this.openGameBtn.TabIndex = 1;
            this.openGameBtn.Text = "Open game";
            this.openGameBtn.UseVisualStyleBackColor = true;
            this.openGameBtn.Click += new System.EventHandler(this.openGameBtn_Click);
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(691, 357);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(150, 23);
            this.testBtn.TabIndex = 3;
            this.testBtn.Text = "Press me";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Visible = false;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(720, 334);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(64, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Tick me";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // networkConnection
            // 
            this.networkConnection.IP = "127.0.0.1";
            this.networkConnection.Port = 8888;
            this.networkConnection.StringTerminator = '$';
            this.networkConnection.OnDataRecieved += new Utilities.Networking.OnDataRecievedEventHandler(this.networkConnection_OnDataRecieved);
            // 
            // historyDisplay
            // 
            this.historyDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.historyDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.historyDisplay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.historyDisplay.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyDisplay.FormattingEnabled = true;
            this.historyDisplay.ItemHeight = 70;
            this.historyDisplay.Location = new System.Drawing.Point(518, 12);
            this.historyDisplay.Name = "historyDisplay";
            this.historyDisplay.Size = new System.Drawing.Size(155, 500);
            this.historyDisplay.TabIndex = 0;
            this.historyDisplay.TabStop = false;
            this.historyDisplay.UseTabStops = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 518);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(856, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 540);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.endGameBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ChessTableContainer);
            this.Controls.Add(this.historyDisplay);
            this.Controls.Add(this.joinGameBtn);
            this.Controls.Add(this.openGameBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(98, 94);
            this.Name = "MainWindow";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portTextBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureListbox historyDisplay;
        private System.Windows.Forms.Panel ChessTableContainer;
        private Utilities.Networking.OneToOneNetworkConnection networkConnection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown portTextBox;
        private System.Windows.Forms.Button joinGameBtn;
        private System.Windows.Forms.Button openGameBtn;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox playerNameField;
        private System.Windows.Forms.Button endGameBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton colorPreferenceOptionWhite;
        private System.Windows.Forms.RadioButton colorPreferenceOptionNone;
        private System.Windows.Forms.RadioButton colorPreferenceOptionBlack;
        private System.Windows.Forms.CheckBox checkBox1;
        private Utilities.Controls.IpField ipField2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

