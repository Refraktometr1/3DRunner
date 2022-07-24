using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamageState : PlayerState
{
    [SerializeField] GameController gameController;
    private bool invincible = false;

    public override void Enter()
    {
        controller.enabled = false;
        invincible = true;
        gameController.playerInfo.Health--;
        if (gameController.playerInfo.Health <= 0)
        {
            gameController.playerInfo.Health = 0;
            Debug.Log("In game you will be already dead");
        }
        gameController.DecreaseHelth();
        transform.position += transform.forward * (-1.0f);
        animator.SetBool("damaged", true);
    }
    public override void Functionality()
    {

    }
    public override void Exit()
    {
        controller.enabled = true;
        animator.SetBool("damaged", false);
    }
    public override string CheckTransitions()
    {
        if(!invincible && mainController.onFrontState)
        {
            return "FRONT_WALK";
        }
        if(!invincible)
        {
            return "WALK";
        }
        return myID;
    }

    public void EndOfAnimation()
    {
        invincible = false;
    }
}
