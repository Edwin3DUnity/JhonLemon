using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{

    public float fadeDuration = 1f;

    private bool isPlayerAtExit;
    public GameObject player;
    public CanvasGroup exitBackgroundCanvasGroup;

    private float timer;

    public float displayImageDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAtExit)
        {
            timer += Time.deltaTime;
           // exitBackgroundCanvasGroup.alpha = timer / fadeDuration;
           exitBackgroundCanvasGroup.alpha = Mathf.Clamp(timer / fadeDuration, 0,1);
            if (timer > fadeDuration + displayImageDuration)
            {
                EndLevel();
            }
        }
    }

    private void EndLevel()
    {
        Application.Quit();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }
}
