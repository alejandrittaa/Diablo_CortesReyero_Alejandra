using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{

    [SerializeField] private Enemigo main;
    [SerializeField] private NavMeshAgent agent;

    void Awake()
    {
        main.Combate = this;
    }


    void Update()
    {
        //le decimos al enemigo que persiga al player/target, calculando su posición (update ya que se va moviendo el player)
        agent.SetDestination(main.Targetglobal.position);
    }
}
