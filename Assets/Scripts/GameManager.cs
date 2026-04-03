using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Node[] allNodes;
    public TextMeshProUGUI CongratsText;
    public TextMeshProUGUI PuzzleSolvedText;
    public AudioSource WinSound;

    public GameObject InsPanel;
    public GameObject InsButton;
    public GameObject CloseButton;


    public void CheckWin()
    {
        foreach (Node node in allNodes)
        {
            // Skip center (no color assigned)
            if (string.IsNullOrEmpty(node.targetColor))
                continue;

            // If node is empty  not solved
            if (node.currentCoin == null)
                return;

            // If wrong coin  not solved
            if (node.currentCoin.colorName != node.targetColor)
                return;
        }

        //  ALL CORRECT
        Debug.Log(" PUZZLE SOLVED!");
        WinSound.Play();
        CongratsText.enabled = true;
        PuzzleSolvedText.enabled = true;
    }

    public void OpenInsPanel()
    {
        InsPanel.SetActive(true);
    }
    public void CloseInsPanel()
    {
        InsPanel.SetActive(false); 
    }
}
