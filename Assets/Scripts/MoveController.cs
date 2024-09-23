using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public Vector2 direction;
    bool running = false;

    float currentTime = 0f;
    float startingTime = 60f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()   
    {
        currentTime -= 1 * Time.deltaTime;

        if (!running)
        {
            StartCoroutine(changeDirection());
        }

        int speedUp = 1;

        // Add twist
        if (currentTime < 20)
        {
            speedUp = 10;
        }

        rb2d.velocity += new Vector2(direction.x, direction.y) * Time.deltaTime * speed * speedUp;

        
    }

    IEnumerator changeDirection()
    {
        running = true;
        yield return new WaitForSeconds(1);
        direction.x = Random.Range(-1, 2);
        direction.y = Random.Range(-1, 2);
        running = false;
    }





}
