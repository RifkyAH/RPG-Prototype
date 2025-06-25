using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class FadeOverlay : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public bool startFadeOut = false;
    bool isDone = true;
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = startFadeOut ? 1 : 0;
    }
    public bool IsDone { get { return isDone; } }
    public IEnumerator FadeIn(float time)
    {
        while (!isDone)
        {
            yield return null;
        }
        StartCoroutine(Fade(0, 1, time));
    }
    public IEnumerator FadeOut(float time)
    {
        while (!isDone)
        {
            yield return null;
        }
        StartCoroutine(Fade(1, 0, time));
    }
    private IEnumerator Fade(float from, float to, float time)
    {
        isDone = false;
        canvasGroup.alpha = from;
        float elapsed = 0f;

        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            float factor = elapsed / time;
            canvasGroup.alpha = Mathf.Lerp(from, to, factor);
            yield return null;
        }

        canvasGroup.alpha = to;
        isDone = true;
    }
    public Coroutine FadeOutOverlay(float time = 1f)
    {
        return MainThreadDispatcher.StartCoroutine(FadeOut(time));
    }

    public Coroutine FadeInOverlay(float time = 1f)
    {
        return MainThreadDispatcher.StartCoroutine(FadeIn(time));
    }
}
