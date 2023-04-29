using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PipeObstacle : MonoBehaviour
{
    [SerializeField] Transform _topPipe;
    [SerializeField] Transform _bottomPipe;

    public float speed;
    public float xBoundPosition;

    public Action<PipeObstacle> OnRelease = delegate { };

    public void FakeFixedUpdate()
    {
        transform.position += transform.right * speed * Time.fixedDeltaTime;

        if (transform.position.x > xBoundPosition)
        {
            OnRelease(this);
        }
    }

    public void ModifyGap(float gap)
    {
        gap /= 2;

        _topPipe.localPosition = Vector3.up * gap;
        _bottomPipe.localPosition = Vector3.up * -gap;
    }
}
