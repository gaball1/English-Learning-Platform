using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundMangerCode : MonoBehaviour
{
    private static SoundMangerCode instance;

    private string[] allowedScenes = { "SoundEffect", "Start", "SampleScene" };

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        // اشترك في حدث تحميل المشاهد
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // إلغاء الاشتراك في الحدث
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // تحقق إذا المشهد الحالي مش مسموح
        if (System.Array.IndexOf(allowedScenes, scene.name) == -1)
        {
            Destroy(gameObject); // امسح الصوت
        }
    }
}
