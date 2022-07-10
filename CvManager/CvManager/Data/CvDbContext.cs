using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CvManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CvManager.Data
{
    public class CvDbContext : IdentityDbContext
    {
        public CvDbContext(DbContextOptions<CvDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
    }
}