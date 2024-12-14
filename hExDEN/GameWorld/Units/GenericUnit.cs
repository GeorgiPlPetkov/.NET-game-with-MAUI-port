using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace hExDEN.GameWorld.Units
{
    internal class GenericUnit : IUnit
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public float MaxHP { get; private set; }
        public float CurrentHP { get; private set; }
        public float Damage { get; private set; }
        public float Defense { get; private set; }
        public float Speed { get; private set; }
        public float Range { get; private set; }

        public float Cost { get; private set; }
        
        public List<string> Tags { get; private set; }

        public Vector2 Position { get; private set; }
        public byte[] Image { get; private set; }

        public void Attack(Tile target)
        {
            throw new NotImplementedException();
        }

        public void Heal()
        {
            throw new NotImplementedException();
        }

        public void Merge(Tile tile)
        {
            throw new NotImplementedException();
        }

        public void MoveTo(Tile tile)
        {
            throw new NotImplementedException();
        }

        public void OnDeath()
        {
            throw new NotImplementedException();
        }

        public void Promote()
        {
            CurrentHP = MaxHP;
            Damage += Damage * 1.2f;
            Defense += Defense * 1.2f;
            Speed += 1;
        }
    }
}
