﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace RayWenderlich.SpaceInvadersUnity
{
    public class GameManager : MonoBehaviour
    {
        internal static GameManager Instance;
        public Animator transition;

        [SerializeField]
        private GameObject CrossFade;

        [SerializeField] 
        private AudioSource sfx;

        [SerializeField] 
        private GameObject explosionPrefab;

        [SerializeField] 
        private float explosionTime = 1f;

        [SerializeField] 
        private AudioClip explosionClip;

        [SerializeField] 
        private int maxLives = 3;

        [SerializeField] 
        private Text livesLabel;

        private int lives;
        
        [SerializeField] 
        private MusicControl music;

        [SerializeField] 
        private Text scoreLabel;

        [SerializeField]
        private Text highScoreLabel;

        [SerializeField] 
        private GameObject gameOver;
        
        [SerializeField]
        private GameObject allClear;

        [SerializeField] 
        private Button restartButton;

        [SerializeField]
        private Button mainMenuButton;

        [SerializeField]
        private Button nextLevelButton;

        public HealthBar healthBar;

        private int score;
        private int highscore;

        internal void UpdateScore(int value)
        {
            score += value;
            scoreLabel.text = $"{score}";
            if (highscore<score)
            {
                highscore = score;
                PlayerPrefs.SetInt("highscore", highscore);
                highScoreLabel.text = $"{highscore}";
                
            }
                
        }

        internal void TriggerGameOver(bool failure = true)
        {
            PlayerPrefs.SetInt("isGameOver", 1);            
            gameOver.SetActive(failure);
            allClear.SetActive(!failure);
            mainMenuButton.gameObject.SetActive(true);
            if (failure) {
                restartButton.gameObject.SetActive(true);
                PlayerPrefs.SetInt("score", 0);
            }

            if (!failure)
            {
                nextLevelButton.gameObject.SetActive(true);
                PlayerPrefs.SetInt("score", score);
            }
             
            Time.timeScale = 0f;
            music.StopPlaying();
        }

        internal void UpdateLives()
        {
            lives = Mathf.Clamp(lives - 1, 0, maxLives);
            livesLabel.text = $"{lives}";
            healthBar.SetHealth(lives);
            if (lives > 0) 
            {
                return;
            }

            TriggerGameOver();
        }

        internal void CreateExplosion(Vector2 position)
        {
            PlaySfx(explosionClip);

            var explosion = Instantiate(explosionPrefab, position,
                Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f)));
            Destroy(explosion, explosionTime);
        }

        internal void PlaySfx(AudioClip clip) => sfx.PlayOneShot(clip);

        private void Awake()
        {
            PlayerPrefs.SetInt("isGameOver", 0);
            score = PlayerPrefs.GetInt("score");
            Debug.Log(score);
            scoreLabel.text = $"{score}";          
                        
            highscore = PlayerPrefs.GetInt("highscore");
            highScoreLabel.text = $"{highscore}";
            if (Instance == null) 
            {
                Instance = this;
            }
            else if (Instance != this) 
            {
                Destroy(gameObject);
            }

            lives = maxLives;
            livesLabel.text = $"{lives}";
            healthBar.SetMaxHealth(maxLives);
            //score = 0;
            //scoreLabel.text = $"Score: {score}";
            gameOver.gameObject.SetActive(false);
            allClear.gameObject.SetActive(false);

            restartButton.onClick.AddListener(() =>
            {
                ReloadGame();
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1f;
            });

            mainMenuButton.onClick.AddListener(() =>
            {
                ChangeSceneToMainMenu();
                Time.timeScale = 1f;
            });

            nextLevelButton.onClick.AddListener(() =>
            {
                LoadNextLevel();
                
                Time.timeScale = 1f;
            });

            restartButton.gameObject.SetActive(false);
            mainMenuButton.gameObject.SetActive(false);
            nextLevelButton.gameObject.SetActive(false);
            CrossFade.SetActive(true);
        }

        public void LoadNextLevel()
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
        }

        public void ReloadGame()
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        }
        public void ChangeSceneToMainMenu()
        {
            StartCoroutine(LoadLevel(0));
        }

        IEnumerator LoadLevel(int levelIndex)
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(1f);

            SceneManager.LoadScene(levelIndex);
        }


    }
}