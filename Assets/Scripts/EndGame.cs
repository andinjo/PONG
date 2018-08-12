using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    private AudioSource audioSource;

	
	void FixedUpdate () {
        //Player 1
        var textUILeft = GameObject.Find("LeftScoreUI").GetComponent<Text>();
        //AI
        var textUIRight = GameObject.Find("RightScoreUI").GetComponent<Text>();

        int scoreLeft = int.Parse(textUILeft.text);
        int scoreRight = int.Parse(textUIRight.text);

        string message = "";

        if(scoreLeft >= 5 || scoreRight >= 5) {
            Destroy(GameObject.Find("Ball"));
            Destroy(GameObject.Find("Music"));

            if (scoreLeft >= 5) {
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.victory);
                message = "YOU WON!";
            } else {
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.gameOver);
                message = "YOU LOST!";
            }

            GameObject.Find("Message").GetComponent<Text>().text = message;
        }
	}
}
