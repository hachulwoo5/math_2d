using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGruondManager : MonoBehaviour
{

    
   // public int count;
   
    //public int sq10;             // 10개짜리 박스 
   // public int sq10c;             // 10개짜리 박스 
    public List<GameObject> BackGroundList = new List<GameObject>();
    ShapesSpawnArea shapesSpawnArea;
    GameManager gameManager;

    void Start()
    {
        shapesSpawnArea = GameObject.Find("ShapeSpawnColiider").GetComponent<ShapesSpawnArea>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Red") || other.CompareTag("Green") || other.CompareTag("Blue") || other.CompareTag("Yellow"))
        {
            // Reset only Code
            BackGroundList.Add(other.gameObject);
            shapesSpawnArea.ShapesList.Remove(other.gameObject);
            gameManager.PlusButOn.gameObject.SetActive(true);

        }
    }


    private void OnTriggerExit2D(Collider2D other)

    {
        if (other.CompareTag("Red") || other.CompareTag("Green") || other.CompareTag("Blue") || other.CompareTag("Yellow"))
        {
            BackGroundList.Remove(other.gameObject);
        }
    }

    public void RecentlyPlus()
    {
        // 리스트 마지막 요소
        // BackGroundList[BackGroundList.Count-1]
        // 모두 지우기 기능을 활용하는 스크립트라서 가장 최근에 들어온 오브젝트를 검색하고 복사함 ( 이 스크립트에 기능을 넣은 이유 )
        if(BackGroundList[BackGroundList.Count - 1].transform.position.x<=3.2f)
        {
            Vector3 CopyObjSpawn = new Vector3(BackGroundList[BackGroundList.Count - 1].transform.position.x + 0.45f, BackGroundList[BackGroundList.Count - 1].transform.position.y, BackGroundList[BackGroundList.Count - 1].transform.position.z);
            GameObject clone = Instantiate(BackGroundList[BackGroundList.Count - 1], CopyObjSpawn, Quaternion.identity);
            clone.name = BackGroundList[BackGroundList.Count - 1].name;
        }
       


    }
}
