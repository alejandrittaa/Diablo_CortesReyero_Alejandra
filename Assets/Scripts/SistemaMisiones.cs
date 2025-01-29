using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager; //cogemos el event manager/cartero
    [SerializeField] private ToggleMision[] togglesMision; //colecci�n de toggles

    private void OnEnable()
    {
        //me suscribo al evento y lo vinculo con el m�todo encender toggle de la misi�n
        eventManager.OnNuevaMision += EncenderToggleMision;
    }

    private void EncenderToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial; //cambiamos el texto al que corresponde de la mision

        //comprueba a ver si tiene repetici�n...
        if(mision.tieneRepeticion)
        {
            //mostramos por pantalla la cantidad de repeteciones que llevas
            togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";
        }

        togglesMision[mision.indiceMision].gameObject.SetActive(true); //enciendo el toggle para que se vea en pantalla
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
