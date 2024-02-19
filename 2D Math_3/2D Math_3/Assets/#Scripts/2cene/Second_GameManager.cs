using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_GameManager : MonoBehaviour
{
    public static Second_GameManager Instance { get; private set; }

    public GameObject PlusButOn;
    public GameObject PlusButOff;

    public int Index_ = 1;

    public Vector3 pos1, pos2, pos3, pos4;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        pos1 = GameObject.Find("Circle Green").transform.position;
        pos2 = GameObject.Find("Circle Red").transform.position;
        pos3 = GameObject.Find("Circle Blue").transform.position;
        pos4 = GameObject.Find("Circle Yellow").transform.position;
    }

    // Update is called once per frame
    private void Update()
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