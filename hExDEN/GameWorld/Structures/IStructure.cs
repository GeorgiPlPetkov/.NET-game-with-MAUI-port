using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace hExDEN.GameWorld.Structures
{
    public interface IStructure : IDrawable
    {
        public List<string> Tags { get; set; }
        public string Owner { get; set; }
        
        public void OnBuild(Tile tile);
        public void OnRemove(Tile tile);
    }
}
