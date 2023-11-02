using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMode : MonoBehaviour
{
    // Start is called before the first frame update


    
    public bool isDragMode;      // 이 스크립트 펜 모드는 펜모드시 오브젝트 드래그 가능 여부 조정용
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DragOff()
    {
        isDragMode = false; 
        
       
       


    }

    public void DragOn()
    {
        isDragMode = true;
       
       
        
        
    }
}
