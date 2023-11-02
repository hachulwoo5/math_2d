using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGruondManager : MonoBehaviour
{


    // public int count;

    //public int sq10;             // 10��¥�� �ڽ� 
    // public int sq10c;             // 10��¥�� �ڽ� 
    public List<GameObject> BackGroundList = new List<GameObject>();
    public GameObject[] FirstObj;
    ShapesSpawnArea shapesSpawnArea;
    GameManager gameManager;

    void Start()
    {
        shapesSpawnArea = GameObject.Find("ShapeSpawnColiider").GetComponent<ShapesSpawnArea>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    void Update()
    {
        // ��׶��尡 ����ٸ� ������ �ε��� 0���� �ʱ�ȭ
        if(BackGroundList.Count ==0)
        {
          //  gameManager.Init();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Box") )
        {
            // Reset only Code
            BackGroundList.Add(other.gameObject);
            
           // shapesSpawnArea.ShapesList.Remove(other.gameObject);
            //gameManager.PlusButOn.gameObject.SetActive(true);

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
        BackGroundList.Remove(gameObject);
    }
   
}
