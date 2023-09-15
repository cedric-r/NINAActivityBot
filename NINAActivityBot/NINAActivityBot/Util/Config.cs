using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NINAActivityBot.Util
{
    public static class Config
    {
        internal static void CreateFolder()
        {
            string strPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            strPath = Path.Combine(strPath, Constants.Name);
            try
            {
                System.IO.Directory.CreateDirectory(strPath);
            }
            catch (Exception e) {
                Logger.Log("Maintenance: Error creating folder: " + e.ToString());
            }
        }

        static Object writeLock = new Object();
        public static void SaveConfig()
        {
            CreateFolder();
            try
            {
                lock (writeLock)
                {
                    string strPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                    strPath = Path.Combine(strPath, Constants.Name);
                    strPath = Path.Combine(strPath, "config.json");
                    System.IO.File.WriteAllText(strPath, JsonConvert.SerializeObject(Parameters.Instance));
                }
            }
            catch (Exception e) {
                Logger.Log("Maintenance: Error writing config: " + e.ToString());
            }
        }

        public static void LoadConfig()
        {
            try
            {
                string strPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                strPath = Path.Combine(strPath, Constants.Name);
                strPath = Path.Combine(strPath, "config.json");
                Parameters.Instance = JsonConvert.DeserializeObject<Parameters>(System.IO.File.ReadAllText(strPath));
            }
            catch (Exception e) 
            {
                Logger.Log("Maintenance: Error loading config: " + e.ToString());

                Parameters.Instance = new Parameters();
            }
        }
    }
}
