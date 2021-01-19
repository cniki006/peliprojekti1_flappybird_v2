using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float JumpForce = 1;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Nikitan lisäykset: AIjump == true
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }     
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Die();
        }
    }
    //add upwards force to player
    public void Jump()
    {
        rb.velocity = new Vector2(0,0);
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }
    //restart game, will change in the future
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
