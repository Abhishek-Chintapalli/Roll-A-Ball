using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private int score;

    public TMP_Text scoreText;

    public TMP_Text winText;

    public TMP_Text loseText;

    public Button playAgainButton;

    private bool gameStarted;

    [SerializeField] public float speed;

    private GameObject[] gems;

    private Vector3 startPos;

   public AudioManager audioManager;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        gems = GameObject.FindGameObjectsWithTag("Gem");

        startPos = rb.position;

        playAgainButton.onClick.AddListener(playAgainButtonAction);

        gameStarted = true;

        score = 0;

        SetScoreText();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            movePlayer();
        }
    }

    void movePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime;

        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(move * speed);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Gem"))
        {
            collider.gameObject.SetActive(false);
            score++;
            audioManager.PlaySFX(audioManager.gem);
            SetScoreText();
        }
        else if (collider.gameObject.CompareTag("Win"))
        {
            gameStarted = false;
            //Debug.Log("You win!");
            resetGameState();
            winText.text = "You Win!\nNow Throw Me A Party\nFinal Score: " + score;
            winText.gameObject.SetActive(true);
            playAgainButton.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            audioManager.PlaySFX(audioManager.win);
           // audioManager.musicSource.Stop();
            //audioManager.SFXSource.clip = audioManager.win;
        }
        else if (collider.gameObject.CompareTag("GameOver"))
        {
            gameStarted = false;
            //Debug.Log("You hit an obstacle!");
            resetGameState();
            audioManager.PlaySFX(audioManager.lose);
            loseText.text = "Game Over!\nBetter Luck Next Time\nFinal Score: " + score;
            loseText.gameObject.SetActive(true);
            playAgainButton.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);

            //audioManager.musicSource.Stop();
            //audioManager.SFXSource.clip = audioManager.lose;
        }
    }

    public void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void resetGameState()
    {
        //Set all gems to active
        foreach (GameObject gem in gems)
        {
            gem.gameObject.SetActive(true);
        }

        //Set player position and velocity to starting position
        rb.position = startPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void playAgainButtonAction()
    {
        //Reset the Score
         score = 0;
         SetScoreText();

         //Hide the win/lose text and play again button
         scoreText.gameObject.SetActive(true);
         winText.gameObject.SetActive(false);
         loseText.gameObject.SetActive(false);
         playAgainButton.gameObject.SetActive(false);

         gameStarted = true;
         audioManager.Start();
    }
}
