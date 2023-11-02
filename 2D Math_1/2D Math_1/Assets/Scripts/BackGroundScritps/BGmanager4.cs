using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmanager4 : MonoBehaviour
{




    


    public int count;
    public int sq1;              // 1개짜리 박스 
    public int sq2;
    public int sq3;
    public int sq4;
    public int sq5;
    public int sq6;
    public int sq7;
    public int sq8;
    public int sq9;
    public int sq10c;


    public int sq10;             // 10개짜리 박스 



    public List<GameObject> BoxList = new List<GameObject>();


    private void Start()
    {

    }
    private void Update()
    {

        count = sq1 + sq2 + sq3 + sq4 + sq5 + sq6 + sq7 + sq8 + sq9 + sq10c;
        /* 사용문 @@
       if (Box1List.Count == 10 && cubeList.Count < 10)
       {
           float y;



            y = Ran[it];    // 밑에서부터 10 자리 생성
           //it++;

           Vector3 Sq100Spawn = new Vector3(-6.3f, y, 0);
           */  //사용문 @@
               //-----------------------------------------------------




        /*  사용문 @@ 
        // 중요 문장
       RaycastHit2D hit;
       Vector3 origin = new Vector3(-6.3f, 1000, 0);
       hit = Physics2D.Raycast(origin, Vector2.down, 1500, LayerMask.GetMask("10Box"));
       Debug.DrawRay(origin, Vector2.down, Color.red, 1500);
       if (hit)
       {
           Vector2 hitPoint = hit.point;                      //닿은 표면의 위치를 가져옴
           var targetX = hit.collider.transform.position.x;   //닿은 오브젝트의 y값을 구함

           float radius = 0.15f;   //박스 콜라이더의 반지름을 구함

           hitPoint.y += radius;

           hitPoint.x = targetX;                              //닿은 y값을 박스에 저장

           Sq100Spawn = hitPoint;                     //이동 적용
       }
        */  //사용문 @@




        /*  사용문 @@ 
        GameObject clone = Instantiate(Sq10, Sq100Spawn, Quaternion.identity);
        clone.name = "Sq10";

        cubeList.Add(clone);
        */  //사용문 @@


        // 이상 생성문

        /*  사용문 @@ 

        // 10개 작은박스 파괴 후 리스트 클리어
        for (int i = Box1List.Count - 1; i >= 0; i--)
        {
            Destroy(Box1List[i]);

        }
        Box1List.Clear();

    }
*/
    }
    /*
        private bool isDuplicate(float y)
        {
            foreach (GameObject clone in cubeList)
                if (clone.transform.position.y==y)
                {
                return true;

                 }


                    return false;


        }*/
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Sq1"))
        {
            BoxList.Add(other.gameObject);
            sq1 = sq1 + 1;
        }
        if (other.CompareTag("Sq2"))
        {
            BoxList.Add(other.gameObject);
            sq2 = sq2 + 2;
        }
        if (other.CompareTag("Sq3"))
        {
            BoxList.Add(other.gameObject);
            sq3 += 3;
        }
        if (other.CompareTag("Sq4"))
        {
            BoxList.Add(other.gameObject);
            sq4 = sq4 + 4;
        }
        if (other.CompareTag("Sq5"))
        {
            BoxList.Add(other.gameObject);
            sq5 = sq5 + 5;
        }
        if (other.CompareTag("Sq6"))
        {
            BoxList.Add(other.gameObject);
            sq6 = sq6 + 6;
        }
        if (other.CompareTag("Sq7"))
        {
            BoxList.Add(other.gameObject);
            sq7 = sq7 + 7;
        }
        if (other.CompareTag("Sq8"))
        {
            BoxList.Add(other.gameObject);
            sq8 = sq8 + 8;
        }
        if (other.CompareTag("Sq9"))
        {
            BoxList.Add(other.gameObject);
            sq9 = sq9 + 9;
        }
        if (other.CompareTag("Sq10c"))
        {
            BoxList.Add(other.gameObject);
            sq10c = sq10c + 10;
        }


        if (other.CompareTag("Sq10"))
        {
            //Box10List.Add(other.gameObject);

            //sq10 = sq10 + 10;
            Destroy(other.gameObject);

        }





    }


    private void OnTriggerExit2D(Collider2D other)

    {

        if (other.CompareTag("Sq1"))
        {
            sq1 = sq1 - 1;
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq2"))
        {
            sq2 = sq2 - 2;
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq3"))
        {
            sq3 = sq3 - 3;
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq4"))
        {
            sq4 = sq4 - 4;
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq5"))
        {
            sq5 = sq5 - 5;
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq6"))
        {
            sq6 = sq6 - 6;
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq7"))
        {
            sq7 = sq7 - 7;
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq8"))
        {
            sq8 = sq8 - 8;
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq9"))
        {
            sq9 = sq9 - 9;
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq10c"))
        {
            sq10c = sq10c - 10;
            BoxList.Remove(other.gameObject);
        }
        /*
        if (other.CompareTag("Sq10"))
        {
            sq10 = sq10 - 10;
            Box10List.Remove(other.gameObject);


        }*/


    }

}