using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Enemy
{
    public string Name{ get; set; }
    public float Health { get; set; }
    public float Speed { get; set; }
    public float AttackSpeed { get; set; }
    public virtual void Attack()
    {

    }

    public virtual void Move()
    {

    }
    public virtual void Die()
    {

    }
}

