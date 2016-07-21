using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WFAppEnvirSetup.Properties;

namespace WFAppEnvirSetup
{
    public partial class MainForm : Form
    {
        List<string> listDBNames = new List<string>();
        const string sql = "SELECT name FROM sys.databases ";

        public MainForm()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            txtBatchFilePath.Text = Settings.Default.batchPath; //Resources.batchPath;
            txtCurrentDBName.Text = String.Equals(Settings.Default.batchDBName, string.Empty)? 
                                GetDefConfig.GetInitFile(Settings.Default.batchPath): Settings.Default.batchDBName;
            txtBatchFilePath.Enabled = false;

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DBconnect.SetConnection();
            listDBNames = DBconnect.GetData(sql).FindAll(m=>m.Contains("SWSK_YOSAN"));
            cmbDataSourceName.DataSource = listDBNames;
        }

        private void btnBatchSet_Click(object sender, EventArgs e)
        {
            string path = txtBatchFilePath.Text;

            if (!GetDefConfig.GetConfigPath(FileType.Batch, ref path))
            {
                MessageBox.Show(String.Format("Please make sure the {0} path is exist?", path));
                txtBatchFilePath.Enabled = true;
                
                return;
            }
            else 
            {
                txtBatchFilePath.Enabled = false;
                if (GetDefConfig.SetConfigFile(FileType.Batch, path, cmbDataSourceName.SelectedValue.ToString()) == string.Empty)
                {
                    MessageBox.Show(String.Format("Please make sure the {0} path is exist?", path));
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //var rset = Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            //Resources.batchPath = txtBatchFilePath.Text;
            Settings.Default.batchPath = txtBatchFilePath.Text;
            Settings.Default.batchDBName = txtCurrentDBName.Text;
            Settings.Default.Save();

        }

        private void txtBatchFilePath_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
