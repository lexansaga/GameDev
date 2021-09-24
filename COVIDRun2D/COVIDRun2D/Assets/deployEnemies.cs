using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployEnemies: MonoBehaviour {
        public GameObject enemyPrefab;
        public float respawnTime = 5.0f;
        private Vector2 screenBounds;
        // Start is called before the first frame update
        void Start() {
                screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
                StartCoroutine(enemyWave());
        }
        private void spawnEnemy() {
                GameObject a = Instantiate(enemyPrefab) as GameObject;
                a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * +1.2f);

        }

        void Update() {

        }
        IEnumerator enemyWave() {
                while (true) {
                        yield
                        return new WaitForSeconds(respawnTime);
                        spawnEnemy();
                }
        }
}