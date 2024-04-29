using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject Crosshair;
    public float crosshairRadius = 2f;
    
    public float movementSpeed = 10f;
    public float rotationSpeed = 10f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Vector2 PlayerInput;
    private bool isGrounded = false;
    private bool fit = false;
    private float initialmovementSpeed;
    private float curmovementSpeed;
    private float horizontal;
    private Vector2 moveForce;
    private Vector2 curs;
    private float camera;
    private float vertical;
    private float speed = 10f;
    private float normalizer = 10f;
    private bool toggle;
    public Vector2 forceToApply = new Vector2(0,0);
    public float forceDamping = .08f;




    // Start is called before the first frame update
    //
    [Header("Events")] 
    public GameEvents Interact;
    void Start()
    {
        
       
   
    
        
    
        initialmovementSpeed = movementSpeed;
        curmovementSpeed = movementSpeed;
        speed = movementSpeed;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        interact();
        curs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        
      //  moving();
       
    }
    void FixedUpdate()
    {
        moveForce = PlayerInput * movementSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;
        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }

        Crosshair.transform.position =curs;

        rb.velocity = moveForce;
    }
    private void moving()
        {
            horizontal = Input.GetAxis("Horizontal");
            //up = Input.GetAxis("Jump");

            vertical = Input.GetAxis("Vertical");

            rb.AddForce(Vector2.right * horizontal * movementSpeed * Time.deltaTime, ForceMode2D.Force);
            rb.AddForce(Vector2.up * vertical * movementSpeed * Time.deltaTime, ForceMode2D.Impulse);
            //transform.Translate(Vector3.up* vertical * movementSpeed * Time.deltaTime);
            // transform.Translate(Vector3.right * horizontal * movementSpeed * Time.deltaTime);



        }

        private void interact()
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                bool toggle = true;
                GameObject[] Interactables = GameObject.FindGameObjectsWithTag("Interactable");
                foreach (GameObject target in Interactables)
                {
                    float distance = Vector3.Distance(target.transform.position, transform.position);
                    if (distance < 1)
                    {
                        if (toggle)
                        {
                            toggle = false;
                            Interact.Raise(this, target);
                        }

                    }
                }
            }

        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            
            Debug.Log("Enemy");
            Vector2 direction = transform.position - collision.collider.gameObject.transform.position;

            forceToApply += direction*10;
            
        }
    }



}

    
