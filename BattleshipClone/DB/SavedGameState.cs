using SQLite;

namespace BattleshipClone.DB
{
    [Table("save_game_state")]
    public class SavedGameState
    {
        [PrimaryKey, AutoIncrement, Column("game_id")]
        public int StateId { get; set; }

        [Column("name")]
        public string Name { get; set; }
        [Column("turn_number")]
        public int TurnNumber { get; set; }

        [Column("player_shots_map")]
        public byte[] PlayerShots { get; set; }
        [Column("enemy_shots_map")]
        public byte[] EnemyShots { get; set; }
    }
}
