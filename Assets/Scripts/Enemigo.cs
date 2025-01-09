using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    private SistemaPatrulla patrulla;
    private SistemaCombate combate;

    private Transform targetglobal;

    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public SistemaCombate Combate { get => combate; set => combate = value; }
    public Transform Targetglobal { get => targetglobal; set => targetglobal = value; }

    public void ActivarCombate(Transform targetlocal)
    {
        //desactivamos patrulla
        patrulla.enabled = false;
        //activamos combate
        combate.enabled = true;  
        //definimos target
        targetglobal = targetlocal;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
