using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 


public class Total : MonoBehaviour
{
   

    public TextMeshProUGUI maintotal;      // TMP 

    public int bg1score;           // �� ��ũ��Ʈ���� ���� ����
    public int bg2score;          // �� ��ũ��Ʈ���� ���� ����
   
    public int totalscore;           // �� ��ũ��Ʈ���� ���� ����

   
    public BGmanager1 bgmanager1;       // ��ũ��Ʈ ���� 
    public BGmanager2 bgmanager2;       // ��ũ��Ʈ ���� 
    
   // public BGmanager5 bgmanager5;       // ��ũ��Ʈ ���� 
    //public BGmanager6 bgmanager6;       // ��ũ��Ʈ ���� 


    void Start()
    {

        
        

    }

    // Update is called once per frame
    void Update()
    {

       
        bg1score = bgmanager1.count;           // �ܺο��� ���� ��������
        bg2score = bgmanager2.count;           // �ܺο��� ���� ��������
      
        totalscore = bg1score + bg2score;        // �ܺ� ��� ���� �ջ�

        maintotal.text = totalscore.ToString();     // �ջ� ���� ���
    }

   
    }
