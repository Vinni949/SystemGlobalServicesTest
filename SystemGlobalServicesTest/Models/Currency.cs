namespace SystemGlobalServicesTest.Models
{
    public class Currency
    {
        public int id { get; set; }
        public string idCurrency { get; set; }
        public int numCode { get; set; }
        public string charCode { get; set; }
        public int nominal { get; set; }
        public string name { get; set; }
        public float value { get; set; }
        public float previous { get; set; }

        public Currency(string id, int numCode, string charCode, int nominal, string name, float value, float previous)
        {
            this.idCurrency = id;
            this.numCode=numCode;
            this.charCode = charCode;
            this.nominal=nominal;
            this.name=name;
            this.value=value;
            this.previous=previous;
        }

    }
}