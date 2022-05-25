using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageCreateScript : MonoBehaviour
{
    private float f_speed;
    private Vector3 direction;
    private float f_fadeTime;

    // Update is called once per frame
    void Update()
    {
        float translate = f_speed * Time.deltaTime;

        transform.Translate(translate * direction);
    }

    public void initialize(float speed, Vector3 direction, float fadeTime)
    {
        this.f_speed = speed;
        this.direction = direction;
        this.f_fadeTime = fadeTime;

        StartCoroutine(FadeOut());
    }

    //suppress the damage text
    private IEnumerator FadeOut()
    {
        float f_startAlpha = GetComponent<Text>().color.a;
        float f_fadeRate = 1.0f / f_fadeTime;
        float f_fadeProgress = 0.0f;

        while(f_fadeProgress < 1.0)
        {
            Color tmpColor = GetComponent<Text>().color;

            GetComponent<Text>().color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, Mathf.Lerp(f_startAlpha, 0, f_fadeProgress));
            f_fadeProgress += f_fadeRate * Time.deltaTime;

            yield return null;
        }
        Destroy(gameObject);
    }
}
