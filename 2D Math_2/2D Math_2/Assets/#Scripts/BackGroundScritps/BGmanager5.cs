using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmanager5 : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> BoxList = new List<GameObject>();


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)

    {/*
        #region 출입금지목록
        if (other.CompareTag("Sq1"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Sq2"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Sq3"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Sq4"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Sq5"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Sq6"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Sq7"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Sq8"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Sq9"))
        {
            Destroy(other.gameObject);
        }
        #endregion*/


        if (other.CompareTag("Sq10"))
        {
            BoxList.Add(other.gameObject);


        }





    }


    private void OnTriggerExit2D(Collider2D other)

    {

        if (other.CompareTag("Sq1"))
        {
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq2"))
        {
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq3"))
        {
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq4"))
        {
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq5"))
        {
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq6"))
        {
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq7"))
        {
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq8"))
        {
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq9"))
        {
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq10c"))
        {
            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq10"))
        {
            BoxList.Remove(other.gameObject);
        }
    }
    }
