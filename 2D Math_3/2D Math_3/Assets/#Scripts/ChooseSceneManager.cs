using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSceneManager : MonoBehaviour
{
    public static ChooseSceneManager instance;

    private void Awake()
    {
        // �̹� �ν��Ͻ��� �����ϸ� �� ��ü�� �ı�
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // �ν��Ͻ��� ������ �� ��ü�� ����
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
