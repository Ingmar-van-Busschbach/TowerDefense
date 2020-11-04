using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int _score = 0;
    private GameObject sendScore;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public int GetScore()
    {
        return _score;
    }

    void Start()
    {
        GameEvents.current.onPlayerScore += AddScore;
        GameEvents.current.onPlayerGameOver += GameOver;
    }

    private void AddScore(int score)
    {
        _score += score;
        Debug.Log(_score);
    }

    private void GameOver(int score)
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }
}
