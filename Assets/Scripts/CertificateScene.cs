using UnityEngine;
using UnityEngine.UI;

public class CertificateScene : MonoBehaviour
{
	public Image characterDisplayImage; // صورة الكاركتر لعرضها

	public Sprite[] characterSprites; // كل صور الكاركترات المتاحة
	public string[] characterNames; // أسماء الكاركترات لمطابقة الاسم

	void Start()
	{
		string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter", null);

		if (!string.IsNullOrEmpty(selectedCharacter))
		{
			for (int i = 0; i < characterNames.Length; i++)
			{
				if (characterNames[i] == selectedCharacter)
				{
					characterDisplayImage.sprite = characterSprites[i]; // عرض صورة الكاركتر
					break;
				}
			}
		}
	}
}
