using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 15f;

    public Vector2 position { get; set; }
    public Vector2 velocity { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public State ExecuteCommand(bool left, bool right,bool jump)
    {
        Vector2 movingDir = Vector2.zero;
        if (left ^ right)
        {
            movingDir = right ? transform.right : -transform.right;
        }
        movingDir.Normalize();
        movingDir *= moveSpeed;
        rb.velocity = movingDir;

        State stateMotor = new State();
        stateMotor.position = transform.position;
        stateMotor.velocity = rb.velocity;
        return stateMotor;
    }
    public struct State
    {
        public Vector2 position;
        public Vector2 velocity;
    }
    private void Jump()
    {
        if(rb.velocity.y ==0)
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    public void SetState(Vector2 position, Vector2 velocity)
    {
        GetComponent<Transform>().position = position;
        rb.velocity = velocity;
        Debug.Log(4);
    }
    
}
