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

    private List<Transform> listadoPuntos = new List<Transform>();

    private int indiceDestinoActual = 0; //marca el punto del destino al que debo ir
    private Transform  destinoActual; //marca la posición del destino al que debo ir 

    private void Awake() //funciona antes del start
    {
        agent = GetComponent<NavMeshAgent>();
        foreach (Transform punto in ruta)
        {
            //añado todos los puntos de ruta al listado
            listadoPuntos.Add(punto);
        }
    }

    void Start()
    {
        StartCoroutine(PatrullaryEsperar()); //inicializamos la corrutina
    }

    private IEnumerator PatrullaryEsperar() //corrutina, ejecución en paralelo al update
    {
        //por siempre, realiza lo de dentro del while
        while (true) 
        {
            CalcularDestino(); //tendré que calcular el destino.
            agent.SetDestination(destinoActual.position); //Ir al destino
            yield return new WaitForSeconds(5f); //tarda 5 segundos desde que empieza a andar para calcular el siguiente
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
