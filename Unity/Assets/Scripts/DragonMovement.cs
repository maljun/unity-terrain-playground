using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public float timeBetweenPings = 1f;
    public float range = 100f;
    public LineRenderer velocityIndicator;
    public LineRenderer headingIndicator;


    float timer;
    Ray pingRay;
    RaycastHit floorHit;
    int floorMask;
    LineRenderer pingLine;
   
    float effectsDisplayTime = 0.02f;


    void Awake ()
    {
        floorMask = LayerMask.GetMask ("Floor");
        pingLine = GetComponent <LineRenderer> ();

    }


    void Update ()
    {
        timer += Time.deltaTime;

		if( timer >= timeBetweenPings && Time.timeScale != 0)
        {
            Ping ();
        }

        if(timer >= timeBetweenPings * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }

    void FixedUpdate()
    {
        
    }


    public void DisableEffects ()
    {
        pingLine.enabled = false;
    }


    void Ping ()
    {
        timer = 0f;

        pingLine.enabled = true;
        pingLine.SetPosition (0, new Vector3(0f, 0f, 0f));

        pingRay.origin = transform.position;
        pingRay.direction = new Vector3(range, -5, 0);
        

        if(Physics.Raycast (pingRay, out floorHit, range))
        {
            // floor hit, steer up
            
            
            Debug.Log("Floor detected");
            IncreaseElevation();
            //EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            //if(enemyHealth != null)
            //{
            //    enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            //}
            //pingLine.SetPosition (1, floorHit.point);
            pingLine.SetPosition(1, new Vector3(range, -5, 0));
        }
        else
        {
            Debug.Log("No floor detected");
            DecreaseElevation();
            
            //pingLine.SetPosition (1, pingRay.origin + pingRay.direction * range);
            pingLine.SetPosition(1, new Vector3(range, -5, 0));
        }

        Debug.Log(rigidbody.velocity + " " + rigidbody.velocity.magnitude);
    }

    private void IncreaseElevation()
    {
        //Debug.Log(rigidbody.angularVelocity.magnitude);
        if (transform.rotation.z < 0.1f && rigidbody.angularVelocity.magnitude < 0.2f)
        {
            rigidbody.AddRelativeTorque(0, 0, 20, ForceMode.Impulse);    
        }
        rigidbody.AddRelativeForce(1000f, 0, 0);
        
    }

    private void DecreaseElevation()
    {
        if (transform.rotation.z > -0.1f && rigidbody.angularVelocity.magnitude < 0.2f)
        {
            rigidbody.AddRelativeTorque(0, 0, -20, ForceMode.Impulse);
        }
        else
        {
            rigidbody.AddRelativeTorque(0, 0, 10, ForceMode.Impulse);
        }
        rigidbody.AddRelativeForce(1000f, 0f, 0f);
    }
}

		
	

