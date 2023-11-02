using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSceneManager : MonoBehaviour
{
    public static ChooseSceneManager instance;

    private void Awake()
    {
        // 이미 인스턴스가 존재하면 이 객체를 파괴
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // 인스턴스가 없으면 이 객체를 유지
        instance = this;
        DontDestroyOnLoad(gameObject);

    }
    public bool FirstEnter1;
    public bool FirstEnter2;
    public bool FirstEnter3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
