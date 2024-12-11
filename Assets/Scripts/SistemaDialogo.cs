using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{

    [SerializeField] private GameObject marcoDialogo; //marco a habilitar/deshabilitar
    [SerializeField] private TMP_Text textoDialogo; //dialogos como tal

    private bool escribiendo;
    private int indiceFraseActual = 0; //para por cual frase va

    private DialogoSO dialogoActual; //para saber cual es el dialogo con el que estamos trabajando en cada momento.


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
        //el diálogo actual que tenemos que tratar, es el que nos pasan por parámetro
        dialogoActual = dialogo;
        marcoDialogo.SetActive(true);
    }

    //sirve para escribir la frase letra por letra
    private void EscribirFrase()
    {

    }

    //sirve para autocompletar la frase
    private void CompletarFrase()
    {

    }

    private void SiguienteFrase()
    {

    }

    private void FinalizarDialogo()
    {

    }

}
