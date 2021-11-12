using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;

    private void Start()
    {
        startScreen.SetActive(true);
    }

    public void OnStartClick()
    {
        startScreen.SetActive(false);
        GameData.Instance.SetLevel();
    }
}
