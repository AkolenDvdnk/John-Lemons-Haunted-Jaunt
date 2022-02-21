using UnityEngine;
using TMPro;

public class QuestController : MonoBehaviour
{
    public static int Count;

    public Animator questDoor;
    public AudioSource audioSource;
    public TextMeshProUGUI text;
    public GameObject finalText;

    private bool hasPlayed = false;

    private void Start()
    {
        Count = 0;
    }
    private void Update()
    {
        UpdateUI();
        QuestCompleted();
    }
    private void QuestCompleted()
    {
        if (Count == 3)
        {
            questDoor.SetTrigger("QuestCompleted");
            finalText.SetActive(true);

            if (!audioSource.isPlaying && !hasPlayed)
            {
                audioSource.Play();
                hasPlayed = true;
            }
        }
    }
    private void UpdateUI()
    {
        text.text = $"Grimoires collected: {Count} / 3";
    }
}
