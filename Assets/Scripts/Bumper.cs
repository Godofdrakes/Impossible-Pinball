using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour
{
    [Range (0,5)]
    public int bumperForce;

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            contact.otherCollider.GetComponent<Rigidbody>().AddForce(-1 * contact.normal * bumperForce, ForceMode.Impulse);
        }
    }
}
