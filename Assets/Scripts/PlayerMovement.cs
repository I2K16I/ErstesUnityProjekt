using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private GameManager _gm;

    private Rigidbody _rb;
    private Boolean _isGrounded;
    private Boolean _isWalled;
    private Boolean _isOnSand;
    private float _sprintMult = 1;
    private GameObject _camera;
    
    [Range(0, 1200)]
    public int movementStrength = 1100;
    [Range(0, 800)]
    public int sandMovementSpeed = 400;

    [Range(400, 800)] public int jumpHeight = 600;
    public float sprintForce = 2.5f;

    public InputAction jump;
    public InputAction sprint;
    private Vector3 _direction;

    private void OnEnable()
    {
        sprint.Enable();
        jump.Enable();
    }

    private void OnDisable()
    {
        sprint.Disable();
        jump.Disable();
    }

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _gm.externalForceChanged.AddListener(ApplyExternalForce);
        _rb = GetComponent<Rigidbody>();
        _camera = GameObject.FindWithTag("MainCamera");
    }


    // Update is called once per frame
    void Update()
    {
        var forward = _camera.transform.forward;
        var right = _camera.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        var forwardRelative = _direction.z * forward;
        var rightRelative = _direction.x * right;


        if (sprint.WasPerformedThisFrame())
        {
            _sprintMult = sprintForce;
        }
        if (sprint.WasReleasedThisFrame())
        {
            _sprintMult = 1;
        }
        //transform.position += movementStrength * Time.deltaTime * _direction;
        var moventMult = movementStrength * Time.deltaTime * _sprintMult;
        if (_isGrounded)
        {
            _rb.AddForce(moventMult * forwardRelative);
            _rb.AddForce(moventMult * rightRelative);
        }
        else if (_isOnSand)
        {
            var moventMultSand = sandMovementSpeed * Time.deltaTime * _sprintMult;
            _rb.AddForce(moventMultSand * forwardRelative);
            _rb.AddForce(moventMultSand * rightRelative);
        }
        else
        {
            _rb.AddForce((moventMult/5) * forwardRelative);
            _rb.AddForce((moventMult/5) * rightRelative);
        }

        if (jump.IsPressed() && _isGrounded && !_gm.isDragging|| jump.IsPressed() && _isGrounded && _isWalled && !_gm.isDragging)
        {
            _isGrounded = false;
            _rb.drag = 0.5f;
            _rb.AddForce(0, jumpHeight, 0);
        }
        else if (jump.IsPressed() && _isWalled)
        {
            _isWalled = false;
            Debug.Log("Walljump");
            // Herausfinden was der aktuelle Bewegungsvektor ist

            //x und z Werte vergleichen, dann den kleineren Umkehren
        }
    }
    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        _direction = new Vector3(input.x, 0.0f, input.y);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _rb.drag = 4;
            _isGrounded = true;
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall Start");
            _isWalled = true;
        }
        else if (other.gameObject.CompareTag("Respawn"))
        {
            _gm.gainMaxHp();
        }
        else if (other.gameObject.CompareTag("Sand"))
        {
            Debug.Log("Sand");
            _isOnSand = true;
            _isGrounded = false;
        }
        else if (other.gameObject.CompareTag("Magma"))
        {
            _isGrounded = true;
            _rb.drag = 7f;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _gm.LeftSaveGround(transform.position);
            //_isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Void"))
        {
            Debug.Log("Leider verloren");
            _gm.FellOfMap();
            //_gm.LooseLevel();
            //transform.position = new Vector3(0, 1, 0);
        }
        else if (other.gameObject.CompareTag("Score"))
        {
            _gm.AddScore();
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Ziel erreicht");
            // UI fürs gewinnenzeigen
            _gm.CheckIfWon();
        }
        else if (other.gameObject.CompareTag("Magma"))
        {
            Debug.Log("DoT aktiviert");
            _gm.ActivateDoT(1, 0.8f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Magma"))
        {
            Debug.Log("DoT deaktiviert");
            _gm.DeactivateDot();
        }
    }

    public void ApplyExternalForce()
    {
        _rb.AddForce(_gm.externalForce.x, _gm.externalForce.y, _gm.externalForce.z);
    }
}
