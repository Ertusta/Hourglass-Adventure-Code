using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Lights : Agent
{
    Rigidbody rb;

    public float Force;
    public float Range;

    public Transform Food;

   

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float x = Force * actions.ContinuousActions[0];
        float z = Force * actions.ContinuousActions[1];


        if (Range <Vector3.Distance(Food.localPosition, transform.localPosition))
        {
            rb.AddForce(new Vector3(x, 0, z), ForceMode.Impulse);

        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }



    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition.x);
        sensor.AddObservation(transform.localPosition.z);
        sensor.AddObservation(rb.velocity.x);
        sensor.AddObservation(rb.velocity.z);



        sensor.AddObservation(Food.transform.localPosition.x);
        sensor.AddObservation(Food.transform.localPosition.z);



    }






}
