using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject PlusButOn;
    public GameObject PlusButOff;

    BackGruondManager backGruondManager;

    public int ObjIndex = 1;

   

    void Start()
    {
        backGruondManager = GameObject.Find("BackGround").GetComponent<BackGruondManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(backGruondManager.BackGroundList.Count==1)
        {
            ObjIndex = 1;
        }
    }

    public void Init()
    {
        ObjIndex = 1;
        backGruondManager.BackGroundList.Clear();
    }
}
