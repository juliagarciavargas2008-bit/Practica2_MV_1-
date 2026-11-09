using Unity.VisualScripting;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    private AudioSource speaker;
    private void Start()
    { 
        speaker = gameObject.GetComponent<AudioSource>(); 

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Item>() != null)
        {
            var componenteItem = other.gameObject.GetComponent<Item>();
            AudioClip clip = componenteItem.GetClip();

            if ((speaker != null) && (clip != null)) speaker.PlayOneShot(clip);
            else
            {
                if (speaker == null) Debug.Log("Falta el componente AudioSource");
                if (clip == null) Debug.Log("Falta Clip");
            }

            Destroy(other.gameObject);

            if (GameManager.instance != null)
            {
                GameManager.instance.AddPuntos(componenteItem.GetPuntos());
            }
            else Debug.Log("Falta GameManager");
        }
    }
}
