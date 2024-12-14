using hExDEN.GameWorld;
using hExDEN.GameWorld.Structures;
using hExDEN.GameWorld.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace hExDEN.BattleResolver.Controllers
{
    internal interface IController
    {
        public bool Select(Tile selected_tile);
        public Vector2 ListInteractions();
        public void ExecuteInteraction(Vector2 position);
    }

    public struct TargetDetails
    {
        public string TargetName { get; private set; }
        public string TargetDescription { get; private set; }
        

        public TargetDetails(string name, string description) 
        {
            TargetName = name;
            TargetDescription = description;
        }

        public TargetDetails(IDrawable target) {
            TargetName = target.Name;
            TargetDescription = target.Description;
        }
    }
}
