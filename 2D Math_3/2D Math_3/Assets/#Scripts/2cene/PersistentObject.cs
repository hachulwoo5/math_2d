using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    private static PersistentObject instance;

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
}