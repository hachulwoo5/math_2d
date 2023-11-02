using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public bool isDraging;

    Drag drag;

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
        SceneManager.LoadScene("MainScene");
    }

    public void SceneChoose1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void SceneChoose2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void SceneChoose3()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void SceneChoose4()
    {
        SceneManager.LoadScene("Stage4");
    }

    public void SceneBack()
    {
        SceneManager.LoadScene("StartScene");
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
