using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject cerve;
    [SerializeField]
    private Transform spwan;
    [SerializeField]
    private float CoolDown;
    private InputAction disparar;
    private float tiempo;
    private bool pulso;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        disparar = InputSystem.actions.FindAction("Jump");
        if (disparar != null) disparar.Enable();
      
        pulso = true;

    }

    // Update is called once per frame
    void Update()
    {
        float boton = disparar.ReadValue<float>();
        tiempo += Time.deltaTime;
        if (boton > 0f && tiempo > CoolDown && pulso)
        {
            Instantiate(cerve);
            cerve.transform.position = spwan.transform.position;
            tiempo = 0f;
            pulso = false;
        }
        else if (boton <= 0f)
        {
            pulso = true;
        }
    }
}
