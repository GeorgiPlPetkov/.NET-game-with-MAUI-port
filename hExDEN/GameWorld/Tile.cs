using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using hExDEN.GameWorld.Structures;
using hExDEN.GameWorld.Units;

namespace hExDEN.GameWorld
{
    public class Tile : IDrawable
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public IStructure? Sructure { get; set; }
        public IUnit? OccupyingUnit { get; set; }

        public List<string> Tags { get; set; }

        public Vector2 Position { get; private set; }
        public byte[] Image { get; private set; }

        public Tile(string name, string description, List<string> tags, Vector2 position, string path_to_drawable)
        { 
            Name = name;
            Description = description;
            Tags = tags;
            Image = File.ReadAllBytes(path_to_drawable);
            Position = position;
        }

        public static Tile BlankTile(Vector2 position, List<string>? tags) 
        {
            return new Tile(
                "blank_tile",
                "testing or something idk",
                tags ?? null, 
                position,
                @"G:\K3\cyoa2\hExDEN Project\hExDEN\Drawables\Tiles\test_tile.png"
            );
        }
    }
}
