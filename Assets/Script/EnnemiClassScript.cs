using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnnemiClassScript : MonoBehaviour
{
    private int n_MaxHealth = 15;
    private int n_Health = 15;
    private int n_PA = 2;
    private int n_Attack = 7;
    private int n_Defense = 2;
    private bool yourTurn = false;
    private int speed = 1;
    private bool takeDamage = false;

    private Slider E_HealthBar;
    private GameObject healthSlider;
    public GameObject healthBar;
    private Text damageTextBox;

    private Vector2 textOriginPosition;
    private Vector2 textTargetPosition;
    private Transform textTargetPositionT;

    //accesseurs
    public int getHealth() { return n_Health; }
    public int getPA() { return n_PA; }
    public int getAttack() { return n_Attack; }
    public int getDefense() { return n_Defense; }
    public bool getYourTurn() { return yourTurn; }
    public bool getTakeDamage() { return takeDamage; }
    //public Text getDamageTextBox() { return damageTextBox; }

    //mutateurs
    public void setHealth(int n_Health) { this.n_Health = n_Health; }
    public void setPA(int n_PA) { this.n_PA = n_PA; }
    public void setAttack(int n_Attack) { this.n_Attack = n_Attack; }
    public void setDefense(int n_Defense) { this.n_Defense = n_Defense; }
    public void setYourTurn(bool yourTurn) { this.yourTurn = yourTurn; }
    public void setTakeDamage(bool takeDamage) { this.takeDamage = takeDamage; }


    private void Start()
    {
        //Vector3 ennemyPos = this.transform.position;

        //E_HealthBar = GameObject.FindGameObjectWithTag("EnnemyHealthBar").GetComponent<Slider>();
        //healthSlider = GameObject.FindGameObjectWithTag("EnnemyFillBar").GetComponent<GameObject>();
        //GameObject healthBars = Instantiate(healthBar, new Vector3(ennemyPos.x, ennemyPos.y + 1, ennemyPos.z), Quaternion.identity);

        damageTextBox = GameObject.FindGameObjectWithTag("damageTextEnnemy").GetComponent<Text>();


        //E_HealthBar.maxValue = n_Health;
        textOriginPosition = this.gameObject.transform.position;
        textTargetPosition = new Vector2(damageTextBox.transform.position.x, (damageTextBox.transform.position.y + 150));
        //textTargetPositionT = new Vector2(damageTextBox.transform.position.x, (damageTextBox.transform.position.y + 150));
    }

    private void Update()
    {
        //print(Input.touchCount);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Ray touchRayLine = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(touchRayLine, out hit))
            //{
            if (touchPosition.x == transform.position.x && touchPosition.y == transform.position.y)
            {
                print(Input.touchCount);
                int n_i = 0;
                while (GlobalVariable.listofEnemy[n_i].entity != this.gameObject)
                {
                    n_i++;
                    print("changed target");
                }
                GlobalVariable.playerTarget = GlobalVariable.listofEnemy[n_i];
            }
                
            //}
        }
        

        if (takeDamage)
        {
            damageTextBox.text = GlobalVariable.damage.ToString();
            damageTextBox.enabled = true;
            DamageNumberScript.Instance.createDamageNumber(this.gameObject.transform.position, GlobalVariable.damage.ToString(), Color.yellow);
            takeDamage = false;

            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(textOriginPosition, textTargetPosition, step);
            if(Vector2.Distance(transform.position, textTargetPosition) < 0.001f)
            {
                damageTextBox.enabled = false;
                damageTextBox.transform.position = textOriginPosition;
                takeDamage = false;
            }
        }
        //E_HealthBar.value = n_Health;
        if (n_Health <= 0 && this)
        {
            StartCoroutine(destroyEverything());
        }
        

    }

    private IEnumerator destroyEverything()
    {
        Destroy(healthSlider);
        yield return new WaitForSeconds(0);
        Destroy(E_HealthBar);
        yield return new WaitForSeconds(0.5f);
        //GlobalVariable.listofEnemy.Remove(this);
        
        int n_i = 0;
        EntityList tempEntity = GlobalVariable.listofEnemy[0];
        while (tempEntity.entity != this.gameObject)// && n_i < GlobalVariable.listofEnemy.Count)
        {
            tempEntity = GlobalVariable.listofEnemy[n_i];
            n_i++;
        };
        GlobalVariable.listofEntity.Remove(tempEntity);
        GlobalVariable.listofEnemy.Remove(tempEntity);
        if(GlobalVariable.listofEnemy.Count > 0)
        {
            GlobalVariable.playerTarget = GlobalVariable.listofEnemy[0];
        }
        Destroy(gameObject);
        /*int n_j = 0;
        do
        {
            GlobalVariable.playerTarget = GlobalVariable.listofEntity[n_j];
        } while (GlobalVariable.playerTarget.n_type != 1);
        GlobalVariable.playerTarget.n_target = 0;*/
    }

    /* private IEnumerator showDamageNumber()
     {


     }*/
}
