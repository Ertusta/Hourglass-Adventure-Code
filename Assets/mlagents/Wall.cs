using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.VisualScripting;
using UnityEngine;

public class Wall : Agent
{
    public Transform Target1;

    public float Speed = 1;
    public float Range;





    public override void OnActionReceived(ActionBuffers actions)
    {
        float x = actions.ContinuousActions[0];
        

       



        if (Range > Vector3.Distance(Target1.localPosition, transform.localPosition))
        {
            transform.position += new Vector3(x, 0, 0) * Speed;

        }


    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(Target1.localPosition.x);
        sensor.AddObservation(transform.localPosition.x);
    }







}
