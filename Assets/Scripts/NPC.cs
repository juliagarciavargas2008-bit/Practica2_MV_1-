using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float wait;

    [SerializeField]
    private float drinktime;

    private enum Estado { esperando, recogiendo, bebiendo};
    private Estado estadoactual = Estado.esperando;
    private float hora;
    private Vector2 cerveza;
    private Vector2 jugador;
    private Vector2 posiactual;
   

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Beer") && (estadoactual== Estado.esperando))
        {
            cerveza = other.transform.position;
            jugador = this.transform.position; 
            hora = Time.time;
            Destroy(other.gameObject);
            estadoactual = Estado.recogiendo;
            
        }

    }

    void Update()
    {
        if (estadoactual == Estado.esperando)
        {
            var desliza = GetComponent<Desliza>();
            desliza.SetVelX(speed);
            desliza.enabled = true;
        }

        if (estadoactual == Estado.recogiendo)
        {
            var desliza = GetComponent<Desliza>();
            desliza.SetVelX(-speed * 2);

            if ((hora + wait) < Time.time)
            {
                estadoactual = Estado.bebiendo;
                hora = Time.time;
            }
        }

        if (estadoactual == Estado.bebiendo)
        {
            var desliza = GetComponent<Desliza>();
            posiactual = this.transform.position;
            desliza.enabled = false;

            if (hora + drinktime < Time.time)
            {
                prefab.transform.position = (cerveza - jugador) + posiactual;
                Instantiate(prefab);
                estadoactual = Estado.esperando;
            }
         
        }
    }
}
