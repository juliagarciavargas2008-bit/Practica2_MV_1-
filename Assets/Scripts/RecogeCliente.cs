using UnityEngine;

public class RecogeCliente : MonoBehaviour
{
    [SerializeField]
    private int puntos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<NPC>()  != null)
        {
            NPC cliente = collision.gameObject.GetComponent<NPC>();

            if (cliente.GetState() == "recogiendo")
            {
                GameManager.instance.MenosCliente();
                GameManager.instance.AddPuntos(puntos);
                Destroy(cliente.gameObject);
            }
        }
    }
}
