using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployEnemies: MonoBehaviour {
        public int enemyPrefabSelector = 0;
        public GameObject[] enemyPrefab;
        public float respawnTime = 3.0f;
        private Vector2 screenBounds;
        // Start is called before the first frame update
        void Start() {
                screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
                StartCoroutine(enemyWave());
             
        }
        private void spawnEnemy() {
                GameObject a = Instantiate(enemyPrefab[enemyPrefabSelector]) as GameObject;
                a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * +1.2f);

        }

        void Update() {
                enemyPrefabSelector = Random.Range(0,enemyPrefab.Length);
        }
        IEnumerator enemyWave() {
                while (true) {
                        yield
                        return new WaitForSeconds(respawnTime);
                        spawnEnemy();
                }
        }


        public void startDeployRate(float rate)
        {
                respawnTime = rate;
        }

        public void speedUpRespawnTime(float speed)
        {
                if(respawnTime > 0.5)
                {
                        respawnTime -= speed;
                }
              
                
                Debug.Log("Enemy Respawn Time : " + respawnTime);
        }
}