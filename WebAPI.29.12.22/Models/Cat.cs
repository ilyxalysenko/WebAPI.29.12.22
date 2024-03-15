using WebAPI._29._12._22.Interfaces;

namespace WebAPI._29._12._22.Models
{
    public class Cat : ITailable
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public bool PuppyDP { get; set; }
        public bool AntiRabic { get; set; }
        public bool Passport { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string ImgPath { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Cat))
            {
                return false;
            }

            var otherCat = (Cat)obj;
            return this.Id == otherCat.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
