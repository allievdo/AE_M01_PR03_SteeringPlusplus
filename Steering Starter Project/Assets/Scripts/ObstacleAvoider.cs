using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoider : Kinematic
{
    ObstacleAvoidance myMoveType;

    //public Kinematic[] theTargets = new Kinematic[4];

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new ObstacleAvoidance();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        //myMoveType.flee = flee;

        //mySeekRotateType = new Face();
        //mySeekRotateType.character = this;
        //mySeekRotateType.target = myTarget;

        //myFleeRotateType = new LookWhereGoing();
        //myFleeRotateType.character = this;
        //myFleeRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        //steeringUpdate = new SteeringOutput();
        steeringUpdate = myMoveType.getSteering();
        base.Update();
    }
}