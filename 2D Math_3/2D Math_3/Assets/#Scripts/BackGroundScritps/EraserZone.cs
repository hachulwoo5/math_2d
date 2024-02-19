using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserZone : MonoBehaviour
{
    public List<GameObject> ObjList = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
            ObjList.Add(other.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other)
        {
            ObjList.Remove(other.gameObject);
        }
    }

}
