using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    private bool _isActive;
    private bool _isTracking;

    private GameObject _canonMain;
    private GameObject _player;
    public GameObject projectile;
    public GameObject smokeSystem;
    public GameObject flash;
    
    public float turnSpeed = 0.03f;
    public float smokeDelay = 0.5f;
    public float shotDelay = 5f;
    private Quaternion _targetRoataion;
    private Quaternion _CanonHeadYManipulated;
    private Vector3 _gameObjectPosition;
    private Vector3 _lookAtDirection;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _canonMain = transform.GetChild(0).gameObject;
        _gameObjectPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!_isActive)
        {
            return;
        }

        // Transform for the holder
        _lookAtDirection = (_player.transform.position - _gameObjectPosition).normalized;
        _lookAtDirection.y = _gameObjectPosition.y;
        _targetRoataion = Quaternion.LookRotation(_lookAtDirection);
        _targetRoataion.x = transform.rotation.x;
        _targetRoataion.z = transform.rotation.z;
        transform.rotation = Quaternion.Slerp(transform.rotation, _targetRoataion, turnSpeed);
        //gameObject.transform.LookAt(_lookAtDirection);
        
        // Transform for the CanonHead
        _lookAtDirection = (_player.transform.position - _canonMain.transform.position).normalized;
        _targetRoataion = Quaternion.LookRotation(_lookAtDirection);
        _canonMain.transform.rotation = Quaternion.Slerp(_canonMain.transform.rotation, _targetRoataion, turnSpeed);
        //_canonMain.transform.LookAt(_player.transform.position - _gameObjectPosition);
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ToogleIsActive();
            Invoke("Fire", 1.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CancelInvoke();
            ToogleIsActive();
        }
    }

    private void ToogleIsActive()
    {
        _isActive =! _isActive;
    }

    private void Fire()
    {
        Instantiate(projectile, _canonMain.transform.position, _canonMain.transform.rotation);
        Invoke("FlashAndSmoke", smokeDelay);
        Invoke("Fire", shotDelay);
    }

    private void FlashAndSmoke()
    {
        Instantiate(smokeSystem, _canonMain.transform.position + _lookAtDirection, _canonMain.transform.rotation, _canonMain.transform);
        Instantiate(flash, _canonMain.transform.position + _lookAtDirection, _canonMain.transform.rotation);
    }
}
