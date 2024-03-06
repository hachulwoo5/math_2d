using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandlerObject_3th : MonoBehaviour
{
    MouseHandler_3th mouseHandler;

    private void Awake ( )
    {
       
    }

    private void OnTriggerEnter2D ( Collider2D other )
    {
        if ( other. gameObject. CompareTag ( "MouseHandler" ) )
        {
            MouseHandler_3th. instance. mouseHandler. HandlingObj. Add ( this. gameObject );
        }
    }

    private void OnTriggerExit2D ( Collider2D other )
    {
        if ( other. gameObject. CompareTag ( "MouseHandler" ) )
        {
            MouseHandler_3th. instance. mouseHandler.HandlingObj. Remove ( this. gameObject );
        }
    }

     
    
}
