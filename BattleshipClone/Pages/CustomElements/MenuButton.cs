using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipClone.Pages.CustomElements
{
    internal partial class MenuButton : Button
    {
        public MenuButton() : base() {
            BackgroundColor = Color.FromRgba(150, 200, 20, .5);
            
            CornerRadius = 10;
            Margin = 10;
        }
    }
}
