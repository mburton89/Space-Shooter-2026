using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinSelectManager : MonoBehaviour
{
    public Button continueButton; // The "Roll Out" button
    private int selectedSkin = -1; // Track which skin the player clicked

    void Start()
    {
        // Hide the continue button until a skin is selected
        continueButton.gameObject.SetActive(false);
    }

    // Call this from your skin buttons
    public void SelectSkin(int skinIndex)
    {
        selectedSkin = skinIndex;

        // Save the selection so the PlayerShip can read it
        PlayerPrefs.SetInt("SelectedSkin", skinIndex);

        // Show the continue button now that a skin is selected
        continueButton.gameObject.SetActive(true);
    }

    // Call this from the continue button
    public void ContinueToGame()
    {
        // Load your gameplay scene (replace 2 with your actual scene index or name)
        SceneManager.LoadScene(2);
    }
}