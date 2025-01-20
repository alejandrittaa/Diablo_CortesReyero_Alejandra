using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMiniMapa : MonoBehaviour
{
    [SerializeField] private Player player;
    private Vector3 distanciaAPlayer; //distancia que tiene que respetar la camara en cuanto al player
    void Start()
    {
        //calculo la distancia que hay entre la cámara (yo/este script) y el player 
        distanciaAPlayer = transform.position - player.transform.position;
    }

    //el Late Update se ejecuta el último de todos los updates, esto lo hacemos para que todo se mueva antes de calcular a donde tiene que moverse la cámara (si no lo hacemos en aquí, podría haber vibraciones/movimientos de camara indiseados)
    void LateUpdate()
    {
        //la posición de la cámara será, la posición del player + la distacia que tiene que respetar en cuanto al player
        transform.position = player.transform.position + distanciaAPlayer;
    }
}
