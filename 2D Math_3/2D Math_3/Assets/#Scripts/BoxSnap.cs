using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BoxSnap : MonoBehaviour
{

    GameManager gameManager;
    BackGruondManager backGruondManager;
    private BoxCollider2D _boxCollider2D;

    [SerializeField] private float snapPower = 0.5f;
    float distance = 10f;

    public bool isDestroy, isSnap;
    public int thisIndex =0;

    Vector3 OriginPos;
    Vector3 newPosition;

    public bool isTest;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        backGruondManager = GameObject.Find("BackGround").GetComponent<BackGruondManager>();
    }

    public void OnEnable()
    {
        isDestroy = true;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        isSnap = false;
        OriginPos = this.transform.position;
    }
    private void OnMouseDown()
    {
        isSnap = false;
        OriginPos = this.transform.position;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(SnapToBox());
    }
    private void OnMouseUp() => StartCoroutine(SnapToBox());



    /// <summary>
    /// 알고리즘 
    /// 1. 자신은 검출하지 않기 위해 레이어를 바꿈
    /// 2. index를 설정해 필드의 1개도형만 있을 경우 삭제 안되고, 1개 이상일 때 붙지 않으면 사라짐. ----- ( 기능 삭제됨... > isDestory/isSnap )
    /// 3. 마우스 포지션을 구해서 도형 붙일 때 기준 x 값 넣어줌------ ( 이 기능 안쓰는 중,, 스냅 때 ( 방향Pos (leftpos,uppos 등) / ClickPosition )  중 1개로 설정 가능, SnapToBoxCheck(?,,,);  ? 자리에 넣으면 됨
    /// 4. 1 도형을 검출하는 레이와 나머지 2~12를 검출하는 도형 구분
    /// 
    /// 5. 방향 체크
    ///  ** 순서 : 좌 > 우 > 상 > 하
    ///  5-1. 레이를 쏴서 1도형 또는 일반 도형 검출 
    ///  5-2. 도형이 갈 x,y 좌표를 구한 후 대입, 상태(destroy, snap) 설정 ,, 위로 쏠 때 1 위에 있는 도형 검출 x 아래도 마찬가지 >> 분석 필요
    ///  5-3. 1도형이 검출 안되면 그냥 도형들기리 y축만 스냅함
    ///   5-3-1 그냥 도형들끼리 스냅 시도하고 스냅 성공 할 경우 위로 긴 레이를 쏴서 1도형에 맞춘 위치 정렬, 그러나 좌우 ray가 우선순위 > 새로운 줄에 도형을 첨 붙일 때 깔끔하게 붙도록함. 그 후로는 좌우 ray 우선이라 알아서 정렬
    ///  
    /// 6. ray 돌리고, 상태에 따른 처리 실행\
    /// 7. isTest == SnapToBoxCheck() 함수들이 4개 있는걸 순서대로 실행하는데 앞에서 실행되어 도형을 검출 성공할 경우 true로해서 중복 실행방지, 마지막에 isTest를 false로 초기화해줌.
    /// </summary>
    /// <returns></returns>
    IEnumerator SnapToBox()
    {
        if (transform.position.x < -1.7f)
        {
            yield break;
        }

        int myLayer = gameObject.layer;
        gameObject.layer = LayerMask.GetMask("Ignore Raycast");

        /*
        thisIndex = backGruondManager.BackGroundList.Count;
        if (thisIndex == 1)
        {
            isDestroy = false;
        }
        */

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 ClickPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        newPosition = transform.position;

        Vector2 Leftpos = new Vector2(_boxCollider2D.bounds.min.x, transform.position.y);
        Vector2 Rightpos = new Vector2(_boxCollider2D.bounds.max.x, transform.position.y);
        Vector2 Uppos = new Vector2(transform.position.x, _boxCollider2D.bounds.max.y);
        Vector2 Downpos = new Vector2(transform.position.x, _boxCollider2D.bounds.min.y);

        SnapToBoxCheck(Leftpos, Vector2.left, snapPower, 3);
        SnapToBoxCheck(Rightpos, Vector2.right, snapPower, 4);        
        SnapToBoxCheck(Uppos, Vector2.up, snapPower, 1);
        SnapToBoxCheck(Downpos, Vector2.down, snapPower, 2);

        
        gameObject.layer = myLayer;

        /*
        if (isDestroy ==true )
        {
            backGruondManager.RemoveList(gameObject);
            Destroy(gameObject);
        }
        
        if (isSnap == false && thisIndex != 1 && transform.position.x > -1.9f && transform.position.x <3.9)
        {
            // 스냅 실패시 제자리
            transform.position = OriginPos;
            isSnap = true;
        }
        */
        isTest = false;
        yield return null;
    }
    private void SnapToBoxCheck(Vector2 checkPosition, Vector2 direction, float snapPower, int index)
    {
        if (isTest == true)
            return;

        RaycastHit2D hit_1 = Physics2D.Raycast(checkPosition, direction, snapPower *1f, LayerMask.GetMask("1"));
        RaycastHit2D hitNormal = Physics2D.Raycast(checkPosition, direction, snapPower * 1f, LayerMask.GetMask("Box"));

        // index == 상하좌우 판별 
        if (hit_1)
        {
           // Hit_1(hit_1, hitNormal, index);
           if(index==1)
            {
                transform.position = new Vector2(GetXPosition(hit_1), hit_1.transform.position.y - hit_1.collider.bounds.size.y);
            }
            else if (index ==2)
            {
                transform.position = new Vector2(GetXPosition(hit_1), hit_1.transform.position.y + hit_1.collider.bounds.size.y);
            }

            isDestroy = false;
            isSnap = true;
            isTest = true;
        }
        else if (hitNormal)
        {
            //HitNormal(hitNormal,index);
            switch (index)
            {
                case 1:
                    RaycastHit2D hit_1_Up = Physics2D.Raycast(transform.position, Vector2.up, snapPower * 99f, LayerMask.GetMask("1"));
                    if (hit_1_Up)
                    {
                        transform.position = new Vector2(
                            GetXPosition(hit_1_Up), 
                            hitNormal.transform.position.y - hitNormal.collider.bounds.size.y);

                    }
                    else
                    {
                        transform.position = new Vector2(
                            //transform.position.x,    
                           
                            hitNormal.collider.bounds.min.x+(_boxCollider2D.bounds.size.x * 1/2),  //  1이 아닌 도형끼리의 좌측정렬  
                            hitNormal.transform.position.y - hitNormal.collider.bounds.size.y);
                        Debug.Log("이건가");
                    }
                    break;
                case 2:
                    RaycastHit2D hit_1_Down = Physics2D.Raycast(transform.position, Vector2.down, snapPower * 99f, LayerMask.GetMask("1"));
                    if (hit_1_Down)
                    {
                        transform.position = new Vector2(
                            GetXPosition(hit_1_Down), 
                            hitNormal.transform.position.y + hitNormal.collider.bounds.size.y );
                    }
                    else
                    {
                        transform.position = new Vector2(
                            //transform.position.x,    
                            hitNormal.collider.bounds.min.x + (_boxCollider2D.bounds.size.x * 1 / 2),  //  1이 아닌 도형끼리의 좌측정렬  
                            hitNormal.transform.position.y + hitNormal.collider.bounds.size.y );
                    }
                    break;
                // 좌 우
                case 3:
                    transform.position = new Vector2(
                        
                        hitNormal.collider.bounds.max.x + _boxCollider2D.size.x * 1 / 2,
                        hitNormal.transform.position.y
                        

                        );
                        
                    break;
                case 4:
                    transform.position = new Vector2(
                        hitNormal.collider.bounds.min.x - _boxCollider2D.size.x * 1 / 2,
                        hitNormal.transform.position.y);
                    break;
            }
            isDestroy = false;
            isSnap = true;
            isTest = true;
        }
    }

    /*
    public void Hit_1(RaycastHit2D hit_1, RaycastHit2D hitNormal,int index)
    {
        transform.position = new Vector2(GetXPosition(hit_1), GetYPosition(hit_1, hitNormal, index));   

        isDestroy = false;
        isSnap = true;
    }
    */
    /*
    public void HitNormal(RaycastHit2D hitNormal, int index)
    {
        switch (index)
        {
            case 1:
                Vector2 Uppos = new Vector2(transform.position.x, _boxCollider2D.bounds.max.y);
                RaycastHit2D hit_1_Up = Physics2D.Raycast(Uppos, Vector2.up, snapPower * 99f, LayerMask.GetMask("1"));
                if (hit_1_Up)
                {
                    transform.position = new Vector2(GetXPosition(hit_1_Up), hitNormal.transform.position.y - hitNormal.collider.bounds.size.y);

                }
                else
                {
                    transform.position = new Vector2(transform.position.x, hitNormal.transform.position.y - hitNormal.collider.bounds.size.y);
                }
                break;
            case 2:
                Vector2 Downpos = new Vector2(transform.position.x, _boxCollider2D.bounds.min.y);
                RaycastHit2D hit_1_Down = Physics2D.Raycast(Downpos, Vector2.down, snapPower * 99f, LayerMask.GetMask("1"));
                if (hit_1_Down)
                {
                    transform.position = new Vector2(GetXPosition(hit_1_Down), hitNormal.transform.position.y + hitNormal.collider.bounds.size.y);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x, hitNormal.transform.position.y + hitNormal.collider.bounds.size.y);
                }
                break;
            // 좌 우
            case 3:
                transform.position = new Vector2(hitNormal.collider.bounds.max.x + _boxCollider2D.size.x * 1 / 2
                    , hitNormal.transform.position.y);
                break;
            case 4:
                transform.position = new Vector2(hitNormal.collider.bounds.min.x - _boxCollider2D.size.x * 1 / 2
                    , hitNormal.transform.position.y);
                break;
        }
        isDestroy = false;
        isSnap = true;
    }
    */
    // 도형 유형에 따라서 구역을 나누고 x 좌표를 구하는 함수. Section으로 이어짐
    private float GetXPosition(RaycastHit2D hit)
    {
        float xPosition;

        if (this.transform.name == "1")
        {
            xPosition = hit.collider.bounds.min.x;
        }
        else
        {
            int divisions = int.Parse(this.transform.name.Split('_')[1]);
            float sectionSize = hit.collider.bounds.size.x / divisions;
            int section = Mathf.FloorToInt((hit.point.x - hit.collider.bounds.min.x) / sectionSize);
            xPosition = hit.collider.bounds.min.x + (section * sectionSize);
        }

        return xPosition + _boxCollider2D.bounds.size.x / 2;
    }





    /*
    /// <summary>
    /// 패치 후 쓸모있는지 애매함
    /// 원래 의도 
    ///  1. 상하 레이를 를 조건없이 길게 쏠 때 문제가 생겨서 만든 것 같음. 위에서 아래로 붙일 때 맨 아래 도형으로 스냅되서 ?
    ///   1-1. 노말과 1 도형을 추적하는 레이를 두개쏴서 판별함.. 
    ///  2. 지금은 레이를 바로 가까운 것만 추적하게 쏘고, 조건 부로 도형 스냅 시 긴레이를 쏴서 x값만 받아오기 때문에 하단에 조건문 필요없어짐.....
    /// </summary>
    /// <param name="hit_1"></param>
    /// <param name="hitNormal"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public float GetYPosition(RaycastHit2D hitNormal,int index)
    {
        float yPosition;
        // 위
        switch (index)
        {

            case 1: // 상               
                    newPosition.y = hitNormal.transform.position.y - hitNormal.collider.bounds.size.y;                           
                break;
            case 2: // 하               
                    newPosition.y = hitNormal.transform.position.y + hitNormal.collider.bounds.size.y;                               
                break;
            case 3: // 좌우
                newPosition.y = hitNormal.transform.position.y;
                break;
        }
        yPosition = newPosition.y;
        return yPosition;
    }
    */
   
}