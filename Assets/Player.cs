using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    void Start()
    {
        //indicamos que camara es la que tiene que tener en cuenta
        cam = Camera.main;
        GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        //si el player hace click izquierdo, el personaje se moverá hacía la posición que indique el ratón
        if (Input.GetMouseButtonDown(0))
        {
            //Creo un rayo desde la cámara que indica la posición del ratón
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //tiramos/lanzamos el rayo anterior
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                //le decimos al agent/player que tiene como destino el punto de impacto
                agent.SetDestination(hitInfo.point);
            }

        }
        
    }
}
