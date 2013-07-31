using System.Data.Linq.Mapping;

namespace WPPerfLab.Common.Database.Normalized
{
    [Table]
    public class BookAuthorNormalized
    {
        private int id;

        [Column(IsPrimaryKey = true, 
            IsDbGenerated = true, 
            DbType = "INT NOT NULL Identity", 
            CanBeNull = false, 
            AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                }
            }
        }

        private string firstname;

        [Column]
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                if (firstname != value)
                {
                    firstname = value;
                }
            }
        }

        private string lastname;

        [Column]
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                if (lastname != value)
                {
                    lastname = value;
                }
            }
        }
    }
}
