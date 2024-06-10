using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HelicopterController : MonoBehaviour
{
    public float engineForce = 1000f;
    public float forwardSpeed = 5f;
    private int score;
    private int gap;
    public TextMeshProUGUI scoreText;
    public GameObject collisionMenu;
    public Rigidbody2D rb;
    public AudioSource audiosr;

    void Start()
    {
        score = 0;
        gap = 0;
        rb = GetComponent<Rigidbody2D>();
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(forwardSpeed * Time.deltaTime, rb.velocity.y);

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * engineForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            AscendForce();
        }

        if (transform.position.x > gap * 10)
        {
            score++;
            UpdateScoreText();
            gap++;
        }
    }

    public void AscendForce()
    {
        rb.AddForce(Vector3.up * engineForce * Time.deltaTime);
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        collisionMenu.SetActive(true);
        GameObject.FindGameObjectWithTag("Pause").SetActive(false);
        audiosr.Pause();
        Time.timeScale = 0;
    }
}
