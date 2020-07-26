﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Repository
{
   public class UserRoleMasterRepository: BaseRepository<UserRoleMaster>,IUserRoleMasterRepository
    {
       public UserRoleMasterRepository(IUnitOfWork _unitOfWork)
           : base(_unitOfWork)
       { }
    }
}
