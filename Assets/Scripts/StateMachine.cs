using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        idle,
        walking,
        swimming,
        climbling
    }
    public State currentState = State.idle;
    Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.idle: Idle();  break;
            case State.walking: Walking();  break;
            case State.swimming: Swimming();  break;
            case State.climbling: Climbing();  break;
            default: break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.name == "WaterTrigger")
        {
            currentState = State.swimming;
        }
        else if(other.name == "MountainTrigger")
        {
            currentState = State.climbling;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentState = State.walking;
    }

    void Swimming()
    {
        Debug.Log("I am swiming");
    }

    void Climbing()
    {
        Debug.Log("I am climbing");
    }

    void Idle()
    {
        Debug.Log("I am idle");
        if(lastPos != transform.position) // See if previous position is not in the current position
        {
            currentState = State.walking;
        }

        lastPos = transform.position;
    }

    void Walking()
    {
        Debug.Log("I am walking");
        if (lastPos == transform.position) // See if previous position is not in the current position
        {
            currentState = State.idle;
        }

        lastPos = transform.position;
    }
}
