using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerClassScript : MonoBehaviour
{
    private int n_Health = 25;
    private int n_PA = 4;
    private int n_Attack = 10;
    private int n_Defense = 4;
    private bool yourTurn = false;
    
    //accesseurs
    public int getHealth() { return n_Health; }
    public int getPA() { return n_PA; }
    public int getAttack() { return n_Attack; }
    public int getDefense() { return n_Defense; }
    public bool getYourTurn() { return yourTurn; }

    //mutateurs
    public void setHealth(int n_Health) { this.n_Health = n_Health; }
    public void setPA(int n_PA) { this.n_PA = n_PA; }
    public void setAttack(int n_Attack) { this.n_Attack = n_Attack; }
    public void setDefense(int n_Defense) { this.n_Defense = n_Defense; }
    public void setYourTurn(bool yourTurn) { this.yourTurn = yourTurn; }




    public GameObject playerPrefab;
    //public GameObject ennemiPrefab;
    //public GameObject entityGeneretor;
    public GameObject playerUI;

    //public EntityList playerTarget;
    
    private EnnemiesGeneratorScript generatorScript;
    //private List<EntityList> listOfEntities;
    //private GameObject entityGenerator;
    //public PlayerClassScript player;
    public GameObject ennemi;
    public EnnemiClassScript ennemiStat;

    private bool isAttackOver = true;


    private IEnumerator Start()
    {
        playerPrefab = GameObject.FindGameObjectWithTag("Player");
        //entityGeneretor = GameObject.FindGameObjectWithTag("generator");
        //generatorScript = entityGeneretor.GetComponent<EnnemiesGeneratorScript>();
        yield return new WaitForEndOfFrame();
        GlobalVariable.playerTarget = GlobalVariable.listofEnemy[0];
        GlobalVariable.playerTarget.n_target = 1;
        ennemi = GlobalVariable.playerTarget.entity;
        yield return new WaitForEndOfFrame();
        ennemiStat = ennemi.GetComponent<EnnemiClassScript>();
        yield return new WaitForEndOfFrame();
    }

    private void Update()
    {
        if (ennemi != GlobalVariable.playerTarget.entity)
        {
            ennemi = GlobalVariable.playerTarget.entity;
            ennemiStat = ennemi.GetComponent<EnnemiClassScript>();
        }
        //ennemiStat = ennemi.GetComponent<EnnemiClassScript>();
        //generatorScript = entityGeneretor.GetComponent<EnnemiesGeneratorScript>();
        /*if (ennemi == null)
        {
            print("error player");
        }*/
        //listOfEntities = generatorScript.entityArray;


    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(characterMovement(+0.5f));
        /*if (ennemiStat.getHealth() <= 0)
        {
            yield return new WaitForSeconds(1.5f);
            if (playerUI)
            {
                hideUI();
            }
        }*/
        if (this.getPA() <= 0)
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

        for (n_i = 0; n_i < 6; n_i++)
        {
            //this.GetComponent<GameObject>().transform.position = this.GetComponent<GameObject>().transform.position + new Vector3(x, 0, 0);
            //this.transform.position = this.transform.position + new Vector3(x, 0, 0);
            //gameObject.transform.position = gameObject.transform.position + new Vector3(x, 0, 0);
            playerPrefab.transform.position = playerPrefab.transform.position + new Vector3(x, 0, 0);
            yield return new WaitForSeconds(.08f);
        }
    }

    public void characterAttack()
    {
        GlobalVariable.damage = this.getAttack() - (ennemiStat.getDefense() / 2);
        if (isAttackOver == true)
        {
            isAttackOver = false;
            if (ennemi && this)
            {
                StartCoroutine(characterMovement(-0.5f));
                //ennemi.getDamageTextBox().text = damage.ToString();
                ennemiStat.setHealth(ennemiStat.getHealth() - (this.getAttack() - (ennemiStat.getDefense() / 2)));
                ennemiStat.setTakeDamage(true);
                this.setPA(this.getPA() - 1);
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
