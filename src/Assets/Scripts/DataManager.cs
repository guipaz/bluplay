using System;
using System.Collections.Generic;
using Proyecto26;
using RSG;
using UnityEngine;

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

    public static void LoadGamesFromFile()
    {
        var file = Resources.Load<TextAsset>("testgames");
        var loadedGames = JsonHelper.ArrayFromJson<BPGame>(file.text);
        games.AddRange(loadedGames);
    }

    public static void SaveGamesToFile()
    {
        //TODO
    }

    public static IPromise<BPGame[]> GetGamesFromCloud()
    {
        return RestClient.GetArray<BPGame>("http://localhost:3000/");
    }

    public static bool ContainsGame(BPGame game)
    {
        foreach (var g in games)
            if (g.uid == game.uid)
                return true;
        return false;
    }
}