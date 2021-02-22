using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScirpt : MonoBehaviour
{

    private Rigidbody2D rigidbody2d;
    private int skor = 0;

    private bool gameOver = true;
    ControllScript GameOver;

    [SerializeField] private Text skorText;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        GameOver = GameObject.FindGameObjectWithTag("GameOver").GetComponent<ControllScript>();
        
    }

    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -45));
        if (Input.GetMouseButtonDown(0) && gameOver)
        {
            rigidbody2d.velocity = new Vector2(0, 0);
            rigidbody2d.AddForce(new Vector2(0, 200));
        }
        if (rigidbody2d.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TriggerTag")
        {
            skor = skor + 1;
            skorText.text = "SKOR = " + skor;
        }
        if (collision.gameObject.tag == "GameOverTag")
        {
            gameOver = false;
            GameOver.GameOver();
        }
    }
}
