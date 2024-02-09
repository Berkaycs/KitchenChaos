using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    // a reference to a specific counter instance.
    [SerializeField] private BaseCounter baseCounter;

    // a reference to a GameObject that this script controls the visibility of
    [SerializeField] private GameObject[] visualGameObjectArray;

    private void Start()
    {
        // Subscribes to an event OnSelectedCounterChanged in the Player.Instance.
        // This indicates that when the selected counter changes, the method Player_OnSelectedCounterChanged will be invoked.
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;            
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        // Checks if the selectedCounter in the event arguments (e) matches the clearCounter set in the script
        if (e.selectedCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach(GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(true);
        }  
    }

    private void Hide()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(false);
        }
    }
}
