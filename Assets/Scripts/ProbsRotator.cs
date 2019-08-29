using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RotationDirection {
    firstDirection,
    SecondDirection
}
public class ProbsRotator : MonoBehaviour
{
    float PlanetRotateSpeed  = -25.0f;
    float OrbitSpeed  = 10.0f;
    float timer;
    RotationDirection currentRotationDirection;
    public List<Transform> rotatableProbsGroups;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // planet to spin on it's own axis
        //transform.Rotate(transform.up * PlanetRotateSpeed * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >=10 )
        {
            if (currentRotationDirection == RotationDirection.firstDirection)
            {
                currentRotationDirection = RotationDirection.SecondDirection;
            }
            else
            {
                currentRotationDirection = RotationDirection.firstDirection;
            }
            timer = 0;
        }
        if (currentRotationDirection == RotationDirection.firstDirection)
        {
            int flag=1;
            foreach (var group in rotatableProbsGroups)
            {
                group.RotateAround(transform.position, transform.right, flag * OrbitSpeed * Time.deltaTime * 0.05f);
                flag *= -1;
            }
        }
        else
        {
            int flag=-1;
            foreach (var group in rotatableProbsGroups)
            {
                group.RotateAround(transform.position, transform.right, flag * OrbitSpeed * Time.deltaTime * 0.05f);
                flag *= -1;
            }
        }
        // planet to travel along a path that rotates around the sun



    }
}
