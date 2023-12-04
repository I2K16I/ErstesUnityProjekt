using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyController : MonoBehaviour
{
    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _player.transform.position;
    }
}
