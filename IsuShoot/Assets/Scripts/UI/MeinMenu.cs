using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MeinMenu : MonoBehaviour
{
    private Button createRoomBtn, _joinRoomBtn, settingsRoomBtn, exitBtn;
    public GameObject createRoom, joinRoom, settingsRoom, menu;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement; 

        createRoomBtn = root.Q<Button>("CreateRoomButton");
        createRoomBtn.clicked += CreateRoomBtnOn—licked;

        _joinRoomBtn = root.Q<Button>("JoinRoomBtn");
        _joinRoomBtn.clicked += JoinRoomBtnOn—licked;

        settingsRoomBtn = root.Q<Button>("OpenSettings");
        settingsRoomBtn.clicked += CreateSettingsBtnOn—licked;

    }
    private void JoinRoomBtnOn—licked() 
    {
        gameObject.SetActive(false);
        joinRoom.SetActive(true);
    }

    private void CreateRoomBtnOn—licked()
    {
        gameObject.SetActive(false);
        createRoom.SetActive(true);
    }

    private void CreateSettingsBtnOn—licked()
    {
        gameObject.SetActive(false);
        settingsRoom.SetActive(true);
    }


}


