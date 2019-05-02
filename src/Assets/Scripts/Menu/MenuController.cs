using UnityEngine;

public abstract class MenuController : MonoBehaviour
{
    public abstract string GetId();

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
