using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractuable
{
    [SerializeField] private DialogoSO miDialogo;
    [SerializeField] private float duracionRotacion;
    [SerializeField] private Transform cameraPoint; //punto en el que se pondrá la cámara npc
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Interactuar(Transform interactuador)
    {
        Debug.Log("Hola");
        //esta sentencia hace que el ncp vaya rotando poco a poco a mirar al player, --
        // -- y que cuando termine de girarse (OnComplete), se iniciara la interacción.
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarInteraccion);
    }

    private void IniciarInteraccion()
    {
        SistemaDialogo.sistema.InciarDialogo(miDialogo, cameraPoint);
    }

    public void Interactuar()
    {
        
    }
}
