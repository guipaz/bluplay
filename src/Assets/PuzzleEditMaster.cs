using Assets.Scripts;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleEditMaster : MonoBehaviour
{
    public Image puzzleImage;
    public Text sizeText;

    string path;
    int width = 5;
    int height = 3;

    public void SetImage()
    {
        var path = EditorUtility.OpenFilePanel("Selecione uma imagem", null, "png");
        if (path != null)
        {
            var img = LoadPNG(path);
            puzzleImage.sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), Vector2.zero);

            this.path = path;
        }

        UpdateText();
    }

    public void Increase()
    {
        width++;
        height++;

        UpdateText();
    }

    public void Decrease()
    {
        width--;
        height--;

        UpdateText();
    }

    void UpdateText()
    {
        sizeText.text = width + "x" + height;
    }

    public static Texture2D LoadPNG(string filePath)
    {
        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }

    public void Save()
    {
        if (path == null)
            return;

        var puzzleGame = (PuzzleGame)BPGame.Current;
        puzzleGame.path = path;
        puzzleGame.width = width;
        puzzleGame.height = height;

        SceneManager.LoadScene("MenuScene");
    }

    public void Cancel()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
