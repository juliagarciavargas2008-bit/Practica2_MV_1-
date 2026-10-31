using Unity.VisualScripting;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    [SerializeField]
    private AudioSource speaker;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Item>() != null)
        {
            var componenteItem = other.gameObject.GetComponent<Item>();
            AudioClip clip = componenteItem.GetClip();
            speaker.PlayOneShot(clip);

            
            Destroy(other.gameObject);
        }
    }
}
