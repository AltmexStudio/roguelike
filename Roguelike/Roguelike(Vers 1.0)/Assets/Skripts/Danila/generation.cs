using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generation : MonoBehaviour
{

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
                what = rooms.Length - 1;

            GameObject room = Instantiate(rooms[what]);


            h = false;
            while (h == false)
            {
                num = rand.Next(takeroom.Count);
                k = true;
                x = rand.Next(1, 5);
                //x = 1;
                if (x == 1)
                {
                    check[0] = takeroom[num].transform.position.x;
                    check[1] = takeroom[num].transform.position.y + takeroom[num].transform.localScale.y / 2.0f + room.transform.localScale.y / 2.0f;

                    for (int j = 0; j < takeroom.Count; j++)
                    {
                        if ((check[1] + room.transform.localScale.y / 2.0f) > (takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) && (check[1] + room.transform.localScale.y / 2.0f) < (takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) && ((check[0] + room.transform.localScale.x / 2.0f <= takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f >= takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f)))
                        {
                            Debug.Log(1);
                            k = false;
                            break;
                        }
                        else if ((check[0] + room.transform.localScale.x / 2.0f) > (takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) && ((check[0] + room.transform.localScale.x / 2.0f) < (takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) || (check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f)) && ((check[1] + room.transform.localScale.y / 2.0f <= takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f >= takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f)))
                        {
                            Debug.Log(2);
                            k = false;
                            break;
                        }
                        else if ((check[0] - room.transform.localScale.x / 2.0f) < (takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) && (check[0] - room.transform.localScale.x / 2.0f) > (takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) && ((check[1] + room.transform.localScale.y / 2.0f <= takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f >= takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f)))
                        {
                            Debug.Log(3);
                            k = false;
                            break;
                        }
                        else if ((check[1] - room.transform.localScale.y / 2.0f) < (takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) && ((check[1] - room.transform.localScale.y / 2.0f) > (takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f)) && ((check[0] + room.transform.localScale.x / 2.0f <= takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f >= takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f)))
                        {
                            Debug.Log(4);
                            k = false;
                            break;
                        }
                    }
                    //k = true;
                    if (k == true)
                    {
                        room.transform.position = new Vector3(check[0], check[1], 0);
                        h = true;
                    }
                }
                else if (x == 2)
                {
                    check[0] = takeroom[num].transform.position.x + takeroom[num].transform.localScale.x / 2.0f + room.transform.localScale.x / 2.0f;
                    check[1] = takeroom[num].transform.position.y;

                    for (int j = 0; j < takeroom.Count; j++)
                    {
                        if ((check[1] + room.transform.localScale.y / 2.0f) > (takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) && (check[1] + room.transform.localScale.y / 2.0f) < (takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) && ((check[0] + room.transform.localScale.x / 2.0f <= takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f >= takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f)))
                        {
                            Debug.Log(1);
                            k = false;
                            break;
                        }
                        else if ((check[0] + room.transform.localScale.x / 2.0f) > (takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) && ((check[0] + room.transform.localScale.x / 2.0f) < (takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) || (check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f)) && ((check[1] + room.transform.localScale.y / 2.0f <= takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f >= takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f)))
                        {
                            Debug.Log(2);
                            k = false;
                            break;
                        }
                        else if ((check[0] - room.transform.localScale.x / 2.0f) < (takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) && (check[0] - room.transform.localScale.x / 2.0f) > (takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) && ((check[1] + room.transform.localScale.y / 2.0f <= takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f >= takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f)))
                        {
                            Debug.Log(3);
                            k = false;
                            break;
                        }
                        else if ((check[1] - room.transform.localScale.y / 2.0f) < (takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) && ((check[1] - room.transform.localScale.y / 2.0f) > (takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f)) && ((check[0] + room.transform.localScale.x / 2.0f <= takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f >= takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f)))
                        {
                            Debug.Log(4);
                            k = false;
                            break;
                        }
                    }
                    //k = true;
                    if (k == true)
                    {
                        room.transform.position = new Vector3(check[0], check[1], 0);
                        h = true;
                    }
                }
                else if (x == 3)
                {
                    check[0] = takeroom[num].transform.position.x;
                    check[1] = takeroom[num].transform.position.y - takeroom[num].transform.localScale.y / 2.0f - room.transform.localScale.y / 2.0f;

                    for (int j = 0; j < takeroom.Count; j++)
                    {
                        if ((check[1] + room.transform.localScale.y / 2.0f) > (takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) && (check[1] + room.transform.localScale.y / 2.0f) < (takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) && ((check[0] + room.transform.localScale.x / 2.0f <= takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f >= takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f)))
                        {
                            Debug.Log(1);
                            k = false;
                            break;
                        }
                        else if ((check[0] + room.transform.localScale.x / 2.0f) > (takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) && ((check[0] + room.transform.localScale.x / 2.0f) < (takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) || (check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f)) && ((check[1] + room.transform.localScale.y / 2.0f <= takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f >= takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f)))
                        {
                            Debug.Log(2);
                            k = false;
                            break;
                        }
                        else if ((check[0] - room.transform.localScale.x / 2.0f) < (takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) && (check[0] - room.transform.localScale.x / 2.0f) > (takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) && ((check[1] + room.transform.localScale.y / 2.0f <= takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f >= takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f)))
                        {
                            Debug.Log(3);
                            k = false;
                            break;
                        }
                        else if ((check[1] - room.transform.localScale.y / 2.0f) < (takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) && ((check[1] - room.transform.localScale.y / 2.0f) > (takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f)) && ((check[0] + room.transform.localScale.x / 2.0f <= takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f >= takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f)))
                        {
                            Debug.Log(4);
                            k = false;
                            break;
                        }
                    }
                    //k = true;
                    if (k == true)
                    {
                        room.transform.position = new Vector3(check[0], check[1], 0);
                        h = true;
                    }
                }
                else if (x == 4)
                {
                    check[0] = takeroom[num].transform.position.x - takeroom[num].transform.localScale.x / 2.0f - room.transform.localScale.x / 2.0f;
                    check[1] = takeroom[num].transform.position.y;

                    for (int j = 0; j < takeroom.Count; j++)
                    {
                        if ((check[1] + room.transform.localScale.y / 2.0f) > (takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) && (check[1] + room.transform.localScale.y / 2.0f) < (takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) && ((check[0] + room.transform.localScale.x / 2.0f <= takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f >= takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f)))
                        {
                            Debug.Log(1);
                            k = false;
                            break;
                        }
                        else if ((check[0] + room.transform.localScale.x / 2.0f) > (takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) && ((check[0] + room.transform.localScale.x / 2.0f) < (takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) || (check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f)) && ((check[1] + room.transform.localScale.y / 2.0f <= takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f >= takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f)))
                        {
                            Debug.Log(2);
                            k = false;
                            break;
                        }
                        else if ((check[0] - room.transform.localScale.x / 2.0f) < (takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) && (check[0] - room.transform.localScale.x / 2.0f) > (takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) && ((check[1] + room.transform.localScale.y / 2.0f <= takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f >= takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) || (check[1] + room.transform.localScale.y / 2.0f > takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f && check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f)))
                        {
                            Debug.Log(3);
                            k = false;
                            break;
                        }
                        else if ((check[1] - room.transform.localScale.y / 2.0f) < (takeroom[j].transform.position.y + takeroom[j].transform.localScale.y / 2.0f) && ((check[1] - room.transform.localScale.y / 2.0f) > (takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f) || (check[1] - room.transform.localScale.y / 2.0f < takeroom[j].transform.position.y - takeroom[j].transform.localScale.y / 2.0f)) && ((check[0] + room.transform.localScale.x / 2.0f <= takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f >= takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f) || (check[0] + room.transform.localScale.x / 2.0f > takeroom[j].transform.position.x + takeroom[j].transform.localScale.x / 2.0f && check[0] - room.transform.localScale.x / 2.0f < takeroom[j].transform.position.x - takeroom[j].transform.localScale.x / 2.0f)))
                        {
                            Debug.Log(4);
                            k = false;
                            break;
                        }
                    }
                    //k = true;
                    if (k == true)
                    {
                        room.transform.position = new Vector3(check[0], check[1], 0);
                        h = true;
                    }
                }
            }
            takeroom.Add(room);
            //if (q == 1) break;
        }

        Boss.transform.position = takeroom[takeroom.Count - 1].transform.position;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
