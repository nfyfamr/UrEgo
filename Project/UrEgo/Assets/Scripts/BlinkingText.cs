using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour {
    Text text;
    bool fadeIn;

	// Use this for initialization
	void Start () {
        fadeIn = false;
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		if (fadeIn)
        {
            StartCoroutine(FadeTextToFullAlpha(text));
        } else
        {
            StartCoroutine(FadeTextToZeroAlpha(text));
        }
	}

    public IEnumerator FadeTextToFullAlpha(Text t)
    {
        t.color = new Color(t.color.r, t.color.g, t.color.b, 0.0f);
        while (t.color.a < 1.0f)
        {
            t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a + (Time.deltaTime / 1.0f));
            if (t.color.a >= 1.0f)
            {
                fadeIn = false;
            }
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(Text t)
    {
        t.color = new Color(t.color.r, t.color.g, t.color.b, 1.0f);
        while (t.color.a > 0.0f)
        {
            t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a - (Time.deltaTime / 1.0f));
            if (t.color.a <= 0.0f)
            {
                fadeIn = true;
            }
            yield return null;
        }
    }
}
