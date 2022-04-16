using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private TMP_Text endText;
    [SerializeField] private Transform target;

    private Vector3 startingPos;
    private void Awake()
    {
        startingPos = transform.position;
        endText.gameObject.SetActive(false);
    }
    private void LateUpdate () {
        
        if (target.position.y > transform.position.y)
        {
            var newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        endText.gameObject.SetActive(true);
    }

    public void ResetBackground()
    {
        transform.position = startingPos;
    }
}
