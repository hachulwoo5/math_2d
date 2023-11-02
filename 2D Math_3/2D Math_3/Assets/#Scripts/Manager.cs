using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
   


    public bool isDraging;

    First_Drag drag;

    public int Att;
    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SceneStart()
    {
        SceneManager.LoadScene("ChooseScene");
    }

    public void SceneChoose1()
    {
        SceneManager.LoadScene("1Scene");

        if(ChooseSceneManager.instance.FirstEnter1==false)
        {
            Scene1Manager.realInstance.scene.gameObject.SetActive(true);

        }
        else
        {
            ChooseSceneManager.instance.FirstEnter1 = false;
        }


    }
    public void SceneChoose2()
    {

        SceneManager.LoadScene("Test2");

        if (ChooseSceneManager.instance.FirstEnter2== false)
        {
            Scene2Manager.realInstance.scene.gameObject.SetActive(true);

        }
        else
        {
            ChooseSceneManager.instance.FirstEnter2 = false;
        }
    }
    public void SceneChoose3()
    {
        SceneManager.LoadScene("3Scene");

        if (ChooseSceneManager.instance.FirstEnter3 == false)
        {
            Scene3Manager.realInstance.scene.gameObject.SetActive(true);

        }
        else
        {
            ChooseSceneManager.instance.FirstEnter3 = false;
        }

    }


    public void SceneChoose4()
    {
        SceneManager.LoadScene("Stage4");
    }

    public void SceneBack()
    {
        SceneManager.LoadScene("ChooseScene");
    }


    public void Quit()
    {
        Application.Quit();
    }
    public void SceneDraw()
    {
        SceneManager.LoadScene("Stage2");
    }

    
}
