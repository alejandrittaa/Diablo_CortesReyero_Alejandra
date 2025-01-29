using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager; //cogemos el event manager/cartero
    [SerializeField] private ToggleMision[] togglesMision; //colección de toggles

    private void OnEnable()
    {
        //me suscribo al evento y lo vinculo con el método encender toggle de la misión
        eventManager.OnNuevaMision += EncenderToggleMision;
        eventManager.OnActualizarMision += ActualizarToggleMision;
        eventManager.OnTerminarMision += TerminarToggleMision;
    }

    private void EncenderToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial; //cambiamos el texto al que corresponde de la mision

        //comprueba a ver si tiene repetición...
        if (mision.tieneRepeticion)
        {
            //mostramos por pantalla la cantidad de repeteciones que llevas
            togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";
        }

        togglesMision[mision.indiceMision].gameObject.SetActive(true); //enciendo el toggle para que se vea en pantalla
    }

    private void ActualizarToggleMision(MisionSO mision)
    {
        //actualizamos el texto
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
        togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";
    }


    private void TerminarToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenFinal; //ponemos el texto de victoria     
        togglesMision[mision.indiceMision].ToggleVisual.isOn = true; //al terminar checkeamos el toggle a completado
    }

}
