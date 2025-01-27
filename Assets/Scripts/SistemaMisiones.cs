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
