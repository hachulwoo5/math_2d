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
        originPosition = this.transform.position;       // ��ü�� �� ��ġ�� �����ϱ� ���� �� �ʱ�ȭ

    }
    private void Update()
    {

    }
    private void OnMouseDown()      // ���콺 Ŭ���� ��ü ����
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

        if (dragmode.isDragMode == true)       // �巡�� ��尡 ������ ������, ������ �׸��� �׸��� ��尡 �Ǵ� ��
        {

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);
            // ���콺 ��ġ�� ��Ƴ��� ��ȯ
            MinusPosition = this.transform.position - mousePosition1;
            // ���̳ʽ� ������ = ������ ��ġ - ���콺 ������  >>> ������ �߾ӿ��� ���콺 �������� ������������ ������ �� ����, ���콺�� ��ü�� ��ġ�� ��� ��� ������� �繰�� �״�� ����� 

            if (SqObject.name == "Sq10")
            {
                if (SqObject.transform.position.x <= -4.88f)   // ���콺�� ���� �繰 ��ǥ�� Ư�� ��ġ��� ���� �Լ��� ����
                {
                    Sq10spawn();
                }
            }

            if (SqObject.name == "Sq1")
            {
                if (SqObject.transform.position.x <= -4.17f)   // ���콺�� ���� �繰 ��ǥ�� Ư�� ��ġ��� ���� �Լ��� ����
                {
                    Sq1spawn();
                }
            }
        }
    }

    void OnMouseDrag()                  // ���콺�� �巡�� �� ��
    {
        if (dragmode.isDragMode == true)
        {
            isDraging = true;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = mousePosition1 + MinusPosition;
            // �巡�� �� �������� ���콺 ��ġ�� Ŭ�� ��� ���հ��� ��� ������

        }
    }

    public void OnMouseUp()
    {
        isDraging = false;
    }

    public void OnPointerDown(PointerEventData eventData)      // ���콺 Ŭ���� ��ü ����
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

        if (dragmode.isDragMode == true)       // �巡�� ��尡 ������ ������, ������ �׸��� �׸��� ��尡 �Ǵ� ��
        {

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);
            // ���콺 ��ġ�� ��Ƴ��� ��ȯ
            MinusPosition = this.transform.position - mousePosition1;
            // ���̳ʽ� ������ = ������ ��ġ - ���콺 ������  >>> ������ �߾ӿ��� ���콺 �������� ������������ ������ �� ����, ���콺�� ��ü�� ��ġ�� ��� ��� ������� �繰�� �״�� ����� 

            if (SqObject.name == "Sq10")
            {
                if (SqObject.transform.position.x <= -4.88f)   // ���콺�� ���� �繰 ��ǥ�� Ư�� ��ġ��� ���� �Լ��� ����
                {
                    Sq10spawn();
                }
            }

            if (SqObject.name == "Sq1")
            {
                if (SqObject.transform.position.x<= -4.17f)   // ���콺�� ���� �繰 ��ǥ�� Ư�� ��ġ��� ���� �Լ��� ����
                {
                    Sq1spawn();
                }
            }
        }
    }

    /*
    public void OnDrag(PointerEventData eventData)                  // ���콺�� �巡�� �� ��
    {
        if (dragmode.isDragMode == true)
        {
            isDraging = true;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = mousePosition1 + MinusPosition;
            // �巡�� �� �������� ���콺 ��ġ�� Ŭ�� ��� ���հ��� ��� ������

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
    }       // 10��¥�� ���� ��ȯ

    public void Sq1spawn()
    {
        GameObject clone = Instantiate(SqObject, originPosition, Quaternion.identity);
        clone.name = "Sq1";
        clone.transform.parent = ObjBox.transform;

    }        // 1��¥�� ���� ��ȯ


}