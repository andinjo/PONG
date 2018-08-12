using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour {

    public void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void DestroyTheMusic() {
        Destroy(GameObject.Find("Music"));
    }

    public void Exit() {
        Application.Quit();
    }
}
