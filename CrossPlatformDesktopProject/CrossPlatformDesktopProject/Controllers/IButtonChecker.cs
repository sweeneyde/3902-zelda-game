using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject
{
    public interface IButtonChecker
    {
        ISet<ButtonKind> GetPressedButtons();
    }
}
