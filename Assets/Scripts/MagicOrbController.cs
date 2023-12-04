using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrbController : MonoBehaviour
{
    private GameManager _gm;
    private GameObject _player;
    public GameObject prefab;
    public GameObject prefabExplosion;
    public int dmg = 2;
    public float speed = 0.01f;
    public float selfDestructionDelay = 10f;
    private Vector3 _direction = new Vector3(0.1f, 0, 0);
    private Vector3 _currentPosition;
    [Range(0, 5000)]
    public int knockbackStrength = 150;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _direction = (_player.transform.position - transform.position).normalized;
        _gm  = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Invoke("noTargetHit", selfDestructionDelay);
    }

    // Update is called once per frame
    void Update()
    {
        _currentPosition = gameObject.transform.position;
        gameObject.transform.position = new Vector3(_currentPosition.x + (_direction.x * speed),
            _currentPosition.y + (_direction.y * speed), _currentPosition.z + (_direction.z * speed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Canon"))
        {
            return;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            _gm.AddExternalForceToPlayer(_direction * knockbackStrength);
            _gm.takeDmg(dmg);
            Instantiate(prefabExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (!other.gameObject.CompareTag("Player"))
        {
            Instantiate(prefabExplosion, transform.position, transform.rotation);
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void noTargetHit()
    {
        Destroy(gameObject);
    }
}
