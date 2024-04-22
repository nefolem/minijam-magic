using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    [SerializeField] private GameObject _firstAnim;
    [SerializeField] private GameObject _secondAnim;
    [SerializeField] private GameObject _thirdAnim;

    public void SwitchFirstAnimation()
    {
        _secondAnim.SetActive(true);
        _firstAnim.SetActive(false);
    }

    public void SwitchSecondAnimation()
    {
        _thirdAnim.SetActive(true);
        _secondAnim.SetActive(false);
    }
}
