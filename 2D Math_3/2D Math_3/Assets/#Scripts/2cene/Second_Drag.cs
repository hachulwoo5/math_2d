using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Second_Drag : MonoBehaviour
{
    public GameObject CloneObj;

    float distance = 10;
    public Vector3 MinusPosition;
    Vector3 originPosition;

    DragMode dragmode;
    ShapesSpawnArea colliderChange;
    ResetAllBt resetAllBt;
    GameManager gameManager;
    Second_BackManager backGruondManager;

    public bool isDraging;
    public bool isOnEnable = false;
    int Check;

    GameObject ObjBox;


    private void Awake()
    {
        dragmode = GameObject.Find("DragManager").GetComponent<DragMode>();
        colliderChange = GameObject.Find("ShapeSpawnColiider").GetComponent<ShapesSpawnArea>();
        resetAllBt = GameObject.Find("ColorUi_Init").GetComponent<ResetAllBt>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        backGruondManager = GameObject.Find("BackGround").GetComponent<Second_BackManager>();

        originPosition = this.transform.position;       // 물체를 원 위치에 복사하기 위한 값 초기화

        ObjBox = GameObject.Find("ObjBox");

    }




    private void OnMouseDown()      // 마우스 클릭시 물체 복사
    {
        if (this.gameObject.transform.position.x < -2f)
        {
            // peu button, function all off
            resetAllBt.On_OffBt();
        }

        Check = 0;
        if (dragmode.isDragMode == true)       // 드래그 모드가 켜져야 움직임, 꺼지면 그림을 그리는 모드가 되는 것
        {


            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);
            // 마우스 위치를 잡아내고 변환
            MinusPosition = this.transform.position - mousePosition1;
            // 마이너스 포지션 = 도형의 위치 - 마우스 포지션  >>> 도형의 중앙에만 마우스 포지션이 무조건적으로 잡히는 것 방지, 마우스가 물체의 위치를 어딜 잡든 잡은대로 사물이 그대로 따라옴 

            if (this.transform.position.x <= -3.8f)
            {
                GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                clone.name = transform.name;
                clone.transform.parent = ObjBox.transform;
                colliderChange.ShapesList.Add(clone);


            }



        }
    }


    public void OnPointerDown(PointerEventData eventData)      // 마우스 클릭시 물체 복사
    {
        if (this.gameObject.transform.position.x < -2f)
        {
            // peu button, function all off
            resetAllBt.On_OffBt();
        }

        Check = 0;
        if (dragmode.isDragMode == true)       // 드래그 모드가 켜져야 움직임, 꺼지면 그림을 그리는 모드가 되는 것
        {

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);
            // 마우스 위치를 잡아내고 변환
            MinusPosition = this.transform.position - mousePosition1;
            // 마이너스 포지션 = 도형의 위치 - 마우스 포지션  >>> 도형의 중앙에만 마우스 포지션이 무조건적으로 잡히는 것 방지, 마우스가 물체의 위치를 어딜 잡든 잡은대로 사물이 그대로 따라옴 

            if (this.transform.position.x <= -3.8f)
            {
                GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                clone.name = transform.name;
                clone.transform.parent = ObjBox.transform;

                colliderChange.ShapesList.Add(clone);


            }



        }
    }


    void OnMouseDrag()
    {
        if (dragmode.isDragMode == true)
        {
            isDraging = true;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = mousePosition1 + MinusPosition;

        }
    }

    public void OnDrag(PointerEventData eventData)                  // 마우스를 드래그 할 때
    {

        if (dragmode.isDragMode == true)
        {
            isDraging = true;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = mousePosition1 + MinusPosition;

        }


    }


    public void OnPointerUp(PointerEventData eventData)  // 마우스 놓을 때 
    {



        Check = 1;
        isDraging = false;
        isOnEnable = true;

    }

    public void OnMouseUp()                             // 마우스 놓을 때 
    {


        Check = 1;
        isDraging = false;      // Draging Quit
        isOnEnable = true;

    }



    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ClearArea") && this.gameObject.CompareTag("Red") && Check == 1)      // Check = 1 >> 마우스 놓을 때 사라지게 
        {
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("ClearArea") && this.gameObject.CompareTag("Blue") && Check == 1)
        {
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("ClearArea") && this.gameObject.CompareTag("Green") && Check == 1)
        {
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("ClearArea") && this.gameObject.CompareTag("Yellow") && Check == 1)
        {
            Destroy(this.gameObject);
        }
        

        else if (other.CompareTag("Trash") && Check == 1)
        {
            
            Destroy(this.gameObject);
            GameObject.Find("Trash").GetComponent<AudioSource>().Play();
        }
    }


}