using UnityEngine;
using UnityEngine.UI;

public class ParamScript : MonoBehaviour
{

    [SerializeField] ScoreManager scoreManager;
    [SerializeField] FiringController firingController;
    [SerializeField] Text time;
    [SerializeField] Text point;
    [SerializeField] Text bulletBox;
    [SerializeField] Text bulllet;

    private void Update()
    {
        time.text = "Time:" + Time.realtimeSinceStartup.ToString();
        point.text = "Point:" + scoreManager.score.ToString();
        bulletBox.text = "BulletBox:" + firingController.bulletBox.ToString();
        bulllet.text = "Bullet:" + firingController.bullet.ToString() + "/30";

    }
}

