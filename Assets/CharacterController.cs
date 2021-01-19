using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float gravity;
    public float jumpForce;
    float verticalSpeed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalSpeed = verticalSpeed - gravity * Time.deltaTime;
        transform.position = transform.position + new Vector3(0.0f, verticalSpeed * Time.deltaTime,0.0f);
        if (Input.GetMouseButtonDown(0))
        {
            verticalSpeed = verticalSpeed + jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }
}
