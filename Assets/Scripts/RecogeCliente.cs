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
                if (GameManager.instance != null)
                {
                    GameManager.instance.MenosCliente();
                    GameManager.instance.AddPuntos(cliente.GetPuntos());
                }
                else Debug.Log("Falta GameManager");
                
            }
        }
    }
}
