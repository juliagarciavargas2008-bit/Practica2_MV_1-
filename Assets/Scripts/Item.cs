using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private AudioClip clip;

    [SerializeField]
    private int puntos;

    public AudioClip GetClip()
    {
        if (clip != null) return clip;
        else return null;
    }
    public int GetPuntos()
    {
        return puntos;
    }
}
