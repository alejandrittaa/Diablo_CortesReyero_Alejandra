using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    private Camera cam;
 
    void Start()
    {
        //cam es la camara con la etiqueta main camera
        cam = Camera.main;
    }


    void Update()
    {
        //mi frontal es el frontal de la camara en sentido contrario
        transform.forward = -cam.transform.forward;
    }
}
