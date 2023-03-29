using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private int runSpeed, walkSpeed;
    public Transform camera;
    public Animator anim;
    Vector3 firstPos, endPos, tempPos;
    Vector3 distance;
    Touch finger;

    void Start()
    {
        runSpeed = 6; walkSpeed = 2;
        distance = new Vector3(-2.2f, 2.7f, 0);
        anim = this.GetComponent<Animator>();
        camera.transform.position = this.transform.position + distance;
    }

    void Update()
    {
        if (anim.GetBool("Run"))
        {
            characterMove();
        }
        else if (anim.GetBool("Walk"))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
        }
    }

    public void characterMove()
    {
         transform.Translate(0, 0, runSpeed * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            finger = Input.GetTouch(0);

            if (finger.phase == TouchPhase.Began)
            {
                firstPos = finger.position;
                endPos = finger.position;
            }

            if (finger.phase == TouchPhase.Moved)
            {
                endPos = finger.position;
            }

            tempPos = (endPos - firstPos).normalized;
            transform.Translate((tempPos.x) / 25, 0, 0);
        }

        camera.transform.position = Vector3.Lerp(camera.transform.position, this.transform.position + distance, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishLine")
        {
            anim.SetBool("Run", false);
            anim.SetBool("Walk", true);
            anim.SetBool("End", false);
            anim.SetBool("Die", false);
        }

        if (other.tag == "End")
        {
            anim.SetBool("Run", false);
            anim.SetBool("Walk", false);
            anim.SetBool("End", true);
            anim.SetBool("Die", false);

            GetComponent<MenuControl>().finishScreen.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent.tag == "Obstacle")
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            anim.SetBool("Die", true);

            camera.transform.position = this.transform.position + distance + new Vector3(-2,0,0);
            GetComponent<MenuControl>().dieScreen.SetActive(true);
        }
    }
}
