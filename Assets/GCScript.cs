using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCScript : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Button startButton;
    public UnityEngine.UI.Text shieldText;
    public GameObject menu;
    public GameObject sSBoom;

    public static GCScript instance;
    public bool isStarted = false; 

    int score = 0;
    int shield = 1;

    public void increaseScore(int increment)
    {
        score += increment;
        scoreText.text = "Score: " + score;
    }
    public void increaseShield(int increment)
    {
        shield += increment;
        shieldText.text = "Shields: " + (shield - 1);
    }
    public void decreaseShield(int increment)
    {
        shield -= increment;
        if (shield == 0)
        {
            Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Instantiate(sSBoom, playerTransform.position, Quaternion.identity);
            return;
        }
        shieldText.text = "Shields: " + (shield - 1);
    }
    void Start()
    {
        instance = this;
        startButton.onClick.AddListener(delegate
        {
            isStarted = true;
            menu.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
