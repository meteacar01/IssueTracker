
using IssueTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.DbAccessContext
{
    public class PostgreContext : DbContext
    {
        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        public DbSet<Iteration> Iteration { get; set; }
        public DbSet<WorkItem> WorkItem { get; set; }
        public DbSet<WorkItemState> WorkItemState { get; set; }
        public DbSet<WorkItemType> WorkItemType { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<WorkItemComments> WorkItemComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //OneToManyRelationshipConfiguration(modelBuilder);
            //ManyToManyRelationshipConfiguration(modelBuilder);


            #region WorkItemType data seed
            
            modelBuilder.Entity<WorkItemType>()
                .HasData(
                   new WorkItemType
                   {
                       Id = 1,
                       Name = "Bug"
                   },
                   new WorkItemType
                   {
                       Id = 2,
                       Name = "Feature"
                   },
                   new WorkItemType
                   {
                       Id = 3,
                       Name = "Task"
                   },
                   new WorkItemType
                   {
                       Id = 4,
                       Name = "Epic"
                   },
                   new WorkItemType
                   {
                       Id = 5,
                       Name = "Issue"
                   },
                   new WorkItemType
                   {
                       Id = 6,
                       Name = "Test Case"
                   },
                   new WorkItemType
                   {
                       Id = 7,
                       Name = "User Story"
                   }
               );

            #endregion
             
            #region WorkItemState data seed
           
            modelBuilder.Entity<WorkItemState>()
               .HasData(
                  new WorkItemState
                  {
                      Id = 1,
                      Name = "Open"
                  },
                  new WorkItemState
                  {
                      Id = 2,
                      Name = "Closed"
                  } 
              );

            #endregion
             
            #region Iteration data seed

            modelBuilder.Entity<Iteration>()
               .HasData(
                  new Iteration
                  {
                      Id = 1,
                      Name = "Iteration 1"
                  },
                  new Iteration
                  {
                      Id = 2,
                      Name = "Iteration 2"
                  },
                  new Iteration
                  {
                      Id = 3,
                      Name = "Iteration 3"
                  }
              );

            #endregion

            #region User data seed

            modelBuilder.Entity<User>()
               .HasData(
                  new User
                  {
                      Id = 1,
                      Name = "meteacar01",
                      CreatedAt = DateTime.Now
                  },
                  new User
                  {
                      Id = 2,
                      Name = "duyguacar01",
                      CreatedAt = DateTime.Now 
                  } 
              );

            #endregion
        }
        //private void ManyToManyRelationshipConfiguration(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<WorkItemComments>()
        //        .HasKey(t => new { t.WorkItemId, t.CommentId});


        //}
        //private void OneToManyRelationshipConfiguration(ModelBuilder modelBuilder)
        //{

        //}
    }
}
