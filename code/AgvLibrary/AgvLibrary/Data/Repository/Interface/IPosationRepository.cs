﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgvLibrary.Model;

namespace AgvLibrary.Data.Repository.Interface
{
   public interface IPosationRepository
    {
        IQueryable<Posation> Search(PosationSearchModel posationSearchModel);

       
    }
}
