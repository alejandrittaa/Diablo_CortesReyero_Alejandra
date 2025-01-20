using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMiniMapa : MonoBehaviour
{
    [SerializeField] private Player player;
    private Vector3 distanciaAPlayer; //distancia que tiene que respetar la camara en cuanto al player
    void Start()
    {
        //calculo la distancia que hay entre la c�mara (yo/este script) y el player 
        distanciaAPlayer = transform.position - player.transform.position;
    }

    //el Late Update se ejecuta el �ltimo de todos los updates, esto lo hacemos para que todo se mueva antes de calcular a donde tiene que moverse la c�mara (si no lo hacemos en aqu�, podr�a haber vibraciones/movimientos de camara indiseados)
    void LateUpdate()
    {
        //la posici�n de la c�mara ser�, la posici�n del player + la distacia que tiene que respetar en cuanto al player
        transform.position = player.transform.position + distanciaAPlayer;
    }
}
