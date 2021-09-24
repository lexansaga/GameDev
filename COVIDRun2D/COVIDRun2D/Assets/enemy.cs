using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class enemy: MonoBehaviour {

        public float speed = 0.5f;
        private Rigidbody2D rb;

        public float rotation = 1f;
        // Start is called before the first frame update
        void Start() {
                rb = this.GetComponent < Rigidbody2D > ();
                // rb.velocity = new Vector2(0,-speed);
        }

        // Update is called once per frame
        void Update() {
                rotation += 0.5f;
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, rotation);
        }

        public void OnTriggerEnter2D(Collider2D other) {
                //Debug.Log(other.gameObject.name);
                if (other.gameObject.name.ToLower() == "character") {
                        //Character Hit
                        Destroy(this.gameObject);

                } else if (other.gameObject.name.ToLower() == "floor") {
                        //Floor Hit

                        Debug.Log("Floor asd");
                        //   rb.velocity = new Vector2(rb.position.x,rb.position.y);
                        Destroy(this.gameObject);
                } else {
                        //Other
                }
        }

}