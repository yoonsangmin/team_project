using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 10.0f;
    public float playerRotation = 50.0f;
    Rigidbody ri;


    public float jumpPower = 5f;
    public bool isJumping = false;


    private void Awake()
    {
        ri = GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == true)
        {
            Jump();
            Debug.Log("aaaaaa");

        }

    }
    private void FixedUpdate()
    {
        Player_Move();


       

    }

    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Plane")
        {
            isJumping = true;

        }
    }


    void Player_Move()
    {
        float keyHorizontal = Input.GetAxis("Horizontal");
        float keyVertical = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.right * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);
        transform.Translate(Vector3.forward * playerSpeed * Time.smoothDeltaTime * keyVertical, Space.Self);
        transform.Rotate(Vector3.up * playerRotation * Time.deltaTime * keyHorizontal);
    }

    void Jump()
    {
        ri.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

        isJumping = false;



    }
}
