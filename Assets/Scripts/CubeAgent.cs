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
    private float startDistance;
    public void Start()
    {
    }
    public override void OnEpisodeBegin()
    {    
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
    }
    public float speedMultiplier = 0.5f;
    public float rotationMultiplier = 5;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {    // Acties, size = 2    
        
        Vector3 controlSignal = Vector3.zero;

        controlSignal.z = actionBuffers.ContinuousActions[0];
        transform.Translate(controlSignal * speedMultiplier);
        transform.Rotate(0.0f, rotationMultiplier * actionBuffers.ContinuousActions[1], 0.0f);

        // Beloningen
        //cube vinden
        if (transform.localPosition.y < -1){
            Debug.Log(GetCumulativeReward());
            EndEpisode();
        }
        else {
            SetReward(1f);
            EndEpisode();
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpforce);
    }
    
}