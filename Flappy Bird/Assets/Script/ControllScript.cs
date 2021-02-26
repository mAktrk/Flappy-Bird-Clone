using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllScript : MonoBehaviour
{
    


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

        time += Time.deltaTime;
        if (time >= 2f)
        {
            time = 0;
            postionY = Random.Range(-0.285f, 0.300f);
            obstalceArray[counter].transform.position = new Vector3(0.115f, postionY);
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
        }
    }
}
