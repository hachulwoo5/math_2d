using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_BackManager : MonoBehaviour
{

    public Second_SizeMultiple second_SizeMultiple;
    // public int count;

    //public int sq10;             // 10��¥�� �ڽ� 
    // public int sq10c;             // 10��¥�� �ڽ� 
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
        if (!BackGroundList.Contains(gameObject)) // ����Ʈ�� �ش� ���� ������Ʈ�� ���� ���
        {
            return; // �Լ� ����
        }
        else
        {
            BackGroundList.Remove(gameObject);

        }
    }
    public void RecentlyPlus()
    {
        // ����Ʈ ������ ���
        // BackGroundList[BackGroundList.Count-1]
        // ��� ����� ����� Ȱ���ϴ� ��ũ��Ʈ�� ���� �ֱٿ� ���� ������Ʈ�� �˻��ϰ� ������ ( �� ��ũ��Ʈ�� ����� ���� ���� )
        if (BackGroundList[BackGroundList.Count - 1].transform.position.x <= 3.2f)
        {
            float GetCorrectionValue ( int sizeText )
            {
                switch ( sizeText )
                {
                    case 1:
                        return 0.25f;
                    case 2:
                        return 0.32f; // ���ð�, �ʿ信 ���� ���� ����
                    case 3:
                        return 0.4f; // ���ð�, �ʿ信 ���� ���� ����
                    case 4:
                        return 0.45f; // ���ð�, �ʿ信 ���� ���� ����
                    case 5:
                        return 0.55f; // ���ð�, �ʿ信 ���� ���� ����
                    default:
                        return 0f; // ���� ó��
                }
            }

            Vector3 CopyObjSpawn = Vector3. zero; // Vector3 �ʱ�ȭ

            // sizeText ���� ���� CopyObjSpawn �����ϴ� �ڵ�
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
                // sizeText�� ������ ����� ��� ���� ó��
                Debug. LogError ( "sizeText ���� ������ ����ϴ�." );
            }


            GameObject clone = Instantiate(BackGroundList[BackGroundList.Count - 1], CopyObjSpawn, Quaternion.identity);
            clone.name = BackGroundList[BackGroundList.Count - 1].name;
            clone.transform.parent = ObjBox.transform;

        }



    }
}