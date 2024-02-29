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

   
    public GameObject bgmanager1;       // 스크립트 참조 
    public GameObject bgmanager2;       // 스크립트 참조 
    public GameObject bgmanager3;       // 스크립트 참조 
    public GameObject bgmanager4;       // 스크립트 참조 
   


    // public BGmanager5 bgmanager5;       // 스크립트 참조 
    //public BGmanager6 bgmanager6;       // 스크립트 참조 


    void Start ()
    {

        
        

    }

    // Update is called once per frame
    void Update()
    {

        if ( GameObject. Find ( "1Scene_RootGameObject" ) != null && GameObject. Find ( "1Scene_RootGameObject" ). activeSelf )
        {
            bg1score = bgmanager1. GetComponent<BGmanager1> ( ). count;           // 외부에서 점수 가져오기
            bg2score = bgmanager2. GetComponent<BGmanager2> ( ). count;

            totalscore = bg1score + bg2score ;        // 외부 모든 점수 합산

            maintotal. text = totalscore. ToString ( );     // 합산 점수 출력
        }
        else if ( GameObject. Find ( "1Scene_RootGameObject" ) != null && GameObject. Find ( "1Scene_RootGameObject" ). activeSelf )
        {
            // 1Scene_RootGameObject가 존재하고 활성화되어 있는 경우
            // 원하는 작업을 수행합니다.
        }

        else if ( GameObject. Find ( "4Scene_RootGameObject" ) != null && GameObject. Find ( "4Scene_RootGameObject" ). activeSelf )
        {       // 뺄셈 계산
            bg1score = bgmanager1. GetComponent<BGmanager1> ( ). count;           
            bg2score = bgmanager2. GetComponent<BGmanager2> ( ). count;          
            bg3score = bgmanager3. GetComponent<BGmanager1> ( ). count;
            bg4score = bgmanager4. GetComponent<BGmanager2> ( ). count;

            totalscore = ( bg1score + bg2score ) - ( bg3score + bg4score );        

            maintotal. text = totalscore. ToString ( );     // 합산 점수 출력
        }
        else if ( GameObject. Find ( "5Scene_RootGameObject" ) != null && GameObject. Find ( "5Scene_RootGameObject" ). activeSelf )
        {       // 곱하기 계산
            bg1score = bgmanager1. GetComponent<BGmanager1> ( ). count;           
            bg2score = bgmanager2. GetComponent<BGmanager2> ( ). count;          
            bg3score = bgmanager3. GetComponent<BGmanager1> ( ). count;
            bg4score = bgmanager4. GetComponent<BGmanager2> ( ). count;
            

            totalscore = ( bg1score + bg2score ) * ( bg3score + bg4score );        // 외부 모든 점수 합산

            maintotal. text = totalscore. ToString ( );     // 합산 점수 출력
        }
    }

   
    }
