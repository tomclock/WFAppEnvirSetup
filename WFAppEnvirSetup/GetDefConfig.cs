using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace WFAppEnvirSetup
{
    public enum FileType
    {
        Batch,
        EDI,
        Web
    }


    public static class GetDefConfig
    {
        const string batchpath = @"C:\WORKBATCH\BatchLibrary\Bin\Conf\Common.ini";
        const string edipath = @"C:\WORKEDI\SWSK.EDI\bin\Release\Conf\Common.ini";
        const string webpath = @"C:\WORK\SWSK\SWSK_Frame\SWSK_Frame\WebSite\Conf\DB.xml";

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
                                                        string lpApplicationName,
                                                        string lpKeyName,
                                                        string lpDefault,
                                                        System.Text.StringBuilder lpReturnedstring,
                                                        int nSize,
                                                        string lpFileName);

        public static bool GetConfigPath(FileType type, ref string path)
        {
            if(path == string.Empty)
                switch (type)
                {
                    case FileType.Batch:
                        path = batchpath;
                        break;
                    case FileType.EDI:
                        path = edipath;
                        break;
                    case FileType.Web:
                        path = webpath;
                        break;

                }
            return File.Exists(path);

        }

        public static string SetConfigFile(FileType type, string path, string startDBName, string desDBName)
        {
            string errorMsg = string.Empty;
            switch (type)
            {
                case FileType.Batch:
                    errorMsg = WriteInitFile(path, startDBName, desDBName);
                    break;
                case FileType.EDI:
                    errorMsg = WriteInitFile(path, startDBName, desDBName);
                    break;
                case FileType.Web:
                    errorMsg = WritetXmlFile(path, startDBName, desDBName);
                    break;
            }
            return errorMsg;
        }


        public static string GetInitFile(string path)
        {
            try
            {
                StringBuilder iniDBName = new StringBuilder(1024);
                string section = "DataBase";
                string key = "DATABASE_NAME";

                GetPrivateProfileString(
                        section,                        // セクション名
                        key,                            // キー名    
                        "",                             // 値が取得できなかった場合に返される初期値
                        iniDBName,                             // 格納先
                        (iniDBName.Capacity),  // 格納先のキャパ
                        path);                   // iniファイル名

                return iniDBName.ToString();

            }
            catch (Exception ex)
            {
                return  ex.ToString();
            }
        }

        public static string GetXmlFile(string path)
        {
            try
            {
                StringBuilder iniDBName = new StringBuilder(1024);
                string section = "DataBase";
                string key = "DATABASE_NAME";


                return iniDBName.ToString();

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        private static string WriteInitFile(string path, string startDBName, string desDBName)
        {
            try
            {
                List<string> listData = new List<string>();
                //read
                using (StreamReader fs = new StreamReader(path, Encoding.Default))
                {
                    while (fs.Peek() > 0)
                    { 
                        string buff = fs.ReadLine();
                        buff = buff.Contains(startDBName) ?
                                     buff.Contains("DATABASE_NAME") ? buff.Replace(startDBName, desDBName) : buff
                                     : buff;
                        listData.Add(buff);
                    }
                    fs.Close();  
                }
                string tempTime = DateTime.Now.ToString();
                File.Copy(path, path + tempTime);
                if(File.Exists(path + tempTime))
                {
                    File.Delete(path);
                }
                
                //write
                using (StreamWriter fs = new StreamWriter(path))
                {
                    foreach (var value in listData)
                    {
                        fs.WriteLine(value);
                    }
                    fs.Flush();
                    fs.Close();
                }
                    return "";

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        private static string WritetXmlFile(string path, string startDBName, string desDBName)
        {
            try
            {



            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return string.Empty;
        }
    }
}