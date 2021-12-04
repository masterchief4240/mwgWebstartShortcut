using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mwgWebstartShortcut
{
    public partial class mwgWebstartShortcut : Form
    {
        public mwgWebstartShortcut()
        {
            InitializeComponent();
        }

        string mwgIP;
        string _filePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

        private void startButton_Click(object sender, EventArgs e)
        {
            mwgIP = textBoxIP.Text;
            string[] createText = { "<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "<jnlp spec=\"1.0 + \" codebase=\"http://" + mwgIP + ":4711/Konfigurator/\" href=\"webstart.jnlp\">", "	<information>", "		<title>McAfee Web Gateway</title>", "		<vendor>McAfee</vendor>", "		<icon href=\"images/icon.png\"/>", "		<icon href=\"images/icon.png\" kind=\"shortcut\" />", "		<description>Management interface of McAfee Web Gateway</description>", "		<description kind=\"short\">McAfee Web Gateway", "		</description>", "		<shortcut online=\"true\" install=\"true\">", "			<desktop />", "			<menu submenu=\"McAfee\">", "				<menu submenu=\"McAfee Web Gateway\" />", "			</menu>", "		</shortcut>", "	</information>", "	<resources>", "	 <property name=\"jnlp.packEnabled\" value=\"true\"/>", "	 <j2se version=\"1.9+\" java-vm-args=\"--add-exports=java.desktop/com.sun.java.swing.plaf.windows=ALL-UNNAMED --add-modules=java.se.ee --add-modules=java.xml.bind  --add-opens=java.base/java.util=ALL-UNNAMED --add-opens=java.base/java.lang.reflect=ALL-UNNAMED --add-opens=java.base/java.text=ALL-UNNAMED --add-opens=java.desktop/java.awt.font=ALL-UNNAMED\"/>", "	 <j2se version=\"1.7+\" />", "	 <jar href=\"jar/webstart.jar\" download=\"eager\" main=\"true\"/>", "	</resources>", "	<application-desc main-class=\"com.scur.k.Application\"/>", "	<security>", "		<all-permissions />", "	</security>", "</jnlp>" };
            File.WriteAllLines(Path.Combine(_filePath, "webstart.jnlp"), createText, Encoding.UTF8);

            //System.Diagnostics.Process.Start(Path.Combine(_filePath, "webstart.jnlp"));
            //strCmdText = "javaws " + Path.Combine(_filePath, "webstart.jnlp");
            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            //MessageBox.Show("javaws " + Path.Combine(_filePath, "webstart.jnlp"));

            Process myProcess = new Process();
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = "/c " + ("javaws " + Path.Combine(_filePath, "webstart.jnlp"));
            myProcess.EnableRaisingEvents = true;
            myProcess.Start();
            myProcess.WaitForExit();



        }
    }
}
