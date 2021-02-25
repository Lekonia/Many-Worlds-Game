using UnityEngine;

public class CubeTest : MonoBehaviour
{
    private GameObject[] cubes = new GameObject[10];
    public float timer, interval = 2f;

    void Start()
    {
        Vector3 pos = new Vector3(-5, 0, 0);

        for (int i = 0; i < 10; i++)
        {
            cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubes[i].transform.position = pos;
            cubes[i].name = "Cube_" + i;
            pos.x++;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            for (int i = 0; i < 10; i++)
            {
                int randomValue = Random.Range(0, 2);
                if (randomValue == 0)
                {
                    cubes[i].SetActive(false);
                }
                else cubes[i].SetActive(true);
            }
            timer = 0;
        }
    }
}
