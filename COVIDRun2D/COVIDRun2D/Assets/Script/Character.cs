using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;

public class Character : MonoBehaviour
{


    private Rigidbody2D rb;
    private Animator anim;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;

    GameObject shield;
    public bool isShielded = false;

    private float speedDuration = 5.0f; // seconds

    public TextMeshProUGUI textScore;
    public int score = 0;

    float CountFPS = 30f;

    int multiplier = 2;

    int scoreAdd = 0;
    int scoreSub = 0;

    int scoreHolder = 0;


   public GameObject[] lifes;

    int lifeCount = 1;
    // Start is called before the first frame update

    public GameOverScreen gameOverScreen;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 5f;


        scoreAdd = Random.Range(800, 1000);
        scoreSub = Random.Range(-800, -1000);
        scoreHolder = scoreAdd;



        shield = GameObject.Instantiate(Resources.Load("Prefab/shield"), transform.position, transform.rotation) as GameObject;
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;

        if ((CrossPlatformInputManager.GetButtonDown("Jump") ||
                        Input.GetKeyDown(KeyCode.UpArrow) ||
                        Input.GetKeyDown(KeyCode.W)) && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * 700f);
        }

        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (rb.velocity.y > 0)
        {
            anim.SetBool("isJumping", true);
        }

        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }


            scoreAdd = Random.Range(800, 1000);
        scoreSub = Random.Range(-800, -1000);
        scoreHolder = scoreAdd;

      //  Debug.Log("Score Add: " + scoreAdd);
       // Debug.Log("Score Sub: " + scoreSub);
      //  Debug.Log("Score Holder: " + scoreHolder);


        ShieldMode();

    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(dirX, rb.velocity.y);

    }

    private void LateUpdate()
    {
        if (dirX > 0)
        {
            facingRight = true;
        }
        else if (dirX < 0)
        {
            facingRight = false;
        }

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        var colliderName = other.gameObject.name;
        if (colliderName.ToLower().Contains("virus"))
        {
            Score(true);

        }
        if (colliderName.ToLower().Contains("shieldspawn"))
        {

            shield.SetActive(true);
            Debug.Log("I am a Shield");
            Destroy(other.gameObject);
            // Debug.Log(speedDuration);
            isShielded = true;
            StartCoroutine(ShieldObject(shield, speedDuration));

        }
    }

    Coroutine cScoreCounter;
    public void Score(bool status)
    {
        if (status)
        {
            //  score += 1000;
            //  textScore.text = score.ToString();
            if (cScoreCounter != null)
            {
                StopCoroutine(cScoreCounter);
            }
            StartCoroutine(ScoreCounter(0.5f, scoreHolder));

          //  Debug.Log("Score Added : " + scoreHolder);
        }
        else
        {
            if (cScoreCounter != null)
            {
                StopCoroutine(cScoreCounter);
            }
            StartCoroutine(ScoreCounter(0.5f, scoreSub));

           // Debug.Log("Score Decrease : " + scoreSub);
        }


    }
    void ShieldMode()
    {
        if (shield.activeSelf)
        {
            shield.transform.position = transform.position;


        }
        else
        {

        }
    }

    void VaccineMOde()
    {

    }

    IEnumerator ShieldObject(GameObject obj, float duration)
    {
        scoreHolder = scoreAdd * multiplier;
        while (isShielded == true)
        {
            yield return new WaitForSeconds(duration);
            obj.SetActive(false);
            scoreHolder = scoreAdd;
            isShielded = false;
            //  Debug.Log("Shield " + isShielded);

        }

    }

    IEnumerator ScoreCounter(float duration, int relativeScore)
    {
        WaitForSeconds wait = new WaitForSeconds(1f / CountFPS);
        int previousScore = score;
        int newScore = (previousScore + relativeScore);
        int stepAmount;
        if (newScore - previousScore < 0)
        {
            stepAmount = Mathf.FloorToInt((newScore - previousScore) / (CountFPS * duration));
        }
        else
        {
            stepAmount = Mathf.CeilToInt((newScore - previousScore) / (CountFPS * duration));
        }

        if (previousScore < newScore)
        {

            while (previousScore < newScore)
            {
                previousScore += stepAmount;
                if (previousScore > newScore)
                {
                    previousScore = newScore;

                }
                score = previousScore;
                textScore.text = previousScore.ToString();


                yield return wait;
            }


        }

        else
        {
            while (previousScore > newScore)
            {
                previousScore += stepAmount;
                if (previousScore < newScore)
                {
                    previousScore = newScore;
                }
                score = previousScore;
                textScore.text = previousScore.ToString();


                yield return wait;
            }
        }
    }


    public void DecreaseLife(int damage)
    {
        if (lifeCount >= 1)
        {
            lifeCount -= damage;
            Destroy(lifes[lifeCount].gameObject);
            if (lifeCount < 1)
            {
                anim.SetTrigger("isDead");
                StartCoroutine(DeathAnimTrigger());
                
            }
        }
    }

    private IEnumerator DeathAnimTrigger()
    {
        
        yield return new WaitForSeconds(0.5f);

        Debug.Log("You are dead!");
                textScore.text = "";
                gameOverScreen.Setup(score);
                Time.timeScale = 0;
    }
}