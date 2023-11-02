using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    /// <summary>
    /// ���� Ŭ ���� �ָ��ִ� ��ü���� ������ �˴ϴ�. 
    /// </summary>
    [SerializeField] private float snapPower=0.1f;

    private BoxCollider2D _boxCollider2D;

     Combine combine; // �ܺ� ��ũ��Ʈ

    // �ڽ� ��ġ�� ���� ������Ʈ��
    public GameObject Sq1;
    public GameObject Sq2;
    public GameObject Sq3;
    public GameObject Sq4;
    public GameObject Sq5;
    public GameObject Sq6;
    public GameObject Sq7;
    public GameObject Sq8;
    public GameObject Sq9;
    public GameObject Sq10c;

    public int Check ;       // �ݶ��̴� ��ġ�� �ڽ��� �����ڽ��� �ٲٴµ�, �ݶ��̴� ��ĥ �� 
                             // ���� ���ڿ��� ����Ǳ� ������ �������� �ڽ��� ��� check���� 1�� ������ �� �� ���ڿ����� �Լ��� ����ǵ��� ��,
                             //  ������ �ִ� �ڽ��� 0 �������� �ڽ��� ��񵿾� 1 �� ������

    public bool isOneCombine =false; // �ڽ��� ������ ������ �� �ϳ��� ��������� �ϱ� ���� ����

    Drag drag;
    Manager manager;
    


    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        drag = GameObject.Find("Sq1").GetComponent<Drag>();
        combine = GameObject.Find("CombineManager").GetComponent<Combine>();


    }



    private void OnMouseDown()      // ���콺�� Ŭ������ �� ó�� ȣ�� 
    {
        Check =0;       
    }

    private void OnMouseDrag()      // ���콺�� Ŭ���ϰ� �巡�� �ϴ� ���� ȣ��
    {
        
    }
    

    private void OnMouseUp()        // ���콺�� ������ �� ȣ��
    {

      
        Check =1;
        StartCoroutine(Second()); 
        // ���� ���� ���� 0.25�ʰ� 1�� �־ ��ĥ �� �ְ���. 0.25�� �ڿ� �ٽ� 0���� ���ϸ鼭 ��ĥ �� ���� ���·� ��ȯ. ( �ǵ����� ������ ���� ���ڴ� ���� 1�̵� ������ �������� 0���� ������ �ʵ忡 ������ �ִ� ���ڰ� �������� ���� ���� )
        // isDraging �� ���� ȿ��
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (this.CompareTag("Sq10") && other.CompareTag("Sq10") && this.gameObject.transform.position.x >= -3.5f && Check == 1)
        {
            // ���� �ʿ���� �ڼ�ȿ�� ��ũ��Ʈ 

           // Vector2 hitPoint = other.transform.position;    //���� ǥ���� ��ġ�� ������

           // float radius = _boxCollider2D.bounds.size.x ;   //�ڽ� �ݶ��̴��� ������

            //hitPoint.x += radius;                              //����

            //transform.position = hitPoint;                     //�̵� ����
        }
       

        #region 1��¥�� ť�� ����


        if (this.CompareTag("Sq1") && other.CompareTag("Sq1") && this.gameObject.transform.position.x >= -3.5f && Check== 1 && combine.isCombine == true && isOneCombine ==false)
        {
            isOneCombine = true;
            Destroy(other.gameObject);

           
            GameObject clone = Instantiate(Sq2, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq2";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq1") && other.CompareTag("Sq2") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq3, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq3";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq1") && other.CompareTag("Sq3") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq4, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq4";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq1") && other.CompareTag("Sq4") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq5, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq5";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq1") && other.CompareTag("Sq5") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq6, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq6";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq1") && other.CompareTag("Sq6") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq7, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq7";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq1") && other.CompareTag("Sq7") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq8, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq8";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq1") && other.CompareTag("Sq8") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq9, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "S9";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq1") && other.CompareTag("Sq9") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            GameObject.Find("Trash").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq10c, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq10c";

            Destroy(this.gameObject);
        }
        #endregion

        #region 2��¥�� ť�� ����
        if (this.CompareTag("Sq2") && other.CompareTag("Sq1") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq3, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq3";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq2") && other.CompareTag("Sq2") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq4, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq4";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq2") && other.CompareTag("Sq3") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq5, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq5";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq2") && other.CompareTag("Sq4") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq6, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq6";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq2") && other.CompareTag("Sq5") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false) 
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq7, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq7";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq2") && other.CompareTag("Sq6") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq8, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq8";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq2") && other.CompareTag("Sq7") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq9, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq9";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq2") && other.CompareTag("Sq8") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            GameObject.Find("Trash").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq10c, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq10c";

            Destroy(this.gameObject);
        }
        #endregion

        #region 3��¥�� ť�� ����

        if (this.CompareTag("Sq3") && other.CompareTag("Sq1") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq4, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq4";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq3") && other.CompareTag("Sq2") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq5, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq5";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq3") && other.CompareTag("Sq3") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq6, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq6";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq3") && other.CompareTag("Sq4") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq7, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq7";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq3") && other.CompareTag("Sq5") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq8, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq8";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq3") && other.CompareTag("Sq6") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq9, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq9";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq3") && other.CompareTag("Sq7") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            GameObject.Find("Trash").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq10c, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq10c";

            Destroy(this.gameObject);
        }
        #endregion

        #region 4��¥�� ť�� ����

        if (this.CompareTag("Sq4") && other.CompareTag("Sq1") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq5, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq5";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq4") && other.CompareTag("Sq2") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq6, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq6";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq4") && other.CompareTag("Sq3") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq7, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq7";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq4") && other.CompareTag("Sq4") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq8, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq8";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq4") && other.CompareTag("Sq5") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq9, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq9";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq4") && other.CompareTag("Sq6") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            GameObject.Find("Trash").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq10c, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq10c";

            Destroy(this.gameObject);
        }
        #endregion

        #region 5��¥�� ť�� ����

        if (this.CompareTag("Sq5") && other.CompareTag("Sq1") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq6, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq6";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq5") && other.CompareTag("Sq2") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq7, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq7";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq5") && other.CompareTag("Sq3") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq8, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq8";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq5") && other.CompareTag("Sq4") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq9, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq9";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq5") && other.CompareTag("Sq5") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            GameObject.Find("Trash").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq10c, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq10c";

            Destroy(this.gameObject);
        }
        #endregion

        #region 6��¥�� ť�� ����

        if (this.CompareTag("Sq6") && other.CompareTag("Sq1") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq7, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq7";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq6") && other.CompareTag("Sq2") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq8, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq8";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq6") && other.CompareTag("Sq3") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq9, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq9";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq6") && other.CompareTag("Sq4") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            GameObject.Find("Trash").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq10c, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq10c";

            Destroy(this.gameObject);
        }
        #endregion

        #region 7��¥�� ť�� ����

        if (this.CompareTag("Sq7") && other.CompareTag("Sq1") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq8, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq8";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq7") && other.CompareTag("Sq2") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq9, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq9";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq7") && other.CompareTag("Sq3") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            GameObject.Find("Trash").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq10c, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq10c";

            Destroy(this.gameObject);
        }

        #endregion

        #region 8��¥�� ť�� ����

        if (this.CompareTag("Sq8") && other.CompareTag("Sq1") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq9, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq9";

            Destroy(this.gameObject);
        }
        if (this.CompareTag("Sq8") && other.CompareTag("Sq2") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            GameObject.Find("Trash").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq10c, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq10c";

            Destroy(this.gameObject);
        }
        #endregion

        #region 9��¥�� ť�� ����

        if (this.CompareTag("Sq9") && other.CompareTag("Sq1") && this.gameObject.transform.position.x >= -3.5f && Check == 1 && combine.isCombine == true && isOneCombine == false)
        {
            isOneCombine = true;

            GameObject.Find("Trash").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);

            GameObject clone = Instantiate(Sq10c, other.gameObject.transform.position, Quaternion.identity);
            clone.name = "Sq10c";

            Destroy(this.gameObject);
        }
        #endregion

        #region ��ĭ ť����� 
        if(other.CompareTag("Left") && this.gameObject.CompareTag("Sq1") && Check == 1)
         {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Left") && this.gameObject.CompareTag("Sq2") && Check == 1)
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Left") && this.gameObject.CompareTag("Sq3") && Check == 1)
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Left") && this.gameObject.CompareTag("Sq4") && Check == 1)
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Left") && this.gameObject.CompareTag("Sq5") && Check == 1)
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Left") && this.gameObject.CompareTag("Sq6") && Check == 1)
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Left") && this.gameObject.CompareTag("Sq7") && Check == 1)
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Left") && this.gameObject.CompareTag("Sq8") && Check == 1)
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Left") && this.gameObject.CompareTag("Sq9") && Check == 1)
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Right") && this.gameObject.CompareTag("Sq10") && Check == 1)
        {
            Destroy(this.gameObject);
        }
        #endregion

        #region ������
        if (other.CompareTag("Trash") && this.gameObject.CompareTag("Sq1") && Check == 1)
        {
            GameObject.Find("SoundTrash").GetComponent<AudioSource>().Play();

            Destroy(this.gameObject);
        }
        if (other.CompareTag("Trash") && this.gameObject.CompareTag("Sq2") && Check == 1)
        {
            GameObject.Find("SoundTrash").GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Trash") && this.gameObject.CompareTag("Sq3") && Check == 1)
        {
            GameObject.Find("SoundTrash").GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Trash") && this.gameObject.CompareTag("Sq4") && Check == 1)
        {
            GameObject.Find("SoundTrash").GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Trash") && this.gameObject.CompareTag("Sq5") && Check == 1)
        {
            GameObject.Find("SoundTrash").GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Trash") && this.gameObject.CompareTag("Sq6") && Check == 1)
        {
            GameObject.Find("SoundTrash").GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Trash") && this.gameObject.CompareTag("Sq7") && Check == 1)
        {
            GameObject.Find("SoundTrash").GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Trash") && this.gameObject.CompareTag("Sq8") && Check == 1)
        {
            GameObject.Find("SoundTrash").GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Trash") && this.gameObject.CompareTag("Sq9") && Check == 1)
        {
            GameObject.Find("SoundTrash").GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Trash") && this.gameObject.CompareTag("Sq10") && Check == 1)
        {
            GameObject.Find("SoundTrash").GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Trash") && this.gameObject.CompareTag("Sq10c") && Check == 1)
        {

            GameObject.Find("SoundTrash").GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
        #endregion


    }
    
    IEnumerator Second()
    {
        yield return new WaitForSeconds(0.15f);
        Check = 0;
        // 0.15�� �� ��ĥ �� ���� ���� , Check���� 1���� 0���� �ٲ�.
    }

   

    /*
    private void SnapToBox()
    {

        if (this.gameObject.name == "Sq1" && this.gameObject.transform.position.y <= 2.2f)
        {
            
            Vector3 origin = transform.position;          
            RaycastHit2D hit;    
            int myLayer = gameObject.layer;

            #region ���� üũ
            origin.y = _boxCollider2D.bounds.max.y;
            gameObject.layer = LayerMask.GetMask("Ignore Raycast");

            //���� ���̸� �߻�
            hit = Physics2D.Raycast(origin, Vector2.up, snapPower*0.1f,LayerMask.GetMask("Box"));

           
            if (hit)
            {

                if(hit.collider.gameObject.CompareTag("Sq1") && Mathf.Abs(hit.collider.bounds.min.y- origin.y)<= 0.06f )
                {
                    Destroy(hit.collider.gameObject);

                    GameObject clone = Instantiate(Sq2, hit.collider.gameObject.transform.position, Quaternion.identity);
                    clone.name = "Sq2";

                    Destroy(this.gameObject);
                }
            }

            #endregion

            #region �Ʒ��� üũ
            origin.y = _boxCollider2D.bounds.min.y;
            gameObject.layer = LayerMask.GetMask("Ignore Raycast");

            //���� ���̸� �߻�
            hit = Physics2D.Raycast(origin, Vector2.down, snapPower * 0.1f, LayerMask.GetMask("Box"));

            if (hit)
            {

                if (hit.collider.gameObject.CompareTag("Sq1") && Mathf.Abs( origin.y- hit.collider.bounds.max.y ) <= 0.06f)
                {
                    Destroy(hit.collider.gameObject);

                    GameObject clone = Instantiate(Sq2, hit.collider.gameObject.transform.position, Quaternion.identity);
                    clone.name = "Sq2";

                    Destroy(this.gameObject);
                }
            }

            #endregion




            gameObject.layer = myLayer;
        }

       

    }

    */
}