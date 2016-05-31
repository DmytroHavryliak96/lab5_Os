using System;
using Microsoft.Win32;
using System.Windows.Forms;

namespace MyFirstSnapIn
{
    public class CnangeRegistry
    {
        public string LocationOfKey { get; set; }
        public string LocationOfBatfile1 { get; set;}
        public string LocationOfBatfile2 { get; set;}
        public string CommonName { get; set; }

        public string GetValueOfKey<T> (string KeyLocation, string NameOfKey, T defaultValue = default(T))
        {
            return Convert.ToString(Registry.GetValue(KeyLocation, NameOfKey, defaultValue));
        }

        public bool SetValueOfKey(string Batfile)
        {
            try
            {
                System.Diagnostics.Process.Start(Batfile);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Batch file failed", MessageBoxButtons.OK);
                return false;
            }
        }

    }
}
