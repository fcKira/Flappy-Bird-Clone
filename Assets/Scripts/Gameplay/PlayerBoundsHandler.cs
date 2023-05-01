using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundsHandler : MonoBehaviour
{
    [SerializeField] Transform _topBound;
    [SerializeField] Transform _botBound;

    [SerializeField] float _yOffsetTop;
    [SerializeField] float _yOffsetBot;

    private void Start()
    {
        Camera camera = Camera.main;
        float screenHeight = (camera.orthographicSize * ((float)Screen.width / Screen.height)) /2;

        _topBound.position = new Vector3(GameManager.Instance.Player.transform.position.x, camera.transform.position.y + screenHeight + _yOffsetTop, 0);
        _botBound.position = new Vector3(GameManager.Instance.Player.transform.position.x, -camera.transform.position.y + screenHeight + _yOffsetBot, 0);
    }
}
