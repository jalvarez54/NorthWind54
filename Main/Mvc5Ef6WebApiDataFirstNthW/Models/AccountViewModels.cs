using System.ComponentModel.DataAnnotations;
using Mvc5Ef6WebApiDataFirstNthW.Resources.Models;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Mvc5Ef6WebApiDataFirstNthW.CustomFiltersAttributes;

namespace Mvc5Ef6WebApiDataFirstNthW.Models
{
    // Not used
    //public class ExternalLoginConfirmationViewModel
    //{
    //    [Required]
    //    [Display(Name = "Nom d’utilisateur")]
    //    public string UserName { get; set; }
    //}

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe actuel")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nouveau mot de passe")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le nouveau mot de passe")]
        [Compare("NewPassword", ErrorMessage = "Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

    }

    public class LoginViewModel
    {
        //[Required]
        //[Display(Name = "Nom d’utilisateur")]
        //public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "Required",
        ErrorMessageResourceType = typeof(AccountViewModels))]
        [Display(Name = "Nom d’utilisateur")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Display(Name = "Mémoriser le mot de passe ?")]
        public bool RememberMe { get; set; }

    }

    // New ViewModel Class to represent the specific data required by a specific view:

    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "Nom d’utilisateur")]
        public string UserName { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Mot de passe")]
        //public string Password { get; set; }

        [Required(ErrorMessageResourceName = "Required",
        ErrorMessageResourceType = typeof(AccountViewModels))]
        [StringLength(100, ErrorMessageResourceName = "PasswordMinLength",
        ErrorMessageResourceType = typeof(AccountViewModels), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(AccountViewModels))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        // New Fields added to extend Application User class:

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        [NotMapped]
        //[Required(ErrorMessage = "Please Upload File")]
        [Display(Name = "Your Avatar")]
        [ValidateFile]
        public HttpPostedFileWrapper Photo { get; set; }


        // Return a pre-poulated instance of AppliationUser:
        public ApplicationUser GetUser()
        {
            var user = new ApplicationUser()
            {
                UserName = this.UserName,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                PhotoUrl = this.PhotoUrl,
                Photo = this.Photo,
            };
            return user;
        }


    }

    // Class added
    public class EditUserViewModel
    {
        public EditUserViewModel() { }

        // Allow Initialization with an instance of ApplicationUser:
        public EditUserViewModel(ApplicationUser user)
        {
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.PhotoUrl = user.PhotoUrl;
        }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        [NotMapped]
        [Display(Name = "Change")]
        [ValidateFile]
        public HttpPostedFileWrapper Photo { get; set; }
        [NotMapped]
        [Display(Name = "Remove if checked")]
        public bool IsNoPhotoChecked { get; set; }


        // Return a pre-populated instance of AppliationUser:
        public ApplicationUser GetUser()
        {
            var user = new ApplicationUser()
            {
                UserName = this.UserName,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                PhotoUrl = this.PhotoUrl,
                Photo = this.Photo,
            };
            return user;
        }

    }

    // SelectUserRolesViewModel – Revisited:
    public class SelectUserRolesViewModel
    {
        public SelectUserRolesViewModel()
        {
            this.Roles = new List<SelectRoleEditorViewModel>();
        }

        // Enable initialization with an instance of ApplicationUser:
        public SelectUserRolesViewModel(ApplicationUser user)
            : this()
        {
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;

            var Db = new ApplicationDbContext();

            // Add all available roles to the list of EditorViewModels:
            var allRoles = Db.Roles;
            foreach (var role in allRoles)
            {
                // An EditorViewModel will be used by Editor Template:
                var rvm = new SelectRoleEditorViewModel(role);
                this.Roles.Add(rvm);
            }

            // Set the Selected property to true for those roles for 
            // which the current user is a member:
            foreach (var userRole in user.Roles)
            {
                var checkUserRole =
                    this.Roles.Find(r => r.RoleName == userRole.Role.Name);
                checkUserRole.Selected = true;
            }
        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SelectRoleEditorViewModel> Roles { get; set; }
    }

    // SelectRoleEditorViewModel, Revisited:
    // Used to display a single role with a checkbox, within a list structure:
    public class SelectRoleEditorViewModel
    {
        public SelectRoleEditorViewModel() { }
        public SelectRoleEditorViewModel(IdentityRole role)
        {
            this.RoleName = role.Name;
        }

        public bool Selected { get; set; }

        [Required]
        public string RoleName { get; set; }
    }

}
