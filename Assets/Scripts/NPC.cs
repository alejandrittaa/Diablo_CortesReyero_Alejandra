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
        //esta sentencia hace que el ncp vaya rotando poco a poco a mirar al player, --
        // -- y que cuando termine de girarse (OnComplete), se iniciara la interacción.
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarInteraccion);
    }

    private void IniciarInteraccion()
    {
        SistemaDialogo.sistema.InciarDialogo();
    }
}
