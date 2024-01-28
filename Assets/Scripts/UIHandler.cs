using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI textHealth;

    void Update()
    {
        text.text = FireHandler.currentMag.ToString() + "/" + FireHandler.magSize.ToString();
        textHealth.text = Player.health.ToString() + "/" + Player.maxHealth.ToString();
    }
}
