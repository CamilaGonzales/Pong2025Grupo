using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    private Image fadeImage;           // Asigna la Image 'Fade' del Canvas
    [SerializeField, Range(0.1f, 2f)] private float duration = 0.5f;

    void Awake()
    {
        if (!fadeImage) fadeImage = GetComponent<Image>();
        if (fadeImage) fadeImage.raycastTarget = true;  // Bloquea clicks durante el fade
    }

    void Start()
    {
        // Si la escena empieza en negro (alpha ~1), haz un fade-in a transparente
        if (fadeImage && fadeImage.color.a > 0.9f)
        {
            StartCoroutine(Fade(1f, 0f));
        }
    }

    public IEnumerator FadeAndLoad(string sceneName)
    {
        // 1) Fade a negro
        yield return Fade(0f, 1f);
        // 2) Carga la escena
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator Fade(float from, float to)
    {
        if (!fadeImage) yield break;

        Color baseColor = fadeImage.color;
        float t = 0f;

        // Usamos unscaledDeltaTime para que funcione aunque el Time.timeScale sea 0
        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            float a = Mathf.Lerp(from, to, t / duration);
            fadeImage.color = new Color(baseColor.r, baseColor.g, baseColor.b, a);
            yield return null;
        }

        fadeImage.color = new Color(baseColor.r, baseColor.g, baseColor.b, to);
    }
}
