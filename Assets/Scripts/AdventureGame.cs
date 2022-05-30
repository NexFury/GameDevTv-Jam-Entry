using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] private TMP_Text locationText;
    [SerializeField] private TMP_Text textComponent;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private State startingState;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject pauseMenu;

    private State state;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        state = startingState;
        locationText.text = state.GetStateLocation();
        textComponent.text = state.GetStateStory();
        backgroundImage.sprite = state.GetStateSprite();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();

        if(Input.GetKeyDown(KeyCode.Q))
        {
            pauseMenu.SetActive(true);
        }
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        if(pauseMenu.activeSelf == false)
        {
            for(int index = 0; index < nextStates.Length; index++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + index))
                {
                    state = nextStates[index];
                }
            }
        }
        locationText.text = state.GetStateLocation();
        textComponent.text = state.GetStateStory();
        backgroundImage.sprite = state.GetStateSprite();
        if(audioSource.clip != state.GetAudioClip())
        {
            audioSource.Stop();
            audioSource.clip = state.GetAudioClip();
            audioSource.Play();
        }
        else
        {
            return;
        }
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        pauseMenu.SetActive(false);
    }
}
