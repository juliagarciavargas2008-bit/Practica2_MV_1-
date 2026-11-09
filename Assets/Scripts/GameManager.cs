using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gamewon;
    [SerializeField]
    private GameObject gameover;
    [SerializeField]
    private GameObject[] vida;
    [SerializeField]
    private TextMeshProUGUI puntos;

    public static GameManager instance;
    private int Puntuacion = 0;
    private int clientes;
    private int nvidas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        clientes = UnityEngine.Object.FindObjectsByType<NPC>().Length;

        if (puntos != null) puntos.text = "puntos: " + Puntuacion;
        if (gameover != null) gameover.SetActive(false);
        if (gamewon != null) gamewon.SetActive(false);
   
        nvidas = vida.Length;
    }

    private void Update()
    {
        if (clientes == 0)
        {
            if (UnityEngine.Object.FindObjectsByType<Desliza>().Length == 0)
            {
                if (gamewon != null) gamewon.SetActive(true);
                else Debug.Log("Falta panel de gamewon");
            }
        }
        else if (nvidas == 0)
        {
            GameObject jugador;
            jugador = UnityEngine.Object.FindAnyObjectByType<PlayerController>().gameObject;
            jugador.GetComponent<PlayerController>().enabled = false;

            var takeitem = jugador.GetComponent<TakeItem>();
            if (takeitem != null) jugador.GetComponent<TakeItem>().enabled = false;

            if (gameover != null) gameover.SetActive(true);
            else Debug.Log("Falta panel de gameover");
        }
    }

    public void AddPuntos(int pts)
    {
        if (nvidas != 0)
        {
            Puntuacion += pts;
            if (puntos != null) puntos.text = "puntos: " + Puntuacion;
        }
    }

    public void VidaMenos()
    {
        if (nvidas != 0)
        {
            Destroy(vida[nvidas - 1]);
            nvidas -= 1;
        }
    }
    public void MenosCliente()
    {
        clientes--;
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(0); 
    }
}
