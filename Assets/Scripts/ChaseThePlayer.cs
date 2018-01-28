using UnityEngine;

public class ChaseThePlayer : MonoBehaviour {

	public GameObject Player = null;
	public float SluggishTimeInterval = 0.5f;
	public float MovementSpeed = 0.33f;
	public float AttackRecoveryTime = 0.5f;

    private float _alertnessTimer = 0;
	public float RecoveryTimeAfterHit = 0;

    public float _attackRecoveryTimer = 0;
    private Vector3 _whereToGo = new Vector3 ();

    private  Vector3 _lastPosiion =new Vector3();
    private Vector3 _velocity = new Vector3();

	// Use this for initialization
	void Start () {
		if(Player == null)
            Debug.Log("<color=yellow> no player to follow :(</color>");
	}

    private bool everyotherFrame;
    
	// Update is called once per frame
	void Update ()
	{
	    if (everyotherFrame)
	    {
	        _velocity = gameObject.transform.position - _lastPosiion;
	        _lastPosiion = gameObject.transform.position;
	    }
	    everyotherFrame = !everyotherFrame;

	    _attackRecoveryTimer-= Time.deltaTime;
		_alertnessTimer += Time.deltaTime;

	    if (_attackRecoveryTimer < 0.01f)
	    {
            _attackRecoveryTimer = 0.0f;
	        if (_alertnessTimer > SluggishTimeInterval)
	        {
	            if (Player != null)
	            {
	                _whereToGo = Player.transform.position;
	            }
	        }

	        Vector3 newPosition = Vector3.MoveTowards(transform.position, _whereToGo, MovementSpeed * Time.deltaTime);
	        newPosition.z = 0;
	        transform.position = newPosition;
	        transform.LookAt(_whereToGo);

	        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
	    }
	    else
	    {
            transform.position = transform.position;
            transform.position = transform.position;
        }
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
        //collision.relativeVelocity
		if (_attackRecoveryTimer <= 0.01f && collision.gameObject.name == "Player") {
            _attackRecoveryTimer = RecoveryTimeAfterHit;

		    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(_velocity * 700, ForceMode2D.Impulse);
            //collision.rigidbody.velocity = new Vector2(0,0)
            gameObject.GetComponent<Rigidbody2D>().AddForce(-_velocity * 60, ForceMode2D.Impulse);

        }

        else if (collision.gameObject.name == "Wave")
        {
            Debug.Log("Hit Wave");
            _attackRecoveryTimer = RecoveryTimeAfterHit;
            //collision.rigidbody.velocity = new Vector2(0,0)
            Vector3 Vel = collision.gameObject.GetComponent<WaveActions>().Velocity;
            Debug.Log("Velocity: " + Vel);
            GetComponent<Rigidbody2D>().AddForce(Vel * 100, ForceMode2D.Impulse);
           
        }
    }

    

}
