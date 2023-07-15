using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject gameOverPanel, winnerPanel;

    public TMP_Text ammoText, healthText, grenadeAmmoText, enemiesNumberText;

    public int gunAmmo = 10, health = 10, grenadesAmmo = 3, enemiesNumber = 50, enemiesSpawned = 0;

    public bool gameOver = false, winner = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        //gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        UiText();

        if (gameOver)
        {
            gameOverPanel.SetActive(true);
        }

        if (enemiesNumber <= 0)
        {
            winner = true;
            winnerPanel.SetActive(true);
        }
    }

    private void UiText()
    {
        ammoText.text = gunAmmo.ToString();
        healthText.text = health.ToString();
        grenadeAmmoText.text = grenadesAmmo.ToString();
        enemiesNumberText.text = enemiesNumber.ToString();
    }
}
