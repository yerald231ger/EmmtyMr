using System;
using EMMTY_GO_WEB.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EMMTY_GO_WEB.Object
{
    public static class ApplicationUserExtencion
    {
        public static IdentityResult Update(this ApplicationUser user)
        {
            using (
                var userManager =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
            {

                var userUpdated = userManager.FindById(user.Id);

                userUpdated.Name = user.Name;
                userUpdated.LastName = user.LastName;
                userUpdated.PhoneNumber = user.PhoneNumber;
                userUpdated.AlterPhoneNumber = user.AlterPhoneNumber;
                userUpdated.Email = user.Email;
                userUpdated.AlterEmail = user.AlterEmail;
                userUpdated.UserName = user.UserName;

                return userManager.Update(userUpdated);
            }
        }

        /// <summary>
        /// Actualiza el Name,LastName,PhoneNumber,AlterPhoneNumber,Email,AlterEmail,UserName del usuario; buscando el usario en la base de datos y 
        /// actualizando sus valores desde el usuario obtenido en el parametro
        /// </summary>
        /// <param name="userManager">La instancia del UserManager</param>
        /// <param name="user">el usario con los datos nuevos a cambiar</param>
        /// <returns></returns>
        public static IdentityResult UpdateUser(this UserManager<ApplicationUser> userManager, ApplicationUser user)
        {
            var userUpdated = userManager.FindById(user.Id);
            if (userUpdated == null) return IdentityResult.Failed("No se encontro el Usuario");

            userUpdated.Name = user.Name;
            userUpdated.LastName = user.LastName;
            userUpdated.PhoneNumber = user.PhoneNumber;
            userUpdated.AlterPhoneNumber = user.AlterPhoneNumber;
            userUpdated.Email = user.Email;
            userUpdated.AlterEmail = user.AlterEmail;
            userUpdated.UserName = user.UserName;

            return userManager.Update(userUpdated);

        }
    }
}