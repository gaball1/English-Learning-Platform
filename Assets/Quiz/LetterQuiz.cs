using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LetterQuiz : MonoBehaviour
{
	public Button letterA, letterD, letterF; // الأزرار
	public GameObject truepanel;
	//public GameObject successEffect, failureEffect; // المؤثرات
	void Start()
	{
		letterA.onClick.AddListener(() => CorrectAnswer());
		letterD.onClick.AddListener(() => StartCoroutine(WrongAnswer(letterD)));
		letterF.onClick.AddListener(() => StartCoroutine(WrongAnswer(letterF)));
	}

	void CorrectAnswer()
	{
		truepanel.SetActive(true);
		//successEffect.SetActive(true); 
	}

	IEnumerator WrongAnswer(Button wrongButton)
	{
		Vector3 originalPosition = wrongButton.transform.localPosition; // حفظ مكان الزر الأصلي
		float duration = 0.5f; // مدة الاهتزاز
		float magnitude = 10f; // مقدار الاهتزاز

		float elapsed = 0f;

		// اهتزاز ذهابًا وإيابًا
		while (elapsed < duration)
		{
			float xOffset = Mathf.Sin(Time.time * 50f) * magnitude; // حساب الحركة السريعة
			wrongButton.transform.localPosition = originalPosition + new Vector3(xOffset, 0, 0);
			elapsed += Time.deltaTime;
			yield return null; // الانتظار حتى الإطار التالي
		}

		// إعادة الزر لمكانه الأصلي
		wrongButton.transform.localPosition = originalPosition;
		//failureEffect.SetActive(true);
	}
}
