namespace NetworkSwitcher
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.NumericUpDown thresholdNumeric;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.NumericUpDown intervalNumeric;
        private System.Windows.Forms.Label failuresLabel;
        private System.Windows.Forms.NumericUpDown failuresNumeric;
        private System.Windows.Forms.Label ethernetLabel;
        private System.Windows.Forms.ComboBox ethernetComboBox;
        private System.Windows.Forms.Label wifiLabel;
        private System.Windows.Forms.ComboBox wifiComboBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox statusTextBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.serverLabel = new System.Windows.Forms.Label();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.thresholdNumeric = new System.Windows.Forms.NumericUpDown();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.intervalNumeric = new System.Windows.Forms.NumericUpDown();
            this.failuresLabel = new System.Windows.Forms.Label();
            this.failuresNumeric = new System.Windows.Forms.NumericUpDown();
            this.ethernetLabel = new System.Windows.Forms.Label();
            this.ethernetComboBox = new System.Windows.Forms.ComboBox();
            this.wifiLabel = new System.Windows.Forms.Label();
            this.wifiComboBox = new System.Windows.Forms.ComboBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.failuresNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Location = new System.Drawing.Point(12, 20);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(91, 20);
            this.serverLabel.TabIndex = 0;
            this.serverLabel.Text = "Game Server Address:";
            // 
            // serverTextBox
            // 
            this.serverTextBox.Location = new System.Drawing.Point(109, 17);
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(200, 27);
            this.serverTextBox.TabIndex = 1;
            this.serverTextBox.Text = "8.8.8.8";
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Location = new System.Drawing.Point(12, 60);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(103, 20);
            this.thresholdLabel.TabIndex = 2;
            this.thresholdLabel.Text = "Ping Threshold (ms):";
            // 
            // thresholdNumeric
            // 
            this.thresholdNumeric.Location = new System.Drawing.Point(121, 57);
            this.thresholdNumeric.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.thresholdNumeric.Name = "thresholdNumeric";
            this.thresholdNumeric.Size = new System.Drawing.Size(120, 27);
            this.thresholdNumeric.TabIndex = 3;
            this.thresholdNumeric.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(12, 100);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(93, 20);
            this.intervalLabel.TabIndex = 4;
            this.intervalLabel.Text = "Check Interval (s):";
            // 
            // intervalNumeric
            // 
            this.intervalNumeric.Location = new System.Drawing.Point(121, 97);
            this.intervalNumeric.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.intervalNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.intervalNumeric.Name = "intervalNumeric";
            this.intervalNumeric.Size = new System.Drawing.Size(120, 27);
            this.intervalNumeric.TabIndex = 5;
            this.intervalNumeric.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // failuresLabel
            // 
            this.failuresLabel.AutoSize = true;
            this.failuresLabel.Location = new System.Drawing.Point(12, 140);
            this.failuresLabel.Name = "failuresLabel";
            this.failuresLabel.Size = new System.Drawing.Size(80, 20);
            this.failuresLabel.TabIndex = 6;
            this.failuresLabel.Text = "Maximum Bad Pings Untill Switch:";
            // 
            // failuresNumeric
            // 
            this.failuresNumeric.Location = new System.Drawing.Point(121, 137);
            this.failuresNumeric.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.failuresNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.failuresNumeric.Name = "failuresNumeric";
            this.failuresNumeric.Size = new System.Drawing.Size(120, 27);
            this.failuresNumeric.TabIndex = 7;
            this.failuresNumeric.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // ethernetLabel
            // 
            this.ethernetLabel.AutoSize = true;
            this.ethernetLabel.Location = new System.Drawing.Point(12, 180);
            this.ethernetLabel.Name = "ethernetLabel";
            this.ethernetLabel.Size = new System.Drawing.Size(97, 20);
            this.ethernetLabel.TabIndex = 8;
            this.ethernetLabel.Text = "Ethernet Adapter:";
            // 
            // ethernetComboBox
            // 
            this.ethernetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ethernetComboBox.FormattingEnabled = true;
            this.ethernetComboBox.Location = new System.Drawing.Point(115, 177);
            this.ethernetComboBox.Name = "ethernetComboBox";
            this.ethernetComboBox.Size = new System.Drawing.Size(200, 28);
            this.ethernetComboBox.TabIndex = 9;
            // 
            // wifiLabel
            // 
            this.wifiLabel.AutoSize = true;
            this.wifiLabel.Location = new System.Drawing.Point(12, 220);
            this.wifiLabel.Name = "wifiLabel";
            this.wifiLabel.Size = new System.Drawing.Size(74, 20);
            this.wifiLabel.TabIndex = 10;
            this.wifiLabel.Text = "Wi-Fi Adapter:";
            // 
            // wifiComboBox
            // 
            this.wifiComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wifiComboBox.FormattingEnabled = true;
            this.wifiComboBox.Location = new System.Drawing.Point(115, 217);
            this.wifiComboBox.Name = "wifiComboBox";
            this.wifiComboBox.Size = new System.Drawing.Size(200, 28);
            this.wifiComboBox.TabIndex = 11;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 260);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 34);
            this.startButton.TabIndex = 12;
            this.startButton.Text = "Start Service";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(168, 260);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(150, 34);
            this.stopButton.TabIndex = 13;
            this.stopButton.Text = "Stop Service";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(12, 300);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusTextBox.Size = new System.Drawing.Size(376, 100);
            this.statusTextBox.TabIndex = 14;
            this.statusTextBox.Text = "Status: Idle";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 420);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.wifiComboBox);
            this.Controls.Add(this.wifiLabel);
            this.Controls.Add(this.ethernetComboBox);
            this.Controls.Add(this.ethernetLabel);
            this.Controls.Add(this.failuresNumeric);
            this.Controls.Add(this.failuresLabel);
            this.Controls.Add(this.intervalNumeric);
            this.Controls.Add(this.intervalLabel);
            this.Controls.Add(this.thresholdNumeric);
            this.Controls.Add(this.thresholdLabel);
            this.Controls.Add(this.serverTextBox);
            this.Controls.Add(this.serverLabel);
            this.Name = "Form1";
            this.Text = "NetPulse";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.failuresNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}