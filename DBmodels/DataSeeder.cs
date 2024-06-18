using DBmodels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DBmodels
{
    using DBmodels.Configuration;
    using DBmodels.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class DataSeeder
    {
        public static void Initialize(GcContext context)
        {
            if (context.Set<User>().Any() || context.Set<Project>().Any())
            {
                // DB has been seeded
                return;
            }

            // Create Role
            var role = new Role { RoleId = 1, RoleName = "Admin", Description = "Admin", CreatedDate = DateTime.UtcNow };

            context.Roles.Add(role);

            // Create Users
            var user1 = new User
            {
                UserId = Guid.NewGuid(),
                Username = "woman_user",
                Email = "woman@example.com",
                Password = "password", // Normally you'd hash this
                FullName = "Woman User",
                RoleId = 1,
                CreatedDate = DateTime.UtcNow
            };

            var user2 = new User
            {
                UserId = Guid.NewGuid(),
                Username = "husband_user",
                Email = "husband@example.com",
                Password = "password",
                FullName = "Husband User",
                RoleId = 1,
                CreatedDate = DateTime.UtcNow
            };

            var user3 = new User
            {
                UserId = Guid.NewGuid(),
                Username = "bestfriend_user",
                Email = "bestfriend@example.com",
                Password = "password",
                FullName = "Best Friend User",
                RoleId = 1,
                CreatedDate = DateTime.UtcNow
            };

            context.Users.AddRange(user1, user2, user3);

        
            // Create Project
            var project = new Project
            {
                ProjectId = Guid.NewGuid(),
                Description = "Car Purchase Project",
                Name = "Car Purchase Project",
                CreatedDate = DateTime.UtcNow,
                CreatedBy = user1.UserId,
                UpdatedDate = DateTime.UtcNow,
                UpdatedBy = user1.UserId
            };

            context.Projects.Add(project);

           
            //Create Group 
            var group1 = new Models.Group
            {
                GroupId = Guid.NewGuid(),
                GroupName = "Group 1",
                ProjectId = project.ProjectId,
                UserId = user2.UserId,
                RoleId = role.RoleId,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = user2.UserId,
                UpdatededDate = DateTime.UtcNow,
                UpdatedBy = user2.UserId
            };

            context.Groups.AddRange(group1);

            // Create Criteria
            var criteria1 = new Criterion { CriterionId = 1, Name = "Price", Value = 1.0, ProjectId = project.ProjectId };
            var criteria2 = new Criterion { CriterionId = 2, Name = "Looks", Value = 1.0, ProjectId = project.ProjectId };
            var criteria3 = new Criterion { CriterionId = 3, Name = "Space", Value = 1.0, ProjectId = project.ProjectId };

            context.Criterions.AddRange(criteria1, criteria2, criteria3);

            // Create Cars (Options)
            var car1 = new Option { OptionId = 1, Name = "Car Model A", Value = 1.0, ProjectId = project.ProjectId };
            var car2 = new Option { OptionId = 2, Name = "Car Model B", Value = 1.0, ProjectId = project.ProjectId };
            var car3 = new Option { OptionId = 3, Name = "Car Model C", Value = 1.0, ProjectId = project.ProjectId };
            var car4 = new Option { OptionId = 4, Name = "Car Model D", Value = 1.0, ProjectId = project.ProjectId };

            context.Options.AddRange(car1, car2, car3, car4);
            

            // Create Evaluations
            var evaluations = new List<Evaluation>
        {
            new Evaluation { EvaluationId = 1, ProjectId = project.ProjectId, GroupId = group1.GroupId, OptionId = car1.OptionId, CriterionId = criteria1.CriterionId, Value = 8.0, CreatedDate = DateTime.UtcNow },
            new Evaluation { EvaluationId = 2, ProjectId = project.ProjectId, GroupId = group1.GroupId, OptionId = car1.OptionId, CriterionId = criteria2.CriterionId, Value = 7.0, CreatedDate = DateTime.UtcNow },
            new Evaluation { EvaluationId = 3, ProjectId = project.ProjectId, GroupId = group1.GroupId, OptionId = car1.OptionId, CriterionId = criteria3.CriterionId, Value = 9.0, CreatedDate = DateTime.UtcNow },

            new Evaluation { EvaluationId = 4, ProjectId = project.ProjectId, GroupId = group1.GroupId, OptionId = car2.OptionId, CriterionId = criteria1.CriterionId, Value = 6.0, CreatedDate = DateTime.UtcNow },
            new Evaluation { EvaluationId = 5, ProjectId = project.ProjectId, GroupId = group1.GroupId, OptionId = car2.OptionId, CriterionId = criteria2.CriterionId, Value = 8.0, CreatedDate = DateTime.UtcNow },
            new Evaluation { EvaluationId = 6, ProjectId = project.ProjectId, GroupId = group1.GroupId, OptionId = car2.OptionId, CriterionId = criteria3.CriterionId, Value = 7.0, CreatedDate = DateTime.UtcNow },

            new Evaluation { EvaluationId = 7, ProjectId = project.ProjectId, GroupId = group1.GroupId, OptionId = car3.OptionId, CriterionId = criteria1.CriterionId, Value = 9.0, CreatedDate = DateTime.UtcNow },
            new Evaluation { EvaluationId = 8, ProjectId = project.ProjectId, GroupId = group1.GroupId, OptionId = car3.OptionId, CriterionId = criteria2.CriterionId, Value = 7.0, CreatedDate = DateTime.UtcNow },
            new Evaluation { EvaluationId = 9, ProjectId = project.ProjectId, GroupId = group1.GroupId, OptionId = car3.OptionId, CriterionId = criteria3.CriterionId, Value = 6.0, CreatedDate = DateTime.UtcNow }
        };

            context.Evaluations.AddRange(evaluations);

            // Create Preferences
            var preferences = new List<Preference>
            {
                new Preference { PreferenceId = 1, ProjectId = project.ProjectId, GroupId = group1.GroupId, CriterionId1 = criteria1.CriterionId, CriterionId2 = criteria2.CriterionId, Value = 1.5, CreatedDate = DateTime.UtcNow },
                new Preference { PreferenceId = 2, ProjectId = project.ProjectId, GroupId = group1.GroupId, CriterionId1 = criteria1.CriterionId, CriterionId2 = criteria3.CriterionId, Value = 2.0, CreatedDate = DateTime.UtcNow },

                new Preference { PreferenceId = 3, ProjectId = project.ProjectId, GroupId = group1.GroupId, CriterionId1 = criteria2.CriterionId, CriterionId2 = criteria3.CriterionId, Value = 1.0, CreatedDate = DateTime.UtcNow },
                new Preference { PreferenceId = 4, ProjectId = project.ProjectId, GroupId = group1.GroupId, CriterionId1 = criteria1.CriterionId, CriterionId2 = criteria3.CriterionId, Value = 1.5, CreatedDate = DateTime.UtcNow },

                new Preference { PreferenceId = 5, ProjectId = project.ProjectId, GroupId = group1.GroupId, CriterionId1 = criteria1.CriterionId, CriterionId2 = criteria2.CriterionId, Value = 2.0, CreatedDate = DateTime.UtcNow },
                new Preference { PreferenceId = 6, ProjectId = project.ProjectId, GroupId = group1.GroupId, CriterionId1 = criteria2.CriterionId, CriterionId2 = criteria3.CriterionId, Value = 1.0, CreatedDate = DateTime.UtcNow }

            };
            context.Preferences.AddRange(preferences);
        }
    }



}
