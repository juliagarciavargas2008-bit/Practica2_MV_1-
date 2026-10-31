using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private AudioClip clip;

    [SerializeField]
    private int puntos;


    public AudioClip GetClip()
    {
       return clip;
    }
}
