using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Node[] allNodes;
    public TextMeshProUGUI CongratsText;
    public TextMeshProUGUI PuzzleSolvedText;
    public AudioSource WinSound;

    public GameObject PlayButton;
    public TextMeshProUGUI InsText;
    public GameObject ExitButton;
    public GameObject MainMenuButton;

    public bool canPlay = false; //IMPORTANT
    public AutoColorChanger ACC;
    public GameTimer GT;

    void Start()
    {
        canPlay = false; //FORCE LOCK

        CongratsText.enabled = false;
        PuzzleSolvedText.enabled = false;
    }

    public void CheckWin()
    {
        foreach (Node node in allNodes)
        {
            if (string.IsNullOrEmpty(node.targetColor))
                continue;

            if (node.currentCoin == null)
                return;

            if (node.currentCoin.colorName != node.targetColor)
                return;
        }

        Debug.Log("PUZZLE SOLVED!");
        canPlay = false;
        GT.GetComponent<GameTimer>().StopTimer();
        StartCoroutine(ACC.GetComponent<AutoColorChanger>().ChangeColorRoutine());
        CongratsText.enabled = true;
        PuzzleSolvedText.enabled = true;
        WinSound.Play();
        MainMenuButton.SetActive(true);
    }

    public void PlayGame()
    {
        canPlay = true;
        GT.GetComponent<GameTimer>().StartTimer(); //START TIMER
        InsText.enabled = false;
        PlayButton.SetActive(false);
        ExitButton.SetActive(false);
    }

    public void ExitGame()
    {
       Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}