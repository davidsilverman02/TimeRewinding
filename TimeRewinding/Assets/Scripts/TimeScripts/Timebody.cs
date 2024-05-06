using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timebody : MonoBehaviour
{
    Rigidbody rb;
    bool isRigidbody;

    int index = -1;

    Vector3 capVelo;

    List<PointInTime> frames;

    bool paused;

    public void Start()
    {
        frames = new List<PointInTime>();

        if (rb = GetComponent<Rigidbody>())
            isRigidbody = true;
    }


    public void Record(int maxSize)
    {
        index++;
        frames.Add(new PointInTime());

        if (index > frames.Count - 1)
            overWrite();
        frames[index].pos = gameObject.transform.position;
        frames[index].rot = gameObject.transform.rotation;
        frames[index].active = gameObject.activeInHierarchy;

        if (isRigidbody)
        {
            frames[index].velo = rb.velocity;
        }

        if(frames.Count > maxSize)
        {
            overTime();
            index--;
        }
    }

    public int getIndex()
    {
        return index;
    }

    public void overTime()
    {
        frames.RemoveAt(0);
    }

    public void makePause(bool time)
    {
        if (isRigidbody)
        {
            if (time == true)
                capVelo = rb.velocity;

            rb.isKinematic = time;

            if (time == false)
                rb.velocity = capVelo;
        }

        paused = time;
    }

    public void Rewind()
    {
        if(frames.Count == 0) { return; }

        if (index > 0)
            index--;

        setPos(frames[index]);
    }

    public void FastForward(int maxTime)
    {
        if (frames.Count == 0) { return; }

        if (index < maxTime - 1 && index < frames.Count - 1)
            index++;

        setPos(frames[index]);
    }

    public void setPos(PointInTime point)
    {
        gameObject.transform.position = point.pos;
        gameObject.transform.rotation = point.rot;
        gameObject.SetActive(point.active);

        if (isRigidbody)
            capVelo = point.velo;
    }

    public bool getPaused()
    {
        return paused;
    }

    void overWrite()
    {
        while (frames.Count > index + 1)
            frames.RemoveAt(index + 1);
    }
}
