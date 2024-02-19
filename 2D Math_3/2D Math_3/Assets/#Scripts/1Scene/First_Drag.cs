using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class First_Drag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject SqObject;

    float distance = 10;

    public Vector3 MinusPosition;
    DragMode dragmode;
    FreeDraw.Drawable drawable;
    ResetMaster reset;
    public bool isDraging;

    Vector3 originPosition;


    GameObject ObjBox;
    private void Awake()
    {
        dragmode = GameObject.Find("DragManager").GetComponent<DragMode>();
        drawable = GameObject.Find("DrawMaster").GetComponent<FreeDraw.Drawable>();
        ObjBox = GameObject.Find("ObjBox");
        originPosition = this.transform.position;       // 물체를 원 위치에 복사하기 위한 값 초기화

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

            if (SqObject.name == "Sq10")
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

    public void OnMouseUp()
    {
        isDraging = false;
    }

    public void OnPointerDown(PointerEventData eventData)      // 마우스 클릭시 물체 복사
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

            if (SqObject.name == "Sq10")
            {
                if (SqObject.transform.position.x <= -4.88f)   // 마우스로 잡은 사물 좌표가 특정 위치라면 복사 함수를 실행
                {
                    Sq10spawn();
                }
            }

            if (SqObject.name == "Sq1")
            {
                if (SqObject.transform.position.x<= -4.17f)   // 마우스로 잡은 사물 좌표가 특정 위치라면 복사 함수를 실행
                {
                    Sq1spawn();
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

    public void OnPointerUp(PointerEventData eventData)
    {
        isDraging = false;
    }


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


}