using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoxController : MonoBehaviour
{
    private PlayerAddition _playerInteraction;
    private GameObject _playerObject;
    private Boolean _isCollidingWithPlayer = false;
    private Boolean _isDraged;
    private float maxDistance;
    private Rigidbody _rb;
    private GameManager _gm;

    public float offset = 1;
    
    private void Awake()
    {
        _playerInteraction = new PlayerAddition();
        _playerInteraction.PlayerCustom.Interact.performed += Interact;
    }
    
    private void Interact(InputAction.CallbackContext value)
    {
        if (_isDraged)
        {
            _isDraged = false;
            _gm.ToggleDragingStatus();
            return;
        }
        if (_isCollidingWithPlayer)
        {
            _isDraged = true;
            maxDistance = Mathf.Abs(Vector3.Distance(transform.position, _playerObject.transform.position)) + offset;
            _gm.ToggleDragingStatus();
        }
    }

    private void OnEnable()
    {
        _playerInteraction.Enable();
    }

    private void OnDisable()
    {
        _playerInteraction.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isCollidingWithPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isCollidingWithPlayer = false;
        }
    }

    private void Start()
    {
        _playerObject = GameObject.FindWithTag("Player");
        _rb = GetComponent<Rigidbody>();
        _gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isDraged)
        {
            return;
        }
        
        var delta = Vector3.Distance(transform.position, _playerObject.transform.position);
        Debug.Log("Maximale Distanz: " + maxDistance);
        if (delta >= maxDistance)
        {
            Debug.Log("Adding Force");
            var forceVektor = _playerObject.transform.position - transform.position;
            forceVektor.y = 0;
            _rb.AddForce(forceVektor.normalized);
        }
    }
}
