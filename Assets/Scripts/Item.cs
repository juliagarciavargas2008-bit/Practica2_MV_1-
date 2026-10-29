using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private int puntos;

    private void OnDestroy()
    {
        
    }
    public void PlayClip()
    {
        source.Play();
        Debug.Log(source.isPlaying);
    }
}
