using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class Enemy : Agent
{
    public Transform Target1;

    public float Speed = 1;

    public float Range;


    private void Start()
    {
       Time.timeScale = 1f;
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float x = actions.ContinuousActions[0];
        float z = actions.ContinuousActions[1];

        if (Range > Vector3.Distance(Target1.localPosition, transform.localPosition))
        {
            transform.position += new Vector3(x, 0, z) * Speed;

        }
        




        
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(Target1.localPosition.x);
        sensor.AddObservation(Target1.localPosition.y);
        sensor.AddObservation(Target1.localPosition.z);


        sensor.AddObservation(transform.localPosition.x);
        sensor.AddObservation(transform.localPosition.y);
        sensor.AddObservation(transform.localPosition.z);

      
    }


    

    

    
    




}
