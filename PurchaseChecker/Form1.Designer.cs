namespace PurchaseChecker
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
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.CsvFile = new System.Windows.Forms.OpenFileDialog();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TargetShopInfo = new System.Windows.Forms.ListView();
            this.BeginButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.IntervalTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EndButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LastExecutionTime = new System.Windows.Forms.Label();
            this.TargetShopName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OpenLinkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CsvFile
            // 
            this.CsvFile.FileName = "openFileDialog1";
            // 
            // FilePath
            // 
            this.FilePath.Font = new System.Drawing.Font("メイリオ", 13F);
            this.FilePath.Location = new System.Drawing.Point(12, 90);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(860, 33);
            this.FilePath.TabIndex = 0;
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.Font = new System.Drawing.Font("メイリオ", 13F);
            this.LoadFileButton.Location = new System.Drawing.Point(12, 12);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(174, 39);
            this.LoadFileButton.TabIndex = 1;
            this.LoadFileButton.Text = "ファイル選択";
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 10F);
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "選択されたCSVファイル";
            // 
            // TargetShopInfo
            // 
            this.TargetShopInfo.Font = new System.Drawing.Font("メイリオ", 10F);
            this.TargetShopInfo.HideSelection = false;
            this.TargetShopInfo.Location = new System.Drawing.Point(12, 225);
            this.TargetShopInfo.Name = "TargetShopInfo";
            this.TargetShopInfo.Size = new System.Drawing.Size(860, 314);
            this.TargetShopInfo.TabIndex = 3;
            this.TargetShopInfo.UseCompatibleStateImageBehavior = false;
            // 
            // BeginButton
            // 
            this.BeginButton.Font = new System.Drawing.Font("メイリオ", 13F);
            this.BeginButton.Location = new System.Drawing.Point(192, 12);
            this.BeginButton.Name = "BeginButton";
            this.BeginButton.Size = new System.Drawing.Size(174, 39);
            this.BeginButton.TabIndex = 4;
            this.BeginButton.Text = "チェック開始";
            this.BeginButton.UseVisualStyleBackColor = true;
            this.BeginButton.Click += new System.EventHandler(this.BeginButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 10F);
            this.label2.Location = new System.Drawing.Point(8, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "実行間隔";
            // 
            // IntervalTextBox
            // 
            this.IntervalTextBox.Font = new System.Drawing.Font("メイリオ", 13F);
            this.IntervalTextBox.Location = new System.Drawing.Point(12, 170);
            this.IntervalTextBox.Name = "IntervalTextBox";
            this.IntervalTextBox.Size = new System.Drawing.Size(117, 33);
            this.IntervalTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 10F);
            this.label3.Location = new System.Drawing.Point(135, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "秒";
            // 
            // EndButton
            // 
            this.EndButton.Font = new System.Drawing.Font("メイリオ", 13F);
            this.EndButton.Location = new System.Drawing.Point(372, 12);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(174, 39);
            this.EndButton.TabIndex = 8;
            this.EndButton.Text = "チェック終了";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 10F);
            this.label4.Location = new System.Drawing.Point(180, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "最終実行時刻";
            // 
            // LastExecutionTime
            // 
            this.LastExecutionTime.AutoSize = true;
            this.LastExecutionTime.Font = new System.Drawing.Font("メイリオ", 10F);
            this.LastExecutionTime.Location = new System.Drawing.Point(280, 170);
            this.LastExecutionTime.Name = "LastExecutionTime";
            this.LastExecutionTime.Size = new System.Drawing.Size(197, 21);
            this.LastExecutionTime.TabIndex = 10;
            this.LastExecutionTime.Text = "2021/01/01 00:00:00.000";
            // 
            // TargetShopName
            // 
            this.TargetShopName.AutoSize = true;
            this.TargetShopName.Font = new System.Drawing.Font("メイリオ", 10F);
            this.TargetShopName.Location = new System.Drawing.Point(280, 135);
            this.TargetShopName.Name = "TargetShopName";
            this.TargetShopName.Size = new System.Drawing.Size(80, 21);
            this.TargetShopName.TabIndex = 12;
            this.TargetShopName.Text = "お店の名前";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("メイリオ", 10F);
            this.label6.Location = new System.Drawing.Point(180, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "現在の監視先";
            // 
            // OpenLinkButton
            // 
            this.OpenLinkButton.Font = new System.Drawing.Font("メイリオ", 13F);
            this.OpenLinkButton.Location = new System.Drawing.Point(552, 12);
            this.OpenLinkButton.Name = "OpenLinkButton";
            this.OpenLinkButton.Size = new System.Drawing.Size(174, 39);
            this.OpenLinkButton.TabIndex = 13;
            this.OpenLinkButton.Text = "URLを開く";
            this.OpenLinkButton.UseVisualStyleBackColor = true;
            this.OpenLinkButton.Click += new System.EventHandler(this.OpenLinkButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 551);
            this.Controls.Add(this.OpenLinkButton);
            this.Controls.Add(this.TargetShopName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LastExecutionTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IntervalTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BeginButton);
            this.Controls.Add(this.TargetShopInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoadFileButton);
            this.Controls.Add(this.FilePath);
            this.Name = "Form1";
            this.Text = "販売状況監視";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog CsvFile;
        private System.Windows.Forms.TextBox FilePath;
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView TargetShopInfo;
        private System.Windows.Forms.Button BeginButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IntervalTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LastExecutionTime;
        private System.Windows.Forms.Label TargetShopName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button OpenLinkButton;
    }
}

