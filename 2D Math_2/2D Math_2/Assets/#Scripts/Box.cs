using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    /// <summary>
    /// 값이 클 수록 멀리있는 객체에게 스냅이 됩니다. 
    /// </summary>
    [SerializeField] private float snapPower=0.1f;

    private BoxCollider2D _boxCollider2D;

     Combine combine; // 외부 스크립트

    // 박스 합치면 만들 오브젝트들
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

    public int Check ;       // 콜라이더 겹치면 박스를 상위박스로 바꾸는데, 콜라이더 겹칠 시 
                             // 양쪽 상자에서 실행되기 때문에 움직였던 박스만 잠깐 check값을 1로 설정해 한 쪽 상자에서만 함수가 실행되도록 함,
                             //  가만히 있는 박스는 0 움직였던 박스는 잠깐동안 1 로 설정됨

    public bool isOneCombine =false; // 박스가 여러개 겹쳤을 때 하나만 만들어지게 하기 위한 변수

    Drag drag;
    Manager manager;
    


    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        drag = GameObject.Find("Sq1").GetComponent<Drag>();
        combine = GameObject.Find("CombineManager").GetComponent<Combine>();


    }



    private void OnMouseDown()      // 마우스를 클릭했을 때 처음 호출 
    {
        Check =0;       
    }

    private void OnMouseDrag()      // 마우스를 클릭하고 드래그 하는 동안 호출
    {
        
    }
    

    private void OnMouseUp()        // 마우스를 놓았을 때 호출
    {

      
        Check =1;
        StartCoroutine(Second()); 
        // 놓는 순간 값을 0.25초간 1을 주어서 합칠 수 있게함. 0.25초 뒤에 다시 0으로 변하면서 합칠 수 없는 상태로 변환. ( 되돌리지 않으면 놓인 상자는 값이 1이돼 언제든 합쳐져서 0으로 설정해 필드에 가만히 있는 상자가 합쳐지는 것을 방지 )
        // isDraging 과 같은 효과
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (this.CompareTag("Sq10") && other.CompareTag("Sq10") && this.gameObject.transform.position.x >= -3.5f && Check == 1)
        {
            // 현재 필요없는 자석효과 스크립트 

           // Vector2 hitPoint = other.transform.position;    //닿은 표면의 위치를 가져옴

           // float radius = _boxCollider2D.bounds.size.x ;   //박스 콜라이더의 반지름

            //hitPoint.x += radius;                              //적용

            //transform.position = hitPoint;                     //이동 적용
        }
       

        #region 1개짜리 큐브 결합


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

        #region 2개짜리 큐브 결합
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

        #region 3개짜리 큐브 결합

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

        #region 4개짜리 큐브 결합

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

        #region 5개짜리 큐브 결합

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

        #region 6개짜리 큐브 결합

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

        #region 7개짜리 큐브 결합

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

        #region 8개짜리 큐브 결합

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

        #region 9개짜리 큐브 결합

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

        #region 옆칸 큐브삭제 
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

        #region 휴지통
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
        // 0.15초 뒤 합칠 수 없는 상태 , Check값을 1에서 0으로 바꿈.
    }

   

    /*
    private void SnapToBox()
    {

        if (this.gameObject.name == "Sq1" && this.gameObject.transform.position.y <= 2.2f)
        {
            
            Vector3 origin = transform.position;          
            RaycastHit2D hit;    
            int myLayer = gameObject.layer;

            #region 위쪽 체크
            origin.y = _boxCollider2D.bounds.max.y;
            gameObject.layer = LayerMask.GetMask("Ignore Raycast");

            //위로 레이를 발사
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

            #region 아래쪽 체크
            origin.y = _boxCollider2D.bounds.min.y;
            gameObject.layer = LayerMask.GetMask("Ignore Raycast");

            //위로 레이를 발사
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