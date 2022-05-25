using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Transform healthBarTarget;
    private int maxHealth;
    private int health;
    private Slider healthbar;

    private RectTransform targetCanvas;
    private Transform target;
    private GameObject entityPrefab;
    public Transform healthBarTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setHealthBar(RectTransform healthBarCanvas, Transform targetPosition, GameObject entity)
    {
        this.targetCanvas = healthBarCanvas;
        healthBarTransform = GetComponent<Transform>();
        this.target = targetPosition;
        entityPrefab = entity;
        health = entityPrefab.GetComponent<EnnemiClassScript>().getHealth();
        healthbar = this.GetComponent<Slider>();
        healthbar.maxValue = health;
               
        RepositionHealthBar();

        healthBarTransform.gameObject.SetActive(true);

        
    }


    // Update is called once per frame
    void Update()
    {
        healthbar.value = entityPrefab.GetComponent<EnnemiClassScript>().getHealth();
        if (healthbar.value <= 0)
        {
            print("ok");
            Destroy(this.gameObject);
        }
        
    }

    private void RepositionHealthBar()
    {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(target.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * targetCanvas.sizeDelta.x) - (targetCanvas.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * targetCanvas.sizeDelta.y) - (targetCanvas.sizeDelta.y * 0.35f)));
        //now you can set the position of the ui element
        healthBarTransform.gameObject.transform.position = WorldObject_ScreenPosition;
    }

    private IEnumerator destroySelf()
    {
        Destroy(this.gameObject);
        yield return new WaitForSeconds(0.5f);
    }
}
