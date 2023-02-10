using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Points : MonoBehaviour
{
    private Consumables consumables;
    public int points;
    private int score = 0;
    private SnekController _snekController;
    private bool hasCollided;
    public GameObject gameOver;
    public TMP_Text scoreText;

    private void Awake()
    {
        consumables = this.gameObject.GetComponent<Consumables>();
        hasCollided = false;
        _snekController = this.gameObject.GetComponent<SnekController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Points") && !hasCollided)
        {
            hasCollided = true;
            score += points;
            Debug.Log(score);
            scoreText.text = score.ToString();
            //if (score == 100) this.gameObject.GetComponent<DisplayAlert>().ShowAlert();
            consumables.RemoveApple();
            _snekController.GrowSnake();
        }
        hasCollided = false;

        if (other.CompareTag("Danger"))
        {
            foreach (GameObject obj in _snekController.bodyParts)
            {
                Destroy(obj);
            }
            gameOver.gameObject.SetActive(true);
            Destroy(_snekController.gameObject);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + score);
    }
}
