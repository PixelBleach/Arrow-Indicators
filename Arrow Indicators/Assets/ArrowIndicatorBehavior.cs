using UnityEngine;
using System.Collections;

public class ArrowIndicatorBehavior : MonoBehaviour {

    #region Public Variables

    [Range(1, 10)]
    public float positionOffset = 2;
    public float minAlphaRange;
    public float maxAlphaRange;
    public bool isVisible;
    
    #endregion

    #region Private Variables

    [SerializeField]
	private GameObject targetObject;
    [SerializeField]
	private GameObject playerObject;
	private GameObject targetObjectWithOffset;
    private Vector3 targetSpawnPoint;
	private Vector3 originToTarget;
    
    #endregion

    #region Unity Callbacks
    void Start () {

        playerObject = GameObject.FindGameObjectWithTag("Player");
		targetObjectWithOffset = new GameObject ("offsetPosition");

	}

	void Update () {

		//Vector Math for pointing the arrow towards the target Bumbletum
		originToTarget = targetObject.transform.position - playerObject.transform.position;

        //Set the position of the indicator arrow on the parent, then offset it so that it "floats" around the parent
        this.gameObject.transform.position = gameObject.transform.parent.position + (originToTarget.normalized * positionOffset);

        //This is a modifier so that the arrow's don't point to a new y position. They'll always point perpendicular to the parent object.
		float PlayerObjectsYPos = gameObject.transform.position.y;

        float SameTargetXPos = targetObject.transform.position.x;
        float SameTargetZPos = targetObject.transform.position.z;
        targetObjectWithOffset.transform.position = new Vector3(SameTargetXPos, PlayerObjectsYPos, SameTargetZPos);

        //Point to object
		this.gameObject.transform.LookAt (targetObjectWithOffset.transform.position);

	}

    public void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.gameObject.tag == "Bumbletum")
        {
            targetObject = otherObject.gameObject;
            Debug.Log("Wow look at this : " + otherObject.gameObject);
        }
    }
    #endregion
}
