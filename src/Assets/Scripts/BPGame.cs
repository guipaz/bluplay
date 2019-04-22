using System;

[Serializable]
public class BPGame
{
    public string uid;
    public string name;

    public string ToJSON()
    {
        return string.Format("{ 'uid': {0}, 'name': {1} }", uid, name);
    }
}
