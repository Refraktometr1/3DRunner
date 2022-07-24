using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FirstBossMain : MonoBehaviour
{
    [SerializeField] private float minAttackDelay;
    [SerializeField] private float maxAttackDelay;

    [SerializeField] private float delayAfterAttackTest;

    [SerializeField] private float delayBeforeShot;
    [SerializeField] private Transform bulletStartPosition;
    [SerializeField] private GameObject bullet;

    [SerializeField] private GameObject groundWeapon;

    [SerializeField] private PunchWeaponScript punchWeapon;
    private bool onPunchAttack = false;

    private UnityEvent[] attacks;

    private SimplePathMoveTriggered movingController;


    void Start()
    {
        movingController = GetComponent<SimplePathMoveTriggered>();

        attacks = new UnityEvent[3];
        for (int i = 0; i < attacks.Length; i++)
            attacks[i] = new UnityEvent();

        attacks[0].AddListener(AttackOnDown);
        attacks[1].AddListener(PunchAttack);
        attacks[2].AddListener(ThrowAttack);
    }

    private void Update()
    {
        punchWeapon.MoveDifference(new Vector3(movingController.delta.x, 0, movingController.delta.z));
        if(onPunchAttack && !punchWeapon.onPunch && movingController.isMoving)
        {
            onPunchAttack = false;
            StartCoroutine(DelayBeforeAttack());
        }
    }

    public void StartRun()
    {
        movingController.isMoving = true;

        StartCoroutine(DelayBeforeAttack());
    }

    IEnumerator DelayBeforeAttack()
    {
        float delay = Random.Range(minAttackDelay, maxAttackDelay);
        yield return new WaitForSeconds(delay);

        int attackType = Random.Range(0, attacks.Length);
        attacks[attackType].Invoke();
    }

    IEnumerator DelayAfterAttack()
    {
        yield return new WaitForSeconds(delayAfterAttackTest);
        groundWeapon.SetActive(false);
        StartCoroutine(DelayBeforeAttack());
    }

    private void AttackOnDown()
    {
        Debug.Log("Attack on Down");
        groundWeapon.SetActive(true);
        StartCoroutine(DelayAfterAttack());
    }

    private void PunchAttack()
    {
        Debug.Log("PunchAttack");
        punchWeapon.SetPunch();
        onPunchAttack = true;
    }

    private void ThrowAttack()
    {
        Debug.Log("Boss Shoot");
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(delayBeforeShot);
        SimpleBuletScript b = Instantiate(bullet, bulletStartPosition.position, Quaternion.identity).GetComponent<SimpleBuletScript>();
        b.SetDirection(GameObject.FindGameObjectWithTag("Player").transform.position + Vector3.up, false);
        StartCoroutine(DelayBeforeAttack());
    }
}
