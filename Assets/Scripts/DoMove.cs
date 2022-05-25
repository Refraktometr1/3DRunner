
using UnityEngine;

public class DoMove : MonoBehaviour
{
    private int _speed = 10;
    public bool isChangeLane;
    private int _swipeDistance = 20;
    private bool isChanged;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        if (isChangeLane && !isChanged && transform.position.z  - PlayerMoving.Instanse.transform.position.z < _swipeDistance)
        {
            ChangeLine();
        }
    }

    private void ChangeLine()
    {
        isChanged = true;
        if (transform.position.x > 1)
            transform.position =  transform.position+ Vector3.left * 3;

        if (transform.position.x < -1)
            transform.position =  transform.position+ Vector3.right * 3;
    }
}
