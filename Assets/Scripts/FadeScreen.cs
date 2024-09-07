using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TO USE THESE SCRIPTS FROM ANOTHER SCRIPT
// FIND FADECONTROLLER OBJECT (fadeController = FindObjectOfType<FadeScreen>();)
// CALL  StartCoroutine(fadeController.FadeOut()); OR StartCoroutine(fadeController.FadeIn());
// gg

public class FadeScreen : MonoBehaviour
{

    public Image fadeImage;
    public float fadeDuration;

    // Start is called before the first frame update
    void Start()
    {

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeIn()
    {
        float timer = 0f;
        Color fadeColor = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeColor.a = Mathf.Lerp(0, 1, timer / fadeDuration);  // From transparent to opaque
            fadeImage.color = fadeColor;
            yield return null;
        }

        fadeColor.a = 1;
        fadeImage.color = fadeColor;
    }

    public IEnumerator FadeOut()
    {
        float timer = 0f;
        Color fadeColor = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeColor.a = Mathf.Lerp(1, 0, timer / fadeDuration);  // From opaque to transparent
            fadeImage.color = fadeColor;
            yield return null;
        }

        fadeColor.a = 0;
        fadeImage.color = fadeColor;
    }


}
