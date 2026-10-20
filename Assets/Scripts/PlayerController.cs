using JetBrains.Annotations;
using System;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private PlayerStandPoint standPoint;
        
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Transform spwan;
    [SerializeField]
    private InputAction disparar;
    private InputAction arriba;
    private InputAction abajo;
    private Array componente;
    private Array[] orden;

    void Start()
    {
        disparar = InputSystem.actions.FindAction("Jump");
        if (disparar != null) disparar.Enable();

        arriba = InputSystem.actions.FindAction("Previous");
        if (arriba != null) arriba.Enable();

        abajo = InputSystem.actions.FindAction("Next");
        if (abajo != null) abajo.Enable();

        componente =  UnityEngine.Object.FindObjectsOfType<PlayerStandPoint>();
        orden = new System.Array[] { componente };
    }

    void Update()
    {
        if (disparar.WasPressedThisFrame())
        {
            Instantiate(prefab);
            prefab.transform.position = spwan.transform.position;
        }

        if (arriba.WasPressedThisFrame())
        {
            Debug.Log("arriba");
            for (int i = 0; i < componente.Length; i++)
            {
                
            }
            
        }
        else if (abajo.WasPressedThisFrame())
        {
            Debug.Log("abajo");
        }
    }
}
