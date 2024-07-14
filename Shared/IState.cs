﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARPG.Shared
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update(float delta);
    }
}
