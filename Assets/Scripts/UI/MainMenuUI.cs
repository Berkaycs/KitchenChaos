using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            // creating function with lambda to add to the listener
            SceneManager.LoadScene(1);
        });

        quitButton.onClick.AddListener(() =>
        {
            // creating function with lambda to add to the listener
            Application.Quit();
        });

        // after esc -> main menu, in the main menu and game scene, the time was still pause so we fix it in here
        Time.timeScale = 1f;
    }
}
