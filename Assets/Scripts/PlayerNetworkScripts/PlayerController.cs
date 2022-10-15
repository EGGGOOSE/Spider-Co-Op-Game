using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerController : NetworkBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce = 3f;
    private Rigidbody2D rb;
    public float move;
    NetworkRigidbody2D networkrb;
    //NetworkPosition networkPosition;*/
    CharacterController controllerPrototype;
    // Start is called before the first frame update
    private void Awake()
    {
        networkrb = GetComponent<NetworkRigidbody2D>();
        
        rb = GetComponent<Rigidbody2D>();
       //networkPosition = GetComponent<NetworkPosition>();*/
        //controllerPrototype = GetComponent<CharacterController>();
    }
    public override void Spawned()
    {
        Debug.Log("spawnedLocal");
        if (Object.HasInputAuthority)
        {
            networkrb.InterpolationDataSource = InterpolationDataSources.Predicted;
        }
    }
    public override void FixedUpdateNetwork()
    {
        //move = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        //networkrb.ReadVelocity();
        //rb.Rigidbody.velocity = new Vector2(move * maxSpeed, rb.Rigidbody.velocity.y);
        if(GetInput(out NetworkInputData NetworkInputData))
        {
            float direction = NetworkInputData.direction;
            //rb.velocity = new Vector2(direction * maxSpeed, rb.velocity.y);*/
            //Vector2 moveDirection = transform.right * direction;
            //networkrb.ReadVelocity();
            networkrb.Rigidbody.velocity = new Vector2(direction * maxSpeed, rb.velocity.y);
            //controllerPrototype.Move(moveDirection);
            //controllerPrototype.Move(moveDirection);
        }
    }
}
