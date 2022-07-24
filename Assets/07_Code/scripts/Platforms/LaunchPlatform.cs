using UnityEngine;

public class LaunchPlatform : ReactivePlatform
{
    [SerializeField]
    private float value;

    protected override void Action()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerStateController>().ForceJump();
        GameObject.FindWithTag("Player").GetComponent<PlayerJumpState>().AddSpeed(value);
    }
}