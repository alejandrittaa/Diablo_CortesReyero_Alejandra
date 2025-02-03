using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    private float tiempoCambio = 1f;

    private void OnTriggerEnter(Collider other)
    { 
        //si en el camino del player se detecta una pared (obstáculo)...
        if(other.CompareTag("Obstaculo"))
        {
            //poenmos en transparente las paredes que estén en nuestro rango
            Debug.Log("Pared detectada");
            Material materialPared = other.GetComponent<MeshRenderer>().material;
            Color transparente = new Color(materialPared.color.r, materialPared.color.g, materialPared.color.b, 0f);
            materialPared.DOColor(transparente, tiempoCambio);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //cuando el player se aleja del obstáculo...
        if (other.CompareTag("Obstaculo"))
        {
            //ponemos la pared de vuelta en visible
            Material materialPared = other.GetComponent<MeshRenderer>().material;
            Color opaco = new Color(materialPared.color.r, materialPared.color.g, materialPared.color.b, 1f);
            materialPared.DOColor(opaco, tiempoCambio);
        }
    }
}
