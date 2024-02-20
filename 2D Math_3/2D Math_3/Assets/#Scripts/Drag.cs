using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IPointerUpHandler
{
    // �ڱ� �ڽ����� ���� > ���� ������ �Ҵ�
    public GameObject CloneObj;

    float distance = 10;
    public Vector3 MinusPosition;
    Vector3 originPosition;

    DragMode dragmode;
    ShapesSpawnArea colliderChange;
    ResetAllBt resetAllBt;
    GameManager gameManager;
    BackGruondManager backGruondManager;
    ResetMaster reset;

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
        backGruondManager = GameObject.Find("BackGround").GetComponent<BackGruondManager>();

        originPosition = this.transform.position;       // ��ü�� �� ��ġ�� �����ϱ� ���� �� �ʱ�ȭ
        ObjBox = GameObject.Find("ObjBox");


    }




    private void OnMouseDown()      // ���콺 Ŭ���� ��ü ����
    {

       
        if (this.gameObject.transform.position.x < -2f)
        {
            // peu button, function all off
            resetAllBt.On_OffBt();
            reset = GameObject. Find ( "ResetMaster3" ). GetComponent<ResetMaster> ( );
            reset. resetmaster ( );
        }

        Check = 0;
        if (dragmode.isDragMode == true)       // �巡�� ��尡 ������ ������, ������ �׸��� �׸��� ��尡 �Ǵ� ��
        {


            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);
            // ���콺 ��ġ�� ��Ƴ��� ��ȯ
            MinusPosition = this.transform.position - mousePosition1;
            // ���̳ʽ� ������ = ������ ��ġ - ���콺 ������  >>> ������ �߾ӿ��� ���콺 �������� ������������ ������ �� ����, ���콺�� ��ü�� ��ġ�� ��� ��� ������� �繰�� �״�� ����� 

            if (this.transform.position.x <= -1.8f)
            {
                if (this.transform.name == "1")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;

                    // �̹����� ������ ���� �� ���������� ũ�� !! 
                    clone.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    clone.transform.parent = ObjBox.transform;

                    this.transform.localScale = new Vector3(1, 1, 1);
                }
                if (this.transform.name == "1_2")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    clone.transform.parent = ObjBox.transform;

                    this.transform.localScale = new Vector3(1, 1, 1);

                }
                if (this.transform.name == "1_3")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    clone.transform.parent = ObjBox.transform;

                    this.transform.localScale = new Vector3(1, 1, 1);

                }
                if (this.transform.name == "1_4")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    clone.transform.parent = ObjBox.transform;

                    this.transform.localScale = new Vector3(1, 1, 1);
                }
                if (this.transform.name == "1_5")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    clone.transform.parent = ObjBox.transform;

                    this.transform.localScale = new Vector3(1, 1, 1);
                }
                if (this.transform.name == "1_6")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    clone.transform.parent = ObjBox.transform;

                    this.transform.localScale = new Vector3(1, 1, 1);
                }
                
                if (this.transform.name == "1_8")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
                    clone.transform.parent = ObjBox.transform;

                    this.transform.localScale = new Vector3(1, 1, 1);
                }
                if (this.transform.name == "1_9")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                    clone.transform.parent = ObjBox.transform;

                    this.transform.localScale = new Vector3(1, 1, 1);
                }
                if (this.transform.name == "1_10")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);
                    clone.transform.parent = ObjBox.transform;

                    this.transform.localScale = new Vector3(1, 1, 1);
                }
                if (this.transform.name == "1_12")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.localScale = new Vector3(1,1,1);
                    clone.transform.parent = ObjBox.transform;

                    this.transform.localScale = new Vector3(1, 1, 1);
                }
            }



        }
    }


    public void OnPointerDown(PointerEventData eventData)      // ���콺 Ŭ���� ��ü ����
    {
        

        
        if (this.gameObject.transform.position.x < -2f)
        {
            // peu button, function all off
            resetAllBt.On_OffBt();
            reset = GameObject. Find ( "ResetMaster3" ). GetComponent<ResetMaster> ( );
            reset. resetmaster ( );
        }

        Check = 0;
        if (dragmode.isDragMode == true)       // �巡�� ��尡 ������ ������, ������ �׸��� �׸��� ��尡 �Ǵ� ��
        {


            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);
            // ���콺 ��ġ�� ��Ƴ��� ��ȯ
            MinusPosition = this.transform.position - mousePosition1;
            // ���̳ʽ� ������ = ������ ��ġ - ���콺 ������  >>> ������ �߾ӿ��� ���콺 �������� ������������ ������ �� ����, ���콺�� ��ü�� ��ġ�� ��� ��� ������� �繰�� �״�� ����� 

            if (this.transform.position.x <= -1.8f)
            {
                if (this.transform.name == "1")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;

                    // �̹����� ������ ���� �� ���������� ũ�� !! 
                    clone.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    clone.transform.parent = ObjBox.transform;

                    this.transform.localScale = new Vector3(1, 1, 1);
                }
                if (this.transform.name == "1_2")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.parent = ObjBox.transform;

                }
                if (this.transform.name == "1_3")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.parent = ObjBox.transform;

                }
                if (this.transform.name == "1_4")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.parent = ObjBox.transform;

                }
                if (this.transform.name == "1_5")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.parent = ObjBox.transform;

                }
                if (this.transform.name == "1_6")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.parent = ObjBox.transform;

                }
                if (this.transform.name == "1_7")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.parent = ObjBox.transform;

                }
                if (this.transform.name == "1_8")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.parent = ObjBox.transform;

                }
                if (this.transform.name == "1_9")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.parent = ObjBox.transform;

                }
                if (this.transform.name == "1_10")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.parent = ObjBox.transform;

                }
                if (this.transform.name == "1_12")
                {
                    GameObject clone = Instantiate(CloneObj, originPosition, Quaternion.identity);
                    clone.name = transform.name;
                    clone.transform.parent = ObjBox.transform;

                }
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

    public void OnDrag(PointerEventData eventData)                  // ���콺�� �巡�� �� ��
    {

        if (dragmode.isDragMode == true)
        {
            isDraging = true;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = mousePosition1 + MinusPosition;

        }


    }


    public void OnPointerUp(PointerEventData eventData)  // ���콺 ���� �� 
    {



        Check = 1;
        isDraging = false;
        isOnEnable = true;

    }

    public void OnMouseUp()                             // ���콺 ���� �� 
    {


        Check = 1;
        isDraging = false;      // Draging Quit
        isOnEnable = true;

    }



    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ClearArea") && this.gameObject.CompareTag("Box") && Check == 1)      // Check = 1 >> ���콺 ���� �� ������� 
        {
            Destroy(this.gameObject);
        }

        else if (other.CompareTag("Trash") && this.gameObject.CompareTag("Box") &&  Check == 1)
        {
            Destroy(this.gameObject);
            GameObject.Find("Trash").GetComponent<AudioSource>().Play();
        }
    }


}