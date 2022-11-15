﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE2_Ins_Wait : BE2_InstructionBase, I_BE2_Instruction
{
    //protected override void OnAwake()
    //{
    //    
    //}

    //protected override void OnStart()
    //{
    //    
    //}

    //protected override void OnUpdate()
    //{
    //
    //}

    I_BE2_BlockSectionHeaderInput _input0;
    bool _firstPlay = true;
    float _counter = 0;
    public bool ExecuteInUpdate => true;

    protected override void OnButtonStop()
    {
        _firstPlay = true; 
        _counter = 0;
    }

    public override void OnStackActive()
    {
        _firstPlay = true;
        _counter = 0;
    }

    public void Function()
    {
        if (_firstPlay)
        {
            _input0 = Section0Inputs[0];
            _counter = _input0.FloatValue;
            _firstPlay = false;
        }

        if (_counter > 0)
        {
            _counter -= Time.deltaTime;
        }
        else
        {
            _counter = 0;
            ExecuteNextInstruction();
            _firstPlay = true;
        }
    }
}
