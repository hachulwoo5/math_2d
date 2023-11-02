using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Manager : MonoBehaviour
{

    public static Scene1Manager realInstance;

    public GameObject scene;
  
    private void Awake()
    {
        // �̹� �ν��Ͻ��� �����ϸ� �� ��ü�� �ı�
        if (realInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        // �ν��Ͻ��� ������ �� ��ü�� ����
        realInstance = this;
        DontDestroyOnLoad(gameObject);

    }
}
