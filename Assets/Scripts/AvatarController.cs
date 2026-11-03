using System;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] avatars;
    public void setActiveAvatar(int index)
    {
        index--;
        for (int i = 0; i < avatars.Length; i++)
        {
            avatars[i].SetActive(i == index);
        }
    }
}
