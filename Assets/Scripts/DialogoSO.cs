using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//para que podamos crear di�logos desde el men� en forma de Scriptable Objects
    //(desde el men� donde creamos scripts, carpetas y dem�s...)
[CreateAssetMenu(menuName = "Di�logo")]
public class DialogoSO : ScriptableObject
{
    //mostrar� m�nimo 5 l�neas y m�ximo 10 l�neas para que nos sea m�s f�cil escribir desde la interfaz.
    [TextArea(5, 10)]
    public string[] frases;
    public float tiempoEntreLetras;
}
