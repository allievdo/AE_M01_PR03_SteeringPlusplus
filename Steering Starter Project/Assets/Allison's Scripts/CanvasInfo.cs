using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasInfo : MonoBehaviour
{
    public PlayerController controller;
    public TMP_Text healthText;

    // Start is called before the first frame update
    private void Update()
    {
        healthText.text = "Health: " + controller.health.ToString();
    }
}
