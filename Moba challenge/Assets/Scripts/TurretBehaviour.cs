using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public GameObject turretShot;
    private GameObject newTurretShot;
    public float turretShotSpeed = 10f;
    private GameObject attackTarget;
    private bool canShoot = true;
    private Vector3 shootDirection = new Vector3(0f, 0f, 0f);
    private List<GameObject> enemyList = new List<GameObject>();

    public GameObject AttackTarget
    {
        get
        {
            return attackTarget;
        }
        set
        {
            attackTarget = value;
        }
    }
    // Start is called before the first frame update
    public bool CanShoot
    {
        get { return canShoot; }
        set { canShoot = value; }
    }
    
    void OnTriggerEnter(Collider other)
    {
        // gonna just do player for now, will need to add in minions
        Debug.Log("player detected");
        if(other.name == "Player")
        {
            enemyList.Add(other.gameObject);
        }
        
        Debug.Log(enemyList.Count);
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            enemyList.Remove(other.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyList.Count != 0 && canShoot)
        {
            AttackTarget = enemyList[0];
            CanShoot = false;
            newTurretShot = Instantiate(turretShot, this.transform.position + new Vector3(0, 6, 0), this.transform.rotation) as GameObject;
            shootDirection = attackTarget.transform.position - newTurretShot.transform.position;
            shootDirection = shootDirection.normalized;
            Debug.Log("got here 1" + canShoot);
        }
        if (canShoot == false)
        {
            Debug.Log("got here!" + canShoot);
            shootDirection = attackTarget.transform.position + new Vector3(0f, 2f, 0f) - newTurretShot.transform.position;
            shootDirection = shootDirection.normalized;
            newTurretShot.transform.Translate(shootDirection * turretShotSpeed * Time.deltaTime);
        }
            
    }
}
