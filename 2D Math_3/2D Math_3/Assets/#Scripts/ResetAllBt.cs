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
        // 펜 상태에서 도형 클릭 시 펜모드 해제 + 도형 드래그 모드 활성화, 컬러 UI 초기화
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
        // 도형 스폰 UI 클릭 시 컬러 UI 초기화 
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
