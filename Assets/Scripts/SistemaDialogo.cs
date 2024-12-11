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
        StartCoroutine(EscribirFrase());
    }

    //sirve para escribir la frase letra por letra
    private IEnumerator EscribirFrase()
    {
        //demenuzo la frase actual en caracteres separados
        char[] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();

        foreach(char letra in fraseEnLetras)
        {
            //1. Incluir la letra por la que estes pasando en el texto. (+=, para que se acumulen y no se sobre escribian)
            textoDialogo.text += letra;
            //2. Esperar 0.02sec
            yield return new WaitForSeconds(0.02f);
        }
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
