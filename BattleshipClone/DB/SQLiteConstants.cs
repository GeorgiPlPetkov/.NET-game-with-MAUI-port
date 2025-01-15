using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipClone.DB
{
    internal static class SQLiteConstants
    {
        public const string DatabaseFilename = "battleship.db";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            "C:\\Users\\white\\Desktop\\idling\\.NET-game-with-MAUI-port\\BattleshipClone\\DB\\battleship.db";
    }
}
