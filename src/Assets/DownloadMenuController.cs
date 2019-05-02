using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadMenuController : MenuController
{
    public GameObject contentObject;
    public GameObject gameCellPrefab;

    public override string GetId()
    {
        return "download";
    }
    
    public override void Activate()
    {
        base.Activate();

        DataManager.GetGamesFromCloud().Then((games) =>
        {
            foreach (var game in games)
            {
                var gameCell = Instantiate(gameCellPrefab);
                gameCell.transform.Find("_GameName").GetComponent<Text>().text = game.name;
                gameCell.transform.Find("_GameModel").GetComponent<Text>().text = BPGame.GetModelName(game.model);
                gameCell.transform.SetParent(contentObject.transform);

                var containsGame = DataManager.ContainsGame(game);
                gameCell.transform.Find("_DownloadButton").gameObject.SetActive(!containsGame);
                gameCell.transform.Find("_DeleteButton").gameObject.SetActive(containsGame);
            }
        });
    }

    public override void Deactivate()
    {
        base.Deactivate();

        foreach (Transform child in contentObject.transform)
            Destroy(child.gameObject);
    }
}
