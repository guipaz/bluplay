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

        ChangeMenu("start");
        loadingText?.SetActive(false);

        DataManager.LoadGamesFromFile();
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
}
