using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    private SistemaPatrulla patrulla;
    private SistemaCombate combate;

    private Transform targetGlobal;

    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public SistemaCombate Combate { get => combate; set => combate = value; }
    public Transform Targetglobal { get => targetGlobal; set => targetGlobal = value; }

    private void Start()
    {
        //activamos la patrulla al empezar el juego
        patrulla.enabled = true;
    }
    public void ActivarCombate(Transform targetLocal)
    {
        //desactivamos patrulla
        patrulla.enabled = false;
        //activamos combate
        combate.enabled = true;  
        //definimos target
        targetGlobal = targetLocal;
    }

    internal void ActivarPatrulla()
    {
        //desactivamos el script de combate
        combate.enabled = false;
        //activamos el script de patrulla
        patrulla.enabled = true;
    }



    void Update()
    {
        
    }
}
