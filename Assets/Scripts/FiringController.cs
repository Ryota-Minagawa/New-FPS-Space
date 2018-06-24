using UnityEngine;

public class FiringController : MonoBehaviour
{

    [SerializeField] Camera firstPersonCamera;
    [SerializeField] ScoreManager scoreManager;
    GameObject firingEffect;
    AudioSource audioSource;
    AudioClip shotSound;
    AudioClip reloadSound;
    int bulletMaximum = 30;     public int bulletBox = 150;     public int bullet = 30;
    float bulletInterval;
    Ray ray;

    void Start()
    {
        firingEffect = Resources.Load<GameObject>("Effects/Sparkle");
        audioSource = gameObject.GetComponent<AudioSource>();
        shotSound = Resources.Load<AudioClip>("Audio/fire");
        reloadSound = Resources.Load<AudioClip>("Audio/reload");
    }


    void Update()
    {
        bulletInterval += Time.deltaTime;
        if (bulletInterval > 1.0f && Input.GetMouseButton(0) && bullet > 0)
        {
            ray = firstPersonCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            HitSomething();
            GenerateHitEffect();
            GenerateMuzzleEffect();
            bullet--;             bulletInterval = 0.0f;
        }

        if (bullet < bulletMaximum && bulletBox > 0)         {             if (Input.GetKey(KeyCode.R))             {                 reload();             }         }

    }

    void HitSomething()
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Target")
            {
                hit.collider.gameObject.GetComponent<TargetManager>().DeclineHp();
                scoreManager.AddScore(hit.point);
            }
        }
    }

    void GenerateHitEffect()     {         GameObject hitEffect = Instantiate(firingEffect);         hitEffect.transform.position = ray.GetPoint(2.0f);         audioSource.PlayOneShot(shotSound);         Destroy(hitEffect, 0.3f);     }

    void GenerateMuzzleEffect()
    {
        GameObject muzzleEffect = Instantiate(firingEffect);
        muzzleEffect.transform.parent = gameObject.transform;
        muzzleEffect.transform.localPosition = new Vector3(0, 0.1f, 0.9f);
        Destroy(muzzleEffect, 0.3f);
    }

    void reload()     {         audioSource.PlayOneShot(reloadSound);         while (bullet < bulletMaximum && bulletBox > 0)         {             ++bullet;             --bulletBox;         }     } 
   
}
