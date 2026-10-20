using UnityEngine;

public class PlayerStandPoint : MonoBehaviour
{
    [SerializeField]
    private int standpoint;

    public int GetOrden()
    {
        return standpoint;
    }

}
