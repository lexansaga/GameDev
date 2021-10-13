using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployPowerups: MonoBehaviour {
        
        public GameObject powerupPrefab;
        public float respawnTime = 10.0f;
        private Vector2 screenBounds;
        // Start is called before the first frame update
        void Start() {
                screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
                //  powerupPrefab.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 1f);
                StartCoroutine(powerupWave());
        }
        private void spawnPowerup() {

                GameObject a = Instantiate(powerupPrefab) as GameObject;
                a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * +1.2f);

        }

        void Update() {

        }
        IEnumerator powerupWave() {
                while (true) {
                        yield
                        return new WaitForSeconds(respawnTime);
                        spawnPowerup();
                }
        }
}