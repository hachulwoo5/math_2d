using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 


public class Total : MonoBehaviour
{
   

    public TextMeshProUGUI maintotal;      // TMP 

    public int bg1score;           // 이 스크립트에서 만든 변수
    public int bg2score;          // 이 스크립트에서 만든 변수
   
    public int totalscore;           // 이 스크립트에서 만든 변수

   
    public BGmanager1 bgmanager1;       // 스크립트 참조 
    public BGmanager2 bgmanager2;       // 스크립트 참조 
    
   // public BGmanager5 bgmanager5;       // 스크립트 참조 
    //public BGmanager6 bgmanager6;       // 스크립트 참조 


    void Start()
    {

        
        

    }

    // Update is called once per frame
    void Update()
    {

       
        bg1score = bgmanager1.count;           // 외부에서 점수 가져오기
        bg2score = bgmanager2.count;           // 외부에서 점수 가져오기
      
        totalscore = bg1score + bg2score;        // 외부 모든 점수 합산

        maintotal.text = totalscore.ToString();     // 합산 점수 출력
    }

   
    }
