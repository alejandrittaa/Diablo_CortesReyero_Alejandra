using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{

    [SerializeField] private Enemigo main;
    [SerializeField] private NavMeshAgent agent;
    
    [SerializeField] private float velocidadCombate; //definimos la velocidad de combate

    void Awake()
    {
        main.Combate = this;
    }
    //OnEnable se ejecuta cuando se activa el script
    private void OnEnable() //si el combate esta activado
    {
        //aumentamos la velocidad del enemigo
        agent.speed = velocidadCombate;
    }

    void Update()
    {
        //le decimos al enemigo que persiga al player/target, calculando su posición (update ya que se va moviendo el player)
        agent.SetDestination(main.Targetglobal.position);
    }
}
