using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMode : MonoBehaviour
{
    // Start is called before the first frame update


    
    public bool isDragMode;      // �� ��ũ��Ʈ �� ���� ����� ������Ʈ �巡�� ���� ���� ������
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
