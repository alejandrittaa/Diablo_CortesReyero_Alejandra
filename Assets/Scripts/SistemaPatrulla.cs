using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private float velocidadPatrulla;
    //cuando nace el sistema patrulla, le indica al 
    [SerializeField] private Enemigo main;

    [SerializeField] private Transform ruta;

    [SerializeField]private NavMeshAgent agent;

    private List<Vector3> listadoPuntos = new List<Vector3>();

    private int indiceDestinoActual = -1; //marca el punto del destino al que debo ir
    private Vector3 destinoActual; //marca la posición del destino al que debo ir 

    private void Awake() //funciona antes del start
    {
        //le digo al main (sccript enemigo), que el sistema de patrulla que tiene soy yo (this)
        main.Patrulla = this;
        foreach (Transform punto in ruta)
        {
            //añado todos los puntos de ruta al listado
            listadoPuntos.Add(punto.position);
        }
    }

    private void OnEnable() //cuando se enciende la patrulla, establecemos velocidad patrulla
    {
        agent.speed = velocidadPatrulla;
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
            agent.SetDestination(destinoActual); //Ir al destino
            yield return new WaitUntil( () => agent.remainingDistance <= 0); //expresión LAMBDA = método anónimo
            //espera hasta que se cumpla la condición para calcular el siguiente punto.
            //lo anterior es, espera hasta que la distancia restante sea 0 para calcular el siguiente punto al que tienes que ir

            //que espere entre 0.5 y 3 segundos hasta avanzar al siguiente punto de manera aleatoria
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.25f, 3f));
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) //si detecta al player...
        {
            StopAllCoroutines(); //abandonamos la corrutina de patrulla

            //activamos el combate, desactivamos la patrulla y le pasamos a quien tiene que perseguir
            main.ActivarCombate(other.transform);
        }
    }
}
