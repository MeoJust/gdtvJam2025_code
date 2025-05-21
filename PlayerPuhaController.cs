using UnityEngine;

public class PlayerPuhaController : MonoBehaviour
{
    Puha[] _puhi;
    Player _player;

    int _currentGoon = 0;

    void Start()
    {
        _puhi = GetComponentsInChildren<Puha>();
        _player = GetComponent<Player>();

        _player.Controls.onFoot.puhaSlot1.performed += _ => ChooseDatGoon(0);
        _player.Controls.onFoot.puhaSlot2.performed += _ => ChooseDatGoon(1);
        _player.Controls.onFoot.puhaSlot3.performed += _ => ChooseDatGoon(2);

        _player.Controls.onFoot.cycleGoon.performed += _ => CycleGoon();

        ChooseDatGoon(0);
    }

    void ChooseDatGoon(int index){
        foreach (Puha puha in _puhi){
            puha.gameObject.SetActive(false);
            puha.TimeFromLastShot = puha.FireRate;
        }
        _puhi[index].gameObject.SetActive(true);
    }

    void CycleGoon(){
        _currentGoon++;
        if (_currentGoon >= _puhi.Length){
            _currentGoon = 0;
        }
        ChooseDatGoon(_currentGoon);
        
    }
}
