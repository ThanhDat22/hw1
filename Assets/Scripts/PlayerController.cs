using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public Text timerText;
    public Text winText;
    public Text gameOverText;
    public Button restartButton;

    float currentTime = 0f;
    float startingTime = 60f;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;

        rb2d = GetComponent<Rigidbody2D>();

        gameOverText.text = "";

        winText.text = "";
        restartButton.gameObject.SetActive(false); // hide button
    }

    // FixedUpdate is in sysc with physics engine
    void FixedUpdate()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = "Timer: " + currentTime.ToString("0");
        if (currentTime < 0)
        {
            currentTime = -1;
        }
        


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //rb2d.AddForce(movement * speed);
        rb2d.velocity = movement * speed;

        if (currentTime < 1 && currentTime > 0)
        {
            winText.text = "You win!";
            gameOverText.text = "";
            restartButton.gameObject.SetActive(true); // show button
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(true); 

            gameOverText.text = "Game Over!";

            currentTime = -1;

            timerText.text = "Timer: ";

            //winText.text = "";

            restartButton.gameObject.SetActive(true); // show button
        }
        
    }

    public void OnRestartButtonPress()
    {
        SceneManager.LoadScene("SampleScene"); // restart the game
    }

}
