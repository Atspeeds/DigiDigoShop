using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastrure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CommentManagement.Infrastrure.EFCore
{
    public class CommentContext : DbContext
    {
        public CommentContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }


        #region DbSet And Entity Table In Sql
        public DbSet<Comment> Comments { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CommentMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }


    }
}
