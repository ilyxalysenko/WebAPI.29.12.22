using Client.Interfaces;

namespace Client.Models
{
    public class Dog : ITailable
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

            var otherWoman = (Cat)obj;
            return this.Id == otherWoman.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
