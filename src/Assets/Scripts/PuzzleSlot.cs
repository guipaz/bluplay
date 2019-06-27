using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public int tag;

    CircleCollider2D collider;
    
    private void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }
}
