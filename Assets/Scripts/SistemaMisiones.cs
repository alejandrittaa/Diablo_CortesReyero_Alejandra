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
        
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
