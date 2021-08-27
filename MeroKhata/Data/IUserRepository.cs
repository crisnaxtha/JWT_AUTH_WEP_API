using MeroKhata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroKhata.Data
{
    public interface IUserRepository
    {
        User Create(User user);
    }
}
