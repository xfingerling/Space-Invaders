using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBorder : MonoBehaviour
{
    [SerializeField] GameObject _bottomLeftBorder;
    [SerializeField] GameObject _topRightBorder;

    private Camera _camera;
    private float _offset = 0.9f;
    
    public static float Top, Bottom, Left, Right;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        SetBoundaries();
    }

    private void SetBoundaries()
    {
        Vector3 point;

        point = _camera.ScreenToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
        Left = point.x * _offset;
        Bottom = point.y * _offset;

        point = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.nearClipPlane));
        Right = point.x * _offset;
        Top = point.y * _offset;
    }
}
