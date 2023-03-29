using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject startScreen, finishScreen, dieScreen;

    private void Start()
    {
        startScreen.SetActive(true);
        dieScreen.SetActive(false);
        finishScreen.SetActive(false);
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
}
