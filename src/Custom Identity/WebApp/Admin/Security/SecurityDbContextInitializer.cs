using Demo.BLL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static WebApp.Admin.Security.Settings;
using WebApp.Models;
//You can learned about database Initialiation stratedgies  on entityframeworktutorial.net
namespace WebApp.Admin.Security
{/// <summary>
/// Provice functionality for setting up the database for the ApplcaitionDbContext.
/// The specific funcationality is to create the database if it does not exist
/// </summary>
    public class SecurityDbContextInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //To "seed" a database is to provide it with some initial data
            // when the database is created.

            #region Seed the security roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //The RoleManager<T> and RoleStore<T> are BLL classes that give flexiblity 
            // to the design/structure of how we're using Asp.Net Identity,
            // The IdentityRole is an entity class that represents a security role.

            //Hard-coded security roles (move later on)
            // roleManager.Create(new IdentityRole { Name = "Registered Users" });
            foreach (var role in DefaultSecurityRoles)
            roleManager.Create(new IdentityRole { Name = role });
           
            #endregion

            #region Seed the users
            //Create a user 
            var adminUser = new ApplicationUser
            {
                UserName="WebAdmin",
                Email="Fake@Hackers.ru",
                EmailConfirmed=true
            };
            //Get the BLL manager
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            // - the ApplicationuserManager is a BLL class in the IdentityConfig.cs file
            var result = userManager.Create(adminUser, "Pa$$w0rd");
            if (result.Succeeded)
            {
                //get the Id that was generated for the user we created/added
                var found = userManager.FindByName("WebAdmin").Id;
                // Add the user to the Administrators role
                userManager.AddToRole(found, AdminRole);
            }
            //Create the oher usres accounts for all the people in my Demo Database
            var demoManager = new DemoController();
            var people = demoManager.ListImportantPeople();
            foreach(var person in people)
            {
                var user = new ApplicationUser
                {
                    UserName = $"{person.FirstName}.{person.LastName}",
                    Email = $"{person.FirstName}.{person.LastName}@DemoIsland.com",
                    EmailConfirmed = true,
                    PersonId = person.PersonID
                };
                result = userManager.Create(user, "Pa$$word1");
                if (result.Succeeded)
                {
                    var userId = userManager.FindByName(user.UserName).Id;
                    userManager.AddToRole(userId, UserRole);
                }
            }

            #endregion

            //keep the call to the base class to do its seeding work
            base.Seed(context);
        }
       
    }
}