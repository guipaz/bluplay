using System;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public int tag;

    CircleCollider2D collider;
    DragTransform dragTransform;

    public Action ScoredAction;

    public void Start()
    {
        collider = GetComponent<CircleCollider2D>();

        dragTransform = GetComponent<DragTransform>();
        dragTransform.stoppedDragAction = CheckSlot;
    }

    void CheckSlot()
    {
        Collider2D[] overlapping = new Collider2D[10];
        Physics2D.OverlapCollider(collider, new ContactFilter2D(), overlapping);
        foreach (var c in overlapping)
        {
            if (c == null)
                continue;

            var slot = c.gameObject.GetComponent<PuzzleSlot>();
            if (slot != null)
            {
                if (slot.tag == tag)
                {
                    transform.position = new Vector3(slot.transform.position.x, slot.transform.position.y, transform.position.z);
                    dragTransform.active = false;
                    Debug.Log("acerto mizeravi");

                    ScoredAction?.Invoke();
                }
            }
        }
    }
}
