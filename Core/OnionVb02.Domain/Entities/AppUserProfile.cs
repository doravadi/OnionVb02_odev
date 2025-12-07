using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Domain.Entities
{
    //Burada dikkat ettiyseniz birebir ilişki icin hazırladıgımız alt yapı aslında bire cok ilişkilerden alısık oldugumuz foreign key ile birlikte hazırlanmaya baslamıstır...Bu artık 3. normalizasyonun ötesinde bir durumdur bize su avantajı saglar : Profile'in id'si kendisini kitleyen bir ilişkiden kurtuldugu icin buradaki veri girişini artık siz manage etmek zorunda kalmazsınız...Configuration otomatik olarak bu sistemi kuracaktır...
    public class AppUserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }


        //Relational Properties
        public virtual AppUser AppUser { get; set; }
    }
}
