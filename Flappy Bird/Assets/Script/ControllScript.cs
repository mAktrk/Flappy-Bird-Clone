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


    [SerializeField] private float speed = -5f;

    void Start()
    {
        rigidbodyOne = backgroundOne.GetComponent<Rigidbody2D>();
        rigidbodyTwo = backgronudTwo.GetComponent<Rigidbody2D>();

        rigidbodyOne.velocity = new Vector2(speed, 0);
        rigidbodyTwo.velocity = new Vector2(speed, 0);

        length = backgroundOne.GetComponent<BoxCollider2D>().size.x;


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
    }
}
