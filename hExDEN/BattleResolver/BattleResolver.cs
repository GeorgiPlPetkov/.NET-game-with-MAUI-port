using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hExDEN.BattleResolver.Controllers;
using hExDEN.GameWorld;

namespace hExDEN.BattleResolver
{
    public class BattleResolver
    {
        public World GameWorld { get; private set; }
        public Tile SelectedTile { get; private set; }
        public int CurrentTurn { get; private set; }

        private PawnController pawn_controller;

        public BattleResolver() {
            GameWorld = World.GenerateWorld(3, 3);

            
        }

      
    }

    internal enum ControllerModes
    {
        View = 0,
        PawnControl = 1,
        Build = 2,
        Destroy = 3
    }


}
