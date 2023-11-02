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
    public  GameObject ObjBox;
    void Awake()
    {
        shapesSpawnArea = GameObject.Find("ShapeSpawnColiider").GetComponent<ShapesSpawnArea>();
        //ObjBox = GameObject.Find("ObjBox");
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
        float size = GameObject.Find("SizeMultiple").GetComponent<Second_SizeMultiple>().SizeMp;
        Vector3 CopyObjSpawn = new Vector3(-4.6f, 0.2f, 0);

        GameObject clone = Instantiate(GreenObj, CopyObjSpawn, Quaternion.identity);
        clone.name = "GreenObj";
        clone.transform.localScale = new Vector3(0.033f * size ,0.033f * size, 0.033f * size);
        clone.transform.parent = ObjBox.transform;
        shapesSpawnArea.ShapesList.Add(clone);
    }
    public void RedObjon()
    {
        float size = GameObject.Find("SizeMultiple").GetComponent<Second_SizeMultiple>().SizeMp;

        Vector3 CopyObjSpawn = new Vector3(-4.6f, -0.6f, 0);
        GameObject clone = Instantiate(RedObj, CopyObjSpawn, Quaternion.identity);
        clone.name = "RedObj";
        clone.transform.localScale = new Vector3(0.033f * size, 0.033f * size, 0.033f * size);
        clone.transform.parent = ObjBox.transform;

        shapesSpawnArea.ShapesList.Add(clone);
    }
    public void BlueObjon()
    {
        float size = GameObject.Find("SizeMultiple").GetComponent<Second_SizeMultiple>().SizeMp;

        Vector3 CopyObjSpawn = new Vector3(-4.6f, -1.4f, 0);
        GameObject clone = Instantiate(BlueObj, CopyObjSpawn, Quaternion.identity);
        clone.name = "BlueObj";
        clone.transform.localScale = new Vector3(0.033f * size, 0.033f * size, 0.033f * size);
        clone.transform.parent = ObjBox.transform;

        shapesSpawnArea.ShapesList.Add(clone);
    }
    public void YellowObjon()
    {
        float size = GameObject.Find("SizeMultiple").GetComponent<Second_SizeMultiple>().SizeMp;

        Vector3 CopyObjSpawn = new Vector3(-4.6f, -2.2f, 0);
        GameObject clone = Instantiate(YellowObj, CopyObjSpawn, Quaternion.identity);
        clone.name = "YellowObj";
        clone.transform.localScale = new Vector3(0.033f * size, 0.033f * size, 0.033f * size);
        clone.transform.parent = ObjBox.transform;

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
