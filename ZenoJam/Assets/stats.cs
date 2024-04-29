using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    public int health = 3;
    public int maxHealth = 3;
    private bool canTakeDamage = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void heal()
    {
        if (health < maxHealth)
        {
            health++;
        }

    }

    public void TakeDamage()
    {
        if (canTakeDamage)
        {
            health--;
            canTakeDamage = false;

            if (health <= 0)
            {
                Die();
            }

            StartCoroutine(DamageCooldown());


        } else {
         
        
        }


    }
    public void Die()
    {
        Destroy(gameObject);
    }
    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(2f);
        canTakeDamage = true;
    }
}








