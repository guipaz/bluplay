using UnityEngine;

public class BG : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 5);
    }
}
