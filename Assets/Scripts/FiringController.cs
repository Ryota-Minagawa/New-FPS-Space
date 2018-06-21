using UnityEngine;

public class FiringController : MonoBehaviour {

    [SerializeField] Camera camera;
    GameObject firingEffect;
    AudioSource audioSource;
    AudioClip shotSound;
    float bulletInterval;
    Ray ray;



    void Start()
    {
        firingEffect = Resources.Load<GameObject>("Effects/Sparkle");
        audioSource = gameObject.GetComponent<AudioSource>();
        shotSound = Resources.Load<AudioClip>("Audio/fire");
    }

	
	void Update () {
        bulletInterval += Time.deltaTime;
        if(bulletInterval >= 1.0f&&Input.GetMouseButton(0))
        {
            ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            GenerateHitEffect();
            GenerateMuzzleEffect();             bulletInterval = 0.0f;
        }
	}

    void GenerateMuzzleEffect()     {         GameObject muzzleEffect = Instantiate(firingEffect);
        muzzleEffect.transform.parent = gameObject.transform;         muzzleEffect.transform.localPosition = new Vector3(0, 0.1f, 0.9f);         Destroy(muzzleEffect, 0.3f);     }
    void GenerateHitEffect()     {         GameObject hitEffect = Instantiate(firingEffect);         hitEffect.transform.position = ray.GetPoint(1.0f);         audioSource.PlayOneShot(shotSound);         Destroy(hitEffect, 0.3f);     }  
}
