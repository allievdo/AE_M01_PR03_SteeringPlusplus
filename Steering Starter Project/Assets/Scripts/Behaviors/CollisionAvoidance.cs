using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class CollisionAvoidance : SteeringBehavior
{
    public Kinematic character;
    public Kinematic[] targets;

    public float maxAcceleration = 1f;

    float radius = 0.5f;

    //Vector3 relativePos = Vector3.zero;
    //Vector3 relativeVel;

    public override SteeringOutput getSteering()
    {
        //find the object that is closest to collision
        //Store the first collision time
        float shortestTime = float.PositiveInfinity;

        //store the target that collides then, and other data
        //that we will need and can avoid recalculating
        Kinematic firstTarget = null;
        float firstMinSeperation = float.PositiveInfinity;
        float firstDistance = float.PositiveInfinity;
        Vector3 firstRelativePos = Vector3.positiveInfinity;
        Vector3 firstRelativeVel = Vector3.zero;

        //loop through each target
        foreach (Kinematic target in targets)
        {
            //calculate the time to collision
            Vector3 relativePos = target.transform.position - character.transform.position;
            Vector3 relativeVel = character.linearVelocity - target.linearVelocity;
            float relativeSpeed = relativeVel.magnitude;
            float timeToCollision = (Vector3.Dot(relativePos, relativeVel) / (relativeSpeed * relativeSpeed));

            //check if it is going to be a collision at all
            float distance = relativePos.magnitude;
            float minSeperation = distance - relativeSpeed * timeToCollision;

            if(minSeperation > 2*radius)
            {
                continue;
            }

            //check if it is the shortest
            if (timeToCollision > 0 && timeToCollision < shortestTime)
            {
                //store the time, target, and other data
                shortestTime = timeToCollision;
                firstTarget = target;
                firstMinSeperation = minSeperation;
                firstDistance = distance;
                firstRelativePos = relativePos;
                firstRelativeVel = relativeVel;
            }
        }

        //calculate the steering

        if(firstTarget == null)
        {
            return null;
        }

        SteeringOutput result = new SteeringOutput();

        float dotResult = Vector3.Dot(character.linearVelocity.normalized, firstTarget.linearVelocity.normalized);

        if (dotResult < -0.9)
        {
            result.linear = new Vector3(character.linearVelocity.z, 0.0f, character.linearVelocity.x);
        }

        else
        {
            result.linear = -firstTarget.linearVelocity;
        }

        result.linear.Normalize();
        result.linear *= maxAcceleration;
        result.angular = 0f;

        return result;
    }
}
