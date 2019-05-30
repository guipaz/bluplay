using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PuzzleEditMaster : MonoBehaviour
{
    public GameObject puzzlePrefab;
    
    public void AddPiece()
    {
        var path = EditorUtility.OpenFilePanel("Selecione uma imagem", null, "png");
        if (path != null)
        {
            var img = LoadPNG(path);
            var gameObject = Instantiate(puzzlePrefab, Vector3.zero, Quaternion.identity);
            var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), Vector2.zero);
        }
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
}
