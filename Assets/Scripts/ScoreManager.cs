using UnityEngine;

public class ScoreManager : MonoBehaviour {
    
    public float score;     Vector3 centor;
    GameObject targetMarker;

	// Use this for initialization
	void Start () {
        targetMarker=GameObject.Find("TargetMarker");
        centor = targetMarker.GetComponent<Renderer>().bounds.center;
	}
	
    public void AddScore(Vector3 hitPoint)
    {         float distance = Vector3.Distance(centor, hitPoint);         score += 100.0f - (distance * 200.0f);     } }
