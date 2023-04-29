using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : MonoBehaviour
{
    public static ObstacleFactory Instance { get; private set; }

    [SerializeField] PipeObstacle _obstaclePrefab;
    [SerializeField] int _initialAmount;

    ObjectPool<PipeObstacle> _obstaclePool;

    void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;

        _obstaclePool = new ObjectPool<PipeObstacle>(() => Instantiate(_obstaclePrefab, transform),
                                                    (o) => o.gameObject.SetActive(true),
                                                    (o) => o.gameObject.SetActive(false),
                                                     _initialAmount);
    }

    public PipeObstacle GetObject()
    {
        return _obstaclePool.GetObject();
    }

    public void ReturnObject(PipeObstacle b)
    {
        _obstaclePool.ReturnObject(b);
    }
    
}
