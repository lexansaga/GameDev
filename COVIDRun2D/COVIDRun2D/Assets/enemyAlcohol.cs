using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAlcohol : MonoBehaviour
{
   public float speed = 0.5f;
    private Rigidbody2D rb;

    public float rotation = 1f;

    public int life = 5;

    Character character;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        // rb.velocity = new Vector2(0,-speed);

        character = GameObject.FindObjectOfType(typeof(Character)) as Character;

    }

    // Update is called once per frame
    void Update()
    {
     //   rotation += 0.5f;
     //   this.gameObject.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
      
    }
}
