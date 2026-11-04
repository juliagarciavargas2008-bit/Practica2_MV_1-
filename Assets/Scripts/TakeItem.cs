using Unity.VisualScripting;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    private AudioSource speaker;
    private void Start()
    { 
        speaker = gameObject.GetComponent<AudioSource>(); 
        if (speaker == null)
        {
            Debug.Log("falta fuente de audio");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Item>() != null)
        {
            var componenteItem = other.gameObject.GetComponent<Item>();
            AudioClip clip = componenteItem.GetClip();
            speaker.PlayOneShot(clip);
            Destroy(other.gameObject);
            GameManager.instance.AddPuntos(componenteItem.GetPuntos());
        }
    }
}
