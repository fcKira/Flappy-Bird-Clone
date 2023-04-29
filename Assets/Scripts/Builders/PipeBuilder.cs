using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PipeBuilder
{
    Func<PipeObstacle> _factoryMethod;

    Vector3 _position;
    float _speed;
    float _xBound;
    float _gap;

    Action<PipeObstacle> _releaseMethod;

    public PipeBuilder(Func<PipeObstacle> factoryMethod)
    {
        _factoryMethod = factoryMethod;

        _releaseMethod = delegate { };
    }

    public PipeBuilder SetPosition(Vector3 position)
    {
        _position = position;
        return this;
    }
    public PipeBuilder SetSpeed(float speed)
    {
        _speed = speed;
        return this;
    }
    public PipeBuilder SetEndPosition(float xBound)
    {
        _xBound = xBound;
        return this;
    }
    public PipeBuilder SetGap(float gap)
    {
        _gap = gap;
        return this;
    }
    public PipeBuilder SetReleaseMethod(Action<PipeObstacle> releaseMethod)
    {
        _releaseMethod = releaseMethod;
        return this;
    }

    public PipeObstacle Done()
    {
        PipeObstacle pipe = _factoryMethod();
        pipe.transform.position = _position;
        pipe.ModifyGap(_gap);
        pipe.speed = _speed;
        pipe.xBoundPosition = _xBound;
        pipe.OnRelease = _releaseMethod;

        return pipe;
    }
}
