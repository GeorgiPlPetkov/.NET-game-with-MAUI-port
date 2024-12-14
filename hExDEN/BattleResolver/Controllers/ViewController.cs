using hExDEN.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace hExDEN.BattleResolver.Controllers
{
    // might get disappeared soon
    internal class ViewController : IController
    {
        public bool Select(Tile selected_tile)
        {
            return true;
        }
        public void ExecuteInteraction(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public Vector2 ListInteractions()
        {
            throw new NotImplementedException();
        }
    }
}
