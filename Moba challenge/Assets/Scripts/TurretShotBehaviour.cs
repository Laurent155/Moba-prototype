using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShotBehaviour : MonoBehaviour
{
    public TurretBehaviour turretBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        turretBehaviour = GameObject.Find("Turret").GetComponent<TurretBehaviour>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        // gonna just do player for now, will need to add in minions
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("destroyed!");
            Destroy(this.gameObject);
            turretBehaviour.CanShoot = true;
            
        }
    }
}
