using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;

    public int ballsRemaining = 10;

    public TextMeshProUGUI ballsText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public AudioClip winClip;
    public AudioClip loseClip;

    public GameObject leftWall;
    public GameObject rightWall;

    public PhysicsMaterial2D originalBallMaterial;

    [HideInInspector] public int score;
    [HideInInspector] public bool ballDropping;
    [HideInInspector] public int bluePegsHitThisDrop;
    [HideInInspector] public bool hitPegThisDrop;
    [HideInInspector] public float bouncinessIncreaseFromOrange = 0.0f;

    private AudioSource audioSource;
    private bool gameEnded;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;

        score = 0;
        bluePegsHitThisDrop = 0;
        audioSource = GetComponent<AudioSource>();
        gameEnded = false;

        gameOverText.gameObject.SetActive(false);
    }

    public void UpdateText()
    {
        ballsText.text = $"Balls: {ballsRemaining}";
        scoreText.text = $"Score: {score}";
    }

    public void CheckGameOver()
    {
        if (gameEnded || FindAnyObjectByType<Ball>() || (ballsRemaining > 0 && FindAnyObjectByType<Peg>())) return;

        if (FindAnyObjectByType<Peg>() != null)
        {
            gameOverText.text = "Game Over!";
            audioSource.clip = loseClip;
        } else
        {
            gameOverText.text = "You Win! Amazing!";
            score += ballsRemaining * 50;
            audioSource.clip = winClip;
        }

        audioSource.Play();
        UpdateText();
        gameOverText.gameObject.SetActive(true);
        gameEnded = true;
    }
}
