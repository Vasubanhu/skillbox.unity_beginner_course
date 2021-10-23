using UnityEngine;

public class BottomBumper : Bumper
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Vector3 opposite = -collision.rigidbody.velocity;
            collision.rigidbody.AddForce(opposite * _power);
        }
    }
}
