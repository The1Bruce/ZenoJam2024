using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float agroRange = 4f;
    public float movementSpeed = 6f;
    public Vector2 direction;
    private Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject target in player)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance < agroRange)
            {
                direction = target.transform.position - transform.position;
                direction.Normalize();
                rb.velocity = direction * movementSpeed;
            }
        }
    }
}
