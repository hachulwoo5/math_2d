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

            mouseHandler = GameObject. Find ( "드래그매니저2" ). GetComponent<MouseHandler> ( );

        }
        else if ( GameObject. Find ( "3Scene_RootGameObject" ) != null && GameObject. Find ( "3Scene_RootGameObject" ). activeSelf )
        {
            ObjBox = GameObject. Find ( "ObjBox3" );

            mouseHandler = GameObject. Find ( "드래그매니저3" ). GetComponent<MouseHandler> ( );

        }
    }

    private void OnMouseOver ( )
    {
    }
    private void OnMouseEnter ( )
    {
        mouseHandler. mouseHandler. HandlingMode = true; // 이걸 해야 드래그사각형 안에서 추가로 생성안함

        Debug. Log ( "asd" );

    }
    private void OnMouseExit ( )
    {
        mouseHandler. mouseHandler. HandlingMode = false;

    }
    private void OnMouseDown ( )      // 마우스 클릭시 물체 복사
    {

        mouseHandler. SuperHandlingMode = true;
        Vector3 mousePosition = new Vector3 ( Input. mousePosition. x , Input. mousePosition. y , distance );
            Vector3 mousePosition1 = Camera. main. ScreenToWorldPoint ( mousePosition );
           
            MinusPosition = this. transform. position - mousePosition1;

        
        
    }


    public void OnPointerDown ( PointerEventData eventData )      // 마우스 클릭시 물체 복사
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

    public void OnDrag ( PointerEventData eventData )                  // 마우스를 드래그 할 때
    {
        Vector3 mousePosition = new Vector3 ( Input. mousePosition. x , Input. mousePosition. y , distance );
        Vector3 mousePosition1 = Camera. main. ScreenToWorldPoint ( mousePosition );

        transform. position = mousePosition1 + MinusPosition;


    }

    public void OnMouseUp ( )                             // 마우스 놓을 때 
    {
        foreach ( GameObject obj in mouseHandler. copiedObjects )
        {
            // 부모를 ObjBox로 설정합니다.
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
    public void OnPointerUp ( PointerEventData eventData )  // 마우스 놓을 때 
    {
        foreach ( GameObject obj in mouseHandler. copiedObjects )
        {
            // 부모를 ObjBox로 설정합니다.
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
