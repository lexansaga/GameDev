using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield: MonoBehaviour {
        private float rotation = 1.0f;
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
                 var colliderName = other.gameObject.name;
                //For HitBox
        }
}