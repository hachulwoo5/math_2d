using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Manager : MonoBehaviour
{

    public static Scene1Manager realInstance;

    public GameObject scene;
  
    private void Awake()
    {
        // 이미 인스턴스가 존재하면 이 객체를 파괴
        if (realInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        // 인스턴스가 없으면 이 객체를 유지
        realInstance = this;
        DontDestroyOnLoad(gameObject);

    }
}
