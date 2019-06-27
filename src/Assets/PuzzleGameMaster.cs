using Assets;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleGameMaster : MonoBehaviour
{
    System.Random random = new System.Random();
    public Sprite gridSprite;

    int scored;
    int maxScore;
    GameObject grid;
    public Text finishedText;
    public GameObject finishedButton;

    void Start()
    {
        //var texture = PNGHandler.LoadImageTexture2D();
        var game = ((PuzzleGame)BPGame.Current);
        var texture = PNGHandler.LoadPNG(game.path);
        var width = game.width;
        var height = game.height;
        maxScore = width * height;

        var sizeX = texture.width / width;
        var sizeY = texture.height / height;

        Sprite completedImage = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        var imageCenter = new Vector3(completedImage.bounds.size.x / 2, completedImage.bounds.size.y / 2, Camera.main.transform.position.z);
        Camera.main.transform.position = imageCenter;

        var parent = new GameObject();
        parent.transform.position = Vector3.zero;

        grid = new GameObject();
        parent.transform.position = Vector3.zero;
        
        int i = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Sprite newSprite = Sprite.Create(texture, new Rect(x * sizeX, y * sizeY, sizeX, sizeY), Vector2.zero);
                GameObject n = new GameObject();
                SpriteRenderer sr = n.AddComponent<SpriteRenderer>();
                sr.sprite = newSprite;
                
                n.transform.position = new Vector3(random.Next(-3, (int)imageCenter.x * 3), random.Next(0, (int)imageCenter.y * 2), 1);
                n.transform.parent = parent.transform;
                n.AddComponent<DragTransform>();
                n.AddComponent<BoxCollider2D>();
                
                GameObject g = new GameObject();
                sr = g.AddComponent<SpriteRenderer>();
                sr.sprite = gridSprite;
                sr.drawMode = SpriteDrawMode.Sliced;
                sr.color = Color.cyan;
                sr.size = newSprite.bounds.size;
                g.transform.position = new Vector3(x * newSprite.bounds.size.x, y * newSprite.bounds.size.y, -5);
                g.transform.parent = grid.transform;
                
                var pieceCollider = n.AddComponent<CircleCollider2D>();
                pieceCollider.radius = 0.2f;
                var piece = n.AddComponent<PuzzlePiece>();
                piece.tag = i;
                piece.ScoredAction = () =>
                {
                    scored++;
                    if (scored >= maxScore)
                    {
                        FinishGame();
                    }
                };

                var slotCollider = g.AddComponent<CircleCollider2D>();
                slotCollider.radius = 0.2f;
                var slot = g.AddComponent<PuzzleSlot>();
                slot.tag = i;

                i++;
            }
        }
    }

    private void Update()
    {
        Camera.main.orthographicSize += Input.mouseScrollDelta.y / -2f;
        if (Camera.main.orthographicSize > 10)
            Camera.main.orthographicSize = 10;
        else if (Camera.main.orthographicSize < 5)
            Camera.main.orthographicSize = 5;
    }

    public void Cancel()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void FinishGame()
    {
        grid.SetActive(false);
        finishedText.gameObject.SetActive(true);
        finishedButton.SetActive(true);
    }
}
