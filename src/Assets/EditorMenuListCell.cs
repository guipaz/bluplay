using System;
using UnityEngine;

public class EditorMenuListCell : MonoBehaviour
{
    public Action playAction;
    public Action editAction;

    public void PlayButtonClicked()
    {
        playAction?.Invoke();
    }

    public void EditButtonClicked()
    {
        editAction?.Invoke();
    }
}
