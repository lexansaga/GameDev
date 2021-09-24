using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Character: MonoBehaviour {
        private Rigidbody2D rb;
        private Animator anim;
        private float moveSpeed;
        private float dirX;
        private bool facingRight = true;
        private Vector3 localScale;

        GameObject shield;
        private bool isShielded;

        private float speedDuration = 5.0f; // seconds

        // Start is called before the first frame update
        void Start() {
                rb = GetComponent < Rigidbody2D > ();
                anim = GetComponent < Animator > ();
                localScale = transform.localScale;
                moveSpeed = 5f;

                isShielded = false;

                 shield = GameObject.Instantiate(Resources.Load("Prefab/shield"), transform.position, transform.rotation) as GameObject;
                shield.SetActive(false);
        }

        // Update is called once per frame
        void Update() {

                dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;

                if ((CrossPlatformInputManager.GetButtonDown("Jump") ||
                                Input.GetKeyDown(KeyCode.UpArrow) ||
                                Input.GetKeyDown(KeyCode.W)) && rb.velocity.y == 0) {
                        rb.AddForce(Vector2.up * 700f);
                }

                if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0) {
                        anim.SetBool("isRunning", true);
                } else {
                        anim.SetBool("isRunning", false);
                }

                if (rb.velocity.y == 0) {
                        anim.SetBool("isJumping", false);
                        anim.SetBool("isFalling", false);
                }

                if (rb.velocity.y > 0) {
                        anim.SetBool("isJumping", true);
                }

                if (rb.velocity.y < 0) {
                        anim.SetBool("isJumping", false);
                        anim.SetBool("isFalling", true);
                }

                ShieldMode();

        }

        private void FixedUpdate() {

                rb.velocity = new Vector2(dirX, rb.velocity.y);
              
        }

        private void LateUpdate() {
                if (dirX > 0) {
                        facingRight = true;
                } else if (dirX < 0) {
                        facingRight = false;
                }

                if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0))) {
                        localScale.x *= -1;
                }
                transform.localScale = localScale;
        }

        private void OnTriggerEnter2D(Collider2D other) {
                Debug.Log(other.gameObject.name);
                var colliderName = other.gameObject.name;
                  if (colliderName.ToLower().Contains("virus")) {

                     

                }
                if (colliderName.ToLower().Contains("shieldspawn")) {

                               shield.SetActive(true);
                               Debug.Log("I am a Shield");
                               Destroy(other.gameObject);
                               Debug.Log(speedDuration);
                               StartCoroutine(GameObjectDestroyer(shield,speedDuration,true));

                }
        }

         void ShieldMode()
        {
                if (shield.activeSelf) {
                    //    Debug.Log("Shielded");
                        shield.transform.position = transform.position;
                        
                } else {

                }
        }

        IEnumerator GameObjectDestroyer(GameObject obj , float duration,bool status)
        {
            while(status == true)
            {
                yield return new WaitForSeconds(duration);        
                obj.SetActive(false);   
                Debug.Log("Shield"+isShielded);
            }
        }
}