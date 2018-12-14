using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2018Pranks.Models
{
    public interface IMockPrank
    {
        IQueryable<Prank> Pranks { get; }
        Prank Save(Prank prank);
    }
}
