using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame_2p : MonoBehaviour {

    private AudioSource audioSource;

    void FixedUpdate()
    {
        //Player 1
        var textUILeft = GameObject.Find("LeftScoreUI").GetComponent<Text>();
        //Player 2
        var textUIRight = GameObject.Find("RightScoreUI").GetComponent<Text>();

        int scoreLeft = int.Parse(textUILeft.text);
        int scoreRight = int.Parse(textUIRight.text);

        string message = "";

        if (scoreLeft >= 5 || scoreRight >= 5) {
            Destroy(GameObject.Find("Ball"));
            Destroy(GameObject.Find("Music"));
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.victory);

            if (scoreLeft >= 5) {
                message = "PLAYER 1 WON!";
            } else {
                message = "PLAYER 2 WON!";
            }

            GameObject.Find("Message").GetComponent<Text>().text = message;
        }
    }
}
