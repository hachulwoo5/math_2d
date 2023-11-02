using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_GameManager : MonoBehaviour
{


    public GameObject PlusButOn;
    public GameObject PlusButOff;

    public int Index_ =1;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    




    /// <summary>
    /// 도형 1 원 2 삼각형 3 사각형 4 오각형
    /// </summary>
    public void Index1()
    {
        Index_ = 1;
    }
    public void Index2()
    {
        Index_ = 2;
    }
    public void Index3()
    {
        Index_ = 3;
    }
    public void Index4()
    {
        Index_ = 4;
    }
}

