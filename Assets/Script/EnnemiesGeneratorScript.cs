using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnnemiesGeneratorScript : MonoBehaviour
{
    //public GameObject playerPrefab;
    public GameObject EntityPrefab;
    public GameObject HealthBarPrefab;
    public RectTransform UICanvas;
    public Transform EnnemiParent;


    //[SerializeField] public List<EntityList> entityArray = new List<EntityList> { };
    //private GameObject[] entityArray;
    private int n_entityCount = 0;



    private void Awake()
    {
        GenerateEnnemy();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
        //GameObject healthbar = Instantiate(HealthBarPrefab) as GameObject;
    }


    void GenerateEnnemy()
    {
        Vector2[] position = new Vector2[3];
        position[0] = new Vector3(-6f, 6.5f);
        position[1] = new Vector3(-5f, 3f);
        position[2] = new Vector3(-6f, -0.5f);

        for(int n_i = 0; n_i < position.Length; n_i++)
        {
            PlaceEnnemy(position[n_i]);
        }
    }

    void PlaceEnnemy(Vector2 position)
    {
        EntityList tempEntity = new EntityList();
        GameObject entity = Instantiate(EntityPrefab, position, Quaternion.identity) as GameObject;
        //entity.transform.parent = EnnemiParent;
        //entityArray[n_entityCount] = entity;
        tempEntity.entity = entity;
        tempEntity.n_type = 1;
        tempEntity.n_target = 0;
        //setEntityArray(entity, 0);
        //n_entityCount++;
        EnnemiParent = entity.transform.parent;
        GlobalVariable.listofEntity.Add(tempEntity);
        GlobalVariable.listofEnemy.Add(tempEntity);
        print("ok");
        //entityArray.Add(tempEntity);
        GenerateHealthBar(entity.transform, entity);
    }

    void GenerateHealthBar (Transform entityTransform, GameObject entity)
    {
        GameObject healthBar = Instantiate(HealthBarPrefab) as GameObject;
        healthBar.GetComponent<HealthBarScript>().setHealthBar(UICanvas, entityTransform , entity);
        healthBar.transform.SetParent(UICanvas, false);
        //healthBar.transform.parent = UICanvas.transform;*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getEntityCount()
    {
        return n_entityCount;
    }

    /*public List<EntityList> getEntityList()
    {
        return entityArray;
    }

    public void setEntityCount(int n_count)
    {
        n_entityCount = n_entityCount - n_count;
    }

    public void setEntityList(EntityList entity, int n_bool)
    {
        if(n_bool == 1)
        {
            entityArray.Remove(entity);
        }
        else
        {
            n_entityCount += 1;
            entityArray.Add(entity);
        }
    }*/
}
