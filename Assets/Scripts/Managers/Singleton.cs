using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;
    public bool notDestroyOnLoad;

    void Awake()
    {
        RegisterSingleton();
    }

    protected void RegisterSingleton()
    {
        if (instance == null)
        {
            instance = this as T;
            if (notDestroyOnLoad) DontDestroyOnLoad(gameObject);
        }
    }
}