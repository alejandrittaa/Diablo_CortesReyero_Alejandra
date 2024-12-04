using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera cam;
    void Start()
    {
        //indicamos que camara es la que tiene que tener en cuenta
        cam = Camera.main;
    }

    
    void Update()
    {
        //si el player hace click izquierdo, el personaje se moverá hacía la posición que indique el ratón
        if (Input.GetMouseButtonDown(0))
        {
            //Creo un rayo desde la cámara que indica la posición del ratón
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        }
        
    }
}
