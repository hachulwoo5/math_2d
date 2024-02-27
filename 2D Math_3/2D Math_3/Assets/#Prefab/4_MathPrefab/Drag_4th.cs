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
        originPosition = this.transform.position;       // ��ü�� �� ��ġ�� �����ϱ� ���� �� �ʱ�ȭ
        spriteRenderer = GetComponent<SpriteRenderer> ( );
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
            spriteRenderer. sortingOrder = 11;

            if ( SqObject.name == "Sq10")
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

    public void OnPointerDown ( PointerEventData eventData )      // ���콺 Ŭ���� ��ü ����
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

        if ( dragmode. isDragMode == true )       // �巡�� ��尡 ������ ������, ������ �׸��� �׸��� ��尡 �Ǵ� ��
        {

            Vector3 mousePosition = new Vector3 ( Input. mousePosition. x , Input. mousePosition. y , distance );
            Vector3 mousePosition1 = Camera. main. ScreenToWorldPoint ( mousePosition );
            // ���콺 ��ġ�� ��Ƴ��� ��ȯ
            MinusPosition = this. transform. position - mousePosition1;
            // ���̳ʽ� ������ = ������ ��ġ - ���콺 ������  >>> ������ �߾ӿ��� ���콺 �������� ������������ ������ �� ����, ���콺�� ��ü�� ��ġ�� ��� ��� ������� �繰�� �״�� ����� 
            spriteRenderer. sortingOrder = 11;

            if ( SqObject. name == "Sq10" )
            {
                if ( SqObject. transform. position. x <= -4.88f )   // ���콺�� ���� �繰 ��ǥ�� Ư�� ��ġ��� ���� �Լ��� ����
                {
                    Sq10spawn ( );
                }
            }

            if ( SqObject. name == "Sq1" )
            {
                if ( SqObject. transform. position. x <= -4.17f )   // ���콺�� ���� �繰 ��ǥ�� Ư�� ��ġ��� ���� �Լ��� ����
                {
                    Sq1spawn ( );
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

    public void OnMouseUp() // ���콺 ���� ��
    {
        isDraging = false;
        if (isLeft) // 10������ ���ʿ��� ����ȭ
        {
            float alpha = 0.5f;
            Color color = spriteRenderer. color; // ���� ������ ������
            color. a = alpha; // ���İ��� ����
            spriteRenderer. color = color; // ����� ������ �ٽ� ����
            killChance = true;
        }
        else if (isRight)
        {
            float alpha = 0.5f;
            Color color = spriteRenderer. color; // ���� ������ ������
            color. a = alpha; // ���İ��� ����
            spriteRenderer. color = color; // ����� ������ �ٽ� ����
            killChance = true;
        }
        else // �� �κ� ���ָ� ������ ���� ����
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
                    Color color = spriteRenderer. color; // ���� ������ ������
                    color. a = alpha; // ���İ��� ����
                    spriteRenderer. color = color; // ����� ������ �ٽ� ����
                    killChance = false;
                }
            }

        }
        


    }

    public void OnPointerUp ( PointerEventData eventData )
    {
        isDraging = false;
        if ( isLeft ) // 10������ ���ʿ��� ����ȭ
        {
            float alpha = 0.5f;
            Color color = spriteRenderer. color; // ���� ������ ������
            color. a = alpha; // ���İ��� ����
            spriteRenderer. color = color; // ����� ������ �ٽ� ����
            killChance = true;
        }
        else if ( isRight )
        {
            float alpha = 0.5f;
            Color color = spriteRenderer. color; // ���� ������ ������
            color. a = alpha; // ���İ��� ����
            spriteRenderer. color = color; // ����� ������ �ٽ� ����
            killChance = true;
        }
        else // �� �κ� ���ָ� ������ ���� ����
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
                    Color color = spriteRenderer. color; // ���� ������ ������
                    color. a = alpha; // ���İ��� ����
                    spriteRenderer. color = color; // ����� ������ �ٽ� ����
                    killChance = false;
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

    public void OnTriggerEnter2D ( Collider2D other )
    {
        if ( other. CompareTag ( "4_MinusLeft" ) && this. gameObject. name == "Sq10" ) // 10������ ���ʿ��� ����ȭ
        {
            isLeft = true;
        }
        else if ( other. CompareTag ( "4_MinusRight" ) && this. gameObject. name == "Sq1" ) // 10������ ���ʿ��� ����ȭ
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
        if ( other. CompareTag ( "4_MinusLeft" ) && this. gameObject. name == "Sq10" ) // 10������ ���ʿ��� ����ȭ
        {
            isLeft = false;
        }
        else if ( other. CompareTag ( "4_MinusRight" ) && this. gameObject. name == "Sq1" ) // 10������ ���ʿ��� ����ȭ
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