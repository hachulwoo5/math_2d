using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandlerObject : MonoBehaviour
{
     MouseHandler mouseHandler;

    private void Awake ( )
    {
        if ( GameObject. Find ( "2Scene_RootGameObject" ) != null && GameObject. Find ( "2Scene_RootGameObject" ). activeSelf )
        {
            mouseHandler = GameObject. Find ( "드래그매니저2" ). GetComponent<MouseHandler> ( );
        }
        if ( GameObject. Find ( "3Scene_RootGameObject" ) != null && GameObject. Find ( "3Scene_RootGameObject" ). activeSelf )
        {
            mouseHandler = GameObject. Find ( "드래그매니저3" ). GetComponent<MouseHandler> ( );
        }
    }
    private void OnTriggerEnter2D ( Collider2D other )
    {
        if ( other. gameObject. CompareTag ( "MouseHandler" ) )
        {
            mouseHandler. mouseHandler. HandlingObj. Add ( this. gameObject );
        }
    }

    private void OnTriggerExit2D ( Collider2D other )
    {
        if ( other. gameObject. CompareTag ( "MouseHandler" ) )
        {
            mouseHandler. mouseHandler.HandlingObj. Remove ( this. gameObject );
        }
    }

     
    
}
