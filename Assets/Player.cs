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
        //si el player hace click izquierdo, el personaje se mover� hac�a la posici�n que indique el rat�n
        if (Input.GetMouseButtonDown(0))
        {
            //Creo un rayo desde la c�mara que indica la posici�n del rat�n
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
