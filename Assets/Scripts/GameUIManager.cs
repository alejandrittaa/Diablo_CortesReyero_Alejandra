using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public GameObject pantallaInicio; // Panel de la pantalla de inicio
    public GameObject pantallaFin; // Panel de la pantalla de fin
    public NPC npc; // Referencia al script del NPC que maneja los diálogos

    private bool juegoIniciado = false;

    private void Awake()
    {
        // Mostrar la pantalla de inicio al CARGAR el juego
        pantallaInicio.SetActive(true);
    }

    void Start()
    {
        pantallaFin.SetActive(false);
    }

    void Update()
    {
        // Si el juego no ha empezado, esperar una tecla para ocultar la pantalla de inicio
        if (!juegoIniciado && Input.anyKeyDown)
        {
            pantallaInicio.SetActive(false);
            juegoIniciado = true;
        }
    }

    public void MostrarPantallaFin()
    {
        pantallaFin.SetActive(true);
    }
}
