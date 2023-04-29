using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class ObstaclesHandler : MonoBehaviour
{
    [Header("Pipes Settings")]
    [SerializeField] float _gap;
    [SerializeField] float _speed;
    [SerializeField] float _minGapPosition;
    [SerializeField] float _maxGapPosition;

    [Header("Handler Settings")]
    [SerializeField] float _spawningTime;
    float _currentTime;
    [SerializeField] float _cameraBoundOffset;

    List<PipeObstacle> _currentObstacles;

    float _startPosition;
    float _endPosition;

    void Start()
    {
        InitializeBoundaries();

        _currentTime = _spawningTime;

        _currentObstacles = new List<PipeObstacle>();
    }
    
    void Update()
    {
        if (_currentTime > _spawningTime)
        {
            _currentTime -= _spawningTime;

            var obstacle = new PipeBuilder(ObstacleFactory.Instance.GetObject)
                            .SetPosition(new Vector3(_startPosition, Random.Range(_minGapPosition, _maxGapPosition), 0))
                            .SetGap(_gap)
                            .SetSpeed(_speed)
                            .SetEndPosition(_endPosition)
                            .SetReleaseMethod((x) => 
                            { 
                                RemoveFromUpdate(x);
                                ObstacleFactory.Instance.ReturnObject(x);
                            })
                            .Done();

            _currentObstacles.Add(obstacle);
        }

        _currentTime += Time.deltaTime;

    }

    private void FixedUpdate()
    {
        for (int i = _currentObstacles.Count - 1; i >= 0; i--)
        {
            _currentObstacles[i].FakeFixedUpdate();
        }
    }

    public void RemoveFromUpdate(PipeObstacle pipe)
    {
        _currentObstacles.Remove(pipe);
    }

    void InitializeBoundaries()
    {
        Camera camera = Camera.main;
        float screenWidth = camera.orthographicSize * Screen.width / Screen.height;

        _endPosition = camera.transform.position.x + screenWidth + _cameraBoundOffset;
        _startPosition = -_endPosition;
    }

    
}
