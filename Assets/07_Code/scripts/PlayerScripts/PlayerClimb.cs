using UnityEngine;
using UnityEngine.Events;
using ps = PlayerStateMachine.PlayerState;

public class PlayerClimb : MonoBehaviour
{
    private bool triggerClimb;
    private PlayerStateController _playerState;
    public ClimbController currentClimbEdge;
    public BoxCollider collider;
    [SerializeField] private UnityEvent triggerClimbSurface;

    // Start is called before the first frame update
    void Start()
    {
        // _playerState = GetComponentInParent<PlayerStateController>();
        // collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if(other.gameObject.GetComponent<ClimbController>() != null)
        // {
        //     currentClimbEdge = other.GetComponent<ClimbController>();
        //     triggerClimbSurface.Invoke();
        //     if(_playerState.currentStateIndex != "CLIMB_FALL"
        //         && _playerState.currentStateIndex != "CLIMB_JUMP")
        //     {
        //         _playerState.currentStateIndex = "CLIMB";
        //         _playerState.machine.ChangeState(_playerState.states[_playerState.currentStateIndex]);
        //     }
        // }
    }
}
