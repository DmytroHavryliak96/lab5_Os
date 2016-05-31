using System.ComponentModel;
using System.Security.Permissions;
using Microsoft.ManagementConsole;
using System.Windows.Forms;
using System.Text;
using System.Configuration;

[assembly: PermissionSetAttribute(SecurityAction.RequestMinimum, Unrestricted = true)]

namespace MyFirstSnapIn
{
    [RunInstaller(true)]
    public class InstallUtilSupport : SnapInInstaller
    {
    }

    [SnapInSettings("{CE255EF6-9E3D-42c8-B725-95CCC761B9D9}",
        DisplayName = "- Changing Registry SnapIn", 
        Description = "This snapin can change the value of key in registry")]
    class Entry : SnapIn
    {
        public Entry()
        {
            this.RootNode = new ScopeNode();
            this.RootNode.DisplayName = "Unknown";

            this.IsModified = true;

            MmcListViewDescription lvd = new MmcListViewDescription();
            lvd.DisplayName = this.RootNode.DisplayName;
            lvd.ViewType = typeof(MyList);
            lvd.Options = MmcListViewOptions.ExcludeScopeNodes;

            this.RootNode.ViewDescriptions.Add(lvd);
            this.RootNode.ViewDescriptions.DefaultIndex = 0;
        }

        protected override bool OnShowInitializationWizard()
        {
            InitializeWizard initializewizard = new InitializeWizard();
            bool result = (initializewizard.ShowDialog() == DialogResult.OK);

            if (result)
            {
                this.RootNode.DisplayName = initializewizard.SelectedSnapInName;
            }

            return result;
        }

        protected override void OnLoadCustomData(AsyncStatus status, byte[] persistenceData)
        {
            if (string.IsNullOrEmpty(Encoding.Unicode.GetString(persistenceData)))
            {
                this.RootNode.DisplayName = "Unknown";
            }
            else
            {
                this.RootNode.DisplayName = Encoding.Unicode.GetString(persistenceData);
            }
        }

        protected override byte[] OnSaveCustomData(SyncStatus status)
        {
            return Encoding.Unicode.GetBytes(this.RootNode.DisplayName);
        }

    }
}


