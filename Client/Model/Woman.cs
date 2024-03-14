using Client.Interfaces;
using System.Collections.Generic;

namespace Client.Models
{
    public class Woman : IFuck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool GoldenRain { get; set; }
        public bool Oral { get; set; }
        public bool Classic {  get; set; }
        public bool Anal { get; set; }
        public byte[] Image { get; set; }
        public string ImgPath { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Woman))
            {
                return false;
            }

            var otherWoman = (Woman)obj;
            return this.Id == otherWoman.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
