using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private float duracionRotacion;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Interactuar(Transform interactuador)
    {
        Debug.Log("Hola");
        //esta sentencia indica a lo que tiene que mirar el NPC.
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y);
    }
}
