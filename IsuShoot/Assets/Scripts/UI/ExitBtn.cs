using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ExitBtn : MonoBehaviour
{
    private Button exitBtn;
    public GameObject menu;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        exitBtn = root.Q<Button>("ExitFromSettings");
        exitBtn.clicked += CloseSettingsBtnOn—licked;
    }

    private void CloseSettingsBtnOn—licked()
    {
        gameObject.SetActive(false);
        menu.SetActive(true);
    }


}
