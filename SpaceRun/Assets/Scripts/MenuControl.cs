using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public void playButton()
    {
        GetComponent<PlayerControl>().anim.SetBool("Run", true);
        GetComponent<PlayerControl>().anim.SetBool("Walk", false);
        GetComponent<PlayerControl>().anim.SetBool("End", false);

        GetComponent<PlayerControl>().startScreen.SetActive(false);

    }
}
