using UnityEngine;
using UnityEngine.UIElements;
using Photon.Pun;

public class RoomMenu : MonoBehaviour
{
    private Button startGameButton;


    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        Label roomName = root.Q<Label>("roomName");
        roomName.text = "Комната создана: " + PhotonNetwork.CurrentRoom.Name;

        startGameButton = root.Q<Button>("StartGameButton");
        startGameButton.clicked += StartGameButtonOnClicked;

        if (!PhotonNetwork.IsMasterClient)
            startGameButton.SetEnabled(false);
    }
    private void StartGameButtonOnClicked()
    {
        PhotonNetwork.LoadLevel(1);
    }
}