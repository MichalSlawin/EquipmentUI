using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private const float SHOW_TIME = 2f;
    private const int FRAME_RATE = 60;

    [SerializeField] private AudioClip[] sounds = null;

    private AudioSource audioSource;
    private TextMeshProUGUI actionText = null;
    private System.Random random;

    void Start()
    {
        Application.targetFrameRate = FRAME_RATE;

        GameObject actionTextObj = GameObject.FindGameObjectWithTag("ActionText");
        if (actionTextObj == null) throw new System.Exception("ActionText object not found");
        actionText = actionTextObj.GetComponent<TextMeshProUGUI>();
        if (actionText == null) throw new System.Exception("ActionText not found");

        audioSource = GetComponent<AudioSource>();
        if(audioSource == null) throw new System.Exception("Audio Source not found");

        random = new System.Random();
    }

    public IEnumerator ShowEquippedItem(Item item)
    {
        actionText.text = "Equipped " + item.ToString();
        PlayRandomSound();
        yield return new WaitForSeconds(SHOW_TIME);
        actionText.text = "";
    }

    private void PlayRandomSound()
    {
        int randomIndex = random.Next(sounds.Length);
        audioSource.clip = sounds[randomIndex];
        audioSource.Play();
    }
}
