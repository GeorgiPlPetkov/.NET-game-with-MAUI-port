using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipClone.Game
{
    enum EnemyStates { 
        FirstShot = 0,
        NoTarget = 1,
        YesTarget = 2,
    }
    public class Enemy
    {
        private int difficulty = -1;
        private List<int> hit_memory;
        //private EnemyStates enemy_state;

        public Enemy() { 
            //enemy_state = EnemyStates.NoTarget;
            hit_memory = [];
        }
        public void SetDificulty(int difficulty) { 
            if (difficulty < 1) difficulty = 1;
            if (difficulty > 3) difficulty = 3;

            this.difficulty = difficulty;
           
        }

        public (int, int) MakeMove() {
            int target_x = -1, target_y = -1;
            
            Random rng = new();
            target_x = rng.Next(0, 8);
            target_y = rng.Next(0, 8);

            //Remember(target_x, target_x);
            return (target_x, target_y);
        }

        public void ReadBoard(BitArray[] shot_map) { 
        
        }

        private void Remember(int last_x, int last_y) {
            hit_memory.Add(last_x); hit_memory.Add(last_y);

            if(hit_memory.Count >= difficulty * 2)
                hit_memory.RemoveRange(hit_memory.Count, hit_memory.Count - 1);
        }
    }
}
