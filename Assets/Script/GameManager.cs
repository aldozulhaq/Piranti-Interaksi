using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Camera cam;
    public static Vector3 camPos;
    public static string Difficulty;
    Timer tr;

    public GameObject winPanel;
    public TMP_Text timePanel;
    public PlayerData pd;

    // Start is called before the first frame update
    void Start()
    {
        if (camPos.x > 0)
            SetCamera(camPos);
        tr = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void ResumetTime()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        StopTime();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        ResumetTime();
    }

    public void SetCamera(Vector3 pos)
    {
        cam.transform.position = pos;
    }

    public void FinishGame()
    {
        PauseGame();
        timePanel.text = tr.currentTime.ToString("0.##");
        winPanel.SetActive(true);
        SetBestTime();
    }

    public void SetBestTime()
    {
        float time;
        switch (Difficulty)
        {
            case "ez":
                time = float.Parse(pd.easyTime);
                if (time > tr.currentTime || time == 0)
                {
                    pd.easyTime = tr.currentTime.ToString("0.##");
                }
                break;
            case "im":
                time = float.Parse(pd.medTime);
                if (time > tr.currentTime || time == 0)
                {
                    pd.medTime = tr.currentTime.ToString("0.##");
                }
                break;
            case "hr":
                time = float.Parse(pd.hardTime);
                if (time > tr.currentTime || time == 0)
                {
                    pd.hardTime = tr.currentTime.ToString("0.##");
                }
                break;
        }
    }
}
