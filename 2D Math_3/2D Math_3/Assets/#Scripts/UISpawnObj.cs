using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpawnObj : MonoBehaviour
{

    public GameObject CloneObj;
    


    public void SpawnObj()
    {
        Vector3 CopyObjSpawn = new Vector3(0, 0, 0);
        GameObject clone = Instantiate(CloneObj, CopyObjSpawn, Quaternion.identity);
        clone.name = this.gameObject.name;        
    }
}
