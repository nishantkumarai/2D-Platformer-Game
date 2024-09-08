using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnclickDisable : MonoBehaviour
{
    public GameObject levelUI;
    public Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(OnButtonClickDisable);
    }

    private void OnButtonClickDisable()
    {
        levelUI.gameObject.SetActive(false);
    }
}
