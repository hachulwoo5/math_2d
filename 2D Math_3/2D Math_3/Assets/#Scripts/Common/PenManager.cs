using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenManager : MonoBehaviour
{

    public GameObject[] PenColor;

   
    

    public void PenColorChanger(int x,int y,int z)
    {
        for(int i=0;i<PenColor.Length;i++)
        {
            PenColor[i].GetComponent<SpriteRenderer>().color = new Color(x / 255f, y / 255f, z / 255f);
        }
    }

    public void PenColorChangeBut()
    {
        PenColorChanger(164, 164, 164);
    }
}
