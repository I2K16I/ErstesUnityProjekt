using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public List<GameObject> movePoints;
    [Range(0, 25)]
    public float moveSpeed = 5f;
    [Range(0, 5)]
    public int invokeTime = 2;
    public Boolean waitAtEnd;

    private int _i = 0;
    private Vector3 _startPosition;
    private Boolean _isMovingForward;
    private Boolean _isMovingBackward;
    private Boolean _isMovingHome;
    private Boolean _isWaiting;

    // Update is called once per frame
    void Update()
    {
        if (_isMovingHome || _isMovingBackward || _isMovingForward)
        {
            Move();
        }
    }

    private void Move()
    {
        if (_isMovingHome)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _startPosition) <= 0.03)
            {
                _isMovingHome = false;
            }
        }
        else
        {
            Vector3 targetedDestination = movePoints[_i].transform.position;
            Vector3 updatedPosition = Vector3.MoveTowards(transform.position, targetedDestination,
                moveSpeed * Time.deltaTime);
            transform.position = updatedPosition;

            if (_isMovingBackward)
            {
                if (Vector3.Distance(transform.position, targetedDestination) <= 0.1 && _i > 0)
                {
                    _i--;
                }
                else if (_i != 0)
                {
                    return;
                }

                if (Vector3.Distance(transform.position, movePoints[0].transform.position) <= 0.1)
                {
                    _isMovingBackward = false;
                    _isMovingHome = true;
                }
            }
            else if (_isMovingForward)
            {
                if (Vector3.Distance(transform.position, targetedDestination) <= 0.1 && _i < movePoints.Count - 1)
                {
                    _i++;
                }
                else if (_i != movePoints.Count - 1)
                {
                    return;
                }
                if (Vector3.Distance(transform.position, movePoints[Index.FromEnd(1)].transform.position) <= 0.1 &&
                    waitAtEnd)
                {
                    _isMovingForward = false;
                    _isWaiting = true;
                }
                else if (Vector3.Distance(transform.position, movePoints[Index.FromEnd(1)].transform.position) <= 0.1 &&
                          !waitAtEnd)
                {
                    _isMovingForward = false;
                    Invoke("ToggleBackwards", invokeTime);
                }
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !_isMovingForward && !_isMovingBackward && !_isMovingHome && !_isWaiting)
        {
            Invoke("MoveAlongPath", invokeTime);
        }
        else if (other.gameObject.CompareTag("Player") && _isWaiting)
        {
            Invoke("ToggleBackwards", invokeTime);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = transform;
        }

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !_isMovingForward && !_isMovingBackward && !_isMovingHome || other.gameObject.CompareTag("Player") && _isWaiting)
        {
            CancelInvoke("MoveAlongPath");
            Debug.Log("Invoke cancelled");
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = null;
        }

    }

    private void MoveAlongPath()
    {
        _isMovingForward = true;
        Debug.Log("Start moving");
        _startPosition = transform.position;
    }

    private void ToggleBackwards()
    {
        _isWaiting = false;
        _isMovingBackward = !_isMovingBackward;
    }
}
