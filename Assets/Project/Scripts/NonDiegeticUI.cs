using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NonDiegeticUI : MonoBehaviour
{
    public GameObject _goPauseScreen;
    public GameObject _goFailScreen;
    public GameObject _goAchievedScreen;

    public GameObject _goScore;
    public GameObject _goRemainingTime;

    public TextMeshPro _txtRemainingTime;
    public TextMeshPro _txtScore;

    public Transform _traCamera;

    #region UpdateEconomicAxises

    public void SetRemainingTime(float value)
    {
        _txtRemainingTime.text = value.ToString("000");
    }

    public void SetScore(int value)
    {
        _txtScore.text = value.ToString("000");
    }

    public void UpdateUITransform()
    {
        if (_traCamera != null)
        {
            transform.position = _traCamera.position;
            transform.rotation = _traCamera.rotation;
        }
    }

    #endregion

    #region ActivateScreens

    public void TogglePauseScreen()
    {
        _goPauseScreen.SetActive(!_goPauseScreen.activeInHierarchy);
    }

    public void ActivateFailScreen()
    {
        _goFailScreen.SetActive(true);
        _goScore.SetActive(false);
        _goRemainingTime.SetActive(false);
    }

    public void ActivateAchieveScreen()
    {
        _goAchievedScreen.SetActive(true);
        _goRemainingTime.SetActive(false);
    }

    #endregion

}
