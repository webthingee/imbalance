using UnityEngine;
using UnityEngine.SceneManagement;

public class BeachBallCtrl : MonoBehaviour 
{
	public bool is3D;
	public float rotationSpeed = 0.1f;
	private Rigidbody2D beachBallrb;
    public bool goal = false;

    public delegate void LevelSuccessCondition();
    public static event LevelSuccessCondition levelSuccessDelegate;
    
    public delegate void LevelFailCondition();
    public static event LevelFailCondition levelFailDelegate;

	void Awake () 
    {
        beachBallrb = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate () 
    {	
        // consistently add rotation as ball moves
        if (is3D) {
			Add3DRotation();
		}

        // execute loading scene when ball passes below screen
        if (transform.position.y <= GameManager.GetBottomLeft.y) {
            if (goal) {
                levelSuccessDelegate();
            }
            else { 
                levelFailDelegate(); 
            }
        }
	}

	void Add3DRotation () {
        // positive is moving RIGHT; negitive is moving LEFT
        var localVelocity = transform.InverseTransformDirection(beachBallrb.velocity);

        // Add rotation to the beach ball
        if (localVelocity.x > 0)
        {
            transform.Rotate(localVelocity.x, Random.Range(rotationSpeed, rotationSpeed*2), 0);
        }
        if (localVelocity.x < 0)
        {
            transform.Rotate(-localVelocity.x, -rotationSpeed, 0);
        }
	}
}
