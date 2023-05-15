using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Person : Entity
    {
        //ręcznie oznaczamy klucz encji
        /*[Key]
        public int Key { get; set; }*/

        //klucz jest wyznaczany automatycznie jeśli właściwość nazywa się Id lub <nazwa klasy>Id (np. PersonId)
        public int Id { get; set; }
        //[Column("FirstName")]
        //[MaxLength(10)]
        public string Name { get; set; }
        //[Required]
        public string? LastName { get; set; }

        public string FullName { get; }

        //[Column(TypeName = "decimal(11,0)")]
        public ulong PESEL { get; set; }
        //[Range(1, 100)]
        public int Age { get; set; }

        public Guid Guid { get; set; }

        //[NotMapped]
        public Address Address { get; set; }
    }
}