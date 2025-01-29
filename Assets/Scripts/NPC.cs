using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractuable
{
    [SerializeField] private DialogoSO dialogo1;
    [SerializeField] private DialogoSO dialogo2;
    private DialogoSO dialogoActual;
    [SerializeField] private float duracionRotacion;
    [SerializeField] private Transform cameraPoint; //punto en el que se pondrá la cámara npc
    [SerializeField] private EventManagerSO eventManager;
    [SerializeField] private MisionSO miMision; //mision asociada al npc

    private void Awake()
    {
        dialogoActual = dialogo1;
    }

    private void OnEnable()
    {
        eventManager.OnTerminarMision += CambiarDialogo; ;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if(miMision == misionTerminada)
        {
            dialogoActual = dialogo2;
        }
    }

    public void Interactuar(Transform tr)
    {
        Debug.Log("Hola");
        //esta sentencia hace que el ncp vaya rotando poco a poco a mirar al player, --
        // -- y que cuando termine de girarse (OnComplete), se iniciara la interacción.
        transform.DOLookAt(tr.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarInteraccion);
    }

    private void IniciarInteraccion()
    {
        SistemaDialogo.sistema.InciarDialogo(dialogoActual, cameraPoint);
    }

    private void OnDisable()
    {
        eventManager.OnTerminarMision -= CambiarDialogo; //nos desuscribimos, para que no se congele el juego ni de error
    }
}
