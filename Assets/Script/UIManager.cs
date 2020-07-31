﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _LivesImg;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Text __gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        __gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }

    public void UpdateLives(int currentLives)
    {

        _LivesImg.sprite = _liveSprites[currentLives];
        if (currentLives == 0)
        {
            __gameOverText.gameObject.SetActive(true);
            StartCoroutine(GameoverFickerroutine());
        }
    }

    IEnumerator GameoverFickerroutine()
    {
        while(true)
        {
            __gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            __gameOverText.text = " ";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
