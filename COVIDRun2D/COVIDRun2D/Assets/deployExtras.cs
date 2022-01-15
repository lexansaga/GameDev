using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployExtras : MonoBehaviour
{
       public int extrasPrefabSelector = 0;
        public GameObject[] extrasPrefab;
        public float respawnTime = 5.0f;
        private Vector2 screenBounds;
        // Start is called before the first frame update
        void Start() {
                screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
                StartCoroutine(extrasWave());
             
        }
        private void spawnExtras() {
                GameObject a = Instantiate(extrasPrefab[extrasPrefabSelector]) as GameObject;
                a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * +1.2f);

        }

        void Update() {
                extrasPrefabSelector = Random.Range(0,extrasPrefab.Length);
        }

        IEnumerator extrasWave() {
                while (true) {
                        yield
                        return new WaitForSeconds(respawnTime);
                        spawnExtras();
                }
        }

         public void startDeployRate(float rate)
        {
                respawnTime = rate;
        }

           public void speedUpRespawnTime(float speed)
        {
                   if(respawnTime > 2.0)
                {
                        respawnTime -= speed;
                }

                Debug.Log("Extras Respawn Time : " + respawnTime);
        }
}
