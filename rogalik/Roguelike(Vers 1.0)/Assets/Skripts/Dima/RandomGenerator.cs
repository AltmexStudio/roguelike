using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour {

    public GameObject[] rooms = new GameObject[11];
    public GameObject Boss;

    // Use this for initialization
    void Start()
    {
        System.Random rand = new System.Random();

        List<GameObject> takeroom = new List<GameObject>();

        float[] check = new float[2];

        takeroom.Add(rooms[0]);

        int num, what, x, q = 0;

        bool h, k;

        while (takeroom.Count < 20)
        {
            q++;
            if (q < 19)
                what = rand.Next(1, rooms.Length - 1);
            else
                what = rooms.Length-1;

            GameObject room = Instantiate(rooms[what]);

            
            h = false;
            while (h == false)
            {
                num = rand.Next(takeroom.Count);
                k = true;
                x = rand.Next(1, 5);

                if (x == 1)
                {
                    check[0] = takeroom[num].transform.position.x;
                    check[1] = takeroom[num].transform.position.y + 1.0f;

                    for (int j = 0; j < takeroom.Count; j++)
                    {
                        if (takeroom[j].transform.position.x == check[0] && takeroom[j].transform.position.y == check[1])
                        {
                            k = false;
                            break;
                        }
                    }

                    if (k == true)
                    {
                        room.transform.position = new Vector3(takeroom[num].transform.position.x, takeroom[num].transform.position.y + 1.0f, 0);
                        h = true;
                    }
                }
                else if (x == 2)
                {
                    check[0] = takeroom[num].transform.position.x + 1.0f;
                    check[1] = takeroom[num].transform.position.y;

                    for (int j = 0; j < takeroom.Count; j++)
                    {
                        if (takeroom[j].transform.position.x == check[0] && takeroom[j].transform.position.y == check[1])
                        {
                            k = false;
                            break;
                        }
                    }

                    if (k == true)
                    {
                        room.transform.position = new Vector3(takeroom[num].transform.position.x + 1.0f, takeroom[num].transform.position.y, 0);
                        h = true;
                    }
                }
                else if (x == 3)
                {
                    check[0] = takeroom[num].transform.position.x;
                    check[1] = takeroom[num].transform.position.y - 1.0f;

                    for (int j = 0; j < takeroom.Count; j++)
                    {
                        if (takeroom[j].transform.position.x == check[0] && takeroom[j].transform.position.y == check[1])
                        {
                            k = false;
                            break;
                        }
                    }

                    if (k == true)
                    {
                        room.transform.position = new Vector3(takeroom[num].transform.position.x, takeroom[num].transform.position.y - 1.0f, 0);
                        h = true;
                    }
                }
                else if (x == 4)
                {
                    check[0] = takeroom[num].transform.position.x - 1.0f;
                    check[1] = takeroom[num].transform.position.y;

                    for (int j = 0; j < takeroom.Count; j++)
                    {
                        if (takeroom[j].transform.position.x == check[0] && takeroom[j].transform.position.y == check[1])
                        {
                            k = false;
                            break;
                        }
                    }

                    if (k == true)
                    {
                        room.transform.position = new Vector3(takeroom[num].transform.position.x - 1.0f, takeroom[num].transform.position.y, 0);
                        h = true;
                    }
                }
            }
            takeroom.Add(room);
        }

        Boss.transform.position = takeroom[takeroom.Count - 1].transform.position;

    }	

	// Update is called once per frame
	void Update () {
		
	}
}
