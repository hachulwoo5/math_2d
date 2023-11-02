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

    public bool isDraging;

    private void Awake()
    {
        dragmode =GameObject.Find("DragManager").GetComponent<DragMode>();
    }
    private void Update()
    {
        
    }
    private void OnMouseDown()      // ���콺 Ŭ���� ��ü ����
    {
        if(dragmode.isDragMode==true)       // �巡�� ��尡 ������ ������, ������ �׸��� �׸��� ��尡 �Ǵ� ��
        {
           
           Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
           Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);
            // ���콺 ��ġ�� ��Ƴ��� ��ȯ
           MinusPosition = SqObject.transform.position - mousePosition1;
            // ���̳ʽ� ������ = ������ ��ġ - ���콺 ������  >>> ������ �߾ӿ��� ���콺 �������� ������������ ������ �� ����, ���콺�� ��ü�� ��ġ�� ��� ��� ������� �繰�� �״�� ����� 

            if (SqObject.name == "Sq10")
            {
                Vector3 Sq10Spawn = new Vector3(-4.887f, 1.601f, 0);
                if (SqObject.transform.position == Sq10Spawn)   // ���콺�� ���� �繰 ��ǥ�� Ư�� ��ġ��� ���� �Լ��� ����
                {
                    Sq10spawn();
                }
            }

            if (SqObject.name == "Sq1")
            {
                Vector3 Sq1Spawn = new Vector3(-3.988f, 1.672f, 0);
                if (SqObject.transform.position == Sq1Spawn)   // ���콺�� ���� �繰 ��ǥ�� Ư�� ��ġ��� ���� �Լ��� ����
                {
                    Sq1spawn();
                }
            }
        }
    }

    void OnMouseDrag()                  // ���콺�� �巡�� �� ��
    {
        if(dragmode.isDragMode==true)
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
        if (dragmode.isDragMode == true)       // �巡�� ��尡 ������ ������, ������ �׸��� �׸��� ��尡 �Ǵ� ��
        {

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);
            // ���콺 ��ġ�� ��Ƴ��� ��ȯ
            MinusPosition = SqObject.transform.position - mousePosition1;
            // ���̳ʽ� ������ = ������ ��ġ - ���콺 ������  >>> ������ �߾ӿ��� ���콺 �������� ������������ ������ �� ����, ���콺�� ��ü�� ��ġ�� ��� ��� ������� �繰�� �״�� ����� 

            if (SqObject.name == "Sq10")
            {
                Vector3 Sq10Spawn = new Vector3(-4.887f, 1.601f, 0);
                if (SqObject.transform.position == Sq10Spawn)   // ���콺�� ���� �繰 ��ǥ�� Ư�� ��ġ��� ���� �Լ��� ����
                {
                    Sq10spawn();
                }
            }

            if (SqObject.name == "Sq1")
            {
                Vector3 Sq1Spawn = new Vector3(-3.988f, 1.672f, 0);
                if (SqObject.transform.position == Sq1Spawn)   // ���콺�� ���� �繰 ��ǥ�� Ư�� ��ġ��� ���� �Լ��� ����
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
        Vector3 Sq10Spawn = new Vector3(-4.887f, 1.601f, 0);            // �ش� ��ġ���� �����
        GameObject clone =Instantiate(SqObject, Sq10Spawn, Quaternion.identity);
        clone.name = "Sq10";
    }       // 10��¥�� ���� ��ȯ

    public void Sq1spawn()
    {
        Vector3 Sq1Spawn = new Vector3(-3.988f, 1.672f, 0);              // �ش� ��ġ���� �����
        GameObject clone = Instantiate(SqObject, Sq1Spawn, Quaternion.identity);
        clone.name = "Sq1";
    }        // 1��¥�� ���� ��ȯ


}
