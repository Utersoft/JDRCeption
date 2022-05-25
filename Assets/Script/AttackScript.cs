using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject playerPrefab;
    //public GameObject ennemiPrefab;
    public GameObject entityGeneretor;
    public GameObject playerUI;

    public GameObject playerTarget;

    private EntityList listOfEntity;
    public PlayerClassScript player;
    public EnnemiClassScript ennemi;

    private bool isAttackOver = true;

    private void Start()
    {
        //isAttackOver = true;
        //listOfEntity = get
    }
    private void Update()
    {
        
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(characterMovement(+0.5f));
        if (ennemi.getHealth() <= 0)
        {
            yield return new WaitForSeconds(1.5f);
            if (playerUI)
            {
                hideUI();
            }
        }
        if (player.getPA() <= 0)
        {
            yield return new WaitForSeconds(1.5f);
            if (playerUI)
            {
                hideUI();
            }
        }
        yield return new WaitForSeconds(0.5f);
        isAttackOver = true;
    }
    public IEnumerator characterMovement(float x)
    {
        int n_i = 0;
        
        for(n_i = 0; n_i < 6; n_i++){
            playerPrefab.transform.position = playerPrefab.transform.position + new Vector3(x, 0, 0);
            yield return new WaitForSeconds(.08f);
        }
    }

    public void characterAttack()
    {
        int damage = player.getAttack() - (ennemi.getDefense()/2);
        if (isAttackOver == true)
        {
            isAttackOver = false;
            if (ennemi && player)
            {
                StartCoroutine(characterMovement(-0.5f));
                //ennemi.getDamageTextBox().text = damage.ToString();
                ennemi.setHealth(ennemi.getHealth() - (player.getAttack() - (ennemi.getDefense() / 2)));
                ennemi.setTakeDamage(true);
                player.setPA(player.getPA() - 1);
                StartCoroutine(wait());
            }
        }
    }

    private void hideUI()
    {
        if (playerUI)
        {
            playerUI.SetActive(false);
        }
    }

    private void showUI()
    {
        if (!playerUI)
        {
            playerUI.SetActive(true);
        }
    }
}
