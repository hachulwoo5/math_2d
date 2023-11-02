using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesSpawnArea : MonoBehaviour
{
    public List<GameObject> ShapesList = new List<GameObject>();

    public GameObject detectedObject;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Red") || other.gameObject.CompareTag("Blue") || other.gameObject.CompareTag("Black") || other.gameObject.CompareTag("Green"))
        {
            if (!ShapesList.Contains(other.gameObject))
            {
                ShapesList.Add(other.gameObject);

            }
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Red") || other.gameObject.CompareTag("Blue") || other.gameObject.CompareTag("Black") || other.gameObject.CompareTag("Green"))
        {
            ShapesList.Remove(other.gameObject);
            for (int i = ShapesList.Count - 1; i >= 0; i--)
            {
                if (ShapesList[i] == null)
                {
                    ShapesList.RemoveAt(i);
                }
            }

        }
    }






}
