using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject Background;
    public GameObject Option;
    public GameObject Level;

    public PlayerData pd;
    public TMP_Text ez;
    public TMP_Text m;
    public TMP_Text h;

    // Start is called before the first frame update
    void Start()
    {
        Background.SetActive(true);
        Option.SetActive(false);

        ez.text = pd.easyTime;
        m.text = pd.medTime;
        h.text = pd.hardTime;
    }
    // option
    public void OptionClicked()
    {
        Option.SetActive(true);
        Background.SetActive(true);
    }

    public void Backclicked()
    {
        Option.SetActive(false);
        Background.SetActive(true);
    }
    public void PlayClicked()
    {
        Level.SetActive(true);
        Background.SetActive(false);
    }
    public void BackPlayclicked()
    {
        Level.SetActive(false);
        Background.SetActive(true);
    }

    public void ExitClicked()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGameEZ()
    {
        GameManager.Difficulty = "ez";
        GameManager.camPos = new Vector3(.2f, 9.28f, 0.6f);
        MazeGenerator.ms = new Vector2Int(5, 5);
        PlayGame();
    }

    public void PlayGameIM()
    {
        GameManager.Difficulty = "im";
        GameManager.camPos = new Vector3(3f, 16f, 1.75f);
        MazeGenerator.ms = new Vector2Int(10, 10);
        PlayGame();
    }

    public void PlayGameHR()
    {
        GameManager.Difficulty = "hr";
        GameManager.camPos = new Vector3(3f, 22f, 3.1f);
        MazeGenerator.ms = new Vector2Int(15, 15);
        PlayGame();
    }
}
