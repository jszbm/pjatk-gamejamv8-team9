using UnityEngine;


public class Cube : MonoBehaviour {
    private float playInterval = 10f;
    private float timer = 0f;
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Engine");
        FindObjectOfType<AudioManager>().Play("Rain");
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= playInterval)
        {
            int rand1 = Random.Range(1, 3);
            if (rand1 == 1) {
                int rand2 = Random.Range(1, 4);
                if (rand2 == 1) {
                    FindObjectOfType<AudioManager>().Play("WomenSpeak1");
                    timer = 0f;
                    rand2 = Random.Range(1, 4);
                    rand1 = Random.Range(1, 3);
                } else if (rand2 == 2) {
                    FindObjectOfType<AudioManager>().Play("WomenSpeak2");
                    timer = 0f;
                    rand2 = Random.Range(1, 4);
                    rand1 = Random.Range(1, 3);
                } else if (rand2 == 3) {
                    FindObjectOfType<AudioManager>().Play("WomenSpeak3");
                    timer = 0f;
                    rand2 = Random.Range(1, 4);
                    rand1 = Random.Range(1, 3);
                }
            } else if (rand1 == 2) {
                FindObjectOfType<AudioManager>().Play("PassingCar");
                timer = 0f; 
                rand1 = Random.Range(1, 3);
            }
        }
    }
}
