using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace hExDEN.GameWorld
{
    public interface IDrawable
    {
        public string Name { get; }
        public string Description { get; }
        
        public Vector2 Position { get; }
        public byte[] Image { get; }
    }
}
