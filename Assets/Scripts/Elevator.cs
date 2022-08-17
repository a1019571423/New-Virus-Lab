using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    enum State
    {
        up,
        down
    }
    public Transform up;
    public Transform down;

    State state;

    void Start()
    {
        state = State.down;
    }

    void Update()
    {
        switch (state)
        {
            case State.up:
                {
                    transform.position += new Vector3(0, 1f, 0) * Time.deltaTime;
                    if (transform.position.y >= up.position.y)
                    {
                        state = State.down;
                    }
                    break;
                }
            case State.down:
                {
                    transform.position -= new Vector3(0, 1f, 0) * Time.deltaTime;
                    if (transform.position.y <= down.position.y)
                    {
                        state = State.up;
                    }
                    break;
                }
        }
    }
}
