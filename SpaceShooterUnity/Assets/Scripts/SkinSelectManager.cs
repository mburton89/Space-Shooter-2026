using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SkinSelectManager : MonoBehaviour
{
    public Button continueButton; // The "To the Sky" button
    public Button[] skinButtons;  // Drag all 3 skin buttons here in order
    public Color selectedColor = Color.yellow;   // Tint when selected
    public Color unselectedColor = Color.white;  // Normal tint (white = no tint)
    private int selectedSkin = -1;
    void Start()
    {
        // Hide the continue button until a skin is selected
        continueButton.gameObject.SetActive(false);
        // Set all buttons to unselected color at start
        foreach (Button btn in skinButtons)
        {
            btn.GetComponent<Image>().color = unselectedColor;
        }
    }
    // Call this from your skin buttons
    public void SelectSkin(int skinIndex)
    {
        selectedSkin = skinIndex;
        // Save the selection so the PlayerShip can read it
        PlayerPrefs.SetInt("SelectedSkin", skinIndex);
        // Show the continue button now that a skin is selected
        continueButton.gameObject.SetActive(true);
        // Tint the selected button, reset others
        for (int i = 0; i < skinButtons.Length; i++)
        {
            if (i == skinIndex)
            {
                skinButtons[i].GetComponent<Image>().color = selectedColor;
            }
            else
            {
                skinButtons[i].GetComponent<Image>().color = unselectedColor;
            }
        }
    }
    // Call this from the continue button
    public void ContinueToGame()
    {
        SceneManager.LoadScene(2);
    }
}
