using Common.Runtime.Interface;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Common.Runtime.Abstract
{
    // A simple Singleton Pattern for MonoBehaviours
    public abstract class AMonoSingleton<T> : MonoBehaviour, IInitialize where T : Object
    {
        private static T _instance;

        public static T Instance => _instance;

        private void Awake()
        {
            var instances = FindObjectsByType<T>(FindObjectsSortMode.None);
            var size = instances.Length;
            if (size < 1)
            {
                Debug.LogError($"There is no instance for {typeof(T).Name} in {SceneManager.GetActiveScene().name}");
                return;
            }

            var selectedInstance = instances[0];
            if (size > 1)
            {
                var message = $"There are multiple instances for {typeof(T).Name} in {SceneManager.GetActiveScene().name}\n";
                if (selectedInstance != this)
                {
                    message += $"Destroying {name}";
                    Destroy(this);
                }
                
                Debug.LogWarning(message);
            }

            _instance = selectedInstance;
            Initialize();
        }

        public abstract void Initialize();
    }
}