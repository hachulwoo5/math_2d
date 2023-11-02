using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnObj : MonoBehaviour
{
    public GameObject RedObj;
    public GameObject GreenObj;
    public GameObject BlueObj;
    public GameObject YellowObj;


    public GameObject[] offList;
    public GameObject[] onList;
 

    ShapesSpawnArea shapesSpawnArea;

    void Awake()
    {
        shapesSpawnArea = GameObject.Find("ShapeSpawnColiider").GetComponent<ShapesSpawnArea>();

    }


    // Create Color Object before Area Clear
    public void ClearObj()
    {
        for (int i = shapesSpawnArea.ShapesList.Count - 1; i >= 0; i--)
        {
            // Shapes Spawn Area Clear
            Destroy(shapesSpawnArea.ShapesList[i]);     
        }
    }

    #region Each Shapes Obj Spawn


    // UI Button Click > Shapes Respawn
    public void GreenObjon()    
    {
       Vector3 CopyObjSpawn = new Vector3(-4.6f, 0.2f, 0);
        
        GameObject clone = Instantiate(GreenObj, CopyObjSpawn, Quaternion.identity);
        clone.name = "GreenObj";

        shapesSpawnArea.ShapesList.Add(clone);
    }
    public void RedObjon()
    {
        Vector3 CopyObjSpawn = new Vector3(-4.6f, -0.6f, 0);
        GameObject clone = Instantiate(RedObj, CopyObjSpawn, Quaternion.identity);
        clone.name = "RedObj";

        shapesSpawnArea.ShapesList.Add(clone);
    }
    public void BlueObjon()
    {
        Vector3 CopyObjSpawn = new Vector3(-4.6f, -1.4f, 0);
        GameObject clone = Instantiate(BlueObj, CopyObjSpawn, Quaternion.identity);
        clone.name = "BlueObj";

        shapesSpawnArea.ShapesList.Add(clone);
    }
    public void YellowObjon()
    {
        Vector3 CopyObjSpawn = new Vector3(-4.6f, -2.2f, 0);
        GameObject clone = Instantiate(YellowObj, CopyObjSpawn, Quaternion.identity);
        clone.name = "YellowObj";

        shapesSpawnArea.ShapesList.Add(clone);
    }

    #endregion

    public void On_OffBut()
    {

        for (int i=0; i<onList.Length;i++)
        {
            onList[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < offList.Length; i++)
        {
            offList[i].gameObject.SetActive(false);
        }

    }
}
