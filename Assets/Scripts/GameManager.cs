using TMPro;
using UnityEngine;

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
        }
        else
        {
            instance = this;
        }
        clientes = UnityEngine.Object.FindObjectsByType<NPC>().Length;
        gameover.SetActive(false);
        gamewon.SetActive(false);
        nvidas = vida.Length;
    }

    private void Update()
    {
        if (clientes == 0 && Puntuacion != 0)
        {
            if (UnityEngine.Object.FindObjectsByType<Desliza>() != null)
            {
                gamewon.SetActive(true);
            }
        }
        else if (nvidas == 0)
        {
            gameover.SetActive(true);
        }
    }

    public void AddPuntos(int pts)
    {
        Puntuacion += pts;
        puntos.text = "puntos: " + Puntuacion;
        Debug.Log("puntos: " + Puntuacion);
    }

    public void VidaMenos()
    {
        Destroy(vida[nvidas - 1]);
        nvidas -= 1;
    }
}
