using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviourPunCallbacks
{
    private static GameControler _game;
    private void Start()
    {
        if (_game != null)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
        _game = this;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += SceneManagerOnScenLoaded;
    }
    public override void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManagerOnScenLoaded;
    }

    private void SceneManagerOnScenLoaded(Scene scene, LoadSceneMode arg1) 
    {
        if (scene.buildIndex == 1)
            PhotonNetwork.Instantiate("PlayerManeger", Vector3.zero, Quaternion.identity);
    }


}
