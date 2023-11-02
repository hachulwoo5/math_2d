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
    /// �˰��� 
    /// 1. �ڽ��� �������� �ʱ� ���� ���̾ �ٲ�
    /// 2. index�� ������ �ʵ��� 1�������� ���� ��� ���� �ȵǰ�, 1�� �̻��� �� ���� ������ �����. ----- ( ��� ������... > isDestory/isSnap )
    /// 3. ���콺 �������� ���ؼ� ���� ���� �� ���� x �� �־���------ ( �� ��� �Ⱦ��� ��,, ���� �� ( ����Pos (leftpos,uppos ��) / ClickPosition )  �� 1���� ���� ����, SnapToBoxCheck(?,,,);  ? �ڸ��� ������ ��
    /// 4. 1 ������ �����ϴ� ���̿� ������ 2~12�� �����ϴ� ���� ����
    /// 
    /// 5. ���� üũ
    ///  ** ���� : �� > �� > �� > ��
    ///  5-1. ���̸� ���� 1���� �Ǵ� �Ϲ� ���� ���� 
    ///  5-2. ������ �� x,y ��ǥ�� ���� �� ����, ����(destroy, snap) ���� ,, ���� �� �� 1 ���� �ִ� ���� ���� x �Ʒ��� �������� >> �м� �ʿ�
    ///  5-3. 1������ ���� �ȵǸ� �׳� ������⸮ y�ุ ������
    ///   5-3-1 �׳� �����鳢�� ���� �õ��ϰ� ���� ���� �� ��� ���� �� ���̸� ���� 1������ ���� ��ġ ����, �׷��� �¿� ray�� �켱���� > ���ο� �ٿ� ������ ÷ ���� �� ����ϰ� �ٵ�����. �� �ķδ� �¿� ray �켱�̶� �˾Ƽ� ����
    ///  
    /// 6. ray ������, ���¿� ���� ó�� ����\
    /// 7. isTest == SnapToBoxCheck() �Լ����� 4�� �ִ°� ������� �����ϴµ� �տ��� ����Ǿ� ������ ���� ������ ��� true���ؼ� �ߺ� �������, �������� isTest�� false�� �ʱ�ȭ����.
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
            // ���� ���н� ���ڸ�
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

        // index == �����¿� �Ǻ� 
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
                           
                            hitNormal.collider.bounds.min.x+(_boxCollider2D.bounds.size.x * 1/2),  //  1�� �ƴ� ���������� ��������  
                            hitNormal.transform.position.y - hitNormal.collider.bounds.size.y);
                        Debug.Log("�̰ǰ�");
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
                            hitNormal.collider.bounds.min.x + (_boxCollider2D.bounds.size.x * 1 / 2),  //  1�� �ƴ� ���������� ��������  
                            hitNormal.transform.position.y + hitNormal.collider.bounds.size.y );
                    }
                    break;
                // �� ��
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
            // �� ��
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
    // ���� ������ ���� ������ ������ x ��ǥ�� ���ϴ� �Լ�. Section���� �̾���
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
    /// ��ġ �� �����ִ��� �ָ���
    /// ���� �ǵ� 
    ///  1. ���� ���̸� �� ���Ǿ��� ��� �� �� ������ ���ܼ� ���� �� ����. ������ �Ʒ��� ���� �� �� �Ʒ� �������� �����Ǽ� ?
    ///   1-1. �븻�� 1 ������ �����ϴ� ���̸� �ΰ����� �Ǻ���.. 
    ///  2. ������ ���̸� �ٷ� ����� �͸� �����ϰ� ���, ���� �η� ���� ���� �� �䷹�̸� ���� x���� �޾ƿ��� ������ �ϴܿ� ���ǹ� �ʿ������.....
    /// </summary>
    /// <param name="hit_1"></param>
    /// <param name="hitNormal"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public float GetYPosition(RaycastHit2D hitNormal,int index)
    {
        float yPosition;
        // ��
        switch (index)
        {

            case 1: // ��               
                    newPosition.y = hitNormal.transform.position.y - hitNormal.collider.bounds.size.y;                           
                break;
            case 2: // ��               
                    newPosition.y = hitNormal.transform.position.y + hitNormal.collider.bounds.size.y;                               
                break;
            case 3: // �¿�
                newPosition.y = hitNormal.transform.position.y;
                break;
        }
        yPosition = newPosition.y;
        return yPosition;
    }
    */
   
}