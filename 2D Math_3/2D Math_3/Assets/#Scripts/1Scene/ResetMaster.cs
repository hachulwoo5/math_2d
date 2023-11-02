using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMaster : MonoBehaviour
{

    public GameObject[] glist;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetmaster()
    {
        for(int i =0; i<8;i++)
        {
            glist[i].gameObject.SetActive(true);

        }
        for (int i = 8; i < 15; i++)
        {
            glist[i].gameObject.SetActive(false);

        }
    }
}
