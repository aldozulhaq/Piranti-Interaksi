using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Camera cam;
    public static Vector3 camPos;
    Timer tr;

    public GameObject winPanel;
    public TMP_Text timePanel;

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
        timePanel.text = tr.currentTime.ToString();
        winPanel.SetActive(true);
    }
}
