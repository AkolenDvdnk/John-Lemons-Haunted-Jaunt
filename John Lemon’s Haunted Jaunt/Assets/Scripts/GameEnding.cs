using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public AudioSource exitAudio;
    public AudioSource caughtAudio;

    public GameObject canvasUI;

    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    public float displayImageDuration = 3f;
    private float fadeDuration = 1f;
    private float timer;

    private bool isPlayerAtExit = false;
    private bool isPlayerCaught = false;
    private bool hasAudioPlayed;

    private void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        if (isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }
    private void EndLevel(CanvasGroup canvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
        }

        timer += Time.deltaTime;
        canvasGroup.alpha = timer / fadeDuration;

        canvasUI.SetActive(false);

        if (timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                Application.Quit();
            }
        }
    }
    public bool CaughtPlayer()
    {
        return isPlayerCaught = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerAtExit = true;
        }
    }
}
