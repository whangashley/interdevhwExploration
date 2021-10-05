using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*using TMPro;
using System;*/

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myBody;

    /* Tried to make a score counter that followed the player + kept track of the keys obtained. 
     * Kept getting console error, so I'll be commenting this out for now.
    public int keysFound;
    public TMP_Text keysText;*/

    [SerializeField] private GameObject WinScreen;

    public int keysFound;
    bool fiveKeys = false;

    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        //keysText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckKeys();
        myBody.gravityScale = 0;
        //keysText.text = keysFound.ToString() + "Found";
        if (keysFound == 5)
        {
            fiveKeys = true;
        }

        if (fiveKeys == true)
        {
            WinScreen.SetActive(true);
        }
    }

    void CheckKeys()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "key")
        {
            keysFound++;
            Destroy(collision.gameObject);
        }
    }


}