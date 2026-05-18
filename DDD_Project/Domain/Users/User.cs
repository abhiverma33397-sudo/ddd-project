    //using System.ComponentModel.DataAnnotations;

    //namespace Domain.Users
    //{
    //    public class User
    //    {
    //        [Key]
    //        public int Id { get; set; }
    //        public string FirstName { get; set; }
    //        public string LastName { get; set; }
    //        public string UserName { get; set; }
    //        public string Password { get; set; }
    //        public string Role { get; set; }
    //        public bool IsVerified { get; set; }
    //    }
    //}
    using System.ComponentModel.DataAnnotations;

    namespace Domain.Users
    {
        public class User
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(50)]
            public string FirstName { get; set; }

            [Required]
            [StringLength(50)]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [StringLength(100)]
            public string UserName { get; set; }

            [Required]
            public string Password { get; set; }

            [Required]
            [StringLength(20)]
            public string Role { get; set; }

            public bool IsVerified { get; set; } = false;

            // ✅ NEW: Profile Image support
            public string? ProfileImage { get; set; }
        }
    }