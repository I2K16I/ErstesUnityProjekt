using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class LaserController : MonoBehaviour
{
    public int dmg = 1;
    private GameManager _gm;
    private Vector3 _homePosition;
    private bool isMovingHome = false;
    private bool _isActive = false;
    private ParticleSystem _lightEffect;
    private ParticleSystem _burnEffect;
    [Range(0, 25)]
    public float moveSpeed = 10f;
    public bool isBase = false;
    public bool isStationary;
    public bool isTimed;
    public GameObject movePoint;
    public GameObject LaserLight;
    public GameObject BurnMark;
    public float toogleDelay = 3f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _homePosition = gameObject.transform.position;
        _gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (!isBase)
        {
            _lightEffect = LaserLight.GetComponent<ParticleSystem>();
            _burnEffect = BurnMark.GetComponent<ParticleSystem>();
        }
        if (isTimed)
        {
            ToggleLaser();
        }
    }

    private void Update()
    {
        if (!isBase)
        {
            return;
        }

        if (isStationary)
        {
            return;
        }

        Debug.Log("Test");
        if (!isMovingHome)
        {
             Vector3 targetedDestination = movePoint.transform.position;
             Vector3 updatedPosition = Vector3.MoveTowards(transform.position, targetedDestination,
                 moveSpeed * Time.deltaTime);
             transform.position = updatedPosition;
      
            if (Vector3.Distance(transform.position, movePoint.transform.position) <= 0.1)
            {
                isMovingHome = true;
            }
        }
        else
        {
            Vector3 updatedPosition = Vector3.MoveTowards(transform.position, _homePosition,
                moveSpeed * Time.deltaTime);
            transform.position = updatedPosition;
            if (Vector3.Distance(transform.position, _homePosition) <= 0.03)
            {
                isMovingHome = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))    
        {
            _gm.takeDmg(dmg);
        }
    }

    private void ToggleLaser()
    {
        _isActive =! _isActive; 
        LaserLight.SetActive(_isActive);
        gameObject.SetActive(_isActive);
        if (_isActive)
        {
            _lightEffect.Play();
            _burnEffect.Play();
        }
        else
        {
            _lightEffect.Stop();
            _burnEffect.Stop();
        }
        Invoke("ToggleLaser", toogleDelay);
    }
}
