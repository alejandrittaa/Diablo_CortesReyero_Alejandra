using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    private Outline outline;

    [SerializeField] private Texture2D iconoInteraccion;
    [SerializeField] private Texture2D iconoDefecto;
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    void Update()
    {
        
    }

    //cuando pongas el raton encima se enciende el outline, cuando lo quitas se apaga.
    private void OnMouseEnter()
    {
        //cambiamos el cursor al de interacción
        Cursor.SetCursor(iconoInteraccion, Vector2.zero, CursorMode.Auto);
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        //cambiamos el cursor al de defecto/original
        Cursor.SetCursor(iconoDefecto, Vector2.zero, CursorMode.Auto);
        outline.enabled=false;
    }

}
