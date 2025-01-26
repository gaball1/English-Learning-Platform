using UnityEngine;

public class CelebrationManager : MonoBehaviour
{
    public GameObject particleEffect;  // مرجع لـ Particle System أو تأثير الاحتفال
    public AudioSource celebrationSound; // مرجع للصوت الاحتفالي (اختياري)

    void OnEnable()
    {
        // تشغيل الاحتفال بمجرد فتح البانل
        if (particleEffect != null)
        {
            particleEffect.SetActive(true); // إظهار الـ Particle Effect
        }

        if (celebrationSound != null)
        {
            celebrationSound.Play(); // تشغيل الصوت
        }

        // إخفاء التأثير بعد مدة (مثلاً 3 ثوانٍ)
        Invoke("StopCelebration", 3f);
    }

    void StopCelebration()
    {
        if (particleEffect != null)
        {
            particleEffect.SetActive(false); // إخفاء التأثير
        }
    }
}
