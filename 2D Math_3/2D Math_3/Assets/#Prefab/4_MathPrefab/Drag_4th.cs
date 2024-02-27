using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag_4th : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject SqObject;

    float distance = 10;

    public Vector3 MinusPosition;
    DragMode dragmode;
    FreeDraw.Drawable drawable;
    ResetMaster reset;
    public bool isDraging;
    SpriteRenderer spriteRenderer;

    Vector3 originPosition;

    public bool isLeft;
    public bool isRight;
    public bool killChance;

    GameObject ObjBox;
    public GameObject duplicatedObj;


    private void Awake()
    {
        dragmode = GameObject.Find("DragManager").GetComponent<DragMode>();
        drawable = GameObject.Find("DrawMaster").GetComponent<FreeDraw.Drawable>();
        ObjBox = GameObject.Find("ObjBox");
        originPosition = this.transform.position;       // 물체를 원 위치에 복사하기 위한 값 초기화
        spriteRenderer = GetComponent<SpriteRenderer> ( );
    }
    private void Update()
    {

    }
    private void OnMouseDown()      // 마우스 클릭시 물체 복사
    {
        if (this.gameObject.transform.position.x < -3.5f)
        {
            drawable.GetComponent<BoxCollider2D>().enabled = false;
            drawable.isPenMode = false;
            dragmode.isDragMode = true;
            GameObject.Find("Pen").GetComponent<PenManager>().PenColorChangeBut();

            reset = GameObject.Find("ResetMaster").GetComponent<ResetMaster>();
            reset.resetmaster();

        }

        if (dragmode.isDragMode == true)       // 드래그 모드가 켜져야 움직임, 꺼지면 그림을 그리는 모드가 되는 것
        {

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);
            // 마우스 위치를 잡아내고 변환
            MinusPosition = this.transform.position - mousePosition1;
            // 마이너스 포지션 = 도형의 위치 - 마우스 포지션  >>> 도형의 중앙에만 마우스 포지션이 무조건적으로 잡히는 것 방지, 마우스가 물체의 위치를 어딜 잡든 잡은대로 사물이 그대로 따라옴 
            spriteRenderer. sortingOrder = 11;

            if ( SqObject.name == "Sq10")
            {
                if (SqObject.transform.position.x <= -4.88f)   // 마우스로 잡은 사물 좌표가 특정 위치라면 복사 함수를 실행
                {
                    Sq10spawn();
                }
            }

            if (SqObject.name == "Sq1")
            {
                if (SqObject.transform.position.x <= -4.17f)   // 마우스로 잡은 사물 좌표가 특정 위치라면 복사 함수를 실행
                {
                    Sq1spawn();
                }
            }
        }
    }

    public void OnPointerDown ( PointerEventData eventData )      // 마우스 클릭시 물체 복사
    {
        if ( this. gameObject. transform. position. x < -3.5f )
        {
            drawable. GetComponent<BoxCollider2D> ( ). enabled = false;
            drawable. isPenMode = false;
            dragmode. isDragMode = true;
            GameObject. Find ( "Pen" ). GetComponent<PenManager> ( ). PenColorChangeBut ( );

            reset = GameObject. Find ( "ResetMaster" ). GetComponent<ResetMaster> ( );
            reset. resetmaster ( );

        }

        if ( dragmode. isDragMode == true )       // 드래그 모드가 켜져야 움직임, 꺼지면 그림을 그리는 모드가 되는 것
        {

            Vector3 mousePosition = new Vector3 ( Input. mousePosition. x , Input. mousePosition. y , distance );
            Vector3 mousePosition1 = Camera. main. ScreenToWorldPoint ( mousePosition );
            // 마우스 위치를 잡아내고 변환
            MinusPosition = this. transform. position - mousePosition1;
            // 마이너스 포지션 = 도형의 위치 - 마우스 포지션  >>> 도형의 중앙에만 마우스 포지션이 무조건적으로 잡히는 것 방지, 마우스가 물체의 위치를 어딜 잡든 잡은대로 사물이 그대로 따라옴 
            spriteRenderer. sortingOrder = 11;

            if ( SqObject. name == "Sq10" )
            {
                if ( SqObject. transform. position. x <= -4.88f )   // 마우스로 잡은 사물 좌표가 특정 위치라면 복사 함수를 실행
                {
                    Sq10spawn ( );
                }
            }

            if ( SqObject. name == "Sq1" )
            {
                if ( SqObject. transform. position. x <= -4.17f )   // 마우스로 잡은 사물 좌표가 특정 위치라면 복사 함수를 실행
                {
                    Sq1spawn ( );
                }
            }
        }
    }
    void OnMouseDrag()                  // 마우스를 드래그 할 때
    {
        if (dragmode.isDragMode == true)
        {
            isDraging = true;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = mousePosition1 + MinusPosition;
            // 드래그 시 움직임은 마우스 위치에 클릭 당시 차잇값을 계속 더해줌

        }
    }

    public void OnMouseUp() // 마우스 놓을 때
    {
        isDraging = false;
        if (isLeft) // 10도형은 왼쪽에서 투명화
        {
            float alpha = 0.5f;
            Color color = spriteRenderer. color; // 현재 색상을 가져옴
            color. a = alpha; // 알파값을 변경
            spriteRenderer. color = color; // 변경된 색상을 다시 설정
            killChance = true;
        }
        else if (isRight)
        {
            float alpha = 0.5f;
            Color color = spriteRenderer. color; // 현재 색상을 가져옴
            color. a = alpha; // 알파값을 변경
            spriteRenderer. color = color; // 변경된 색상을 다시 설정
            killChance = true;
        }
        else // 이 부분 없애면 투명은 영구 투명
        {
            if ( killChance == true )
            {
                if ( this. killChance && duplicatedObj && ( duplicatedObj. gameObject. name == "Sq1" || duplicatedObj. gameObject. name == "Sq10" ) )
                {
                    Debug. Log ( "2" );
                    DeleteSq ( duplicatedObj );
                }
                else
                {
                    Debug. Log ( "1" );
                    float alpha = 1f;
                    Color color = spriteRenderer. color; // 현재 색상을 가져옴
                    color. a = alpha; // 알파값을 변경
                    spriteRenderer. color = color; // 변경된 색상을 다시 설정
                    killChance = false;
                }
            }

        }
        


    }

    public void OnPointerUp ( PointerEventData eventData )
    {
        isDraging = false;
        if ( isLeft ) // 10도형은 왼쪽에서 투명화
        {
            float alpha = 0.5f;
            Color color = spriteRenderer. color; // 현재 색상을 가져옴
            color. a = alpha; // 알파값을 변경
            spriteRenderer. color = color; // 변경된 색상을 다시 설정
            killChance = true;
        }
        else if ( isRight )
        {
            float alpha = 0.5f;
            Color color = spriteRenderer. color; // 현재 색상을 가져옴
            color. a = alpha; // 알파값을 변경
            spriteRenderer. color = color; // 변경된 색상을 다시 설정
            killChance = true;
        }
        else // 이 부분 없애면 투명은 영구 투명
        {
            if ( killChance == true )
            {
                if ( this. killChance && duplicatedObj && ( duplicatedObj. gameObject. name == "Sq1" || duplicatedObj. gameObject. name == "Sq10" ) )
                {
                    Debug. Log ( "2" );
                    DeleteSq ( duplicatedObj );
                }
                else
                {
                    Debug. Log ( "1" );
                    float alpha = 1f;
                    Color color = spriteRenderer. color; // 현재 색상을 가져옴
                    color. a = alpha; // 알파값을 변경
                    spriteRenderer. color = color; // 변경된 색상을 다시 설정
                    killChance = false;
                }
            }

        }



    }


    /*
    public void OnDrag(PointerEventData eventData)                  // 마우스를 드래그 할 때
    {
        if (dragmode.isDragMode == true)
        {
            isDraging = true;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = mousePosition1 + MinusPosition;
            // 드래그 시 움직임은 마우스 위치에 클릭 당시 차잇값을 계속 더해줌

        }
    }
    */



    public void Sq10spawn()
    {
        GameObject clone = Instantiate(SqObject, originPosition, Quaternion.identity);
        clone.name = "Sq10";
        clone.transform.parent = ObjBox.transform;
    }       // 10개짜리 도형 소환

    public void Sq1spawn()
    {
        GameObject clone = Instantiate(SqObject, originPosition, Quaternion.identity);
        clone.name = "Sq1";
        clone.transform.parent = ObjBox.transform;

    }        // 1개짜리 도형 소환

    public void OnTriggerEnter2D ( Collider2D other )
    {
        if ( other. CompareTag ( "4_MinusLeft" ) && this. gameObject. name == "Sq10" ) // 10도형은 왼쪽에서 투명화
        {
            isLeft = true;
        }
        else if ( other. CompareTag ( "4_MinusRight" ) && this. gameObject. name == "Sq1" ) // 10도형은 왼쪽에서 투명화
        {
            isRight = true;
        }

        if ( other. gameObject. name =="Sq1" || other. gameObject. name == "Sq10" )
        {
            duplicatedObj = other. gameObject;
        }
    }

    public void OnTriggerExit2D ( Collider2D other )
    {
        if ( other. CompareTag ( "4_MinusLeft" ) && this. gameObject. name == "Sq10" ) // 10도형은 왼쪽에서 투명화
        {
            isLeft = false;
        }
        else if ( other. CompareTag ( "4_MinusRight" ) && this. gameObject. name == "Sq1" ) // 10도형은 왼쪽에서 투명화
        {
            isRight = false;
        }
        duplicatedObj = null;
    }

    void DeleteSq(GameObject obj)
    {
            Destroy ( obj. gameObject );
            Destroy ( this. gameObject );
        
    }

    
}