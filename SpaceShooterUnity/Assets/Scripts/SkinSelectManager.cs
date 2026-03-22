using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinSelectManager : MonoBehaviour
{
    public Button continueButton; // The "To the Sky" button
    public Button[] skinButtons;  // Drag all 3 skin buttons here in order
    public Color highlightColor = Color.yellow; // Color of the selection box
    public float outlineWidth = 3f; // Thickness of the selection box

    private int selectedSkin = -1;


    void Start()
    {
        // Hide the continue button until a skin is selected
        continueButton.gameObject.SetActive(false);


        // Remove any existing outlines at start
        foreach (Button btn in skinButtons)
        {
            Outline outline = btn.GetComponent<Outline>();
            if (outline != null)
            {
                outline.enabled = false;
            }
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


        // Update the highlight box on all buttons
        for (int i = 0; i < skinButtons.Length; i++)
        {
            Outline outline = skinButtons[i].GetComponent<Outline>();
            // Add an Outline component if one doesn't exist yet
            if (outline == null)
            {
                outline = skinButtons[i].gameObject.AddComponent<Outline>();
                outline.effectColor = highlightColor;
                outline.effectDistance = new Vector2(outlineWidth, outlineWidth);
            }
            // Enable outline only on the selected skin, disable on others
            outline.enabled = (i == skinIndex);
        }
    }

    // Call this from the continue button
    public void ContinueToGame()
    {
        SceneManager.LoadScene(2);
    }
}