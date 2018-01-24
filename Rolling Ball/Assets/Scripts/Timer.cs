using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    public Text loseText;
    private float startTime;
    private float timeGiven = 30;
    private bool complete = false;

	// Use this for initialization
	void Start () {
        startTime = timeGiven;
	}

    // Update is called once per frame
    void Update() {
        if (complete)
            return;

        float t = startTime - Time.time;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        double sec = (t % 60);

        timerText.text = minutes + ":" + seconds;

        if (sec <= 0.00)
            Lose();
	}

    public void Win()
    {
        complete = true;
        timerText.color = Color.yellow;
    }

    public void Lose()
    {
        complete = true;
        timerText.text = "0:0.00";
        timerText.color = Color.red;
        loseText.text = "You Lose...";
        GameObject.Find("Player").SendMessage("Lose");
    }
}
