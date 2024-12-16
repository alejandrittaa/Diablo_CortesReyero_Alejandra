using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPatrulla : MonoBehaviour
{

    [SerializeField] private Transform ruta;
    private List<Transform> listadoPuntos = new List<Transform>();

    void Start()
    {
        foreach (Transform punto in ruta)
        {

        }
    }

    void Update()
    {
        
    }
}
