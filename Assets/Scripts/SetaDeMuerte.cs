using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetaDeMuerte : MonoBehaviour, IInteractuable
{

    private Outline outline;
    [SerializeField] private EventManagerSO eventmanager;
    [SerializeField] private MisionSO mision;

    

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    public void Interactuar(Transform tr)
    {
        mision.repeticionActual++; //registramos la repetición

        //si todavía quedan setas por recoger
        if(mision.repeticionActual < mision.totalRepeticiones)
        {
            eventmanager.ActualizarMision(mision);
            
        }
        else //ya hemos terminado de recoger todas las setas
        {
            eventmanager.TerminarMision(mision);
        }
        Destroy(gameObject);
    }


    private void OnMouseEnter()
    {
        outline.enabled = true; //encendemos
    }

    private void OnMouseExit()
    {
        outline.enabled = false; //apagamos
    }

}
