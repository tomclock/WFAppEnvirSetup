namespace WFAppEnvirSetup
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabDB = new System.Windows.Forms.TabPage();
            this.btnBatchSet = new System.Windows.Forms.Button();
            this.cmbDataSourceName = new System.Windows.Forms.ComboBox();
            this.txtBatchFilePath = new System.Windows.Forms.TextBox();
            this.lblBatch = new System.Windows.Forms.Label();
            this.tabUnDefine = new System.Windows.Forms.TabPage();
            this.bindSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtCurrentDBName = new System.Windows.Forms.TextBox();
            this.tabMain.SuspendLayout();
            this.tabDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabDB);
            this.tabMain.Controls.Add(this.tabUnDefine);
            this.tabMain.Location = new System.Drawing.Point(-1, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1047, 426);
            this.tabMain.TabIndex = 0;
            // 
            // tabDB
            // 
            this.tabDB.Controls.Add(this.txtCurrentDBName);
            this.tabDB.Controls.Add(this.lblCurrent);
            this.tabDB.Controls.Add(this.btnBatchSet);
            this.tabDB.Controls.Add(this.cmbDataSourceName);
            this.tabDB.Controls.Add(this.txtBatchFilePath);
            this.tabDB.Controls.Add(this.lblBatch);
            this.tabDB.Location = new System.Drawing.Point(4, 22);
            this.tabDB.Name = "tabDB";
            this.tabDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabDB.Size = new System.Drawing.Size(1039, 400);
            this.tabDB.TabIndex = 0;
            this.tabDB.Text = "DB Setup";
            this.tabDB.UseVisualStyleBackColor = true;
            // 
            // btnBatchSet
            // 
            this.btnBatchSet.Location = new System.Drawing.Point(928, 23);
            this.btnBatchSet.Name = "btnBatchSet";
            this.btnBatchSet.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSet.TabIndex = 3;
            this.btnBatchSet.Text = "Set";
            this.btnBatchSet.UseVisualStyleBackColor = true;
            this.btnBatchSet.Click += new System.EventHandler(this.btnBatchSet_Click);
            // 
            // cmbDataSourceName
            // 
            this.cmbDataSourceName.FormattingEnabled = true;
            this.cmbDataSourceName.Location = new System.Drawing.Point(742, 26);
            this.cmbDataSourceName.Name = "cmbDataSourceName";
            this.cmbDataSourceName.Size = new System.Drawing.Size(180, 20);
            this.cmbDataSourceName.TabIndex = 2;
            // 
            // txtBatchFilePath
            // 
            this.txtBatchFilePath.Location = new System.Drawing.Point(96, 27);
            this.txtBatchFilePath.Multiline = true;
            this.txtBatchFilePath.Name = "txtBatchFilePath";
            this.txtBatchFilePath.Size = new System.Drawing.Size(406, 42);
            this.txtBatchFilePath.TabIndex = 1;
            this.txtBatchFilePath.DoubleClick += new System.EventHandler(this.txtBatchFilePath_DoubleClick);
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Location = new System.Drawing.Point(18, 30);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(58, 12);
            this.lblBatch.TabIndex = 0;
            this.lblBatch.Text = "Batch Env";
            // 
            // tabUnDefine
            // 
            this.tabUnDefine.Location = new System.Drawing.Point(4, 22);
            this.tabUnDefine.Name = "tabUnDefine";
            this.tabUnDefine.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnDefine.Size = new System.Drawing.Size(653, 361);
            this.tabUnDefine.TabIndex = 1;
            this.tabUnDefine.Text = "Undefine";
            this.tabUnDefine.UseVisualStyleBackColor = true;
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(523, 27);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(130, 12);
            this.lblCurrent.TabIndex = 4;
            this.lblCurrent.Text = "Current DataBase Name";
            // 
            // txtCurrentDBName
            // 
            this.txtCurrentDBName.Location = new System.Drawing.Point(525, 49);
            this.txtCurrentDBName.Name = "txtCurrentDBName";
            this.txtCurrentDBName.Size = new System.Drawing.Size(153, 19);
            this.txtCurrentDBName.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 505);
            this.Controls.Add(this.tabMain);
            this.Name = "MainForm";
            this.Text = "Smart Environment Setup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabMain.ResumeLayout(false);
            this.tabDB.ResumeLayout(false);
            this.tabDB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabDB;
        private System.Windows.Forms.TabPage tabUnDefine;
        private System.Windows.Forms.Button btnBatchSet;
        private System.Windows.Forms.ComboBox cmbDataSourceName;
        private System.Windows.Forms.TextBox txtBatchFilePath;
        private System.Windows.Forms.Label lblBatch;
        private System.Windows.Forms.BindingSource bindSource;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.TextBox txtCurrentDBName;
    }
}

