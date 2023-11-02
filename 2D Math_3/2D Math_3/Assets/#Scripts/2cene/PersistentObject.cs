using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    private static PersistentObject instance;

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
}