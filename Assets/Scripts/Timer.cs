using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    public int totalSeconds = 30;
    private float startTime;
    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished) return;
        float runningSeconds = (totalSeconds - Time.time) % 60;

        if (runningSeconds >= 0) {
            string secondsLeft = (runningSeconds % 60).ToString("f0");
            timerText.text = "Time: " + secondsLeft;

            if (runningSeconds < 3) {
                timerText.color = new Color (1f, 0.5f, 0.5f, 0.5f);
            }
        } else {
            var cubes = GameObject.FindGameObjectsWithTag("PickUp");
			foreach (var cube in cubes) {
				cube.SetActive(false);
			}

            timerText.color = Color.red;
            timerText.text = "You lost!";
            finished = true;
        }
    }

    public void Finish() {
        finished = true;
        timerText.color = Color.green;
    }
}
