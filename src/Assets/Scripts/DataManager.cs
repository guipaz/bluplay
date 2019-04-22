using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class DataManager
    {
        public static List<BPGame> games { get; private set; }

        static DataManager()
        {
            games = new List<BPGame>();
        }
        
        public static void AddGame(BPGame game)
        {
            games.Add(game);
        }
    }
}
