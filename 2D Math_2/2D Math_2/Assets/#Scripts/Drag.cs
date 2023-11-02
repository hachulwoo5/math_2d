using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour,  IPointerUpHandler
{
    public GameObject CloneObj;
    
    float distance = 10;
    public Vector3 MinusPosition;

    DragMode dragmode;
    ShapesSpawnArea colliderChange;
    ResetAllBt resetAllBt;
    GameManager gameManager;

    public bool isDraging;

    int Check; 

    public GameObject colorobj1;
    public GameObject colorobj2;
    public GameObject colorobj3;
    public GameObject colorobj4;

    private void Awake()
    {
        dragmode =GameObject.Find("DragManager").GetComponent<DragMode>();
        colliderChange = GameObject.Find("ShapeSpawnColiider").GetComponent<ShapesSpawnArea>();
        resetAllBt = GameObject.Find("ColorUi_Init").GetComponent<ResetAllBt>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        
    }
    
    
    

    private void OnMouseDown()      // ���콺 Ŭ���� ��ü ����
    {
        if (this.gameObject.transform.position.x < -4.0f)
        {
            // peu button, function all off
            resetAllBt.On_OffBt();
        }

        Check = 0;
        if (dragmode.isDragMode==true)       // �巡�� ��尡 ������ ������, ������ �׸��� �׸��� ��尡 �Ǵ� ��
        {
           
           Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
           Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);
            // ���콺 ��ġ�� ��Ƴ��� ��ȯ
           MinusPosition = CloneObj.transform.position - mousePosition1;
            // ���̳ʽ� ������ = ������ ��ġ - ���콺 ������  >>> ������ �߾ӿ��� ���콺 �������� ������������ ������ �� ����, ���콺�� ��ü�� ��ġ�� ��� ��� ������� �繰�� �״�� ����� 


            // Check Position Before Copy
            Vector3 GreenSpawn = new Vector3(-4.6f, 0.2f, 0);
            if (CloneObj.transform.position == GreenSpawn)
            {
                GreenObj();
            }
            Vector3 RedSpawn = new Vector3(-4.6f, -0.6f, 0);
            if (CloneObj.transform.position == RedSpawn)
            {
                RedObj();
            }
            Vector3 BlueSpawn = new Vector3(-4.6f, -1.4f, 0);
            if (CloneObj.transform.position == BlueSpawn)
            {
                BlueObj();
            }
            Vector3 BlackSpawn = new Vector3(-4.6f, -2.2f, 0);
            if (CloneObj.transform.position == BlackSpawn)
            {
                YellowObj();
            }
            gameManager.PlusButOn.gameObject.SetActive(false);
        }
    }

    
    public void OnPointerDown(PointerEventData eventData)      // ���콺 Ŭ���� ��ü ����
    {
        if(this.gameObject.transform.position.x < -4.0f)
        {
            resetAllBt.On_OffBt();
        }
       

         Check = 0;
        if (dragmode.isDragMode == true)       // �巡�� ��尡 ������ ������, ������ �׸��� �׸��� ��尡 �Ǵ� ��
        {

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 mousePosition1 = Camera.main.ScreenToWorldPoint(mousePosition);
            // ���콺 ��ġ�� ��Ƴ��� ��ȯ
            MinusPosition = CloneObj.transform.position - mousePosition1;
            // ���̳ʽ� ������ = ������ ��ġ - ���콺 ������  >>> ������ �߾ӿ��� ���콺 �������� ������������ ������ �� ����, ���콺�� ��ü�� ��ġ�� ��� ��� ������� �繰�� �״�� ����� 


            // Check Position Before Copy
            Vector3 GreenSpawn = new Vector3(-4.6f, 0.2f, 0);
            if (CloneObj.transform.position == GreenSpawn)
            {
                GreenObj();
            }
            Vector3 RedSpawn = new Vector3(-4.6f, -0.6f, 0);
            if (CloneObj.transform.position == RedSpawn)
            {
                RedObj();
            }
            Vector3 BlueSpawn = new Vector3(-4.6f, -1.4f, 0);
            if (CloneObj.transform.position == BlueSpawn)
            {
                BlueObj();
            }
            Vector3 BlackSpawn = new Vector3(-4.6f, -2.2f, 0);
            if (CloneObj.transform.position == BlackSpawn)
            {
                YellowObj();
            }
            gameManager.PlusButOn.gameObject.SetActive(false);


        }


    }


    void OnMouseDrag()                  
    {
        if(dragmode.isDragMode==true)
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

    }

    public void OnMouseUp()                             // ���콺 ���� �� 
    {
        

        Check = 1;
        isDraging = false;      // Draging Quit

    }









    // Mouse Drag > Copy Obj
    public void GreenObj()    
    {
        Vector3 CopyObjSpawn = new Vector3(-4.6f, 0.2f, 0);
       
        GameObject clone = Instantiate(CloneObj, CopyObjSpawn, Quaternion.identity);
        clone.name = "GreenObj";
        colliderChange.ShapesList.Add(clone);
    }
    public void RedObj()
    {
        Vector3 CopyObjSpawn = new Vector3(-4.6f, -0.6f, 0);
        GameObject clone = Instantiate(CloneObj, CopyObjSpawn, Quaternion.identity);
        clone.name = "RedObj";
        colliderChange.ShapesList.Add(clone);
    }
    public void BlueObj()
    {
        Vector3 CopyObjSpawn = new Vector3(-4.6f, -1.4f, 0);
        GameObject clone = Instantiate(CloneObj, CopyObjSpawn, Quaternion.identity);
        clone.name = "BlueObj";
        colliderChange.ShapesList.Add(clone);
    }
    public void YellowObj()
    {
        
        Vector3 CopyObjSpawn = new Vector3(-4.6f, -2.2f, 0);
        GameObject clone = Instantiate(CloneObj, CopyObjSpawn, Quaternion.identity);
        clone.name = "YellowObj";
        colliderChange.ShapesList.Add(clone);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ClearArea") && this.gameObject.CompareTag("Red") && Check == 1  )      // Check = 1 >> ���콺 ���� �� ������� 
        {
            Destroy(this.gameObject);
        }
        else if(other.CompareTag("ClearArea") && this.gameObject.CompareTag("Blue") && Check == 1)
        {
            Destroy(this.gameObject);
        }
        else if(other.CompareTag("ClearArea") && this.gameObject.CompareTag("Green") && Check == 1)
        {
            Destroy(this.gameObject);
        }
        else if(other.CompareTag("ClearArea") && this.gameObject.CompareTag("Yellow") && Check == 1)
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
