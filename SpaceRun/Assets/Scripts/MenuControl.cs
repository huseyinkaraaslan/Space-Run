using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject startScreen, finishScreen, dieScreen, levelScreen, menuScreen;

    private void Start()
    {
        menuScreen.SetActive(true);
        levelScreen.SetActive(false);
    }

    public void startButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void levelButton()
    {
        levelScreen.SetActive(true);
        menuScreen.SetActive(false);
    }

    public void level1Button()
    {
        SceneManager.LoadScene("Level1");
    }

    public void level2Button()
    {
        SceneManager.LoadScene("Level2");
    }

    public void menuButton()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0){
            levelScreen.SetActive(false);
            menuScreen.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
        
    }

    public void playButton()
    {
        GetComponent<PlayerControl>().anim.SetBool("Run", true);
        GetComponent<PlayerControl>().anim.SetBool("Walk", false);
        GetComponent<PlayerControl>().anim.SetBool("End", false);

        startScreen.SetActive(false);
    }

    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
