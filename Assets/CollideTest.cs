using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTest : MonoBehaviour
{
  public string rivalType;
  public int attackDamage = 1;

  private Movement rivalScript;
  //public HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
      rivalScript = GameObject.FindGameObjectWithTag(rivalType).GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.tag == rivalType && rivalScript.damageTaken != true)
      {
        Debug.Log("It Hit");
        other.gameObject.GetComponent<HealthManager>().TakeDamage(attackDamage);
        rivalScript.damageTaken = true;
      }
    }

}
