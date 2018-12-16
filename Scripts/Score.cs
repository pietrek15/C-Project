using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text timerText;

    private float startTime;
    bool finished = false;

   
    void Start () {
        float startTime = Time.time;
    }
	
	
	void Update () {
        if (finished)
            return;

        float t = Time.time - startTime;

        int min = ((int)t / 60);
        float sec = ((float)t % 60);
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        if (minutes == "0")
            timerText.text = seconds;
        else
            timerText.text = minutes + " : " + seconds;
    }
    public void StopTimer()
    {
        finished = true;
    }
}
