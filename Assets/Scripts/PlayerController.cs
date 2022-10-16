using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;
using UnityEngine.UI;

public class PlayerController : EntityBehaviour<IPlayerPositionState>
{
    public Text txtType;

    bool _left;
    bool _right;
    bool _jump;

    PlayerMotor motor;
   public bool hasControl = false;
    void Awake()
    {
        motor = GetComponent<PlayerMotor>();
        if (BoltNetwork.IsServer)
        {
            txtType.text = "Server";
        }
        else
            txtType.text = "Client";
    }

    public override void Attached()
    {
        state.SetTransforms(state.PlayerPos, transform);
        if (entity.HasControl)
        {
            hasControl = true;
        }
    }
    void PollReys()
    {
        _left = Input.GetKey(KeyCode.A);
        _right = Input.GetKey(KeyCode.D);
        _jump = Input.GetKey(KeyCode.Space);
    }
    void Update()
    {
        PollReys();
    }
    public override void SimulateController()
    {
        IPlayerCommandInput input = PlayerCommand.Create();
        input.left = _left;
        input.right = _right;
        input.jump = _jump;

        entity.QueueInput(input);
        motor.ExecuteCommand(_left, _right,_jump);
        
    }
    /*void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }*/
    public override void ExecuteCommand(Command command, bool resetState)
    {
        PlayerCommand cmd = (PlayerCommand)command;

        if (resetState)
        {
            // we got a correction from the server, reset (this only runs on the client)
            motor.SetState(cmd.Result.position, cmd.Result.velocity);
        }
        else
        {
            PlayerMotor.State motorState = new PlayerMotor.State();
            motorState = motor.ExecuteCommand(cmd.Input.left, cmd.Input.right,cmd.Input.jump);

            cmd.Result.position = motorState.position;
            cmd.Result.velocity = motorState.velocity;
        }
    }
}
