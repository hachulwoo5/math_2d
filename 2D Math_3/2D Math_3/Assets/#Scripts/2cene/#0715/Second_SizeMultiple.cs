using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Second_SizeMultiple : MonoBehaviour
{
    public static Second_SizeMultiple second_SizeMultiple;
    public int SizeText=1;
    public float SizeMp=1.0f;
    public Text SizeMpText;

    public GameObject Circle_G;
    public GameObject Circle_R;
    public GameObject Circle_B;
    public GameObject Circle_Y;
    public GameObject Triangle_G;
    public GameObject Triangle_R;
    public GameObject Triangle_B;
    public GameObject Triangle_Y;
    public GameObject Rectangle_G;
    public GameObject Rectangle_R;
    public GameObject Rectangle_B;
    public GameObject Rectangle_Y;
    public GameObject Pentagon_G;
    public GameObject Pentagon_R;
    public GameObject Pentagon_B;
    public GameObject Pentagon_Y;


    GameObject ObjBox;

    ShapesSpawnArea shapesSpawnArea;

    Vector3 pos1, pos2, pos3, pos4;

    void Awake()
    {
        shapesSpawnArea = GameObject.Find("ShapeSpawnColiider").GetComponent<ShapesSpawnArea>();
        ObjBox = GameObject.Find("ObjBox");
        pos1= GameObject.Find("Circle Green").transform.position;
        pos2 = GameObject.Find("Circle Red").transform.position;
        pos3 = GameObject.Find("Circle Blue").transform.position;
        pos4 = GameObject.Find("Circle Yellow").transform.position;
    }


    // Create Color Object before Area Clear
    public void ClearObj()
    {
        for (int i = shapesSpawnArea.ShapesList.Count - 1; i >= 0; i--)
        {
            // Shapes Spawn Area Clear
            Destroy(shapesSpawnArea.ShapesList[i]);
            //shapesSpawnArea.ShapesList.Clear();
        }
    }

    // Update is called once per frame
    void Update()
    {
        SizeMpText.text = "" + SizeText;


    }

    /// <summary>
    /// 1. 모두 지움
    /// 2. 1~5단계 표시, 크기 배율 설정 ( 1~5단계에 해당하는 각 크기 배율이 있음 20% 씩 커짐 )
    /// 3. index (어떤 도형인지에 대한) 를 구해서 인덱스에 따라 소환할 도형 정하고 소환
    /// </summary>
    public void SizeButtonPlus()
    {
        if (SizeText == 5)
            return;

        ClearObj();
        

        SizeText++;
        SizeMp += 0.4f;

        int index = GameObject.Find("GameManager").GetComponent<Second_GameManager>().Index_;
        // index는 도형번호 1~4 원 삼각 사각 오각 
        switch(index)
        {
            case 1:
                GreenObjon(Circle_G);
                RedObjon(Circle_R);
                BlueObjon(Circle_B);
                YellowObjon(Circle_Y);
                break;
            case 2:
                GreenObjon(Triangle_G);
                RedObjon(Triangle_R);
                BlueObjon(Triangle_B);
                YellowObjon(Triangle_Y);
                break;
            case 3:
                GreenObjon(Rectangle_G);
                RedObjon(Rectangle_R);
                BlueObjon(Rectangle_B);
                YellowObjon(Rectangle_Y);
                break;
            case 4:
                GreenObjon(Pentagon_G);
                RedObjon(Pentagon_R);
                BlueObjon(Pentagon_B);
                YellowObjon(Pentagon_Y);
                break;

        }
    }

    public void SizeButtonMinus()
    {
        if (SizeText == 1)
            return;
        ClearObj();

        
        SizeText--;
        SizeMp -= 0.4f;
        int index = GameObject.Find("GameManager").GetComponent<Second_GameManager>().Index_;
        switch (index)      // index는 도형번호 1원, 2삼각형, 3사각형, 4오각형
        {
            case 1:
                GreenObjon(Circle_G);
                RedObjon(Circle_R);
                BlueObjon(Circle_B);
                YellowObjon(Circle_Y);
                break;
            case 2:
                GreenObjon(Triangle_G);
                RedObjon(Triangle_R);
                BlueObjon(Triangle_B);
                YellowObjon(Triangle_Y);
                break;
            case 3:
                GreenObjon(Rectangle_G);
                RedObjon(Rectangle_R);
                BlueObjon(Rectangle_B);
                YellowObjon(Rectangle_Y);
                break;
            case 4:
                GreenObjon(Pentagon_G);
                RedObjon(Pentagon_R);
                BlueObjon(Pentagon_B);
                YellowObjon(Pentagon_Y);
                break;

        }
    }

    public void GreenObjon(GameObject What)
    {
        
        Vector3 CopyObjSpawn = new Vector3(-4.6f, 0.2f, 0);

        GameObject clone = Instantiate(What, pos1, Quaternion.identity);
        clone.name = "GreenObj";
        clone.transform.localScale = new Vector3(0.033f * SizeMp, 0.033f * SizeMp, 0.033f * SizeMp);
        clone.transform.parent = ObjBox.transform;
        shapesSpawnArea.ShapesList.Add(clone);
    }
    public void RedObjon(GameObject What)
    {

        Vector3 CopyObjSpawn = new Vector3(-4.6f, -0.6f, 0);
        GameObject clone = Instantiate(What, pos2, Quaternion.identity);
        clone.name = "RedObj";
        clone.transform.localScale = new Vector3(0.033f * SizeMp, 0.033f * SizeMp, 0.033f * SizeMp);
        clone.transform.parent = ObjBox.transform;

        shapesSpawnArea.ShapesList.Add(clone);
    }
    public void BlueObjon(GameObject What)
    {

        Vector3 CopyObjSpawn = new Vector3(-4.6f, -1.4f, 0);
        GameObject clone = Instantiate(What, pos3, Quaternion.identity);
        clone.name = "BlueObj";
        clone.transform.localScale = new Vector3(0.033f * SizeMp, 0.033f * SizeMp, 0.033f * SizeMp);
        clone.transform.parent = ObjBox.transform;

        shapesSpawnArea.ShapesList.Add(clone);
    }
    public void YellowObjon(GameObject What)
    {

        Vector3 CopyObjSpawn = new Vector3(-4.6f, -2.2f, 0);
        GameObject clone = Instantiate(What, pos4, Quaternion.identity);
        clone.name = "YellowObj";
        clone.transform.localScale = new Vector3(0.033f * SizeMp, 0.033f * SizeMp, 0.033f * SizeMp);
        clone.transform.parent = ObjBox.transform;

        shapesSpawnArea.ShapesList.Add(clone);
    }

    public void SizeInit()
    {
        SizeMp = 1.4f;
        SizeText=3;
        GameObject.Find("GameManager").GetComponent<Second_GameManager>().Index_ =1;
        for (int i = shapesSpawnArea.ShapesList.Count - 1; i >= 0; i--)
        {
            Destroy(shapesSpawnArea.ShapesList[i]);
        }
        shapesSpawnArea.ShapesList.Clear();


        GreenObjon(Circle_G);
        RedObjon(Circle_R);
        BlueObjon(Circle_B);
        YellowObjon(Circle_Y);

    }
}
