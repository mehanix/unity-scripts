/**
 * TextOverload (TextOverload.cs)
 * 
 * Description: Captures keyboard typing character by character and spawns randomized TextMeshPro UI text elements on screen when words complete.
 * Usage: Attach to a manager object. Assign a TextMeshProUGUI prefab to textPrefab and set mainCanvas in the Inspector. Requires TextMeshPro package.
 */
using UnityEngine;
using TMPro;

public class TextOverload : MonoBehaviour
{
    public GameObject textPrefab;
    public Canvas mainCanvas;

    // This stores the letters invisibly until you finish the word
    private string currentWord = "";

    void Update()
    {
        // Read whatever is being typed this frame
        foreach (char c in Input.inputString)
        {
            if (c == '\b')
            {
                // Handle Backspace: remove the last letter
                if (currentWord.Length > 0)
                {
                    currentWord = currentWord.Substring(0, currentWord.Length - 1);
                }
            }
            else if (c == ' ' || c == '\n' || c == '\r')
            {
                // Space or Enter means the word is finished!
                if (currentWord.Length > 0)
                {
                    SpawnTextChaos(currentWord);
                    currentWord = ""; // Clear the buffer for the next word
                }
            }
            else
            {
                // Add the typed letter to our invisible buffer
                currentWord += c;
            }
        }
    }

    void SpawnTextChaos(string word)
    {
        // 1. Spawn the text object
        GameObject newTextObj = Instantiate(textPrefab, mainCanvas.transform);
        TextMeshProUGUI tmp = newTextObj.GetComponent<TextMeshProUGUI>();

        // 2. Set it to the full word we just finished typing
        tmp.text = word;

        // 3. Randomize size, position, and rotation
        tmp.fontSize = Random.Range(80, 300);

        float randomX = Random.Range(-Screen.width / 2f, Screen.width / 2f);
        float randomY = Random.Range(-Screen.height / 2f, Screen.height / 2f);

        newTextObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(randomX, randomY);
        newTextObj.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, Random.Range(-25f, 25f));
    }
}