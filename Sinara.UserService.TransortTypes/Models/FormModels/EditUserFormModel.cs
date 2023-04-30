using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinara.UserService.TransortTypes.Models.FormModels
{
    public class EditUserFormModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string NewLogin { get; set; } = string.Empty;
    }
}
