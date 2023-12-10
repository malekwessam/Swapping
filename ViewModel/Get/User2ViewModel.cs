using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoqaydaGP.ViewModel.Get
{
    public class User2ViewModel
    {
        public string Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string address { get; set; }


        public string email { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string PathImage { get; set; }

        public List<UserProductViewModel> UserProductViewModels { get; set; }
    }
}
