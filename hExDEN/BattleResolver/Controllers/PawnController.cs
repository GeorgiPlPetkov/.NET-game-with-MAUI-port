using hExDEN.GameWorld.Units;
using hExDEN.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace hExDEN.BattleResolver.Controllers
{
    internal class PawnController : IController
    {
        private IUnit? unit;
        private bool hasUnit = false;
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
            hasUnit = selected_tile.OccupyingUnit != null;

            if (!hasUnit)
                return hasUnit;

            unit = selected_tile.OccupyingUnit;

            return hasUnit;
        }
    }
}
