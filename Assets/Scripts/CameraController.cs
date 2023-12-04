using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraController : MonoBehaviour
{
    
    public GameObject player;
    public GameObject empty;
    private GameManager _gm;
    
    private Vector3 _offset; //Abstand Kamera zu Player
    private Vector2 _rotate;
    private float _offsetDistance = 1;
    private float _scale;  //Scrollgeschwindigkeit
    private float _cameraSensitivity;
    

    public List<GameObject> movePoints;

    [Range(0, 100)]
    public float moveSpeed = 50f;

    private int _i = 0;
    
    private bool _startCamIntro;
    public bool hasCameraIntro;
    private bool _staticCamera = true;


    void Start()
    {
        _offset = transform.position - player.transform.position; //Abstand Kamera zu Player
        _gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _gm.mouseSensitivityChanged.AddListener(UpdateCameraSensitivity);
        _cameraSensitivity = _gm.mouseSens;
        if (hasCameraIntro)
        {
            _startCamIntro = true;
            transform.position = movePoints[0].transform.position;
        }
    }

    void Awake()
    {
        _scale = 0.3f;
    }

    void Update()
    {
        if (_startCamIntro)
        {
            //Debug.Log("StartCamIntro");
            if (Vector3.Distance(transform.position, movePoints[_i].transform.position) <= 0.1)
            {
                _i++;
            }
          
            Vector3 targetedDestination = movePoints[_i].transform.position;
            Vector3 updatedPosition = Vector3.MoveTowards(transform.position, targetedDestination,
                moveSpeed * Time.deltaTime);
            transform.position = updatedPosition;
          
            if (Vector3.Distance(transform.position, movePoints[movePoints.Count - 1].transform.position) <= 0.1)
            {
                _startCamIntro = false;
            }  
        }
    }

    void LateUpdate()
    {
        if (_staticCamera)
        {
            _offsetDistance+=Input.mouseScrollDelta.y * _scale; //Scrolling
            //Input.mouseScrollDelta.
            if (!_startCamIntro)
            {
                transform.position = player.transform.position+ _offset*_offsetDistance;
            }
        }
        else if (!_staticCamera)
        {
            empty.transform.localRotation = Quaternion.Euler(-_rotate.y, _rotate.x, 0);
        }
    }

    public void OnMouseMovement(InputAction.CallbackContext value)
    {
        if (_staticCamera)
        {
            return;
        }
        _rotate += value.ReadValue<Vector2>() * _cameraSensitivity;
    }

    public void OnToggleCameraMode(InputAction.CallbackContext value)
    {
        if (!value.started)
        {
            return;
        }

        _staticCamera = !_staticCamera;
        if (_staticCamera)
        {
            _offset = transform.position-empty.transform.position;
            _offsetDistance = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void UpdateCameraSensitivity()
    {
        _cameraSensitivity = _gm.mouseSens;
    }
}
