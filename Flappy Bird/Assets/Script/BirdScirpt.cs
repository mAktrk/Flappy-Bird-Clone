using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdScirpt : MonoBehaviour
{

    private Rigidbody2D rigidbody2d;
    private int skor = 0;
    private int rekor = 0;

    private bool gameOver = true;
    ControllScript GameOver;

    [SerializeField] private Text skorText;

    private AudioSource []audioSource;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        GameOver = GameObject.FindGameObjectWithTag("GameOver").GetComponent<ControllScript>();
        audioSource = GetComponents<AudioSource>();
        rekor = PlayerPrefs.GetInt("kayit");

        Debug.Log(rekor);
    }

    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -45));
        if (Input.GetMouseButtonDown(0) && gameOver)
        {
            rigidbody2d.velocity = new Vector2(0, 0);
            rigidbody2d.AddForce(new Vector2(0, 7));
            audioSource[0].Play();
            
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
            skorText.text = skor.ToString();
            audioSource[1].Play();
        }
        if (collision.gameObject.tag == "GameOverTag")
        {
            gameOver = false;
            audioSource[2].Play();
            GameOver.GameOver();
            GetComponent<CircleCollider2D>().enabled = false;
            if(skor > rekor)
            {
                rekor = skor;
                PlayerPrefs.SetInt("kayit", rekor);
            }
            Invoke("startMenu", 1f);
        }
    }

    void startMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
