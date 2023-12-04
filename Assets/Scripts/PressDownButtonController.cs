using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PressDownButtonController : MonoBehaviour
{
    public Material firstMaterial;
    public Material secondMaterial;
    public GameObject Gate;
    public float speedToOpenGate = 2f;
    public float speedToLowerGate = 1f;
    public Boolean autoOpen;
    public Boolean stayOpen;
    private Vector3 _gateParentScale;
    private float _gateHeight = 1.8f;
    private Boolean _isDown = false;
    private Boolean _minTime = true;
    private Boolean _isOpening;
    private Boolean _isClosing;
    private Boolean _isTouchingPlayer;
    private Boolean _isTouchingBox;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private Vector3 _tempGate;
    private Vector3 _gateStartPosition;



    // Start is called before the first frame update
    void Start()
    {
        var temp = transform.position;
        _startPosition = temp;
        temp.y -= 0.1f;
        _endPosition = temp;
        _gateParentScale = Gate.transform.parent.localScale;
        _tempGate = Gate.transform.position;
        _gateStartPosition = _tempGate;
        _tempGate.y += _gateHeight * _gateParentScale.y;
    }
    // Update is called once per frame
    void Update()
    {
        if (_isOpening)
        {
            Vector3 updatedPosition =
                Vector3.MoveTowards(Gate.transform.position, _tempGate, speedToOpenGate * Time.deltaTime);
            Gate.transform.position = updatedPosition;
            if (Vector3.Distance(_tempGate, Gate.transform.position) <= 0.03f)
            {
                _isOpening = false;
            }
        } else if (_isClosing)
        {
            Vector3 updatedPosition =
                Vector3.MoveTowards(Gate.transform.position, _gateStartPosition, speedToLowerGate * Time.deltaTime);
            Gate.transform.position = updatedPosition;
            if (Vector3.Distance(_gateStartPosition, Gate.transform.position) <= 0.03f)
            {
                _isClosing = false;
            }
        }


    }
    private void OnCollisionEnter(Collision other)
    {
        if (! (!_isDown && _minTime))
        {
            return;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            _isTouchingPlayer = true;
        }
        else if (other.gameObject.CompareTag("Box"))
        {
            _isTouchingBox = true;
        }
        else
        {
            return;
        }
        
        transform.position = _endPosition;
        _isDown = true;
        _minTime = false;
        Invoke("MinTimeHasEnded", 0.5f);
        Debug.Log("Button Down");
        GetComponent<MeshRenderer>().material = secondMaterial;
        _isOpening = true;
        if (_isClosing)
        {
            _isClosing = false;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (!(_isDown && _minTime))
        {
            return;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            _isTouchingPlayer = false;
        } else if (other.gameObject.CompareTag("Box"))
        {
            _isTouchingBox = false;
        }
        else
        {
            return;
        }

        if (_isTouchingPlayer || _isTouchingBox)
        {
            return;
        }
        if (!autoOpen)
        {
            _isOpening = false;
        }

        if (!stayOpen)
        {
            _isClosing = true;
        }
        transform.position = _startPosition;
        _isDown = false;
        _minTime = false;
        Invoke("MinTimeHasEnded", 0.5f);
        Debug.Log("Button Up");
        GetComponent<MeshRenderer>().material = firstMaterial;
    }
    private void MinTimeHasEnded()
    {
        _minTime = true;
    }
}
