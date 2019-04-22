using Assets.Scripts.Menu;
using System.Collections.Generic;
using UnityEngine;

public class MenuMaster : MonoBehaviour
{
    public List<MenuController> controllers;

    void Start()
    {
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
}
