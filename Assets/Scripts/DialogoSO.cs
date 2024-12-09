using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//para que podamos crear diálogos desde el menú en forma de Scriptable Objects
    //(desde el menú donde creamos scripts, carpetas y demás...)
[CreateAssetMenu(menuName = "Diálogo")]
public class DialogoSO : ScriptableObject
{
    //mostrará mínimo 5 líneas y máximo 10 líneas para que nos sea más fácil escribir desde la interfaz.
    [TextArea(5, 10)]
    public string[] frases;
    public float tiempoEntreLetras;
}
