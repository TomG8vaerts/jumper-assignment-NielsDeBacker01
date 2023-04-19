using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.MLAgents;
using UnityEngine;
using JetBrains.Annotations;

public class CubeAgent : Agent
{
    public Rigidbody rb;
    public float jumpforce;
    bool end = false;
    bool isGrounded;
    float reward = 0;
    public void Start()
    {
    }
    public override void OnEpisodeBegin()
    {
        reward = .1f;
        // reset de positie en orientatie als de agent gevallen is
        if (this.transform.localPosition.y < -.5||this.transform.position.y>5)
        {

            this.transform.localPosition = new Vector3(0, 0.6f, 5.19f);
        }
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
    }
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {    // Acties, size = 2    
        

        int a;
        
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.55f);
        
        //Debug.Log(isGrounded);
        if (isGrounded)
        {
            a = actionBuffers.DiscreteActions[0];
            if (a==1)
            {
                Jump();
            }
        }

        if (end)
        {
            print(reward);
            if (reward>=1)
            {
                AddReward(1);
                EndEpisode();
            }
            else
            {
                AddReward(reward);
                EndEpisode();
            }
        }
        else
        {
            reward += .2f;
        }
    }

    public void Jump()
    {
        reward -= reward/4;
        rb.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
    }
    public void End()
    {
        end = true;
    }
}