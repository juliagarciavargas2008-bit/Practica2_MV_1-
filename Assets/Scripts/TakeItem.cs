using Unity.VisualScripting;
using UnityEngine;

public class TakeItem : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Item>() != null)
        {
            collision.gameObject.GetComponent<Item>().PlayClip();
           // Destroy(collision.gameObject);
        }
    }
}
