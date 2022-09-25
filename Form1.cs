using Microsoft.Win32;

namespace Windows_11_Tools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cbRemoveHomeNavPane_CheckedChanged(object sender, EventArgs e)
        {
            var explorer = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer", true);
            if (explorer == null) return;

            if (cbRemoveHomeNavPane.Checked)
            {
                explorer.SetValue("HubMode", 1, RegistryValueKind.DWord);
                explorer.DeleteSubKey(@"Desktop\NameSpace_36354489\{F874310E-B6B7-47DC-BC84-B9E6B38F5903}", false);
            }
            else
            {
                explorer.DeleteValue("HubMode");

                var home = explorer.CreateSubKey(@"Desktop\NameSpace_36354489\{F874310E-B6B7-47DC-BC84-B9E6B38F5903}", true);
                home.SetValue("", "CLSID_MSGraphHomeFolder", RegistryValueKind.String);
            }
        }
    }
}