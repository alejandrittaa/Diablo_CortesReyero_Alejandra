using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SistemaPatrulla : MonoBehaviour
{

    [SerializeField] private Transform ruta;

    [SerializeField]private NavMeshAgent agent;

    private List<Vector3> listadoPuntos = new List<Vector3>();

    private int indiceDestinoActual = -1; //marca el punto del destino al que debo ir
    private Vector3 destinoActual; //marca la posici�n del destino al que debo ir 

    private void Awake() //funciona antes del start
    {
        foreach (Transform punto in ruta)
        {
            //a�ado todos los puntos de ruta al listado
            listadoPuntos.Add(punto.position);
        }
    }

    void Start()
    {
        StartCoroutine(PatrullaryEsperar()); //inicializamos la corrutina
    }

    private IEnumerator PatrullaryEsperar() //corrutina, ejecuci�n en paralelo al update
    {
        //por siempre, realiza lo de dentro del while
        while (true) 
        {
            CalcularDestino(); //tendr� que calcular el destino.
            agent.SetDestination(destinoActual); //Ir al destino
            yield return new WaitUntil( () => agent.remainingDistance <= 0); //expresi�n LAMBDA = m�todo an�nimo
            //|| espera hasta que se cumpla la condici�n para calcular el siguiente punto.
            //lo anterior es, espera hasta que la distancia restante sea 0 para calcular el siguiente punto al que tienes que ir        
        }
    }

    private void CalcularDestino()
    {
        indiceDestinoActual++; //vamos avanzando por los puntos, uno a uno

        if(indiceDestinoActual >= listadoPuntos.Count) //si el indice actual supera los puntos existentes....
        {
            indiceDestinoActual = 0; //volvemos al 0, el primer punto / punto inicial
        }

        //mi destino dentro del listado de puntos, es aquel con el nuevo indice que acabamos de calcular (lo del if anterior)
        destinoActual = listadoPuntos[indiceDestinoActual];
    }
}
