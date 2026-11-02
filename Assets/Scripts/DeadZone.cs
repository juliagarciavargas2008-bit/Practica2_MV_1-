using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Desliza>() != null)
        {
            Destroy(other.gameObject);
            GameManager.instance.VidaMenos();
        }
    }
}
