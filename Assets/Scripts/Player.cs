using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    //almaceno el último tranform que clicke con el raton
    private Transform ultimoClick;
    void Start()
    {
        //indicamos que camara es la que tiene que tener en cuenta
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Movimiento();
        ComprobarInteraccion();
    }

    private void Movimiento()
    {
        //si el player hace click izquierdo, el personaje se moverá hacía la posición que indique el ratón
        if (Input.GetMouseButtonDown(0))
        {
            //Creo un rayo desde la cámara que indica la posición del ratón
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //tiramos/lanzamos el rayo anterior
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                //le decimos al agent/player que tiene como destino el punto de impacto
                agent.SetDestination(hitInfo.point);

                //actualizo el último hit con el transform que acabo de clickar
                ultimoClick = hitInfo.transform;
            }
        }
    }

    private void ComprobarInteraccion()
    {
        //si el ultimo click que hice fue en el npc...
        if(ultimoClick != null && ultimoClick.TryGetComponent(out NPC npc))
        {
            //actualizamos la distancia de parada para no superponernos al npc
            agent.stoppingDistance = 2f; 

            //comprobar si ya hemos llegado a dicho destino (delante del npc)
            if(agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                //si hemos llegado, llamamos al metodo interacción de dentro del npc
                npc.Interactuar();
            }
        }
    }
}
