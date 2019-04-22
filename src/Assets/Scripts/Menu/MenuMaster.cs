using Assets.Scripts;
using Assets.Scripts.Menu;
using Proyecto26;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MenuMaster : MonoBehaviour
{
    public List<MenuController> controllers;

    void Start()
    {
        ChangeMenu("start");
        ExecuteRequest();
    }

    public void ChangeMenu(string controllerId)
    {
        Debug.Log(controllerId);
        foreach (var controller in controllers)
        {
            if (controller.GetId() == controllerId)
                controller.Activate();
            else
                controller.Deactivate();
        }
    }

    private void ExecuteRequest()
    {
        Debug.Log("executing request");
        RestClient.GetArray<BPGame>("http://localhost:3000/").Then(
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
