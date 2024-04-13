using UnityEngine;
using System.Collections;

public class FadeOutGameObject : MonoBehaviour
{
    public float fadeDuration = 1f; // Duration in seconds over which the fade-out effect takes place

    public void StartFadeOut()
    {
        StartCoroutine(FadeOutProcess());
    }

    private IEnumerator FadeOutProcess()
    {
        GameObject popGameObject = GameObject.FindGameObjectWithTag("Pop");

        if (popGameObject != null)
        {
            // Handle UI Elements via Canvas Group
            CanvasGroup canvasGroup = popGameObject.GetComponentInParent<CanvasGroup>();
            if (canvasGroup != null)
            {
                float startAlpha = canvasGroup.alpha;
                for (float t = 0; t < 1; t += Time.deltaTime / fadeDuration)
                {
                    float newAlpha = Mathf.Lerp(startAlpha, 0, t);
                    canvasGroup.alpha = newAlpha;
                    yield return null;
                }
            }

            // Handle Sprite Renderer separately
            SpriteRenderer spriteRenderer = popGameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                float startAlpha = spriteRenderer.color.a;
                for (float t = 0; t < 1; t += 40*Time.deltaTime /fadeDuration)
                {
                    float newAlpha = Mathf.Lerp(startAlpha, 0, t);
                    spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);
                    yield return null;
                }
            }

            popGameObject.SetActive(false); // Finally, deactivate the GameObject
        }
    }
}
