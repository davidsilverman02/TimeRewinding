using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    const int recordedFrames = 10000;

    Timebody[] entities;

    bool paused;

    bool hasGone;

    // Start is called before the first frame update
    void Start()
    {
        entities = FindObjectsOfType<Timebody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("it do");

            paused = !paused;
        }
    }


    void FixedUpdate()
    {
        if(paused)
        {
            if(!hasGone)
            {
                foreach (Timebody body in entities)
                {
                    body.makePause(paused);
                }

                hasGone = true;
            }

            if(Input.GetKey(KeyCode.LeftArrow))
            {
                foreach(Timebody body in entities)
                {
                    body.Rewind();
                }
            }
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                foreach (Timebody body in entities)
                {
                    body.FastForward(recordedFrames);
                }
            }
        }
        else
        {
            if (hasGone)
            {
                foreach (Timebody body in entities)
                {
                    body.makePause(paused);
                }

                hasGone = false;
            }
               
            foreach (Timebody body in entities)
            {
                body.Record(recordedFrames);
            }
        }
    }
}
