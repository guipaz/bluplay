using Proyecto26;
using RSG;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MenuMaster : MonoBehaviour
{
    public static MenuMaster _instance;

    public static MenuMaster Instance
    {
        get
        {
            if (_instance == null)
                _instance = new MenuMaster();
            return _instance;
        }
    }

    public List<MenuController> controllers;
    public GameObject loadingText;

    void Start()
    {
        _instance = this;

        loadingText?.SetActive(true);
        LoadGames().Then(() =>
        {
            ChangeMenu("start");
            loadingText?.SetActive(false);
        });
    }

    public void ChangeMenu(string controllerId)
    {
        foreach (var controller in controllers)
        {
            if (controller.GetId() == controllerId)
                controller.Activate();
            else
                controller.Deactivate();
        }
    }

    private IPromise LoadGames()
    {
        Debug.Log("executing request");
        return RestClient.GetArray<BPGame>("http://localhost:3000/").Then(
            res =>
            {
                try
                {
                    foreach (var game in res)
                    {
                        Debug.Log(game);
                        DataManager.AddGame(game);
                    }
                } catch (Exception e)
                {
                    Debug.Log(e);
                }
                
            });
    }
}
