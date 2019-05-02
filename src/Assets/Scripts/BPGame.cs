using System;

public enum GameModel
{
    Memory = 0,
    Crosswords,
    Puzzle,
    Letters
}

[Serializable]
public class BPGame
{
    public string uid;
    public string name;
    public GameModel model;

    public string ToJSON()
    {
        return string.Format("{ 'uid': {0}, 'name': {1}, 'model': {2} }", uid, name, model);
    }

    public static string GetModelName(GameModel model)
    {
        switch (model)
        {
            case GameModel.Crosswords:
                return "Caça-palavras";
            case GameModel.Puzzle:
                return "Quebra-cabeças";
            case GameModel.Letters:
                return "Letras";
            default:
                return "Memória";
        }
    }
}
