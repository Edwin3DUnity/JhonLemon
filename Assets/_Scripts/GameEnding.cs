using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{

    public float fadeDuration = 1f;

    private bool isPlayerAtExit;
    private bool isPlayerCaught;
    public GameObject player;
    public CanvasGroup exitBackgroundCanvasGroup;
    public CanvasGroup caughtBackgroundCanvasGroup;

    private float timer;

    public float displayImageDuration = 1f;

    public AudioSource exitAudio;
    public AudioSource caughtAudio;

    private bool hasAudioPlayed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(isPlayerAtExit)
       {
           EndLevel(exitBackgroundCanvasGroup, false, exitAudio);
       }
        else if(isPlayerCaught)
        {
            EndLevel(caughtBackgroundCanvasGroup, true, caughtAudio);
        }
    }
    /// <summary>
    /// Lanza La imageen de fin de la partidad
    /// </summary>
    /// <param name="imageCanvaasGroup">Imagen de fin de partida correspondeinte</param>
    private void EndLevel(CanvasGroup imageCanvaasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
        }
        
            timer += Time.deltaTime;
            // exitBackgroundCanvasGroup.alpha = timer / fadeDuration;
            imageCanvaasGroup.alpha = Mathf.Clamp(timer / fadeDuration, 0,1);
            if (timer > fadeDuration + displayImageDuration)
            {
                if (doRestart)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                else
                {
                    Application.Quit();
                }
               
            }
        
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }

    public void CatchPlayer()
    {
        isPlayerCaught = true;
    }
}
