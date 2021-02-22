using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllScript : MonoBehaviour
{
    
    public GameObject backgroundOne;
    
    public GameObject backgronudTwo;

    private Rigidbody2D rigidbodyOne;
    private Rigidbody2D rigidbodyTwo;

    private float length = 0;

    [SerializeField] private GameObject obstalces;
    [SerializeField] private int howManyObstalces;
    private GameObject []obstalceArray;

    private int counter = 0;
    private float time = 0;

    private float postionY;

    [SerializeField] private float speed = -5f;

    void Start()
    {
        rigidbodyOne = backgroundOne.GetComponent<Rigidbody2D>();
        rigidbodyTwo = backgronudTwo.GetComponent<Rigidbody2D>();

        rigidbodyOne.velocity = new Vector2(speed, 0);
        rigidbodyTwo.velocity = new Vector2(speed, 0);

        length = backgroundOne.GetComponent<BoxCollider2D>().size.x;

        obstalceArray = new GameObject[howManyObstalces];

        for (int i = 0; i < obstalceArray.Length; i++)
        {
            obstalceArray[i] = Instantiate(obstalces, new Vector3(-20, -20), Quaternion.identity);
            Rigidbody2D rigidbodyObstalces = obstalceArray[i].AddComponent<Rigidbody2D>();
            rigidbodyObstalces.gravityScale = 0;
            rigidbodyObstalces.velocity = new Vector2(speed, 0);
        }

    }

    
    void Update()
    {
        if (backgroundOne.transform.position.x <= -length) 
        {
            backgroundOne.transform.position += new Vector3(length * 2, 0, 0);
        }
        if (backgronudTwo.transform.position.x <= -length)
        { 
           backgronudTwo.transform.position += new Vector3(length * 2, 0, 0);
        }

        time += Time.deltaTime;
        if (time >= 2f)
        {
            time = 0;
            postionY = Random.Range(-1f, 1.3f);
            obstalceArray[counter].transform.position = new Vector3(18, postionY);
            counter++;
            if (counter >= obstalceArray.Length)
            {
                counter = 0;
            }
        } 
         
    }

    public void GameOver()
    {
        for (int i = 0; i < obstalceArray.Length; i++)
        {
            obstalceArray[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            rigidbodyOne.velocity = Vector2.zero;
            rigidbodyTwo.velocity = Vector2.zero;
        }
    }
}
