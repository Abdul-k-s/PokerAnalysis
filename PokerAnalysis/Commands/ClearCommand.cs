using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerAnalysis.Commands
{
    public class ClearCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            System.Diagnostics.Process.Start(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            App.Current.Shutdown();
        }
    }
}
