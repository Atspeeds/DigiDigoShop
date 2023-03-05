using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastrure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BlogManagement.Infrastrure.EfCore
{
    public class BlogContext : DbContext
    {

        public BlogContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        #region  DbSet And Entity Table In Sql
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assamble = typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assamble);
            base.OnModelCreating(modelBuilder);
        }
    }
}
