using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Image[] characterImages; // Array of character images
    public Vector3 selectedScale = new Vector3(1.5f, 1.5f, 1f); // Scale for the selected character
    public Vector3 defaultScale = Vector3.one; // Scale for non-selected characters
    public Vector3 centerPosition = new Vector3(0, 0, 0); // Position for the selected character
    public Vector3[] surroundingPositions; // Array of positions for the other characters

    private string selectedCharacterName;

    void Start()
    {
        // استعادة الكاركتر المختار مسبقًا
        selectedCharacterName = PlayerPrefs.GetString("SelectedCharacter", null);
        if (!string.IsNullOrEmpty(selectedCharacterName))
        {
            SelectCharacter(selectedCharacterName); // عرض الكاركتر المختار
        }
        else
        {
            UpdateCharacterPositions(); // إعادة ترتيب الكاركترات
        }
    }

    public void SelectCharacter(string characterName)
    {
        // Save selected character's name
        PlayerPrefs.SetString("SelectedCharacter", characterName);
        PlayerPrefs.Save();

        selectedCharacterName = characterName;

        // Update character positions and scales
        UpdateCharacterPositions();
    }

    void UpdateCharacterPositions()
    {
        int positionIndex = 0;
        foreach (Image img in characterImages)
        {
            if (img.name == selectedCharacterName)
            {
                img.transform.localPosition = centerPosition; // Move to center
                img.transform.localScale = selectedScale; // Enlarge selected character
            }
            else
            {
                if (positionIndex < surroundingPositions.Length)
                {
                    img.transform.localPosition = surroundingPositions[positionIndex]; // Position others around
                    img.transform.localScale = defaultScale; // Reset size
                    positionIndex++;
                }
            }
        }
    }

    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
