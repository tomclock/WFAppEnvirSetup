using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using WFAppEnvirSetup.Properties;

namespace WFAppEnvirSetup
{
    public partial class MainForm : Form
    {
        List<string> listDBNames = new List<string>();
        const string sql = "SELECT name FROM sys.databases ";

        private string batchPath
        {
            get
            {
                if (Directory.Exists(Settings.Default.batchPath))
                    return Settings.Default.batchPath;
                else
                {
                    //"@\"C:\\WORKBATCH\\BatchLibrary\\Bin\\Conf\\Common.ini\""
                    return PathCovert(Settings.Default.batchPath);
                }
            }
            set
            {
                Settings.Default.batchPath = value;
            }
        }

        private string PathCovert(string path)
        {
            string buff = path.Remove(0, 2);
            buff = buff.Remove(buff.Length - 1, 1);
            return buff;
        }

        public MainForm()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            txtBatchFilePath.Text = Settings.Default.batchPath; //Resources.batchPath;
            txtCurrentDBName.Text = String.Equals(Settings.Default.batchDBName, string.Empty)? 
                                GetDefConfig.GetInitFile(batchPath) : Settings.Default.batchDBName;
            txtCurrentDBName.Enabled = false;
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
            if (cmbDataSourceName.SelectedValue.ToString() == string.Empty)
            {
                return;
            }
            string path = PathCovert( txtBatchFilePath.Text);

            if (!GetDefConfig.GetConfigPath(FileType.Batch, ref path))
            {
                MessageBox.Show(String.Format("Please make sure the {0} path is exist?", path));
                txtBatchFilePath.Enabled = true;
                
                return;
            }
            else 
            {
                if (GetDefConfig.SetConfigFile(FileType.Batch, path, txtCurrentDBName.Text, cmbDataSourceName.SelectedValue.ToString()) != string.Empty)
                {
                    MessageBox.Show(String.Format("Please make sure the {0} path is exist?", path));
                }
                txtCurrentDBName.Text = GetDefConfig.GetInitFile(batchPath);
                txtBatchFilePath.Enabled = false;
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
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = "*ini|*.xml";
                fd.InitialDirectory = "C:\\";
                fd.RestoreDirectory = true;
                fd.Title = "Please choose the proper configure file";
                fd.CheckFileExists = true;
                fd.CheckPathExists = true;
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    txtBatchFilePath.Text = fd.FileName; //fd.SafeFileName;
                    txtBatchFilePath.Enabled = false;
                }
            }
        }
    }
}
