using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmanager1 : MonoBehaviour
{

    
    public int count;
   
    public int sq10;             // 10개짜리 박스 
    public int sq10c;             // 10개짜리 박스 

    public List<GameObject> BoxList = new List<GameObject>();
   

    private void Update()
    {
        count =  sq10;
       
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
        #endregion
        */

        if (other.CompareTag("Sq10"))
        {
            BoxList.Add(other.gameObject);
            sq10 = sq10 + 10;


        }
        if (other.CompareTag("Sq10c"))
        {
            BoxList.Add(other.gameObject);
            sq10 = sq10 + 10;


        }





    }


    private void OnTriggerExit2D(Collider2D other)

    {

        
        if (other.CompareTag("Sq10"))
        {

            sq10 = sq10 - 10;

            BoxList.Remove(other.gameObject);
        }
        if (other.CompareTag("Sq10c"))
        {

            sq10 = sq10 - 10;

            BoxList.Remove(other.gameObject);
        }


    }

}
