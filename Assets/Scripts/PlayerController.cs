using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Transform spwan;
    [SerializeField]
    private InputAction disparar;
    private InputAction move;
    private Vector2 direccion;
    private Array orden;
  
    void Start()
    {
        disparar = InputSystem.actions.FindAction("Jump");
        if (disparar != null) disparar.Enable();

        move = InputSystem.actions.FindAction("move");
        if (move != null) move.Enable();

        orden = UnityEngine.Object.FindObjectsByType<PlayerStandPoint>( FindObjectsSortMode.None);
      
    }

    void Update()
    {
        direccion = move.ReadValue<Vector2>();
       if (disparar.WasPressedThisFrame())
        {
            Instantiate(prefab);
            prefab.transform.position = spwan.transform.position;
        }

        if (move.WasPressedThisFrame())
        {
            Debug.Log("arriba");
        }
        ;
    
    }
 
}
