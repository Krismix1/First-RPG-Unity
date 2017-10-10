﻿using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    #region Singleton
    public static PlayerManager instance;
    private void Awake() {
        instance = this;
    }
    #endregion

    public GameObject player;

    public void KillPlayer() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
