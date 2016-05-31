using System;
using System.Text;
using Microsoft.ManagementConsole;
using System.Windows.Forms;

namespace MyFirstSnapIn
{
    class MyList : MmcListView
    {
        CnangeRegistry reg = new CnangeRegistry()
        {
            LocationOfKey=@"HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics",
            LocationOfBatfile1 = @"D:\batRegistry1.bat",
            LocationOfBatfile2 = @"D:\batRegistry2.bat",
            CommonName = "MinAnimate"
        };

        

        public MyList()
        {

        }

        protected override void OnInitialize(AsyncStatus status)
        {
            base.OnInitialize(status);

            this.Columns[0].Title = "Name of the registry key";
            this.Columns[0].SetWidth(250);

            this.Columns.Add(new MmcListViewColumn("Current value", 150));

            this.Mode = MmcListViewMode.Report;

            this.SelectionData.EnabledStandardVerbs = StandardVerbs.Refresh;

            Refresh();
        }

        protected override void OnSelectionChanged(SyncStatus status)
        {
            if (this.SelectedNodes.Count == 0)
            {
                this.SelectionData.Clear();
            }
            else
            {
                this.SelectionData.Update(GetSelectedKeyNames(), this.SelectedNodes.Count > 1, null, null);
                this.SelectionData.ActionsPaneItems.Clear();
                this.SelectionData.ActionsPaneItems.Add(new Microsoft.ManagementConsole.Action("Cnange", "Change the keyvalue of the registry", -1, "Change"));
                this.SelectionData.ActionsPaneItems.Add(new Microsoft.ManagementConsole.Action("Restore", "Restore the previous keyvalue of the registry", -1, "Restore"));
                this.SelectionData.ActionsPaneItems.Add(new Microsoft.ManagementConsole.Action("ShowSelected", "Shows list of selected KeyNames", -1, "ShowSelected"));
            }
        }

        protected override void OnRefresh(AsyncStatus status)
        {
            Refresh();
        }

        protected override void OnSelectionAction(Microsoft.ManagementConsole.Action action, AsyncStatus status)
        {
            switch ((string)action.Tag)
            {
                case "Change":
                    {
                        Change();
                        break;
                    }
                case "Restore":
                    {
                        Restore();
                        break;
                    }
                case "ShowSelected":
                    {
                        ShowSelected();
                        break;
                    }
            }
        }

        private void Change()
        {
            if (!reg.SetValueOfKey(reg.LocationOfBatfile1))
            {
                throw new Exception("Setting value error");
            }
        }

        private void Restore()
        {
            if (!reg.SetValueOfKey(reg.LocationOfBatfile2))
            {
                throw new Exception("Setting value error");
            }
        }

        private void ShowSelected()
        {
            MessageBox.Show("Selected KeyNames: \n" + GetSelectedKeyNames());
        }

        private string GetSelectedKeyNames()
        {
            StringBuilder selectedKeyNames = new StringBuilder();

            foreach (ResultNode snappinnode in this.SelectedNodes)
            {
                selectedKeyNames.Append(snappinnode.DisplayName + "\n");
            }

            return selectedKeyNames.ToString();
        }

        public void Refresh()
        {
            this.ResultNodes.Clear();
            string[][] snapinvalues = { new string[] { reg.CommonName, reg.GetValueOfKey<int>(reg.LocationOfKey, reg.CommonName, 1) } };

            foreach (string[] iterator in snapinvalues)
            {
                ResultNode snapinnode = new ResultNode();
                snapinnode.DisplayName = iterator[0];
                snapinnode.SubItemDisplayNames.Add(iterator[1]);

                this.ResultNodes.Add(snapinnode);

            }
        }
    }
}
