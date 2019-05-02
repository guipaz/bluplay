﻿using UnityEngine;
using UnityEngine.UI;

public class EditorMenuController : MenuController
{
    public GameObject contentObject;
    public GameObject gameCellPrefab;

    public override string GetId()
    {
        return "editor";
    }

    public override void Activate()
    {
        base.Activate();

        foreach (var game in DataManager.games)
        {
            var gameCell = Instantiate(gameCellPrefab);
            gameCell.transform.Find("_GameName").GetComponent<Text>().text = game.name;
            gameCell.transform.Find("_GameModel").GetComponent<Text>().text = BPGame.GetModelName(game.model);
            gameCell.transform.SetParent(contentObject.transform);
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();

        foreach (Transform child in contentObject.transform)
            Destroy(child.gameObject);
    }
}
