using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private TMP_Text endText;

    private void Awake()
    {
        endText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("YEET");
        endText.gameObject.SetActive(true);
        Debug.Log("DONE?");
    }
}
