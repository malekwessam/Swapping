using System;

namespace MoqaydaGP.ViewModel.Get
{
    public class UserProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Descriptions { get; set; }
        public string pathImage { get; set; }

        public DateTime AvailableSince { get; set; }
        public bool IsActive { get; set; }
        public short CategoryId { get; set; }
        public bool IsFavourite { get; set; } = false;

        public string UserId { get; set; }
        public string ProductToSwap { get; set; }
    }
}
