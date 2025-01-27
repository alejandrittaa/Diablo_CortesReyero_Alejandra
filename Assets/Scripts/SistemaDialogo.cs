using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager; //cogemos el event manager
    [SerializeField] private GameObject marcoDialogo; //marco a habilitar/deshabilitar
    [SerializeField] private TMP_Text textoDialogo; //dialogos como tal
    [SerializeField] private Transform npcCamera; // Cámara compartida por todos los nps

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

    public void InciarDialogo(DialogoSO dialogo, Transform cameraPoint)
    {
        //cuando inciamos el dialogo, dejamos de movernos, es decir, congelamos el tiempo
        Time.timeScale = 0;
        //el diálogo actual que tenemos que tratar, es el que nos pasan por parámetro
        dialogoActual = dialogo;
        marcoDialogo.SetActive(true);
        //posiciono y roto la cámara en el punto de este npc.
        npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);

        StartCoroutine(EscribirFrase());
    }

    //sirve para escribir la frase letra por letra
    private IEnumerator EscribirFrase()
    {
        escribiendo = true;

        //limpiamos el cuadro antes de escribir una nueva frase
        textoDialogo.text = "";
        //demenuzo la frase actual en caracteres separados
        char[] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();

        foreach(char letra in fraseEnLetras)
        {
            //1. Incluir la letra por la que estes pasando en el texto. (+=, para que se acumulen y no se sobre escribian)
            textoDialogo.text += letra;
            //2. Esperar 0.02sec (WaitForSecondsRealtime, no se para si el tiempo está congelado)
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);
        }

        escribiendo = false;
    }

    //sirve para autocompletar la frase
    private void CompletarFrase()
    {
        //si me piden completar la frase entera, en el texto pondremos la frase entera.
        textoDialogo.text = dialogoActual.frases[indiceFraseActual];
        //y paramos las corrutinas que puedan estar escribiendo la frase, y no me añada más texto
        StopAllCoroutines();
        //dejamos de escribir
        escribiendo = false;
    }

    public void SiguienteFrase()
    {
        //si no estoy escribiendo entonces cambiamos de frase
        if(!escribiendo)
        {
            //cambiamos a la segunda frase
            indiceFraseActual++;
            //si aun me quedan frases por sacar, la escribo
            if (indiceFraseActual < dialogoActual.frases.Length)
            {
                StartCoroutine(EscribirFrase());
            }
            else
            {
                FinalizarDialogo();
            }
        }
        //si estamos escribiendo, que se complete la frase
        else
        {
            CompletarFrase();
        }
    }

    private void FinalizarDialogo()
    {
        //descongelamos el tiempo
        Time.timeScale = 1;
        //quitamos el marco de dialogo de la vista, ya que ya hemos terminado la interaccion
        marcoDialogo.SetActive(false);
        //para que en posteriores interacciones, se empiece siempre desde el indice 0
        indiceFraseActual = 0;
        //dejamos de escribir
        escribiendo = false;

        //comprobamos si tiene mision, para saber si hay que activar un toggle o no
        if(dialogoActual.tieneMision)
        {
            eventManager.NuevaMision(dialogoActual.mision);
        }

        //ya no etngo dialogo del que coger cosas para escribir
        dialogoActual = null;
    }

}
