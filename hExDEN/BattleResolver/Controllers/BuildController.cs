using hExDEN.GameWorld.Structures;
using hExDEN.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace hExDEN.BattleResolver.Controllers
{
    public class BuildController : IController
    {
        private IStructure? structure;
        private bool hasStructure = false;
        public void ExecuteInteraction(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public Vector2 ListInteractions()
        {
            throw new NotImplementedException();
        }

        public bool Select(Tile selected_tile)
        {
            hasStructure = selected_tile.Sructure != null;

            if (!hasStructure)
                return hasStructure;

            structure = selected_tile.Sructure;

            return hasStructure;
        }
    }
}
