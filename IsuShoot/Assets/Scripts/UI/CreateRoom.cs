using UnityEngine;
using UnityEngine.UIElements;
using Photon.Pun;

public class CreateRoom : MonoBehaviour
{

    private Button createRoomBtn;
    private TextField _userRoomName;
    public GameObject loadingUI;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        createRoomBtn = root.Q<Button>("CreateRoomButton");
        createRoomBtn.clicked += CreateRoomBtnOn—licked;

        _userRoomName = root.Q<TextField>("UserRoomName");
    }

    private void CreateRoomBtnOn—licked()
    {
        string userInput = _userRoomName.value;
        if (string.IsNullOrEmpty(userInput)) return;

        PhotonNetwork.CreateRoom(userInput);

        gameObject.SetActive(false);
        loadingUI.SetActive(true);

    }

}
