using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  public float speed;
  private Animator anim;
  public Transform rival;
  private bool isRight;

  //inputVariables
  public string hInput;
  public string vInput;
  public string fireInput;

  public bool damageTaken;

    // Start is called before the first frame update
    void Start()
    {
      damageTaken = true;
      anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

      Vector3 mov = new Vector3(Input.GetAxis(hInput), Input.GetAxis(vInput),0);
      transform.position = Vector3.MoveTowards(transform.position, transform.position + mov, speed * Time.deltaTime);
      if(mov.x != 0 || mov.y != 0)
      {
        anim.SetBool("Moving", true);
      } else {
        anim.SetBool("Moving", false);
      }

      if (rival.gameObject.name == "Player")
      {
        if (transform.position.y > rival.position.y)
        {
          isRight = true;
        } else {
          isRight = false;
        }
      } else {
        if (transform.position.y < rival.position.y)
        {
          isRight = true;
        } else {
          isRight = false;
        }
      }

      if (Input.GetButtonDown(fireInput))
      {
        if (!isRight)
        {
          PunchLeft();
        } else {
          PunchRight();
        }
      }
    }

    void PunchRight()
    {
      ResetDamager();
      anim.SetTrigger("PunchRight");
      //Debug.Log("Right punch");
    }

    void PunchLeft()
    {
      ResetDamager();
      anim.SetTrigger("PunchLeft");
      //Debug.Log("Left punch");
    }

    public void ResetDamager()
    {
      damageTaken = false;
    }
}
