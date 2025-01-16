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

            //le decimos al enemigo que persiga al player/target, calculando su posición (update ya que se va moviendo el player)
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
        // calcular la dirección al objetivo
        Vector3 direccionATarget = (main.Targetglobal.transform.position - transform.position).normalized;
        direccionATarget.y = 0; // pongo la "y" a 0 para que no se vuelque.

        // transformo una dirección en una rotación
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);

        // aplico la rotación
        transform.rotation = rotacionATarget;
    }

    //lo de abajo de #region es para dividir el código en partes (en este caso comprimir los dos métodos)
    #region Ejecutados por evento de animación
    private void Atacar()
    {
        //hacer daño al target
        main.Targetglobal.GetComponent<Player>().HacerDanho(danhoAtaque);
    }

    private void FinAnimacionAtaque()
    {
        anim.SetBool("attacking", false); //desactivamos la aniamcion de atacar
    }
    #endregion
}
