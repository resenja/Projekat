namespace Domen
{
    public class Objekat1
    {
        public int id { get; set; }
        public string atribut1 { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1}", id, atribut1);
        }
    }
}
