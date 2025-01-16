using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{

    [SerializeField] private Enemigo main;
    [SerializeField] private NavMeshAgent agent;
    
    [SerializeField] private float velocidadCombate; //definimos la velocidad de combate
    [SerializeField] private float distanciaAtaque;

    void Awake()
    {
        main.Combate = this;
    }
    //OnEnable se ejecuta cuando se activa el script
    private void OnEnable() //cuando el combate se activa
    {
        //aumentamos la velocidad del enemigo
        agent.speed = velocidadCombate;
    }

    void Update()
    {
        //solo si existe un objetivo y es alcanzable...
        if(main.Targetglobal != null && agent.CalculatePath(main.Targetglobal.position, new NavMeshPath()))
        {
            //le decimos al enemigo que persiga al player/target, calculando su posición (update ya que se va moviendo el player)
            agent.SetDestination(main.Targetglobal.position);

            //cuando tenga al objetivo en distancia de ataque, atacamos
            if(!agent.pathPending && agent.remainingDistance <= distanciaAtaque)
            {
                agent.isStopped = true;
                //atacar 
            }

        }else
        {
            //si no, quitamos el combate y habilitamos la patrulla
            main.ActivarPatrulla();
        }
        
    }
}
