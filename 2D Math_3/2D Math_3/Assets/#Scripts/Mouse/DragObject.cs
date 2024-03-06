using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. EventSystems;

public class DragObject : MonoBehaviour
{

    float distance = 10;
    public Vector3 MinusPosition;
    Vector3 originPosition;

    GameObject ObjBox;
    MouseHandler mouseHandler;
    private void Awake ( )
    {
        if ( GameObject. Find ( "2Scene_RootGameObject" ) != null && GameObject. Find ( "2Scene_RootGameObject" ). activeSelf )
        {
            ObjBox = GameObject. Find ( "ObjBox2" );

            mouseHandler = GameObject. Find ( "�巡�׸Ŵ���2" ). GetComponent<MouseHandler> ( );

        }
        else if ( GameObject. Find ( "3Scene_RootGameObject" ) != null && GameObject. Find ( "3Scene_RootGameObject" ). activeSelf )
        {
            ObjBox = GameObject. Find ( "ObjBox3" );

            mouseHandler = GameObject. Find ( "�巡�׸Ŵ���3" ). GetComponent<MouseHandler> ( );

        }
    }

    private void OnMouseOver ( )
    {
    }
    private void OnMouseEnter ( )
    {
        mouseHandler. mouseHandler. HandlingMode = true; // �̰� �ؾ� �巡�׻簢�� �ȿ��� �߰��� ��������

        Debug. Log ( "asd" );

    }
    private void OnMouseExit ( )
    {
        mouseHandler. mouseHandler. HandlingMode = false;

    }
    private void OnMouseDown ( )      // ���콺 Ŭ���� ��ü ����
    {

        mouseHandler. SuperHandlingMode = true;
        Vector3 mousePosition = new Vector3 ( Input. mousePosition. x , Input. mousePosition. y , distance );
            Vector3 mousePosition1 = Camera. main. ScreenToWorldPoint ( mousePosition );
           
            MinusPosition = this. transform. position - mousePosition1;

        
        
    }


    public void OnPointerDown ( PointerEventData eventData )      // ���콺 Ŭ���� ��ü ����
    {
        mouseHandler. SuperHandlingMode = true;

        Vector3 mousePosition = new Vector3 ( Input. mousePosition. x , Input. mousePosition. y , distance );
        Vector3 mousePosition1 = Camera. main. ScreenToWorldPoint ( mousePosition );

        MinusPosition = this. transform. position - mousePosition1;
    }


    void OnMouseDrag ( )
    {
        

            Vector3 mousePosition = new Vector3 ( Input. mousePosition. x , Input. mousePosition. y , distance );
            Vector3 mousePosition1 = Camera. main. ScreenToWorldPoint ( mousePosition );

            transform. position = mousePosition1 + MinusPosition;

        
    }

    public void OnDrag ( PointerEventData eventData )                  // ���콺�� �巡�� �� ��
    {
        Vector3 mousePosition = new Vector3 ( Input. mousePosition. x , Input. mousePosition. y , distance );
        Vector3 mousePosition1 = Camera. main. ScreenToWorldPoint ( mousePosition );

        transform. position = mousePosition1 + MinusPosition;


    }

    public void OnMouseUp ( )                             // ���콺 ���� �� 
    {
        foreach ( GameObject obj in mouseHandler. copiedObjects )
        {
            // �θ� ObjBox�� �����մϴ�.
            obj. transform. SetParent ( ObjBox. transform );
            
        }
        if ( GameObject. Find ( "2Scene_RootGameObject" ) != null && GameObject. Find ( "2Scene_RootGameObject" ). activeSelf )
        {
            Destroy ( GameObject. Find ( "DragSquare(Clone)" ). gameObject );
        }
        else if ( GameObject. Find ( "3Scene_RootGameObject" ) != null && GameObject. Find ( "3Scene_RootGameObject" ). activeSelf )
        {
            Destroy ( GameObject. Find ( "DragSquare_3th(Clone)" ). gameObject );
        }
        mouseHandler. SetOrigin ( );
        mouseHandler. HandlingMode = false;
        mouseHandler. SuperHandlingMode = false;
    }
    public void OnPointerUp ( PointerEventData eventData )  // ���콺 ���� �� 
    {
        foreach ( GameObject obj in mouseHandler. copiedObjects )
        {
            // �θ� ObjBox�� �����մϴ�.
            obj. transform. SetParent ( ObjBox. transform );

        }
        if ( GameObject. Find ( "2Scene_RootGameObject" ) != null && GameObject. Find ( "2Scene_RootGameObject" ). activeSelf )
        {
            Destroy ( GameObject. Find ( "DragSquare(Clone)" ). gameObject );
        }
        else if ( GameObject. Find ( "3Scene_RootGameObject" ) != null && GameObject. Find ( "3Scene_RootGameObject" ). activeSelf )
        {
            Destroy ( GameObject. Find ( "DragSquare_3th(Clone)" ). gameObject );
        }
        mouseHandler. SetOrigin ( );
        mouseHandler. HandlingMode = false;
        mouseHandler. SuperHandlingMode = false;
    }


    

    
}
