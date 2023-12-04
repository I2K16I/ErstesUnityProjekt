using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DmgFieldController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 _currentScale;
    private Vector3 _updatedScale;
    public float scaleSpeed = 0.03f;
    public float particleScaleSpeed = 0.01f;
    public float targetScale = 4.47f;
    public float scaleUpSpeed = 0.05f;
    private float _particleScale = 1f;
    private bool IsDownscaling = false;
    private bool IsUpScaling = true;
    private Transform _particleSystem;
    private GameManager _gm;
    public int dmg = 1;
    void Start()
    {
        _particleSystem = gameObject.transform.GetChild(0).transform;
        Invoke("StartDownscale", 5);
        _gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (IsDownscaling)
        {
            ScaleDownAndDestroy();
            return;
        }
        if (!IsUpScaling)
        {
            return;
        }

        _currentScale = gameObject.transform.localScale;
        if (_currentScale.x < targetScale)
        {
            _updatedScale = new Vector3(_currentScale.x + scaleUpSpeed, _currentScale.y + scaleUpSpeed,
                _currentScale.z + scaleUpSpeed);
            gameObject.transform.localScale = _updatedScale;
        }
    }

    private void StartDownscale()
    {
        IsDownscaling = true;
    }
    
    private void ScaleDownAndDestroy()
    {
        _currentScale = gameObject.transform.localScale;
        _updatedScale = new Vector3(_currentScale.x - scaleSpeed, _currentScale.y - scaleSpeed, _currentScale.z - scaleSpeed);
        gameObject.transform.localScale = _updatedScale;

        if (_particleScale >= 0.05)
        {
            _particleScale -= particleScaleSpeed; 
            _particleSystem.localScale = new Vector3(_particleScale, _particleScale, _particleScale);
        }
        
        if (_updatedScale.x <= 0.05)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
                {
                    _gm.takeDmg(dmg);
                    Destroy(gameObject);
                }
    }
}
