using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumberScript : MonoBehaviour
{
    private static DamageNumberScript instance;
    public GameObject textPrefab;
    public RectTransform canvasTransform;

    //public int n_health;
    private float f_speed = 2.0f;
    public Vector3 direction;
    private float fadeTime = 1;
    //public Text text;

    public static DamageNumberScript Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<DamageNumberScript>();
            }

            return instance;
        }
    }

    public void createDamageNumber(Vector3 position, string text, Color color)
    {
        position.y = position.y + 1;
        position.x = position.x + 1;
        GameObject textInstance = (GameObject)Instantiate(textPrefab, position, Quaternion.identity);

        textInstance.transform.SetParent(canvasTransform);
        textInstance.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        textInstance.GetComponent<DamageCreateScript>().initialize(f_speed, direction, fadeTime);
        textInstance.GetComponent<Text>().text = text;
        textInstance.GetComponent<Text>().color = color;
    }
}
