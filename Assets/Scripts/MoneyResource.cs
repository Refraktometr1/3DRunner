using UnityEngine;

public class MoneyResource : MonoBehaviour
{
    public int BonusValue;
    private AudioResources _audioResources;

    private void Start()
    {
        _audioResources =  Resources.Load<AudioResources>("AudioResources");
    }

    private void OnTriggerEnter(Collider other)
    {
        IResourceCollector collector = other.GetComponent<IResourceCollector>();
        if ( collector == null )
            return;
        
        collector.Collect(BonusValue, transform.gameObject);
        AudioManager.Instanse.PlaySound(_audioResources.PickCoin);
        //transform.gameObject.SetActive(false);
    }
}
