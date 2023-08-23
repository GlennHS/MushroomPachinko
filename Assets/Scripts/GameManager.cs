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

    [HideInInspector] public int score;
    [HideInInspector] public bool ballDropping;
    [HideInInspector] public int bluePegsHitThisDrop;
    [HideInInspector] public bool hitPegThisDrop;

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

        // SetUpWallColliders();
    }

    //public void SetUpWallColliders()
    //{
    //    Rect rect = Camera.main.pixelRect;
    //    float cx = rect.center.x;
    //    float cy = rect.center.y;
    //    float cz = Vector3.zero.z;
    //    Vector3 v = new Vector3(cx, cy, cz);
    //    Vector3 w = new Vector3(cx, cy, cz);
    //    v.x = rect.xMin;
    //    w.x = rect.xMax;

    //    leftWall.transform.position = Camera.main.ScreenToWorldPoint(v);
    //    rightWall.transform.position = Camera.main.ScreenToWorldPoint(w);
    //}

    public void UpdateText()
    {
        ballsText.text = $"Balls: {ballsRemaining}";
        scoreText.text = $"Score: {score}";
    }

    public void CheckGameOver()
    {
        if (gameEnded || (ballsRemaining > 0 && FindAnyObjectByType<Peg>())) return;

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
        gameOverText.gameObject.SetActive(true);
        gameEnded = true;
    }
}
