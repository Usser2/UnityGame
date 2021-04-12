using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hero : MonoBehaviour
{
    Rigidbody2D rb;
    int Life = 100;
    Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetAxis("Horizontal") == 0)
        { anim.SetInteger("anim_numb", 0); }
        else
        { anim.SetInteger("anim_numb", 1); }
        Flip();
        OnGUI();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 6f, rb.velocity.y);
    }

    void Jump()
    {
        rb.AddForce(transform.up * 7f, ForceMode2D.Impulse);
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void ReloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);

    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "knife")
        {
            // ReloadLevel();
            Life = Life - 25;
            if (Life <= 0)
                ReloadLevel();
        }

    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "heal")
        {
            // ReloadLevel();
            Life = Life + 50;
            if (Life >= 100)
                Life = 100;
            Destroy(obj.gameObject);

        if (obj.gameObject.tag == "Finish")
            {
                 Application.LoadLevel("Scene2");
                // SceneManager.LoadScene("Scene2");
            }
        }

    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 30), "Life=" + Life);
    }
}
