using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Oculus.Voice;
using Meta.WitAi.CallbackHandlers;
public class DictationManager : MonoBehaviour
{
    [SerializeField]
    AppVoiceExperience appVoiceExperience;

    [SerializeField]
    //gameobject 
    Text transcriptionText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        appVoiceExperience.VoiceEvents.OnRequestCompleted.AddListener(ReactivateVoice);
        appVoiceExperience.VoiceEvents.OnPartialTranscription.AddListener(OnPartialTranscription);
        appVoiceExperience.VoiceEvents.OnFullTranscription.AddListener(OnFullTranscription);
    }

    private void ReactivateVoice()
    {

    }

    private void OnPartialTranscription(string transcription)
    {
        //transcriptionText.text = transcription;
    }

    private void OnFullTranscription(string transcription)
    {
 
        Debug.Log(transcription);
    }

    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
