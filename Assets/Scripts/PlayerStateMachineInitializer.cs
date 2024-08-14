using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachineInitializer : MonoBehaviour
{
    [SerializeField] private PlayerInputInitializer _inputInitializer;

    [SerializeField] private StatesView _view;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerRotator _playerRotator;

    [SerializeField] private PlayerStats _stats;
    [SerializeField] private WeaponView _weaponView;
    [SerializeField] private PlayerInteractionsHandler _interactionHandler;
    [SerializeField] private SaveStationInteraction _saveStationInteraction;
    [SerializeField] private ComboTimer _comboTimer;

    void Start()
    {
        var machine = new PlayerStateMachine(_view, _playerMover, _playerRotator);
        var states = new List<PlayerState>()
        {
            new IdleState(machine),
            new WalkState(machine, _stats),
            new RunState(machine, _stats),
            new IdleCrouchState(machine),
            new CrouchState(machine, _stats),
            new FastCrouchState(machine, _stats),
            new RollState(machine, _stats),
            new JumpBackState(machine, _stats),
            new JumpState(machine, _stats),
            new MoveJumpState(machine, _stats),
            new FallState(machine),
            new LandState(machine),
            new ComboAttack1State(machine, _comboTimer),
            new ComboAttack2State(machine, _comboTimer),
            new FinalComboAttackState(machine),
            new FallAttack(machine),
            new RunAttackState(machine),
            new RemoveWeaponState(machine, _interactionHandler, _weaponView),
            new GetWeaponState(machine, _weaponView),
            new UseSaveStationState(machine, _saveStationInteraction)
        };
        machine.SetStates(states);
        machine.SwitchState<IdleState>();
        _inputInitializer.Initialize(machine);
    }
}
