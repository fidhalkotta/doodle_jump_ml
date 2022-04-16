using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class DoodleJumpAgent : Agent
{
    [Header("References")]
    //[SerializeField] private Rigidbody2D rb;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private Background _background;
    
    

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float levelWidth = 3f;

    private float score = 0f;
    [SerializeField] private Rigidbody2D rb;
    
    float movement = 0f;
    
    private Vector3 startingPos;
    
    public override void Initialize()
    {
        startingPos = transform.position;
        score = 0f;
    }

    public override void OnEpisodeBegin()
    {
        transform.position = startingPos;
        score = 0f;
        rb.velocity = Vector2.zero;
        _levelGenerator.ResetPlatforms();
        _background.ResetBackground();
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        movement = actions.ContinuousActions[0] * movementSpeed;
        
        var velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;

        if (transform.position.x < _levelGenerator.transform.position.x - levelWidth)
        {
            transform.position = new Vector3(_levelGenerator.transform.position.x + levelWidth, transform.position.y,transform.position.z);
        }
        else if (transform.position.x > _levelGenerator.transform.position.x + levelWidth)
        {
            transform.position = new Vector3(_levelGenerator.transform.position.x - levelWidth, transform.position.y,transform.position.z);
        }
    }

    public void FixedUpdate()
    {
        var possibleNewScore = rb.transform.position.y;

        if (possibleNewScore > score)
        {
            score = possibleNewScore;
            SetReward(score);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Background")
        {
            AddReward(-1f);
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxis("Horizontal");
    }
}
