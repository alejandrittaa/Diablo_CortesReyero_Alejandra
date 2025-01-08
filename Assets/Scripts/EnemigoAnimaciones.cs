using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoAnimaciones : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private NavMeshAgent agent;
    void Start()
    {
        //obtengo mi animator
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        //actualizamos el velocity en funcion de la velocidad de la agente
        anim.SetFloat("velocity", agent.velocity.magnitude / agent.speed);
    }
}
