using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets
{
    public class PNGHandler
    {
        public static Texture2D LoadImageTexture2D()
        {
            var path = EditorUtility.OpenFilePanel("Selecione uma imagem", null, "png");
            if (path != null)
            {
                return LoadPNG(path);
            }

            return null;
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
}
