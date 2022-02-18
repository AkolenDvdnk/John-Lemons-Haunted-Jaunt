using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    public float displayImageDuration = 3f;
    private float fadeDuration = 1f;
    private float timer;

    private bool isPlayerAtExit = false;
    private bool isPlayerCaught = false;

    private void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        if (isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }
    private void EndLevel(CanvasGroup canvasGroup, bool doRestart)
    {
        timer += Time.deltaTime;
        canvasGroup.alpha = timer / fadeDuration;

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
