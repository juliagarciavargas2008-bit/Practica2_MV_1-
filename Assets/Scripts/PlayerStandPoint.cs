using UnityEngine;

public class PlayerStandPoint : MonoBehaviour
{
    [SerializeField]
    private int standpoint;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    public int GetOrden()
    {
        return standpoint;
    }

}
