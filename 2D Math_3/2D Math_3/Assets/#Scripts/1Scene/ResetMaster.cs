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
        for(int i =0; i<8;i++)                   // �ȷ�Ʈ ���󺹱�
        {
            glist[i].gameObject.SetActive(true);
        }
        for (int i = 8; i < 16; i++ )            // �ȷ�Ʈ ���󺹱�
        {
            glist[i].gameObject.SetActive(false);
        }
        for ( int i = 16 ; i < 18 ; i++ )       // ���찳 ���󺹱�
        {
            glist [ 16 ]. gameObject. SetActive ( true ); 
            glist [ 17 ]. gameObject. SetActive ( false ); 
        }
       
        for ( int i = 18 ; i < 21 ; i++ ) // �� ���󺹱�
        { 
                SpriteRenderer spriteRenderer = glist [ i ]. GetComponent<SpriteRenderer> ( );
                Color currentColor = spriteRenderer. color;
                Color newColor = new Color ( currentColor. r , currentColor. g , currentColor. b , 1f );
                spriteRenderer. color = newColor;

         }
    }
}
