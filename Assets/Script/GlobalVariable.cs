using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct EntityList
{
    public GameObject entity;
    public int n_type;
    public int n_target;
};

public static class GlobalVariable
{
    public static EntityList playerTarget;
    public static List<EntityList> listofEntity = new List<EntityList> { };
    public static List<EntityList> listofEnemy = new List<EntityList> { };
    public static List<EntityList> listofAllies = new List<EntityList> { };


    public static int damage;
}
