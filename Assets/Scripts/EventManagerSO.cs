using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventManager")]
public class EventManagerSO : ScriptableObject
{
    //creamos un evento (su nombre es OnNuevaMision)
    public event Action<MisionSO> OnNuevaMision;
    public event Action<MisionSO> OnActualizarMision;
    public event Action<MisionSO> OnTerminarMision;

    public void NuevaMision(MisionSO mision)
    {
        // ?. -> invocación SEGURA, se asegura de que exisan suscriptores
        //si lanzas un evento y no hay suscriptores, peta unity, SIEMPRE TIENE QUE HABER SUSCRIPTORES O AL LANZARLO PETARÁ
        OnNuevaMision?.Invoke(mision); //para encender/lanzar/disparar al evento, lo invocamos CON parámetros
    }

    public void ActualizarMision(MisionSO mision)
    {
        OnActualizarMision?.Invoke(mision);
    }

    public void TerminarMision(MisionSO mision)
    {
        OnTerminarMision?.Invoke(mision);
    }

}
