using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeController : MonoBehaviour
{
    public float timeTillDelete = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeTillDelete);
    }


}
