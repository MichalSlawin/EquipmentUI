using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private const float SHOW_TIME = 2f;
    private const int FRAME_RATE = 60;

    private Color32 changedColor = new Color32(255, 223, 0, 255);

    [SerializeField] private AudioClip[] sounds = null;

    private AudioSource audioSource;
    private TextMeshProUGUI actionText = null;
    private System.Random random;

    private Item previousItem = null;

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

    public void StartShowCoroutine(Item item)
    {
        if(previousItem != null)
        {
            Image slotImage = previousItem.OccupiedSlot.GetComponent<Image>();
            slotImage.color = previousItem.OccupiedSlot.OriginalColor;
        }

        StopAllCoroutines();
        StartCoroutine(ShowEquippedItem(item));
        previousItem = item;
    }

    private IEnumerator ShowEquippedItem(Item item)
    {
        actionText.text = "Equipped " + item.ToString();
        PlayRandomSound();

        Image slotImage = item.OccupiedSlot.GetComponent<Image>();

        slotImage.color = changedColor;
        yield return new WaitForSeconds(SHOW_TIME);
        actionText.text = "";
        slotImage.color = item.OccupiedSlot.OriginalColor;
    }

    private void PlayRandomSound()
    {
        int randomIndex = random.Next(sounds.Length);
        audioSource.clip = sounds[randomIndex];
        audioSource.Play();
    }
}
