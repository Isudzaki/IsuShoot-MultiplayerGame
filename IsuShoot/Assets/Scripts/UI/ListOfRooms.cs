using UnityEngine;
using Photon.Pun;
using UnityEngine.UIElements;
using Photon.Realtime;
using System.Collections.Generic;

public class ListOfRooms : MonoBehaviourPunCallbacks
{
    private VisualElement _listOfRooms;
    public GameObject loadingUI;
    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _listOfRooms = root.Q<VisualElement>("ListOfRooms");
        ChangeRooms(); 
    }

    public void ChangeRooms()
    {
        if (_listOfRooms == null) return;

        _listOfRooms.Clear();
        foreach (string el in Launcher.RoomList)
        {
            Button button = new Button();
            button.text = el;
            button.clicked += () => JoinRoom(el);
            _listOfRooms.Add(button);
        } 
    }
    private void JoinRoom(string name) 
    {
        PhotonNetwork.JoinRoom(name);
        loadingUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
