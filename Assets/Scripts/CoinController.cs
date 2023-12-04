using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinController : MonoBehaviour
{
    private Transform _trans;
    private int _i = 0;
    private bool _down;
    private Vector3 position;
    public float rotationSpeed = 1;

    private void Start()
    {
        _trans = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        _trans.Rotate(0, 0, rotationSpeed);
        position = _trans.position;
        if (!_down)
        {
            _trans.position = new Vector3(position.x, position.y + 0.0015f, position.z);
            _i++;
        }
        else
        {
            _trans.position = new Vector3(position.x, position.y - 0.0015f, position.z);
            _i--;
        }

        if (_i <= 0 || _i >= 200)
        {
            _down = !_down;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
