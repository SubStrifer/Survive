using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool _destroyed = false;
    private static object _lock = new object();
    private static T _instance;
 
    public static T Instance
    {
        get
        {
            if(_destroyed)
            {
                Debug.LogWarning("Singleton Instance " + typeof(T) +
                    " is already destroyed. Returning null.");
                return null;
            }
 
            lock(_lock)
            {
                if(_instance == null)
                {
                    // Search for an existing instance
                    _instance = (T)FindObjectOfType(typeof(T));
 
                    // Create new instance if necessary
                    if(_instance == null)
                    {
                        GameObject singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString();
 
                        // Make instance persistent
                        //DontDestroyOnLoad(singletonObject);
                    }
                }
 
                return _instance;
            }
        }
    }

    private void OnApplicationQuit()
    {
        _destroyed = true;
    }
 
    private void OnDestroy()
    {
        //_destroyed = true;
    }
}