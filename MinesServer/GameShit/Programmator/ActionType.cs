﻿namespace MinesServer.GameShit.Programmator
{
    public enum ActionType
    {
        None,
        MoveUp,
        MoveLeft,
        MoveDown,
        MoveRight,
        MoveForward,
        RotateUp,
        RotateLeft,
        RotateDown,
        RotateRight,
        RotateLeftRelative,
        RotateRightRelative,
        RotateRandom,
        Dig,
        BuildBlock,
        BuildPillar,
        BuildRoad,
        BuildMilitaryBlock,
        Geology,
        Heal,
        NextRow,
        CreateFunction,
        GoTo,
        WritableStateMore,
        WritableStateLower,
        WritableState,
        RunSub,
        RunFunction,
        RunState,
        RunOnRespawn,
        RunIfTrue,
        RunIfFalse,
        Return,
        ReturnFunction,
        ReturnState,
        Start,
        Stop,
        Beep,
        CheckUp,
        CheckLeft,
        CheckDown,
        CheckRight,
        CheckUpLeft,
        CheckUpRight,
        CheckDownLeft,
        CheckDownRight,
        CheckForward,
        CheckForwardLeft,
        CheckForwardRight,
        CheckLeftRelative,
        CheckRightRelative,
        ShiftUp,
        ShiftLeft,
        ShiftDown,
        ShiftRight,
        ShiftForward,
        EnableAgression,
        DisableAgression,
        EnableAutoDig,
        DisableAutoDig,
        Flip,
        MacrosDig,
        MacrosBuild,
        MacrosHeal,
        MacrosMine,
        Or,
        And,
        IsHpLower100,
        IsHpLower50,
        IsNotEmpty,
        IsEmpty,
        IsFalling,
        IsCrystal,
        IsLivingCrystal,
        IsBoulder,
        IsSand,
        IsBreakableRock,
        IsUnbreakable,
        IsAcid,
        IsRedRock,
        IsBlackRock,
        IsGreenBlock,
        IsYellowBlock,
        IsRedBlock,
        IsPillar,
        IsQuadBlock,
        IsRoad,
        IsBox,
        CheckGun,
        FillGun
    }
}
