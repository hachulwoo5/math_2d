using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 


public class Total : MonoBehaviour
{
   

    public TextMeshProUGUI maintotal;      // TMP 

    public int bg1score;           
    public int bg2score;
    public int bg3score;
    public int bg4score;
    public int bg5score;
    public int bg6score;



    public int totalscore;           

   
    public GameObject bgmanager1;       // ��ũ��Ʈ ���� 
    public GameObject bgmanager2;       // ��ũ��Ʈ ���� 
    public GameObject bgmanager3;       // ��ũ��Ʈ ���� 
    public GameObject bgmanager4;       // ��ũ��Ʈ ���� 
   


    // public BGmanager5 bgmanager5;       // ��ũ��Ʈ ���� 
    //public BGmanager6 bgmanager6;       // ��ũ��Ʈ ���� 


    void Start ()
    {

        
        

    }

    // Update is called once per frame
    void Update()
    {

        if ( GameObject. Find ( "1Scene_RootGameObject" ) != null && GameObject. Find ( "1Scene_RootGameObject" ). activeSelf )
        {
            bg1score = bgmanager1. GetComponent<BGmanager1> ( ). count;           // �ܺο��� ���� ��������
            bg2score = bgmanager2. GetComponent<BGmanager2> ( ). count;

            totalscore = bg1score + bg2score ;        // �ܺ� ��� ���� �ջ�

            maintotal. text = totalscore. ToString ( );     // �ջ� ���� ���
        }
        else if ( GameObject. Find ( "1Scene_RootGameObject" ) != null && GameObject. Find ( "1Scene_RootGameObject" ). activeSelf )
        {
            // 1Scene_RootGameObject�� �����ϰ� Ȱ��ȭ�Ǿ� �ִ� ���
            // ���ϴ� �۾��� �����մϴ�.
        }

        else if ( GameObject. Find ( "4Scene_RootGameObject" ) != null && GameObject. Find ( "4Scene_RootGameObject" ). activeSelf )
        {       // ���� ���
            bg1score = bgmanager1. GetComponent<BGmanager1> ( ). count;           
            bg2score = bgmanager2. GetComponent<BGmanager2> ( ). count;          
            bg3score = bgmanager3. GetComponent<BGmanager1> ( ). count;
            bg4score = bgmanager4. GetComponent<BGmanager2> ( ). count;

            totalscore = ( bg1score + bg2score ) - ( bg3score + bg4score );        

            maintotal. text = totalscore. ToString ( );     // �ջ� ���� ���
        }
        else if ( GameObject. Find ( "5Scene_RootGameObject" ) != null && GameObject. Find ( "5Scene_RootGameObject" ). activeSelf )
        {       // ���ϱ� ���
            bg1score = bgmanager1. GetComponent<BGmanager1> ( ). count;           
            bg2score = bgmanager2. GetComponent<BGmanager2> ( ). count;          
            bg3score = bgmanager3. GetComponent<BGmanager1> ( ). count;
            bg4score = bgmanager4. GetComponent<BGmanager2> ( ). count;
            

            totalscore = ( bg1score + bg2score ) * ( bg3score + bg4score );        // �ܺ� ��� ���� �ջ�

            maintotal. text = totalscore. ToString ( );     // �ջ� ���� ���
        }
    }

   
    }
