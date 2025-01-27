using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "Misión")]
public class MisionSO : ScriptableObject
{

    public string ordenInicial; //mensaje inicial
    public string ordenFinal; //mensaje final/mensaje de victoria
    public bool tieneRepeticion; //se tiene que repetir la mision?? ejemplo: matar un orco 3 veces 
    public int totalRepeticiones; //veces que tengo que repetir ese paso
    public int indiceMision; //numero de la mision (índice único que representa cada misión)

    public int repeticionActual; //la vez concreta en la que estas haciendo la repetición (el avance de misión que llevas)

}
