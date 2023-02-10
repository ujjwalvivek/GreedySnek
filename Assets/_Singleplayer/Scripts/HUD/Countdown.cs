using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private GameObject countdownCanvas;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameObject snekObj;

    public float timeLeft;
    public bool timerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        countdownCanvas.SetActive(true);
        snekObj.SetActive(false);
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = Mathf.Ceil(timeLeft).ToString();
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                timeLeft = 0;
                timerOn = false;
                countdownCanvas.SetActive(false);
                snekObj.SetActive(true);
            }
        }
    }
    
}
