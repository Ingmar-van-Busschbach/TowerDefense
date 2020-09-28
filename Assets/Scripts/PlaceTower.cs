using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceTower : MonoBehaviour
{
    private float _nextPlace;
    [SerializeField] private GameObject _selectedTower;
    [SerializeField] private GameObject _preview;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private GameObject[] _towers;

    void Start()
    {
        Button btn0 = _buttons[0].GetComponent<Button>();
        btn0.onClick.AddListener(OnClick0);
        Button btn1 = _buttons[1].GetComponent<Button>();
        btn1.onClick.AddListener(OnClick1);
        Button btn2 = _buttons[2].GetComponent<Button>();
        btn2.onClick.AddListener(OnClick2);
        Button btn3 = _buttons[3].GetComponent<Button>();
        btn3.onClick.AddListener(OnClick3);
    }

    void OnClick0()
    {
        _selectedTower = _towers[0];
    }
    void OnClick1()
    {
        _selectedTower = _towers[1];
    }
    void OnClick2()
    {
        _selectedTower = _towers[2];
    }
    void OnClick3()
    {
        _selectedTower = _towers[3];
    }

    private void Update()
    {
        Vector3 placeBlockPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.y));
        _preview.transform.position = placeBlockPosition;
        float scale = _selectedTower.GetComponent<TowerRangeCheck>()._range;
        _preview.transform.localScale = new Vector3(scale, scale, scale);
        if (Input.GetButton("Fire1") && Time.time > _nextPlace)
        {
            _nextPlace = Time.time + 0.5f;
            Debug.Log(placeBlockPosition);
            Instantiate(_selectedTower, placeBlockPosition, Quaternion.identity);
        }
    }
}
