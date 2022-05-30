using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [SerializeField] private Sprite backgroundImage;
    [SerializeField] private string locationName;
    [TextArea(15,15)][SerializeField] private string storyText;

    [SerializeField] private AudioClip audioClip;
    [SerializeField] private State[] nextStates;

    public string GetStateStory()
    {
        return storyText;
    }

    public string GetStateLocation()
    {
        return locationName;
    }

    public Sprite GetStateSprite()
    {
        return backgroundImage;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public AudioClip GetAudioClip()
    {
        return audioClip;
    }
}
