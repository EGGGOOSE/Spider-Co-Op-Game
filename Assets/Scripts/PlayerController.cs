using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce = 3f;
    private Rigidbody2D rb;
    public float move;
    PhotonView view;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (view.IsMine)
        {
            move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
            Jumping();
        }
    }
    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }
}
