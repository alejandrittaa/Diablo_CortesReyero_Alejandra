using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    //PATRÓN SINGLETON:

        //1. Solo existe una instancia de SistemaDialogo.
            //Es decir, que basicamente no se puedan crear varios sistemas de dialogos.

        //2. Es accesible desde cualquier punto del programa.

    public static SistemaDialogo sistema;

    //AWAKE:
        //Se ejecuta ANTES del Start, independientemente de que el gameObject este activo o no.
            //Es decir, el patrón singleton se ejecuta en el Awake, porque "para empezar una clase, tiene que estar el profesor"          
    void Awake()
    {
        //si el trono esta libre
        if(sistema == null)
        {
            //me hago con el sistema, y entonces SistemaDialogo, seré yo (this)
            sistema = this;
        }
        else
        {
            //si el sistema ya esta ocupado, pues me mato
            Destroy(this.gameObject);
        }
    }

    public void InciarDialogo(DialogoSO dialogo)
    {
        
    }


    void Update()
    {
        
    }
}
