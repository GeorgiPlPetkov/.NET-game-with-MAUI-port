using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hExDEN.GameWorld.Units
{
    public interface IUnit : IDrawable
    {
        float Cost { get; }
        float MaxHP { get; }
        float CurrentHP { get; }
        float Damage { get; }
        float Defense { get; }
        float Speed { get; }
        float Range { get; }

        List<string> Tags { get; }
        
        public void Attack(Tile target);
        public void MoveTo(Tile tile);
        public void Heal();
        public void Merge(Tile tile);
        public void Promote();
        public void OnDeath();
    }
}
