using UnityEngine;

public class PlayerStandPoint : MonoBehaviour
{
    [SerializeField]
    private int standpoint;

    private void Start()
    {
        var sprite = GetComponent<SpriteRenderer>();
        if (sprite != null) sprite.enabled = false;
    }
    public int GetOrden()
    {
        return standpoint;
    }

}
