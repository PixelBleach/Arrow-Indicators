using UnityEngine;
using System.Collections;

public class ArrowIndicatorManager : MonoBehaviour {

    #region Public Variables

    public GameObject PlayerObject;
    public GameObject IndicatorPrefab;

	[SerializeField]
	public GameObject[] BumbleTumObjects;
    public Transform[] locations;
    public GameObject[] arrowIndicators;

    #endregion

    #region Unity Callbacks

    void Start () {

        //For now all the bumbletum objects are defined on start. Adding and subtracting bumbletums to the array of bumbletums around you needs to be done at a later date. 

        for (int i = 0; i < BumbleTumObjects.Length; i++)
        {
            //Debug.Log("Bumbletum object " + i + " is named " + BumbleTumObjects[i].name);
            locations[i] = BumbleTumObjects[i].gameObject.transform;

            GameObject arrowIndic = Instantiate(IndicatorPrefab, locations[i].transform.position, Quaternion.identity) as GameObject;
            arrowIndicators[i] = arrowIndic;
            arrowIndicators[i].transform.parent = PlayerObject.transform;
            //Debug.Log(arrowIndicators[i]);
            //Debug.Log("The transform of object " + i + " is :" + locations[i]);
        }
    }

    void Update () {

        //TODO: Update the list of bumbletums around the player

        //TODO: Add + subtract bumbletums from the indicator list 

	}
   
    #endregion
}



