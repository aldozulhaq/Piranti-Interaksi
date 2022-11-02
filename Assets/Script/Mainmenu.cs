using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject Background;
    public GameObject Option;
    public GameObject Level;

    // Start is called before the first frame update
    void Start()
    {
        Background.SetActive(true);
        Option.SetActive(false);
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
}
    