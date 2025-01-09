using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    private SistemaPatrulla patrulla;
    private SistemaCombate combate;

    private Transform targetGlobal;

    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public SistemaCombate Combate { get => combate; set => combate = value; }
    public Transform Targetglobal { get => targetGlobal; set => targetGlobal = value; }

    public void ActivarCombate(Transform targetLocal)
    {
        //desactivamos patrulla
        patrulla.enabled = false;
        //activamos combate
        combate.enabled = true;  
        //definimos target
        targetGlobal = targetLocal;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
