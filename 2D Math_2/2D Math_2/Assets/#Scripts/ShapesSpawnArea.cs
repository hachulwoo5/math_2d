using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesSpawnArea : MonoBehaviour
{
    public List<GameObject> ShapesList = new List<GameObject>();
    


    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Red") || other.gameObject.CompareTag("Blue") || other.gameObject.CompareTag("Black") || other.gameObject.CompareTag("Green"))
        {
            ShapesList.Remove(other.gameObject);
        }
    }






}
