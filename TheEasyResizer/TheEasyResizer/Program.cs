using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheEasyResizer
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         var cmdLineArgs = Environment.GetCommandLineArgs();
         MessageBox.Show(string.Join(Environment.NewLine, cmdLineArgs));

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new EasyResizerMainForm(cmdLineArgs));
      }
   }
}
