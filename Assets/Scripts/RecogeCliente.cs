using UnityEngine;

public class RecogeCliente : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<NPC>()  != null)
        {
            NPC cliente = collision.gameObject.GetComponent<NPC>();

            if (cliente.GetState() == "recogiendo")
            {
                Destroy(cliente.gameObject);
                GameManager.instance.AddPuntos(1);
            }
        }
    }
}
