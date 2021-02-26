using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneScript : MonoBehaviour
{

    public Text skorText;

    void Start()
    {
       int skor = PlayerPrefs.GetInt("kayit");

       skorText.text = skor.ToString();
    }

   

    public void Scene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
