using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_BackManager : MonoBehaviour
{

    public Second_SizeMultiple second_SizeMultiple;
    // public int count;

    //public int sq10;             // 10개짜리 박스 
    // public int sq10c;             // 10개짜리 박스 
    public List<GameObject> BackGroundList = new List<GameObject>();
    ShapesSpawnArea shapesSpawnArea;
    Second_GameManager Second_gameManager;
    GameObject ObjBox;
    void Start()
    {
        shapesSpawnArea = GameObject.Find("ShapeSpawnColiider").GetComponent<ShapesSpawnArea>();
        Second_gameManager = GameObject.Find("GameManager").GetComponent<Second_GameManager>();
        ObjBox = GameObject.Find("ObjBox2");
    }

    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Red") || other.CompareTag("Green") || other.CompareTag("Blue") || other.CompareTag("Yellow"))
        {
            // Reset only Code
            BackGroundList.Add(other.gameObject);
            shapesSpawnArea.ShapesList.Remove(other.gameObject);
            Second_gameManager.PlusButOn.gameObject.SetActive(true);

        }
    }


    private void OnTriggerExit2D(Collider2D other)

    {
        if (other.CompareTag("Red") || other.CompareTag("Green") || other.CompareTag("Blue") || other.CompareTag("Yellow"))
        {
            BackGroundList.Remove(other.gameObject);
        }
    }

    public void RemoveList(GameObject gameObject)
    {
        if (!BackGroundList.Contains(gameObject)) // 리스트에 해당 게임 오브젝트가 없는 경우
        {
            return; // 함수 종료
        }
        else
        {
            BackGroundList.Remove(gameObject);

        }
    }
    public void RecentlyPlus()
    {
        // 리스트 마지막 요소
        // BackGroundList[BackGroundList.Count-1]
        // 모두 지우기 기능을 활용하는 스크립트라서 가장 최근에 들어온 오브젝트를 검색하고 복사함 ( 이 스크립트에 기능을 넣은 이유 )
        if (BackGroundList[BackGroundList.Count - 1].transform.position.x <= 3.2f)
        {
            float GetCorrectionValue ( int sizeText )
            {
                switch ( sizeText )
                {
                    // return 수치들은 얼마나 띄울건지, 콜라이더 길이로 편하게 로직 짜고 싶었는데 polygon 오각형 오브젝트가 엉망이라 수동으로 함..
                    // 아래 수치를 변경하면 복사할 때 도형 크기(1~5)마다 생성되는 거리를 조절 가능 
                    case 1:
                        return 0.2f;
                    case 2:
                        return 0.3f; // 예시값, 필요에 따라 변경 가능
                    case 3:
                        return 0.4f; // 예시값, 필요에 따라 변경 가능
                    case 4:
                        return 0.475f; // 예시값, 필요에 따라 변경 가능
                    case 5:
                        return 0.58f; // 예시값, 필요에 따라 변경 가능
                    default:
                        return 0f; // 예외 처리
                }
            }

            Vector3 CopyObjSpawn = Vector3. zero; // Vector3 초기화

            // sizeText 값에 따라 CopyObjSpawn 설정하는 코드
            if ( second_SizeMultiple. SizeText >= 1 && second_SizeMultiple. SizeText <= 5 )
            {
                float correctionValue = GetCorrectionValue ( second_SizeMultiple. SizeText );
                CopyObjSpawn = new Vector3 (
                    BackGroundList [ BackGroundList. Count - 1 ]. transform. position. x + correctionValue ,
                    BackGroundList [ BackGroundList. Count - 1 ]. transform. position. y ,
                    BackGroundList [ BackGroundList. Count - 1 ]. transform. position. z );
            }
            else
            {
                // sizeText가 범위를 벗어나는 경우 예외 처리
                Debug. LogError ( "sizeText 값이 범위를 벗어납니다." );
            }


            GameObject clone = Instantiate(BackGroundList[BackGroundList.Count - 1], CopyObjSpawn, Quaternion.identity);
            clone.name = BackGroundList[BackGroundList.Count - 1].name;
            clone.transform.parent = ObjBox.transform;

        }



    }

    float GetCorrectionValueBasedOnCollider ( Collider2D collider )
    {
        float distance = 0f;

        if ( collider is BoxCollider2D )
        {
            BoxCollider2D boxCollider = ( BoxCollider2D ) collider;
            distance = boxCollider. size. x / 2f;
        }
        else if ( collider is CircleCollider2D )
        {
            CircleCollider2D circleCollider = ( CircleCollider2D ) collider;
            distance = circleCollider. radius;
        }
        else if ( collider is PolygonCollider2D )
        {
            PolygonCollider2D polygonCollider = ( PolygonCollider2D ) collider;

            float minX = float. MaxValue;
            float maxX = float. MinValue;

            foreach ( Vector2 point in polygonCollider. points )
            {
                if ( point. x < minX )
                    minX = point. x;
                if ( point. x > maxX )
                    maxX = point. x;
            }

            distance = maxX - minX;
        }
        else
        {
            Debug. LogError ( "지원되지 않는 Collider 유형입니다." );
        }

        return distance;
    }
}