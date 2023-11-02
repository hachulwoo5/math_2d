using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAllBt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] onList;
    public GameObject[] offList;


    FreeDraw.Drawable drawable;
    DragMode dragmode;

    void Start()
    {
        dragmode = GameObject.Find("DragManager").GetComponent<DragMode>();
        drawable = GameObject.Find("DrawingBackGround").GetComponent<FreeDraw.Drawable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void On_OffBt()
    {
        // �� ���¿��� ���� Ŭ�� �� ���� ���� + ���� �巡�� ��� Ȱ��ȭ, �÷� UI �ʱ�ȭ
        if(this.gameObject.name == "ColorUi_Init")
        {
            drawable.GetComponent<BoxCollider2D>().enabled = false;
            drawable.isPenMode = false;
            dragmode.isDragMode = true;
            for (int i = 0; i < onList.Length; i++)
            {
                onList[i].gameObject.SetActive(true);
            }
            for (int i = 0; i < offList.Length; i++)
            {
                offList[i].gameObject.SetActive(false);
            }
        }
        // ���� ���� UI Ŭ�� �� �÷� UI �ʱ�ȭ 
        else
        {
            for (int i = 0; i < onList.Length; i++)
            {
                onList[i].gameObject.SetActive(true);
            }
            for (int i = 0; i < offList.Length; i++)
            {
                offList[i].gameObject.SetActive(false);
            }
        }
      
    }
}
