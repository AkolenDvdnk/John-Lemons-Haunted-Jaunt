using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public CanvasGroup exitBackgroundImageCanvasGroup;

    private float displayImageDuration = 3.5f;
    private float fadeDuration = 1f;
    private float timer;

    private bool isPlayerAtExit = false;

    private void Update()
    {
        if (!isPlayerAtExit)
            return;

        Victory();
    }
    private void Victory()
    {
        timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerAtExit = true;
        }
    }
}
