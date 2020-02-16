using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private GameObject _bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    void CalculateMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontal * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * vertical * _speed * Time.deltaTime);

        if (transform.position.y < -4.1f)
        {
            transform.position = new Vector3(transform.position.x, 6f, -2);
        }
        else if (transform.position.y > 6f)
        {
            transform.position = new Vector3(transform.position.x, -4.1f, -2);
        }
        else if (transform.position.x < -9.2f)
        {
            transform.position = new Vector3(9.2f, transform.position.y, -2);
        }
        else if (transform.position.x > 9.2f)
        {
            transform.position = new Vector3(-9.2f, transform.position.y, -2);
        }
    }
}
