using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NewGameMenuController : MenuController
{
    private InputField nameField;
    private ToggleGroup toggleGroup;

    public override string GetId()
    {
        return "newgame";
    }

    public override void Activate()
    {
        base.Activate();

        ClearFields();
    }

    public void Awake()
    {
        nameField = transform.Find("_GameNameField").gameObject.GetComponent<InputField>();
        toggleGroup = transform.Find("_ToggleGroup").gameObject.GetComponent<ToggleGroup>();
    }

    private void ClearFields()
    {
        nameField.text = "";
    }

    public void NewGameClicked()
    {
        if (String.IsNullOrEmpty(nameField.text) ||
            !toggleGroup.AnyTogglesOn())
            return;

        var activeToggle = toggleGroup.ActiveToggles().First();

        BPGame game;
        var model = GetGameModel(activeToggle.gameObject.name);
        if (model == GameModel.Puzzle)
        {
            game = new PuzzleGame();
        } else
        {
            game = new BPGame();
        }

        game.name = nameField.text.Trim();
        game.model = model;

        DataManager.AddGame(game);
        MenuMaster.Instance.ChangeMenu("editor");
    }

    private GameModel GetGameModel(string objectName)
    {
        if (objectName == "_MemoryToggle")
            return GameModel.Memory;
        if (objectName == "_CrosswordsToggle")
            return GameModel.Crosswords;
        if (objectName == "_PuzzleToggle")
            return GameModel.Puzzle;
        if (objectName == "_LettersToggle")
            return GameModel.Letters;

        throw new Exception("No recognizable model was selected while creating a game");
    }
}
