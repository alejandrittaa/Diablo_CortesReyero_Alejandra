using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{

    [SerializeField] private Enemigo main;
    [SerializeField] private NavMeshAgent agent;
    
    [SerializeField] private float velocidadCombate; //definimos la velocidad de combate
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private float danhoAtaque;
    [SerializeField] private Animator anim;

    void Awake()
    {
        main.Combate = this;
    }
    //OnEnable se ejecuta cuando se activa el script
    private void OnEnable() //cuando el combate se activa
    {
        //aumentamos la velocidad del enemigo
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;
    }

    void Update()
    {
        //solo si existe un objetivo y es alcanzable...
        if(main.Targetglobal != null && agent.CalculatePath(main.Targetglobal.position, new NavMeshPath()))
        {
            //enfocar al player siempre
            EnfocarObjetivo();

            //le decimos al enemigo que persiga al player/target, calculando su posici�n (update ya que se va moviendo el player)
            agent.SetDestination(main.Targetglobal.position);

            //cuando tenga al objetivo en distancia de ataque, atacamos
            if(!agent.pathPending && agent.remainingDistance <= distanciaAtaque)
            {
                anim.SetBool("attacking", true);
            }

        }else
        {
            //si no, quitamos el combate y habilitamos la patrulla
            main.ActivarPatrulla();
        }
        
    }

    private void EnfocarObjetivo()
    {
        // calcular la direcci�n al objetivo
        Vector3 direccionATarget = (main.Targetglobal.transform.position - transform.position).normalized;
        direccionATarget.y = 0; // pongo la "y" a 0 para que no se vuelque.

        // transformo una direcci�n en una rotaci�n
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);

        // aplico la rotaci�n
        transform.rotation = rotacionATarget;
    }

    //lo de abajo de #region es para dividir el c�digo en partes (en este caso comprimir los dos m�todos)
    #region Ejecutados por evento de animaci�n
    private void Atacar()
    {
        //hacer da�o al target
        main.Targetglobal.GetComponent<Player>().HacerDanho(danhoAtaque);
    }

    private void FinAnimacionAtaque()
    {
        anim.SetBool("attacking", false); //desactivamos la aniamcion de atacar
    }
    #endregion
}
