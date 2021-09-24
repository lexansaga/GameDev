using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldSpawner : MonoBehaviour
{   private float rotation = 1.0f;
        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
                rotation += 1.0f;
                this.transform.rotation = Quaternion.Euler(0, 0, rotation);
        }

        public void OnTriggerEnter2D(Collider2D other) {
                //Debug.Log(other.gameObject.name);
                if (other.gameObject.name.ToLower() == "character") {
                        //Character Hit
              // this.gameObject.SetActive(false);
                //        Destroy(this.gameObject);

                } else if (other.gameObject.name.ToLower() == "floor") {
                        //Floor Hit

                        //  Debug.Log("Floor asd");
                        //   rb.velocity = new Vector2(rb.position.x,rb.position.y);
                Destroy(this.gameObject);
                } else {
                        //Other
                }
        }
}
