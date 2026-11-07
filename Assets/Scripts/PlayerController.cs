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
    private Transform spawn;
    [SerializeField]
    private InputAction disparar;
    private InputAction arriba;
    private InputAction abajo;
    private PlayerStandPoint[] componente;
    private int ind;
    private bool moverse;

    void Start()
    {
        disparar = InputSystem.actions.FindAction("Jump");
        if (disparar != null) disparar.Enable();

        componente = UnityEngine.Object.FindObjectsByType<PlayerStandPoint>();
        if (componente.Length != 0)
        {
            moverse = true;
            arriba = InputSystem.actions.FindAction("Previous");
            if (arriba != null) arriba.Enable();

            abajo = InputSystem.actions.FindAction("Next");
            if (abajo != null) abajo.Enable();


            ind = 1;
            transform.position = RegresaPos().position;
        } else 
        {
            moverse = false;
            Debug.Log("No hay puntos por los que moverse");
        }

    
    }

    void Update()
    {

        if (moverse && arriba.WasPressedThisFrame())
        {
            Debug.Log("arriba");
            if (ind == 1)
            {
                ind = componente.Length;
                transform.position = RegresaPos().position;
            }
            else
            {
                ind--;
                transform.position = RegresaPos().position;
            }
            
        }
        else if (moverse && abajo.WasPressedThisFrame())
        {
            Debug.Log("abajo");
            if (ind == componente.Length)
            {
                ind = 1;
                transform.position = RegresaPos().position;
            }
            else
            {
                ind++;
                transform.position = RegresaPos().position;
            }

        }
        
        if (disparar.WasPressedThisFrame())
        {
            prefab.transform.position = spawn.position;
            Instantiate(prefab);
        } 
    }
    private Transform RegresaPos()
    {
        Transform ret = null;
        for (int i = 0; i < componente.Length; i++)
        {
           if (componente[i].GetOrden() == ind)
            {
                ret = componente[i].transform;
            }
        }
        return ret;
    }
}
