﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.DAO
{
    internal class DAOManagerImpl: IDAOManager
    {
        private MODEL.ClassicModelsDBContext context = null;
        public DAOManagerImpl(MODEL.ClassicModelsDBContext context)
        {
            this.context = context;
        }


    }
}