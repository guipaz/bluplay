using System;
using UnityEngine;

class DragTransform : MonoBehaviour
{
    public bool dragging = false;
    private float distance;
    new Renderer renderer;

    public bool active = true;

    public Action stoppedDragAction;

    public void Awake()
    {
        renderer = GetComponent<Renderer>();
    }
    
    void OnMouseDown()
    {
        if (!active)
            return;

        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        if (!active)
            return;

        dragging = false;
        stoppedDragAction?.Invoke();
    }

    void Update()
    {
        if (!active)
            return;

        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            var vec = rayPoint - (GetComponent<SpriteRenderer>().sprite.bounds.size / 2);
            transform.position = new Vector3(vec.x, vec.y, transform.position.z);
        }
    }
}

