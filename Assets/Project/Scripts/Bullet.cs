using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Shot shot;
    public float bulletSpeed = 25.0f;

    private float cronometer;
    protected RaycastHit raycastHit;
    protected Ray ray;

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * bulletSpeed;

        cronometer += Time.deltaTime;

        ScanShot();

        if (cronometer > 5.0f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Switch":
                other.gameObject.GetComponent<Switch>().ActivateSwitch();
                Destroy(this.gameObject);
                break;

            case "Room":
                Destroy(this.gameObject);
                break;
        }
    }

    protected void ScanShot()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;
        Debug.DrawRay(ray.origin, ray.direction * Time.fixedDeltaTime * bulletSpeed, Color.red, Time.deltaTime);

        if (Physics.Raycast(ray, out raycastHit, Time.fixedDeltaTime * bulletSpeed))
        {
            
        }
    }
}
