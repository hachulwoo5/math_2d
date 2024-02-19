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
        ObjBox = GameObject.Find("ObjBox");
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
                    case 1:
                        return 0.25f;
                    case 2:
                        return 0.32f; // 예시값, 필요에 따라 변경 가능
                    case 3:
                        return 0.4f; // 예시값, 필요에 따라 변경 가능
                    case 4:
                        return 0.45f; // 예시값, 필요에 따라 변경 가능
                    case 5:
                        return 0.55f; // 예시값, 필요에 따라 변경 가능
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
}