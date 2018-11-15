using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowControls : MonoBehaviour
{

    [SerializeField] private GameObject controlsPanel;
    private bool firstCheck = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (!firstCheck)
        {

            ShowControlPanel();
            firstCheck = true;

        }

        if (Input.GetKey(KeyCode.Escape))
        {
            ShowControlPanel();
        }

        if (Input.GetKey(KeyCode.Return))
        {
            HideControlPanel();
        }
    }

    private void ShowControlPanel()
    {
        Time.timeScale = 0.0f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        controlsPanel.SetActive(true);
    }

    private void HideControlPanel()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        controlsPanel.SetActive(false);
    }
}
