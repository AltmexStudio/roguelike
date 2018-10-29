using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    [SerializeField]
    private int CountOfRooms;

    public GameObject[] rooms = new GameObject[12];
    public GameObject Boss;
    public GameObject dend;

    int[] Napr(GameObject room)
    {
        int[] v = new int[4] { 0, 0, 0, 0 };

        string s = "";

        int l = room.name.Length - 8;

        if (room.name == "StartRoom(Clone)")
        {
            s = "U, R, L, D";
        }
        else if (room.name == "BossRoom(Clone)")
            s = "U, D";
        else
        {
            while (room.name[l - 1] != '(')
            {
                s += room.name[l - 1];
                l--;
            }
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'U')
                v[0] = 1;
            else if (s[i] == 'R')
                v[1] = 1;
            else if (s[i] == 'D')
                v[2] = 1;
            else if (s[i] == 'L')
                v[3] = 1;
        }

        return v;
    }

    // Use this for initialization
    void Start()
    {
        System.Random rand = new System.Random();

        List<GameObject> takeroom = new List<GameObject>();
        GameObject tup;

        Dictionary<GameObject, int[]> dict = new Dictionary<GameObject, int[]>(CountOfRooms);

        float[] check = new float[2];

        GameObject room = Instantiate(rooms[0]);

        room.transform.position = new Vector3(0, 0, 0);

        takeroom.Add(room);

        dict[room] = new int[] { 0, 0, 0, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11 };

        int num, what = 0, x, q = 1;

        bool h, k;

        string s1, s2;

        while (q < CountOfRooms)
        {
            q++;

            //Debug.Log(room.name);

            h = false;
            while (h == false)
            {

                x = 0;
                num = 0;
                k = true;

                bool e = false;

                while (e == false)
                {


                    int[] v1 = new int[4] { 0, 0, 0, 0 };
                    int[] v2 = new int[4] { 0, 0, 0, 0 };

                    s1 = "";
                    s2 = "";

                    num = rand.Next(takeroom.Count);

                    int l = takeroom[num].name.Length - 8;

                    // Debug.Log(takeroom[num].transform.position);

                    //Debug.Log(takeroom[num].name);

                    if (takeroom[num].name == "StartRoom(Clone)")
                    {
                        s2 = "U, R, L, D";
                    }
                    else
                    {
                        while (takeroom[num].name[l - 1] != '(')
                        {
                            s2 += takeroom[num].name[l - 1];
                            l--;
                        }
                    }

                    for (int i = 0; i < s2.Length; i++)
                    {
                        if (s2[i] == 'U')
                            v2[0] = 1;
                        else if (s2[i] == 'R')
                            v2[1] = 1;
                        else if (s2[i] == 'D')
                            v2[2] = 1;
                        else if (s2[i] == 'L')
                            v2[3] = 1;
                    }

                    if (q < CountOfRooms)
                    {
                        what = rand.Next(dict[takeroom[num]].Length - 1);
                        what = dict[takeroom[num]][what];
                    }
                    else
                    {
                        // Debug.Log("takeboss");
                        //Debug.Log(q);
                        what = dict[takeroom[num]][dict[takeroom[num]].Length - 1];
                    }
                    room = Instantiate(rooms[what]);

                    l = room.name.Length - 8;

                    if (room.name == "BossRoom(Clone)")
                        s1 = "U, D";

                    else if (room.name == "StartRoom(Clone)")
                        s1 = "U, D, R, L";

                    else if (room.name != "BossRoom(Clone)")
                    {
                        while (room.name[l - 1] != '(')
                        {
                            s1 += room.name[l - 1];
                            l--;
                        }
                    }

                    for (int i = 0; i < s1.Length; i++)
                    {
                        if (s1[i] == 'U')
                            v1[0] = 1;
                        else if (s1[i] == 'R')
                            v1[1] = 1;
                        else if (s1[i] == 'D')
                            v1[2] = 1;
                        else if (s1[i] == 'L')
                            v1[3] = 1;
                    }

                    x = rand.Next(1, 5);

                    // Debug.Log(x);
                    //Debug.Log(s1);
                    //Debug.Log(s2);

                    if (x == 1)
                    {
                        if (v2[0] == 1 && v1[2] == 1)
                            e = true;
                    }
                    else if (x == 2)
                    {
                        if (v2[1] == 1 && v1[3] == 1)
                            e = true;
                    }
                    else if (x == 3)
                    {
                        if (v2[2] == 1 && v1[0] == 1)
                            e = true;
                    }
                    else if (x == 4)
                    {
                        if (v2[3] == 1 && v1[1] == 1)
                            e = true;
                    }
                    //Debug.Log(e);
                    //break;
                    if (e == false)
                        Destroy(room, 0.002f);
                }

                //Debug.Log(num);
                //Debug.Log(x);
                if (q < CountOfRooms)
                {
                    if (x == 1)
                    {
                        check[0] = takeroom[num].transform.position.x;
                        check[1] = takeroom[num].transform.position.y + 2.0f;

                        for (int j = 0; j < takeroom.Count; j++)
                        {
                            if ((check[1] + 1.0f) > (takeroom[j].transform.position.y - 1.0f) && (check[1] + 1.0f) < (takeroom[j].transform.position.y + 1.0f) && ((check[0] + 1.0f <= takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f >= takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x - 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f)))
                            {
                                //Debug.Log(1);
                                k = false;
                                break;
                            }
                            else if ((check[0] + 1.0f) > (takeroom[j].transform.position.x - 1.0f) && ((check[0] + 1.0f) < (takeroom[j].transform.position.x + 1.0f) || (check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f)) && ((check[1] + 1.0f <= takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f >= takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y - 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f)))
                            {
                                // Debug.Log(2);
                                k = false;
                                break;
                            }
                            else if ((check[0] - 1.0f) < (takeroom[j].transform.position.x + 1.0f) && (check[0] - 1.0f) > (takeroom[j].transform.position.x - 1.0f) && ((check[1] + 1.0f <= takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f >= takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y - 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f)))
                            {
                                // Debug.Log(3);
                                k = false;
                                break;
                            }
                            else if ((check[1] - 1.0f) < (takeroom[j].transform.position.y + 1.0f) && ((check[1] - 1.0f) > (takeroom[j].transform.position.y - 1.0f) || (check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f)) && ((check[0] + 1.0f <= takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f >= takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x - 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f)))
                            {
                                // Debug.Log(4);
                                k = false;
                                break;
                            }
                            else if (check[0] + 1.0f == takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f == takeroom[j].transform.position.x - 1.0f && check[1] + 1.0f == takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f == takeroom[j].transform.position.y - 1.0f)
                            {
                                k = false;
                                break;
                            }
                        }
                        // k = true;
                        if (k == true)
                        {
                            room.transform.position = new Vector3(check[0], check[1], 0);
                            h = true;
                        }
                        else
                            Destroy(room, 0.002f);
                    }
                    else if (x == 2)
                    {
                        check[0] = takeroom[num].transform.position.x + 2.0f;
                        check[1] = takeroom[num].transform.position.y;

                        for (int j = 0; j < takeroom.Count; j++)
                        {
                            if ((check[1] + 1.0f) > (takeroom[j].transform.position.y - 1.0f) && (check[1] + 1.0f) < (takeroom[j].transform.position.y + 1.0f) && ((check[0] + 1.0f <= takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f >= takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x - 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f)))
                            {
                                // Debug.Log(1);
                                k = false;
                                break;
                            }
                            else if ((check[0] + 1.0f) > (takeroom[j].transform.position.x - 1.0f) && ((check[0] + 1.0f) < (takeroom[j].transform.position.x + 1.0f) || (check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f)) && ((check[1] + 1.0f <= takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f >= takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y - 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f)))
                            {
                                // Debug.Log(2);
                                k = false;
                                break;
                            }
                            else if ((check[0] - 1.0f) < (takeroom[j].transform.position.x + 1.0f) && (check[0] - 1.0f) > (takeroom[j].transform.position.x - 1.0f) && ((check[1] + 1.0f <= takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f >= takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y - 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f)))
                            {
                                //Debug.Log(3);
                                k = false;
                                break;
                            }
                            else if ((check[1] - 1.0f) < (takeroom[j].transform.position.y + 1.0f) && ((check[1] - 1.0f) > (takeroom[j].transform.position.y - 1.0f) || (check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f)) && ((check[0] + 1.0f <= takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f >= takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x - 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f)))
                            {
                                //Debug.Log(4);
                                k = false;
                                break;
                            }
                            else if (check[0] + 1.0f == takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f == takeroom[j].transform.position.x - 1.0f && check[1] + 1.0f == takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f == takeroom[j].transform.position.y - 1.0f)
                            {
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
                        else
                            Destroy(room, 0.002f);
                    }
                    else if (x == 3)
                    {
                        check[0] = takeroom[num].transform.position.x;
                        check[1] = takeroom[num].transform.position.y - 2.0f;

                        for (int j = 0; j < takeroom.Count; j++)
                        {
                            if ((check[1] + 1.0f) > (takeroom[j].transform.position.y - 1.0f) && (check[1] + 1.0f) < (takeroom[j].transform.position.y + 1.0f) && ((check[0] + 1.0f <= takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f >= takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x - 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f)))
                            {
                                // Debug.Log(1);
                                k = false;
                                break;
                            }
                            else if ((check[0] + 1.0f) > (takeroom[j].transform.position.x - 1.0f) && ((check[0] + 1.0f) < (takeroom[j].transform.position.x + 1.0f) || (check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f)) && ((check[1] + 1.0f <= takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f >= takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y - 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f)))
                            {
                                // Debug.Log(2);
                                k = false;
                                break;
                            }
                            else if ((check[0] - 1.0f) < (takeroom[j].transform.position.x + 1.0f) && (check[0] - 1.0f) > (takeroom[j].transform.position.x - 1.0f) && ((check[1] + 1.0f <= takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f >= takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y - 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f)))
                            {
                                // Debug.Log(3);
                                k = false;
                                break;
                            }
                            else if ((check[1] - 1.0f) < (takeroom[j].transform.position.y + 1.0f) && ((check[1] - 1.0f) > (takeroom[j].transform.position.y - 1.0f) || (check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f)) && ((check[0] + 1.0f <= takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f >= takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x - 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f)))
                            {
                                //Debug.Log(4);
                                k = false;
                                break;
                            }
                            else if (check[0] + 1.0f == takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f == takeroom[j].transform.position.x - 1.0f && check[1] + 1.0f == takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f == takeroom[j].transform.position.y - 1.0f)
                            {
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
                        else
                            Destroy(room, 0.002f);
                    }
                    else if (x == 4)
                    {
                        check[0] = takeroom[num].transform.position.x - 2.0f;
                        check[1] = takeroom[num].transform.position.y;

                        for (int j = 0; j < takeroom.Count; j++)
                        {
                            if ((check[1] + 1.0f) > (takeroom[j].transform.position.y - 1.0f) && (check[1] + 1.0f) < (takeroom[j].transform.position.y + 1.0f) && ((check[0] + 1.0f <= takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f >= takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x - 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f)))
                            {
                                //Debug.Log(1);
                                k = false;
                                break;
                            }
                            else if ((check[0] + 1.0f) > (takeroom[j].transform.position.x - 1.0f) && ((check[0] + 1.0f) < (takeroom[j].transform.position.x + 1.0f) || (check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f)) && ((check[1] + 1.0f <= takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f >= takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y - 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f)))
                            {
                                // Debug.Log(2);
                                k = false;
                                break;
                            }
                            else if ((check[0] - 1.0f) < (takeroom[j].transform.position.x + 1.0f) && (check[0] - 1.0f) > (takeroom[j].transform.position.x - 1.0f) && ((check[1] + 1.0f <= takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f >= takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y - 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] + 1.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f)))
                            {
                                // Debug.Log(3);
                                k = false;
                                break;
                            }
                            else if ((check[1] - 1.0f) < (takeroom[j].transform.position.y + 1.0f) && ((check[1] - 1.0f) > (takeroom[j].transform.position.y - 1.0f) || (check[1] - 1.0f < takeroom[j].transform.position.y - 1.0f)) && ((check[0] + 1.0f <= takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f >= takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x - 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] + 1.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f < takeroom[j].transform.position.x - 1.0f)))
                            {
                                // Debug.Log(4);
                                k = false;
                                break;
                            }
                            else if (check[0] + 1.0f == takeroom[j].transform.position.x + 1.0f && check[0] - 1.0f == takeroom[j].transform.position.x - 1.0f && check[1] + 1.0f == takeroom[j].transform.position.y + 1.0f && check[1] - 1.0f == takeroom[j].transform.position.y - 1.0f)
                            {
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
                        else
                            Destroy(room, 0.002f);
                    }
                }

                else if (q == CountOfRooms)
                {
                    // Debug.Log("INBOSS");
                    if (x == 1)
                    {
                        check[0] = takeroom[num].transform.position.x;
                        check[1] = takeroom[num].transform.position.y + 4.0f;

                        for (int j = 0; j < takeroom.Count; j++)
                        {
                            if (check[0] + 3.0f <= takeroom[j].transform.position.x + 1.0f && check[0] + 3.0f > takeroom[j].transform.position.x - 1.0f && ((check[1] + 3.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 3.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] - 3.0f < takeroom[j].transform.position.y - 1.0f && check[1] + 3.0f > takeroom[j].transform.position.y - 1.0f)))
                            {
                                //Debug.Log(1);
                                k = false;
                                break;
                            }
                            else if (check[1] + 3.0f <= takeroom[j].transform.position.y + 1.0f && check[1] + 3.0f > takeroom[j].transform.position.y - 1.0f && ((check[0] + 3.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 3.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] - 3.0f < takeroom[j].transform.position.x - 1.0f && check[0] + 3.0f > takeroom[j].transform.position.x - 1.0f)))
                            {
                                // Debug.Log(2);
                                k = false;
                                break;
                            }
                            else if (check[0] - 3.0f >= takeroom[j].transform.position.x - 1.0f && check[0] - 3.0f < takeroom[j].transform.position.x + 1.0f && ((check[1] + 3.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 3.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] - 3.0f < takeroom[j].transform.position.y - 1.0f && check[1] + 3.0f > takeroom[j].transform.position.y - 1.0f)))
                            {
                                // Debug.Log(3);
                                k = false;
                                break;
                            }
                            else if (check[1] - 3.0f >= takeroom[j].transform.position.y - 1.0f && check[1] - 3.0f < takeroom[j].transform.position.y + 1.0f && ((check[0] + 3.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 3.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] - 3.0f < takeroom[j].transform.position.x - 1.0f && check[0] + 3.0f > takeroom[j].transform.position.x - 1.0f)))
                            {
                                // Debug.Log(4);
                                k = false;
                                break;
                            }
                            else if (check[1] + 3.0f >= takeroom[j].transform.position.y + 1.0f && check[1] - 3.0f <= takeroom[j].transform.position.y - 1.0f && check[0] + 3.0f >= takeroom[j].transform.position.x + 1.0f && check[0] - 3.0f <= takeroom[j].transform.position.x - 1.0f)
                            {
                                //Debug.Log(228);
                                k = false;
                                break;
                            }
                        }
                        //k = true;
                        if (k == true)
                        {
                            room.transform.position = new Vector3(check[0], check[1], 0);
                            h = true;
                            // Debug.Log("BoosCreated");
                        }
                        else
                            Destroy(room, 0.002f);
                    }
                    if (x == 2)
                    {
                        check[0] = takeroom[num].transform.position.x + 4.0f;
                        check[1] = takeroom[num].transform.position.y;

                        for (int j = 0; j < takeroom.Count; j++)
                        {
                            if (check[0] + 3.0f <= takeroom[j].transform.position.x + 1.0f && check[0] + 3.0f > takeroom[j].transform.position.x - 1.0f && ((check[1] + 3.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 3.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] - 3.0f < takeroom[j].transform.position.y - 1.0f && check[1] + 3.0f > takeroom[j].transform.position.y - 1.0f)))
                            {
                                //Debug.Log(1);
                                k = false;
                                break;
                            }
                            else if (check[1] + 3.0f <= takeroom[j].transform.position.y + 1.0f && check[1] + 3.0f > takeroom[j].transform.position.y - 1.0f && ((check[0] + 3.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 3.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] - 3.0f < takeroom[j].transform.position.x - 1.0f && check[0] + 3.0f > takeroom[j].transform.position.x - 1.0f)))
                            {
                                // Debug.Log(2);
                                k = false;
                                break;
                            }
                            else if (check[0] - 3.0f >= takeroom[j].transform.position.x - 1.0f && check[0] - 3.0f < takeroom[j].transform.position.x + 1.0f && ((check[1] + 3.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 3.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] - 3.0f < takeroom[j].transform.position.y - 1.0f && check[1] + 3.0f > takeroom[j].transform.position.y - 1.0f)))
                            {
                                // Debug.Log(3);
                                k = false;
                                break;
                            }
                            else if (check[1] - 3.0f >= takeroom[j].transform.position.y - 1.0f && check[1] - 3.0f < takeroom[j].transform.position.y + 1.0f && ((check[0] + 3.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 3.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] - 3.0f < takeroom[j].transform.position.x - 1.0f && check[0] + 3.0f > takeroom[j].transform.position.x - 1.0f)))
                            {
                                // Debug.Log(4);
                                k = false;
                                break;
                            }
                            else if (check[1] + 3.0f >= takeroom[j].transform.position.y + 1.0f && check[1] - 3.0f <= takeroom[j].transform.position.y - 1.0f && check[0] + 3.0f >= takeroom[j].transform.position.x + 1.0f && check[0] - 3.0f <= takeroom[j].transform.position.x - 1.0f)
                            {
                                k = false;
                                break;
                            }
                        }
                        //k = true;
                        if (k == true)
                        {
                            room.transform.position = new Vector3(check[0], check[1], 0);
                            h = true;
                            // Debug.Log("BoosCreated");
                        }

                    }
                    if (x == 3)
                    {
                        check[0] = takeroom[num].transform.position.x;
                        check[1] = takeroom[num].transform.position.y - 4.0f;

                        for (int j = 0; j < takeroom.Count; j++)
                        {
                            if (check[0] + 3.0f <= takeroom[j].transform.position.x + 1.0f && check[0] + 3.0f > takeroom[j].transform.position.x - 1.0f && ((check[1] + 3.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 3.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] - 3.0f < takeroom[j].transform.position.y - 1.0f && check[1] + 3.0f > takeroom[j].transform.position.y - 1.0f)))
                            {
                                //Debug.Log(1);
                                k = false;
                                break;
                            }
                            else if (check[1] + 3.0f <= takeroom[j].transform.position.y + 1.0f && check[1] + 3.0f > takeroom[j].transform.position.y - 1.0f && ((check[0] + 3.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 3.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] - 3.0f < takeroom[j].transform.position.x - 1.0f && check[0] + 3.0f > takeroom[j].transform.position.x - 1.0f)))
                            {
                                // Debug.Log(2);
                                k = false;
                                break;
                            }
                            else if (check[0] - 3.0f >= takeroom[j].transform.position.x - 1.0f && check[0] - 3.0f < takeroom[j].transform.position.x + 1.0f && ((check[1] + 3.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 3.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] - 3.0f < takeroom[j].transform.position.y - 1.0f && check[1] + 3.0f > takeroom[j].transform.position.y - 1.0f)))
                            {
                                // Debug.Log(3);
                                k = false;
                                break;
                            }
                            else if (check[1] - 3.0f >= takeroom[j].transform.position.y - 1.0f && check[1] - 3.0f < takeroom[j].transform.position.y + 1.0f && ((check[0] + 3.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 3.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] - 3.0f < takeroom[j].transform.position.x - 1.0f && check[0] + 3.0f > takeroom[j].transform.position.x - 1.0f)))
                            {
                                // Debug.Log(4);
                                k = false;
                                break;
                            }
                            else if (check[1] + 3.0f >= takeroom[j].transform.position.y + 1.0f && check[1] - 3.0f <= takeroom[j].transform.position.y - 1.0f && check[0] + 3.0f >= takeroom[j].transform.position.x + 1.0f && check[0] - 3.0f <= takeroom[j].transform.position.x - 1.0f)
                            {
                                k = false;
                                break;
                            }
                        }
                        //k = true;
                        if (k == true)
                        {
                            room.transform.position = new Vector3(check[0], check[1], 0);
                            h = true;
                            // Debug.Log("BoosCreated");
                        }
                        else
                            Destroy(room, 0.002f);
                    }
                    if (x == 4)
                    {
                        check[0] = takeroom[num].transform.position.x - 4.0f;
                        check[1] = takeroom[num].transform.position.y;

                        for (int j = 0; j < takeroom.Count; j++)
                        {
                            if (check[0] + 3.0f <= takeroom[j].transform.position.x + 1.0f && check[0] + 3.0f > takeroom[j].transform.position.x - 1.0f && ((check[1] + 3.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 3.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] - 3.0f < takeroom[j].transform.position.y - 1.0f && check[1] + 3.0f > takeroom[j].transform.position.y - 1.0f)))
                            {
                                //Debug.Log(1);
                                k = false;
                                break;
                            }
                            else if (check[1] + 3.0f <= takeroom[j].transform.position.y + 1.0f && check[1] + 3.0f > takeroom[j].transform.position.y - 1.0f && ((check[0] + 3.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 3.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] - 3.0f < takeroom[j].transform.position.x - 1.0f && check[0] + 3.0f > takeroom[j].transform.position.x - 1.0f)))
                            {
                                // Debug.Log(2);
                                k = false;
                                break;
                            }
                            else if (check[0] - 3.0f >= takeroom[j].transform.position.x - 1.0f && check[0] - 3.0f < takeroom[j].transform.position.x + 1.0f && ((check[1] + 3.0f > takeroom[j].transform.position.y + 1.0f && check[1] - 3.0f < takeroom[j].transform.position.y + 1.0f) || (check[1] - 3.0f < takeroom[j].transform.position.y - 1.0f && check[1] + 3.0f > takeroom[j].transform.position.y - 1.0f)))
                            {
                                // Debug.Log(3);
                                k = false;
                                break;
                            }
                            else if (check[1] - 3.0f >= takeroom[j].transform.position.y - 1.0f && check[1] - 3.0f < takeroom[j].transform.position.y + 1.0f && ((check[0] + 3.0f > takeroom[j].transform.position.x + 1.0f && check[0] - 3.0f < takeroom[j].transform.position.x + 1.0f) || (check[0] - 3.0f < takeroom[j].transform.position.x - 1.0f && check[0] + 3.0f > takeroom[j].transform.position.x - 1.0f)))
                            {
                                // Debug.Log(4);
                                k = false;
                                break;
                            }
                            else if (check[1] + 3.0f >= takeroom[j].transform.position.y + 1.0f && check[1] - 3.0f <= takeroom[j].transform.position.y - 1.0f && check[0] + 3.0f >= takeroom[j].transform.position.x + 1.0f && check[0] - 3.0f <= takeroom[j].transform.position.x - 1.0f)
                            {
                                k = false;
                                break;
                            }
                        }
                        //k = true;
                        if (k == true)
                        {
                            room.transform.position = new Vector3(check[0], check[1], 0);
                            h = true;
                            //Debug.Log("BoosCreated");
                        }
                        else
                            Destroy(room, 0.002f);
                    }
                }

            }
            takeroom.Add(room);
            if (what == 0)
                dict[room] = new int[] { 0, 0, 0, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11 };
            else if (what == 1)
                dict[room] = new int[] { 3, 6, 9, 10, 11 };
            else if (what == 2)
                dict[room] = new int[] { 4, 7, 8, 10, 11 };
            else if (what == 3)
                dict[room] = new int[] { 1, 5, 6, 7, 11 };
            else if (what == 4)
                dict[room] = new int[] { 2, 5, 8, 9, 11 };
            else if (what == 5)
                dict[room] = new int[] { 0, 0, 0, 0, 0, 3, 6, 9, 10, 4, 7, 8, 11 };
            else if (what == 6)
                dict[room] = new int[] { 0, 0, 0, 0, 0, 3, 6, 9, 10, 1, 5, 7, 11 };
            else if (what == 7)
                dict[room] = new int[] { 0, 0, 0, 0, 0, 3, 6, 9, 10, 2, 5, 8, 11 };
            else if (what == 8)
                dict[room] = new int[] { 0, 0, 0, 0, 0, 4, 7, 8, 10, 2, 5, 9, 11 };
            else if (what == 9)
                dict[room] = new int[] { 0, 0, 0, 0, 0, 4, 7, 8, 10, 1, 5, 6, 11 };
            else if (what == 10)
                dict[room] = new int[] { 0, 0, 0, 0, 0, 1, 5, 6, 7, 2, 8, 9, 11 };
            //if (q == C - 1)
            //  break;
        }

        GameObject boss = Instantiate(Boss);
        boss.transform.position = takeroom[CountOfRooms - 1].transform.position;

        Debug.Log(takeroom[0].transform.position);
        Debug.Log(takeroom[1].transform.position);

        for (int i = 0; i < takeroom.Count - 1; i++)
        {
            room = takeroom[i];

            int[] v = new int[4];

            v = Napr(room);

            if (v[0] == 1)
            {

                float a = room.transform.position.x;
                float b = room.transform.position.y + 2.0f;

                bool e = false;

                for (int j = 0; j < takeroom.Count - 1; j++)
                {
                    int[] v1 = new int[4];

                    v1 = Napr(takeroom[j]);

                    if (v1[2] == 1 && a == takeroom[j].transform.position.x && b == takeroom[j].transform.position.y)
                    {
                        e = true;
                        break;
                    }

                }

                if (a == takeroom[takeroom.Count - 1].transform.position.x && b + 2.0f == takeroom[takeroom.Count - 1].transform.position.y)
                    e = true;

                if (e == false)
                {
                    Debug.Log(1);

                    tup = Instantiate(dend, new Vector3(a, b - 2.0f + 0.95f, 0), Quaternion.identity);

                    Debug.Log(tup.transform.position);
                }
            }
            if (v[1] == 1)
            {
                float a = room.transform.position.x + 2.0f;
                float b = room.transform.position.y;

                bool e = false;

                for (int j = 0; j < takeroom.Count - 1; j++)
                {
                    int[] v1 = new int[4];
                    v1 = Napr(takeroom[j]);

                    if (v1[3] == 1 && a == takeroom[j].transform.position.x && b == takeroom[j].transform.position.y)
                    {

                        e = true;
                        break;
                    }

                }

                if (e == false)
                {
                    Debug.Log(2);
                    tup = Instantiate(dend, new Vector3(a - 2.0f + 0.95f, b, 0), Quaternion.Euler(0, 0, 90));


                    //Debug.Log(tup.transform.position);
                }
            }
            if (v[2] == 1)
            {
                float a = room.transform.position.x;
                float b = room.transform.position.y - 2.0f;

                bool e = false;
                for (int j = 0; j < takeroom.Count - 1; j++)
                {
                    int[] v1 = new int[4];

                    v1 = Napr(takeroom[j]);

                    if (v1[0] == 1 && a == takeroom[j].transform.position.x && b == takeroom[j].transform.position.y)
                    {

                        e = true;
                        break;
                    }

                }

                if (a == takeroom[takeroom.Count - 1].transform.position.x && b - 2.0f == takeroom[takeroom.Count - 1].transform.position.y)
                    e = true;

                if (e == false)
                {
                    Debug.Log(3);
                    tup = Instantiate(dend, new Vector3(a, b + 2.0f - 0.95f, 0), Quaternion.identity);

                    //Debug.Log(tup.transform.position);
                }

            }
            if (v[3] == 1)
            {
                float a = room.transform.position.x - 2.0f;
                float b = room.transform.position.y;

                bool e = false;
                for (int j = 0; j < takeroom.Count - 1; j++)
                {
                    int[] v1 = new int[4];
                    v1 = Napr(takeroom[j]);

                    if (v1[1] == 1 && a == takeroom[j].transform.position.x && b == takeroom[j].transform.position.y)
                    {

                        e = true;
                        break;
                    }
                }

                if (e == false)
                {
                    Debug.Log(4);
                    tup = Instantiate(dend, new Vector3(a + 2.0f - 0.95f, b, 0), Quaternion.Euler(0, 0, 90));


                    //Debug.Log(tup.transform.position);
                }
            }
        }

        float a1 = takeroom[takeroom.Count - 1].transform.position.x;
        float b1 = takeroom[takeroom.Count - 1].transform.position.y;
        bool e1 = true, e2 = true;

        for (int i = 0; i < takeroom.Count - 1; i++)
        {
            int[] v = Napr(takeroom[i]);

            if (v[2] == 0 && a1 == takeroom[i].transform.position.x && (b1 + 4.0f) == takeroom[i].transform.position.y && e1 == true)
            {
                
                Instantiate(dend, new Vector3(a1, b1 + 2.95f, 0), Quaternion.identity);
                e1 = false;
            }
            if (v[0] == 0 && a1 == takeroom[i].transform.position.x && (b1 - 4.0f) == takeroom[i].transform.position.y && e2 == true)
            {
               
                Instantiate(dend, new Vector3(a1, b1 - 2.95f, 0), Quaternion.identity);
                e2 = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
